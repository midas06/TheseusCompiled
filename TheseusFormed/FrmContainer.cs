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
    public partial class FrmContainer : Form
    {
        Form previousForm;
        FrmSplash frmSplash;
        FrmFilerLoadGame frmMapFiler;
        FrmDesignerMenu frmBuilderMenu;
        FrmSetDimensions frmDimensions;
        FrmDesigner frmBuilder;
        FrmMap frmGame;
        FrmFilerLoadDesigner frmBuilderLoader;


        int extraHeight = 4, extraWidth = 4;
        
        public FrmContainer()
        {
            InitializeComponent();
            Init();
            this.KeyPreview = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            
        }
       

            
            
        public void Init()
        {
            if (frmSplash == null)
            {
                frmSplash = new FrmSplash();
                frmSplash.MdiParent = this;
                frmSplash.SetParentForm(this);
                SetClientSize(frmSplash);
                SetFormProperties(frmSplash);
            }
            
            frmSplash.Show();
        }

        /*** Set map properties ***/

        public void SetPreviousForm(Form oldForm)
        {
            previousForm = oldForm;
        }

        public void SetClientSize(Form childForm)
        {
            this.pnlNav.Width = childForm.Size.Width;
            this.pnlNav.Location = new Point(2, childForm.Size.Height);
            this.ClientSize = new Size(childForm.Size.Width + extraWidth, childForm.Size.Height + extraHeight + 40);
        }

        public void SetChildSize(Form childForm)
        {
            childForm.Size = this.ClientSize;
        }
        
        public void SetFormProperties(Form childForm)
        {
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.StartPosition = FormStartPosition.Manual;
            childForm.Location = new Point(0, 0);
        }

        public void OpenMap(Form childForm)
        {
            
            SetFormProperties(childForm);
            SetClientSize(childForm);
            childForm.Show();
            childForm.BringToFront();
        }

        public void SetSizeManually(Form theForm, Size newSize)
        {
            this.pnlNav.Width = newSize.Width;
            this.pnlNav.Location = new Point(2, frmBuilder.GetSize().Height);
            this.ClientSize = new Size(frmBuilder.GetSize().Width + extraWidth, frmBuilder.GetSize().Height + extraHeight + 40);
        }




        /**** Open the maps ****/


        public void OpenMapFiler()
        {
            if (frmMapFiler == null)
            {
                frmMapFiler = new FrmFilerLoadGame();
                frmMapFiler.MdiParent = this;
                frmMapFiler.SetParentForm(this);
                OpenMap(frmMapFiler);
            }
            else
            {
                frmMapFiler.Show();
                frmMapFiler.BringToFront();
            }
        }

        public void OpenBuilderMenu()
        {
            if (frmBuilderMenu == null)
            {
                frmBuilderMenu = new FrmDesignerMenu();
                frmBuilderMenu.MdiParent = this;
                frmBuilderMenu.SetParentForm(this);
                OpenMap(frmBuilderMenu);
            }
            else
            {
                frmBuilderMenu.Show();
                frmBuilderMenu.BringToFront();
            }
        }

        public void OpenDimensions()
        {
            if (frmDimensions == null)
            {
                frmDimensions = new FrmSetDimensions();
                frmDimensions.MdiParent = this;
                frmDimensions.SetParentForm(this);
                OpenMap(frmDimensions);
            }
            else
            {
                frmDimensions.Show();
                frmDimensions.BringToFront();
            }
        }

        public void OpenNewBuilder(Point newDimensions)
        {
            //if (frmBuilder == null)
            //{
                frmBuilder = new FrmDesigner();
                frmBuilder.MdiParent = this;
                frmBuilder.SetParentForm(this);
                frmBuilder.Init(newDimensions);

                SetFormProperties(frmBuilder);
                SetSizeManually(frmBuilder, frmBuilder.GetSize());
                frmBuilder.Show();
                frmBuilder.BringToFront();

            /*}
            else
            {
                frmBuilder.Init(newDimensions);
                SetSizeManually(frmBuilder, frmBuilder.GetSize());
                frmBuilder.Show();
                frmBuilder.BringToFront();
            }*/
        }

        public void OpenGameForm(int theList, string theMap)
        {
            frmGame = new FrmMap();
            frmGame.MdiParent = this;
            frmGame.SetParentForm(this);
            frmGame.Init(theList, theMap);
            OpenMap(frmGame);
           
            //frmGame.Init(theList, theMap);
            frmGame.Show();
            frmGame.BringToFront();
        }

        public void OpenMapListBuilder()
        {
            if (frmBuilderLoader == null)
            {
                frmBuilderLoader = new FrmFilerLoadDesigner();
                frmBuilderLoader.MdiParent = this;
                frmBuilderLoader.SetParentForm(this);
                OpenMap(frmBuilderLoader);

            }
            else
            {
                frmBuilderLoader.Show();
                frmBuilderLoader.BringToFront();
            }
        }

        public void OpenExistingBuilder(AMap theMap)
        {
            this.KeyPreview = true;
            //if (frmBuilder == null)
            //{
                frmBuilder = new FrmDesigner();
                frmBuilder.MdiParent = this;
                frmBuilder.SetParentForm(this);
                frmBuilder.LoadUserMap(theMap);

                SetFormProperties(frmBuilder);
                SetSizeManually(frmBuilder, frmBuilder.GetSize());
                frmBuilder.Show();
                frmBuilder.BringToFront();

           // }
           /* else
            {
                SetFormProperties(frmBuilder);
                SetSizeManually(frmBuilder, frmBuilder.GetSize());
                frmBuilder.Show();
                frmBuilder.BringToFront();
            }*/
        }












        /**** Button onclicks ****/

        public void Home()
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Hide();
            }
            OpenMap(frmSplash);
        }

        public void Back()
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Hide();
            }
            OpenMap(previousForm);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(-1);
        }

   


        


        
    }
}
