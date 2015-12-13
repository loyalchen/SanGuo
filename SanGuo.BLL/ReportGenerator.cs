using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanGuo.BLL;
using SanGuo.Model;

namespace SanGuo.BLL
{
    public class ReportGenerator : IDisposable
    {
        #region Events

        public event EventHandler SelectedDataRangeChanged;

        public event EventHandler CurrentReportDestroying;

        #endregion Events

        #region Public Properties

        public string ReportName { get; private set; }

        public ReportGenerator SubReport { get; private set; }

        public BindingList<DataRow> CurrentReport { get; private set; }

        public DataTable SelectedDataRange { get; private set; }

        #endregion Public Properties

        #region Private Fields

        private ReportGenerator _preReport;

        private DataTable _dataSource;

        private Option<string> _groupName;

        private bool _isRootReport;

        #endregion Private Fields

        #region Constructor

        public ReportGenerator(DataTable dataSource, Option<string> groupName, string reportName = null) : this(reportName)
        {
            if (dataSource == null || dataSource.Rows.Count == 0)
            {
                throw new ArgumentNullException("dataSource");
            }

            this._preReport = null;
            this._dataSource = dataSource;
            this._groupName = groupName;
            this._isRootReport = true;

            GenerateReport();
        }

        public ReportGenerator(string reportName = null)
        {
            if (string.IsNullOrEmpty(reportName))
            {
                ReportName = Guid.NewGuid().ToString();
            }
            else
            {
                ReportName = reportName;
            }
            this._isRootReport = false;
        }

        #endregion Constructor

        #region Public Methods

        public void  ChangePreReport(ReportGenerator preReport, DataTable dataSource)
        {
            if (preReport == null)
            {
                throw new ArgumentNullException("preReport");
            }
            if (this._preReport != null)
            {
                this.CurrentReportDestroying -= _preReport.DropSubReport;
            }
            this._preReport = preReport;
            this.CurrentReportDestroying += _preReport.DropSubReport;
            this._dataSource = dataSource;
            GenerateReport();
        }

        public void ChangeSubReport(ReportGenerator subReport)
        {
            if (this.SubReport != null)
            {
                this.SelectedDataRangeChanged -= this.SubReport.DataSourceChanged;
            }
            if (subReport == null)
            {
                this.SubReport = null;
            }
            else
            {
                this.SubReport = subReport;
                this.SelectedDataRangeChanged += this.SubReport.DataSourceChanged;
            }
        }

        public void DropReport()
        {
            if (this._isRootReport)
            {
                throw new InvalidOperationException("Root report can't be destroyed.");
            }

            if (CurrentReportDestroying != null)
            {
                CurrentReportDestroying(this, null);
            }

            Dispose();
        }

        public void SelectGroupValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }

            SelectedDataRange = _dataSource;
            //_selectedDataRange = _dataSource.Select(string.Format("{0} = {1}", _groupName.Value, value)).CopyToDataTable();
            if (SelectedDataRangeChanged != null)
            {
                SelectedDataRangeChanged(this, null);
            }
        }

        public void DataSourceChanged(object sender, EventArgs e)
        {
            GenerateReport();
        }

        /// <summary>
        /// drop the sub report link, and then link to the grandson report if it existed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DropSubReport(object sender, EventArgs e)
        {
            if (SubReport.SubReport != null)
            {
                var grandsonReport = SubReport.SubReport;

                this.ChangeSubReport(grandsonReport);
                grandsonReport.ChangePreReport(this, this.SelectedDataRange);

                this.SubReport = grandsonReport;
            }
            else
            {
                this.SubReport = null;
            }
        }

        public ReportGenerator AddSubReport(Option<string> groupName, string reportName = null)
        {
            ReportGenerator sub = new ReportGenerator(reportName);
            if (SubReport != null)
            {
                var grandson = SubReport;
                this.ChangeSubReport(sub);
                sub.ChangePreReport(this, this.SelectedDataRange);
                sub.ChangeSubReport(grandson);
                grandson.ChangePreReport(sub, sub.SelectedDataRange);
            }
            else
            {
                this.ChangeSubReport(sub);
                sub.ChangePreReport(this, this.SelectedDataRange);
            }

            return sub;
        }

        public void GenerateReport()
        {
            //1.generate report
            //2.select first row to trigger sub report refresh data.

            #region test

            Trace.WriteLine(string.Format("{0} generates report", this.ReportName), "TestConsole");

            #endregion test

            SelectGroupValue("test");
        }

        #endregion Public Methods

        #region Private Methods

        private void CutEventOff()
        {
            if (this.SubReport != null)
            {
                this.SelectedDataRangeChanged -= this.SubReport.DataSourceChanged;
            }
            if (this._preReport != null)
            {
                this.CurrentReportDestroying -= _preReport.DropSubReport;
            }
        }

        #endregion Private Methods

        #region Dispose

        public void Dispose()
        {
            CutEventOff();
            this.CurrentReport = null;
            this._dataSource = null;
            this._groupName = null;
            this._preReport = null;
            this.SelectedDataRange = null;
            this.SubReport = null;
            GC.Collect();
        }

        #endregion Dispose
    }
}