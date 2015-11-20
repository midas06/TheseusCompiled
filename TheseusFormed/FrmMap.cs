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
        FileHandler filer;
        Game game;
        string mediaPath;
        PictureBox pbTheseus, pbMinotaur, pbExit;
        Theseus theseus; 
        Minotaur minotaur; 

        //ImageList tileList;
 


        public FrmMap()
        {
            InitializeComponent();
            this.KeyPreview = true;

            foreach (Control control in this.Controls)
            {
                control.PreviewKeyDown += control_PreviewKeyDown;
            }
        }

        void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        public void SetMap(AMap newMap)
        {
            theMap = newMap;
            
        }

        public void SetTestData(int theList, string newMap)
        {
            filer = new FileHandler();
            game = new Game();
            mediaPath = @"H:\2015\semester 2\PR 283 C#\Theseus\TheseusFormed - Test\media";
            filer.Init();
            filer.SetMap(theList, newMap);
            game.SetFiler(filer);
            game.SetMap();
            SetMap(game.GetCurrentMap());
            theseus = theMap.TheTheseus;
            minotaur = theMap.TheMinotaur;
            SetTitle();
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

        protected Point SetLocation(Point thePoint, int multiplier)
        {
            Point newLocation = new Point();
            newLocation.X = (multiplier * thePoint.X) + 10;
            newLocation.Y = (multiplier * thePoint.Y) + 5;
            return newLocation;
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
                    pbExit = new PictureBox();
                    pbExit.Name = "pbExit";
                    Point exitPoint = SetLocation(tile.Coordinate, 50);
                    exitPoint.X = exitPoint.X + 5;
                    exitPoint.Y = exitPoint.Y + 5;


                    pbExit.Location = exitPoint;
                    pbExit.Image = Image.FromFile(mediaPath + @"\images\exit.gif");
                    pbExit.Size = new Size(30, 30);
                    pbExit.SizeMode = PictureBoxSizeMode.Zoom;

                    pnlBackground.Controls.Add(pbExit);
                    pbExit.BringToFront();
                }
            }

            g.Dispose();
        }


  
        private void pnlBackground_Click(object sender, EventArgs e)
        {
            Point point = pnlBackground.PointToClient(Cursor.Position);
            MessageBox.Show(point.ToString());
        }

        protected void RenderCharacters()
        {
            pbTheseus = new PictureBox();
            pbTheseus.Name = "pbTheseus";
            pbTheseus.Location = SetLocation(theseus.Coordinate, 50);
            pbTheseus.Image = Image.FromFile(mediaPath + @"\images\theseus.png");
            pbTheseus.Size = pbTheseus.Image.Size;

            pbMinotaur = new PictureBox();
            pbMinotaur.Name = "pbMinotaur";
            pbMinotaur.Location = SetLocation(minotaur.Coordinate, 50);
            pbMinotaur.Image = Image.FromFile(mediaPath + @"\images\minotaur.png");
            pbMinotaur.Size = pbMinotaur.Image.Size;

            
            pnlBackground.Controls.Add(pbTheseus);
            pnlBackground.Controls.Add(pbMinotaur);
            pbTheseus.BringToFront();
            pbMinotaur.BringToFront();
        }

        protected void UpdateLocation()
        {
            pbTheseus.Location = SetLocation(theseus.Coordinate, 50);
            pbMinotaur.Location = SetLocation(minotaur.Coordinate, 50);
            pbTheseus.BringToFront();
            pbMinotaur.BringToFront();
        }


        private void FrmMap_KeyDown(object sender, KeyEventArgs e)
        {
            Keys theKey = e.KeyCode;
            game.Run(theKey);
     
            //MessageBox.Show(theseus.Coordinate.ToString());
            UpdateLocation();
        }

        

       
   

    }
}
