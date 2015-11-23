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
    public partial class FrmDesignerMenu : Form
    {
        FrmContainer parentForm;
        public FrmDesignerMenu()
        {
            InitializeComponent();
        }

        public void SetParentForm(FrmContainer newForm)
        {
            parentForm = newForm;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            parentForm.OpenMapListBuilder();
            parentForm.SetPreviousForm(this);
            this.Hide();
        }

        private void btnNewMap_Click(object sender, EventArgs e)
        {
            parentForm.OpenDimensions();
            parentForm.SetPreviousForm(this);
            this.Hide();
            
        }

     
    }
}
