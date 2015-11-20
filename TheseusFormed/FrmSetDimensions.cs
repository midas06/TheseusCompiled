using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheseusFormed
{
    public partial class FrmSetDimensions : Form
    {
        public FrmSetDimensions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDesigner frm = new FrmDesigner();
            Point p = new Point(Decimal.ToInt32(numX.Value), Decimal.ToInt32(numY.Value));
            frm.Init(p);
            frm.Show();
        }

        
    }
}
