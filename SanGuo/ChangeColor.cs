using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanGuo
{
    public partial class ChangeColor : Form
    {
        public ChangeColor()
        {
            InitializeComponent();
        }

        private void colorHatch_ColorChange(object sender, Controls.ColorHatch.ColorChangeEventArgs e)
        {
            label1.ForeColor = e.Color;
        }
    }
}
