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
        FrmSetDimensions designer;
        public FrmDesignerMenu()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnNewMap_Click(object sender, EventArgs e)
        {
            if (designer == null)
            {
                designer = new FrmSetDimensions();
            }
            designer.Show();
        }

     
    }
}
