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
        FrmFilerLoad frmFiler;
        FrmDesignerMenu frmDesigner;

        public FrmSplash()
        {
            InitializeComponent();
        }

        private void btnLoadFiler_Click(object sender, EventArgs e)
        {
            if (frmFiler == null)
            {
                frmFiler = new FrmFilerLoad();
            }
            frmFiler.Show();
        }

        private void btnLoadBuilder_Click(object sender, EventArgs e)
        {
            if (frmDesigner == null)
            {
                frmDesigner = new FrmDesignerMenu();
            }
            frmDesigner.Show();
        }
    }
}
