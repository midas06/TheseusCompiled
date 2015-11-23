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
    public partial class FrmSplash : Form
    {
        FrmContainer parentForm;


        public FrmSplash()
        {
            InitializeComponent();
        }

        public void SetParentForm(FrmContainer theParent)
        {
            this.parentForm = theParent;
        }

        private void btnLoadFiler_Click(object sender, EventArgs e)
        {
            parentForm.OpenMapFiler();
            parentForm.SetPreviousForm(this);
            this.Hide();
        }

        private void btnLoadBuilder_Click(object sender, EventArgs e)
        {
            parentForm.OpenBuilderMenu();
            parentForm.SetPreviousForm(this);
            this.Hide();
        }
    }
}
