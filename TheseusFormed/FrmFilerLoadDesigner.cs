using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheseusCompiled;

namespace TheseusFormed
{
    public partial class FrmFilerLoadDesigner : Form
    {
       
        FileHandler filer;
        string theMap;
        int theList;
        FrmContainer parentForm;

        public FrmFilerLoadDesigner()
        {
            InitializeComponent();
            LoadList();
        }

        public void SetParentForm(FrmContainer newForm)
        {
            parentForm = newForm;
        }

        public void LoadList()
        {
            if (filer == null)
            {
                filer = new FileHandler();
            }

            filer.Init();
            
            foreach (string str in filer.GetMapListArray(1))
            {
                lbxUserCreated.Items.Add(str);
            }

        }

        
        private void btnLoadMap_Click(object sender, EventArgs e)
        {
            if (lbxUserCreated.Text != "")
            {
                theMap = lbxUserCreated.Text;
                theList = 1;
                filer.SetMap(theList, theMap);
                parentForm.OpenExistingBuilder(filer.GetMap());

                parentForm.SetPreviousForm(this);
                this.Hide();
            }
        }
    }
}
