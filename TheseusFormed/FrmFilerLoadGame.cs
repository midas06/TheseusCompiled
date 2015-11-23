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
    public partial class FrmFilerLoadGame : Form
    {
        FileHandler filer;
        string theMap;
        int theList;
        FrmContainer parentForm;
        public FrmFilerLoadGame()
        {
            InitializeComponent();
            LoadLists();
        }
        public void SetParentForm(FrmContainer theParent)
        {
            this.parentForm = theParent;
        }
        public void LoadLists()
        {
            if (filer == null)
            {
                filer = new FileHandler();
            }

            filer.Init();


            foreach (string str in filer.GetMapListArray(0))
            {
                lbxOriginalMaps.Items.Add(str);
            }

            foreach (string str in filer.GetMapListArray(1))
            {
                lbxUserCreated.Items.Add(str);
            }

        }

        private void btnLoadUser_Click(object sender, EventArgs e)
        {            
            if (lbxOriginalMaps.Text != "")
            {
                theMap = lbxOriginalMaps.Text;
                theList = 0;
                parentForm.OpenGameForm(theList, theMap);
                parentForm.SetPreviousForm(this);
                this.Hide();
            }
            if (lbxUserCreated.Text != "")
            {
                theMap = lbxUserCreated.Text;
                theList = 1;
                parentForm.OpenGameForm(theList, theMap);
                parentForm.SetPreviousForm(this);
                this.Hide();
            }
            if (lbxOriginalMaps.Text == "" && lbxUserCreated.Text == "")
            {
                theMap = "";
            }
        }

        public int GetTheList()
        {
            return theList;
        }
        public string GetTheMap()
        {
            return theMap;
        }

        private void lbxUserCreated_Click(object sender, EventArgs e)
        {
            lbxOriginalMaps.ClearSelected();
        }

        private void lbxOriginalMaps_Click(object sender, EventArgs e)
        {
            lbxUserCreated.ClearSelected();
        }
       
    }
}
