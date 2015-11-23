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
        FrmContainer parentForm;
        public FrmSetDimensions()
        {
            InitializeComponent();
        }

        public void SetParentForm(FrmContainer newForm)
        {
            parentForm = newForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point p = new Point(Decimal.ToInt32(numX.Value), Decimal.ToInt32(numY.Value));

            parentForm.OpenNewBuilder(p);
            parentForm.SetPreviousForm(this);
            this.Hide();
        }

        
    }
}
