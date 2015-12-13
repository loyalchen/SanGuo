using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanGuo.Controls
{
    public partial class ColorHatch: UserControl
    {
        private Color _hatchColor;

        [Description("设置当前颜色")]
        [DefaultValue(typeof(Color), "Black")]
        public Color HatchColor
        {
            get
            {
                return _hatchColor;
            }
            set
            {
                _hatchColor = value;
                panel1.BackColor = value;
            }
        }

        public delegate void ColorChangeEventHandler(object sender, ColorChangeEventArgs e);
        public event ColorChangeEventHandler ColorChange;

        public ColorHatch()
        {
            InitializeComponent();
        }

        private void PanelClick(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                _hatchColor = panel.BackColor;
                panel1.BackColor = _hatchColor;
                OnColorChange(new ColorChangeEventArgs(_hatchColor));
            }
        }

        protected virtual void OnColorChange(ColorChangeEventArgs e)
        {
            if (ColorChange != null)
            {
                ColorChange(this, e);
            }
        }

        public class ColorChangeEventArgs : EventArgs
        {
            private Color _color;

            public ColorChangeEventArgs(Color color)
            {
                _color = color;
            }

            public Color Color
            {
                get { return _color; }
            }
        }
    }
}
