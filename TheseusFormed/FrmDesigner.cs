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
    public partial class FrmDesigner : Form
    {
        LevelBuilder builder;
        FileHandler filer;
        PictureBox pbTheseus, pbMinotaur, pbExit, pbSelectedTile;
        string mediaPath;
        Point point;

        public FrmDesigner()
        {
            InitializeComponent();
        }

        public void Init(Point dimensions)
        {
            if (builder == null)
            {
                builder = new LevelBuilder();
            }
            builder.Init(dimensions);
            mediaPath = @"H:\2015\semester 2\PR 283 C#\Theseus\TheseusFormed - Test\media";
            
           
        }

        protected void ShowSelectedTile(Point coordinate)
        {
            Point newPoint = new Point();
            newPoint.X = (coordinate.X * 50) + 5;
            newPoint.Y = (coordinate.Y * 50) + 5;
            if (pbSelectedTile == null)
            {
                pbSelectedTile = new PictureBox();
                pbSelectedTile.Name = "pbSelectedTile";
                pbSelectedTile.Location = newPoint;
                pbSelectedTile.Size = new Size(45, 45);
                pbSelectedTile.BackColor = Color.Honeydew;
                pnlBackground.Controls.Add(pbSelectedTile);
                pbSelectedTile.BringToFront();
            }
            else
            {
                pbSelectedTile.Location = newPoint;
            }
        }


        private void pnlBackground_Click(object sender, EventArgs e)
        {
            if (builder.GetTiles() != null)
            {
                point = pnlBackground.PointToClient(Cursor.Position);
                point.X = point.X / 50;
                point.Y = point.Y / 50;

                if ((point.X < builder.GetTiles().GetLength(0)) && (point.Y < builder.GetTiles().GetLength(1)))
                {
                    builder.SelectTile(point);
                    ShowSelectedTile(point);

                }

                pnlBackground.Invalidate();
                Refresh();// DrawMap();
            }

        }

        private void pnlBackground_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            Pen pen = new Pen(Color.Red, 3);
            Brush brush = new SolidBrush(Color.Black);



            foreach (Tile tile in builder.GetTiles())
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

                //exit
                
            }

            g.Dispose();
        }

        protected Point SetLocation(Point thePoint, int multiplier)
        {
            Point newLocation = new Point();
            newLocation.X = (multiplier * thePoint.X) + 10;
            newLocation.Y = (multiplier * thePoint.Y) + 5;
            return newLocation;
        }

        protected void RenderCharacters()
        {
            if (builder.GetTheseus() != null)
            {
                pbTheseus = new PictureBox();
                pbTheseus.Name = "pbTheseus";
                pbTheseus.Location = SetLocation(builder.GetTheseus().Coordinate, 50);
                pbTheseus.Image = Image.FromFile(mediaPath + @"\images\theseus.png");
                pbTheseus.Size = pbTheseus.Image.Size;
                pnlBackground.Controls.Add(pbTheseus);
                pbTheseus.BringToFront();
            }

            if (builder.GetMinotaur() != null)
            {
                pbMinotaur = new PictureBox();
                pbMinotaur.Name = "pbMinotaur";
                pbMinotaur.Location = SetLocation(builder.GetMinotaur().Coordinate, 50);
                pbMinotaur.Image = Image.FromFile(mediaPath + @"\images\minotaur.png");
                pbMinotaur.Size = pbMinotaur.Image.Size;
                pnlBackground.Controls.Add(pbMinotaur);
                pbMinotaur.BringToFront();
            }

            if (builder.GetExit() != null)
            {
                pbExit = new PictureBox();
                pbExit.Name = "pbExit";
                Point exitPoint = SetLocation(builder.GetExit().Coordinate, 50);
                exitPoint.X = exitPoint.X + 3;
                exitPoint.Y = exitPoint.Y + 3;
                pbExit.Location = exitPoint;
                pbExit.Image = Image.FromFile(mediaPath + @"\images\exit.gif");
                pbExit.Size = new Size(30, 30);
                pbExit.SizeMode = PictureBoxSizeMode.Zoom;
                pnlBackground.Controls.Add(pbExit);
                pbExit.BringToFront();

            }
        }

        private void btnNW_Click(object sender, EventArgs e)
        {
            if (point != null)
            {
                builder.NorthWall();
                this.Invalidate();
                Refresh();
            }
           
        }

        private void btnEW_Click(object sender, EventArgs e)
        {
            if (point != null)
            {
                builder.EastWall();
                this.Invalidate();
                Refresh();

            }
            
        }

        private void btnSW_Click(object sender, EventArgs e)
        {
            if (point != null)
            {
                builder.SouthWall();
                this.Invalidate();
                Refresh();
            }
            
        }

        private void btnWW_Click(object sender, EventArgs e)
        {
            if (point != null)
            {
                builder.WestWall();
                this.Invalidate();
                Refresh();
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (point != null)
            {
                builder.Exit();
                if (pbExit == null)
                {
                    RenderCharacters();
                }
                if (pbExit != null)
                {
                    Point exitPoint = SetLocation(builder.GetExit().Coordinate, 50);
                    exitPoint.X = exitPoint.X + 3;
                    exitPoint.Y = exitPoint.Y + 3;
                    pbExit.Location = exitPoint;
                }
                this.Invalidate();
                Refresh();
            }
            
        }

        private void btnTheseus_Click(object sender, EventArgs e)
        {
            if (point != null)
            {
                builder.SetTheseus();
                if (pbTheseus == null)
                {
                    RenderCharacters();
                }
                if (pbTheseus != null)
                {
                    pbTheseus.Location = SetLocation(builder.GetTheseus().Coordinate, 50);
                }
                this.Invalidate();
                Refresh();
            }
            
        }

        private void btnMinotaur_Click(object sender, EventArgs e)
        {
            if (point != null)
            {
                builder.SetMinotaur();
                if (pbMinotaur == null)
                {
                    RenderCharacters();
                }
                if (pbMinotaur != null)
                {
                    pbMinotaur.Location = SetLocation(builder.GetMinotaur().Coordinate, 50);
                }
                this.Invalidate();
                Refresh();
            }
            
        }

        protected bool IsValid()
        {
            if (!builder.IsValid())
            {
                MessageBox.Show("Your map is not valid, you need a Theseus, Minotaur and an Exit");
                return false;
            }
            if (filer == null)
            {
                filer = new FileHandler();
            }
            filer.Init();

            if (tbxMapName.Text == "")
            {
                MessageBox.Show("Please enter a name for your map");
                return false;
            }
            if (filer.MapNameUsed(tbxMapName.Text))
            {
                MessageBox.Show("This map name is already used");
                return false;
            }
            return true;
        

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                filer.NewUserMap(tbxMapName.Text, builder.Export());
                MessageBox.Show("Your map has been saved!");
            }
            
        }





    }
}
