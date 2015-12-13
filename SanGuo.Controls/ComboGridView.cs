using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace SanGuo.Controls
{
    public partial class ComboGridView : UserControl
    {
        public IEnumerable _datasource;

        [Description("设置控件的数据源")]
        public IEnumerable DataSource
        {
            set { _datasource = value; }
        }

        public ComboGridView()
        {
            InitializeComponent();
        }

        private void cmbRoot_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            if (cmb != null)
            {
                if (String.IsNullOrWhiteSpace(cmb.SelectedItem.ToString()))
                {
                    cmbChild1.Visible = false;
                    gvRoot.Visible = false;
                }
                else
                {
                    cmbChild1.Visible = true;
                    gvRoot.Visible = true;
                    gvRoot.DataSource = _datasource;
                }
            }
        }
    }
}
