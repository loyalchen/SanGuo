namespace SanGuo
{
    partial class ReportDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbGVReport = new SanGuo.Controls.ComboGridView();
            this.SuspendLayout();
            // 
            // cmbGVReport
            // 
            this.cmbGVReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbGVReport.Location = new System.Drawing.Point(0, 0);
            this.cmbGVReport.Name = "cmbGVReport";
            this.cmbGVReport.Size = new System.Drawing.Size(740, 415);
            this.cmbGVReport.TabIndex = 0;
            // 
            // ReportDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 415);
            this.Controls.Add(this.cmbGVReport);
            this.Name = "ReportDetails";
            this.Text = "ReportDetails";
            this.Shown += new System.EventHandler(this.ReportDetails_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ComboGridView cmbGVReport;
    }
}