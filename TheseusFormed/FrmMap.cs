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
    public partial class FrmMap : Form
    {

        AMap theMap;
        int currentList;
        string currentMap;
        FileHandler filer;
        Game game;
        string mediaPath;
        PictureBox pbTheseus, pbMinotaur, pbExit;
        Theseus theseus; 
        Minotaur minotaur;
        FrmContainer parentForm;

        //ImageList tileList;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Left || keyData == Keys.Right)
            {
                FrmMap_KeyDown(this, new KeyEventArgs(keyData));
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /*private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode.ToString());
        }*/

        public FrmMap()
        {
            InitializeComponent();
            this.KeyPreview = true;

            foreach (Control control in this.Controls)
            {
                control.PreviewKeyDown += control_PreviewKeyDown;
            }
        }

        public void SetParentForm(FrmContainer theParent)
        {
            parentForm = theParent;
        }

        void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        public void SetMap(AMap newMap)
        {
            theMap = newMap;
            
        }

        public void Init(int theList, string newMap)
        {
            currentMap = newMap;
            currentList = theList;
            filer = new FileHandler();
            game = new Game();
            mediaPath = @"H:\2015\semester 2\PR 283 C#\Theseus\TheseusFormed - Test\media";
            
            filer.Init();
            filer.SetMap(theList, newMap);
            game.SetFiler(filer);
            LoadMap();
        }

        public void LoadMap()
        {
            game.SetMap();
            SetMap(game.GetCurrentMap());

            theseus = theMap.TheTheseus;
            minotaur = theMap.TheMinotaur;
            SetTitle();
            Painter.SetPanelSize(pnlBackground, this, theMap.Tiles, 2);
            RenderCharacters();
        }




        private void FrmMap_Load(object sender, EventArgs e)
        {
  
        }

        protected void SetTitle()
        {
            lblTitle.Text = theMap.Name;
            lblTitle.Font = new Font("Georgia", 21);
            //lblTitle.TextAlign = HorizontalAlignment.Center;
        }
        
        private void pnlBackground_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;
            Pen pen = new Pen(Color.Red, 3);
            Brush brush = new SolidBrush(Color.Black);
            


            foreach (Tile tile in theMap.Tiles)
            {
                Point topLeft, topRight, bottomLeft, bottomRight;
                topLeft = new Point(tile.Coordinate.X * 50, tile.Coordinate.Y * 50);
                topRight = new Point((tile.Coordinate.X + 1) * 50, tile.Coordinate.Y * 50);
                bottomLeft = new Point(tile.Coordinate.X * 50, (tile.Coordinate.Y + 1) * 50);
                bottomRight = new Point((tile.Coordinate.X + 1) * 50, (tile.Coordinate.Y + 1) * 50);

                // add 4 points
                
                g.FillEllipse(brush, topLeft.X, topLeft.Y, 3, 3);
                g.FillEllipse(brush, topRight.X, topRight.Y, 3, 3);
                g.FillEllipse(brush, bottomLeft.X, bottomLeft.Y, 3, 3);
                g.FillEllipse(brush, bottomRight.X, bottomRight.Y, 3, 3);

                // walls
                if (tile.MyWalls.HasFlag(TheWalls.North))
                {
                    g.DrawLine(pen, topLeft, topRight);
                }
                if (tile.MyWalls.HasFlag(TheWalls.South))
                {
                    g.DrawLine(pen, bottomLeft, bottomRight);
                }
                if (tile.MyWalls.HasFlag(TheWalls.East))
                {
                    g.DrawLine(pen, topRight, bottomRight);
                }
                if (tile.MyWalls.HasFlag(TheWalls.West))
                {
                    g.DrawLine(pen, topLeft, bottomLeft);
                }

                // exit
                if (tile.MyWalls.HasFlag(TheWalls.End))
                {
                    if (pbExit == null)
                    {
                        pbExit = new PictureBox();
                        pbExit.Name = "pbExit";
                        Point exitPoint = Painter.SetLocation(tile.Coordinate, 50);
                        exitPoint.X = exitPoint.X + 5;
                        exitPoint.Y = exitPoint.Y + 5;


                        pbExit.Location = exitPoint;
                        pbExit.Image = Image.FromFile(mediaPath + @"\images\exit.gif");
                        pbExit.Size = new Size(30, 30);
                        pbExit.SizeMode = PictureBoxSizeMode.Zoom;

                        pnlBackground.Controls.Add(pbExit);
                        pbExit.BringToFront();
                    }
                    else
                   {
                        Point exitPoint = Painter.SetLocation(tile.Coordinate, 50);
                        exitPoint.X = exitPoint.X + 5;
                        exitPoint.Y = exitPoint.Y + 5;
                        pbExit.Location = exitPoint;
                    }
                    
                }
            }

            g.Dispose();
        }


        protected void RenderCharacters()
        {
            if (pbTheseus == null)
            {
                pbTheseus = new PictureBox();
                pbTheseus.Name = "pbTheseus";
                pbTheseus.Location = Painter.SetLocation(theseus.Coordinate, 50);
                pbTheseus.Image = Image.FromFile(mediaPath + @"\images\theseus.png");
                pbTheseus.Size = pbTheseus.Image.Size;
            }
            else
            {
                pbTheseus.Location = Painter.SetLocation(theseus.Coordinate, 50);
            }

            if (pbMinotaur == null)
            {
                pbMinotaur = new PictureBox();
                pbMinotaur.Name = "pbMinotaur";
                pbMinotaur.Location = Painter.SetLocation(minotaur.Coordinate, 50);
                pbMinotaur.Image = Image.FromFile(mediaPath + @"\images\minotaur.png");
                pbMinotaur.Size = pbMinotaur.Image.Size;
            }
            else
            {
                pbMinotaur.Location = Painter.SetLocation(minotaur.Coordinate, 50);
            }
            pnlBackground.Controls.Add(pbTheseus);
            pnlBackground.Controls.Add(pbMinotaur);
            pbTheseus.BringToFront();
            pbMinotaur.BringToFront();
        }
        protected void ClearCharacters()
        {
            pnlBackground.Controls.Remove(pbTheseus);
            pnlBackground.Controls.Remove(pbMinotaur);
        }
        protected void UpdateLocation()
        {
            if (!game.IsGameOver())
            {
                pbTheseus.Location = Painter.SetLocation(theseus.Coordinate, 50);
                pbMinotaur.Location = Painter.SetLocation(minotaur.Coordinate, 50);
                pbTheseus.BringToFront();
                pbMinotaur.BringToFront();
            }
            else
            {
                if (theseus.IsFinished())
                {
                    pbTheseus.Location = Painter.SetLocation(theseus.Coordinate, 50);
                    if (currentList == 0)
                    {
                        if (filer.GetNextMap() == true)
                        {
                            //filer.GetNextMap();
                            LoadMap();
                            this.Refresh();
                            parentForm.SetClientSize(this);
                            currentMap = theMap.Name;
                        }
                        else 
                        {
                            DialogResult dialogResult = MessageBox.Show("Congrats, you have finished Theseus and the Minotaur! Do you want to try a User created map?", "Congrats!", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                parentForm.Back();
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                parentForm.Home();
                            }

                        }
                        
                    }
                    else if (currentList == 1)
                    {
                        DialogResult dialogResult = MessageBox.Show("Congrats! Do you want to try another User created map?", "Congrats!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            parentForm.Back();
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            parentForm.Home();
                        }
                    }
                    
                }
                if (minotaur.HasEaten())
                {
                    pbTheseus.SendToBack();
                    pbTheseus.Location = Painter.SetLocation(theseus.Coordinate, 50);
                    pbMinotaur.Location = Painter.SetLocation(minotaur.Coordinate, 50);
                    DialogResult dialogResult = MessageBox.Show("Do you want to restart?", "You were eaten!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ClearCharacters();
                        Init(currentList, currentMap);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        parentForm.Home();
                    }
                }
            }
        }


        private void FrmMap_KeyDown(object sender, KeyEventArgs e)
        {
            Keys theKey = e.KeyCode;
            game.Run(theKey);

            
            UpdateLocation();
        }

        

       
   

    }
}
