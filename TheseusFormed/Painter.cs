using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheseusCompiled;
using System.Drawing;

namespace TheseusFormed
{
    static class Painter
    {
        /*public static string mediaPath;

        public static void SetMediaPath(string thePath)
        {
            mediaPath = thePath;
        }*/


        public static void SetPanelSize(Panel thePanel, Form theForm, Tile[,] theTiles, int mapType)
        {
            int newPnlWidth, newPnlHeight, newFrmHeight, newFrmWidth;
            newPnlWidth = (theTiles.GetLength(0) + 1) * 50;
            newPnlHeight = (theTiles.GetLength(1) + 1) * 50;
            thePanel.Size = new Size(newPnlWidth, newPnlHeight);

            

            if (mapType == 1)
            {
                newFrmWidth = newPnlWidth + 250;
                if (newPnlHeight > 400)
                {
                    newFrmHeight = newPnlHeight + 40;
                    theForm.Size = new Size(newFrmWidth, newFrmHeight);
                }
                else
                {
                    theForm.Size = new Size(newFrmWidth, 435);
                }
            }
            if (mapType == 2)
            {
                if (newPnlWidth < 475)
                {
                    newFrmWidth = 475;
                }
                else
                {
                    newFrmWidth = newPnlWidth;
                }
                

                newFrmHeight = newPnlHeight + 50;
                theForm.Size = new Size(newFrmWidth, newFrmHeight);
            }
        }

        public static Point SetLocation(Point thePoint, int multiplier)
        {
            Point newLocation = new Point();
            newLocation.X = (multiplier * thePoint.X) + 10;
            newLocation.Y = (multiplier * thePoint.Y) + 5;
            return newLocation;
        }
        /*
        public static void RenderTheseus(PictureBox pbTheseus, Theseus theseus, Panel thePanel)
        {
            pbTheseus = new PictureBox();
            pbTheseus.Name = "pbTheseus";
            pbTheseus.Location = SetLocation(theseus.Coordinate, 50);
            pbTheseus.Image = Image.FromFile(mediaPath + @"\images\theseus.png");
            pbTheseus.Size = pbTheseus.Image.Size;
            thePanel.Controls.Add(pbTheseus);
        }

        public static PictureBox RenderMinotaur(Minotaur minotaur, Panel thePanel)
        {
            PictureBox pbMinotaur;

            pbMinotaur = new PictureBox();
            pbMinotaur.Name = "pbMinotaur";
            pbMinotaur.Location = SetLocation(minotaur.Coordinate, 50);
            pbMinotaur.Image = Image.FromFile(mediaPath + @"\images\minotaur.png");
            pbMinotaur.Size = pbMinotaur.Image.Size;
            thePanel.Controls.Add(pbMinotaur);

            return pbMinotaur;
        }

        public static void RenderExit(PictureBox pbExit, Tile theTile, Panel thePanel)
        {
            pbExit = new PictureBox();
            pbExit.Name = "pbExit";
            Point exitPoint = SetLocation(theTile.Coordinate, 50);
            exitPoint.X = exitPoint.X + 3;
            exitPoint.Y = exitPoint.Y + 3;
            pbExit.Location = exitPoint;
            pbExit.Image = Image.FromFile(mediaPath + @"\images\exit.gif");
            pbExit.Size = new Size(30, 30);
            pbExit.SizeMode = PictureBoxSizeMode.Zoom;
            thePanel.Controls.Add(pbExit);
            pbExit.BringToFront();
        }

        public static void paintTiles(object sender, PaintEventArgs e, Tile[,] theMap)
        {
            var p = sender as Panel;
            var g = e.Graphics;
            Pen pen = new Pen(Color.Red, 3);
            Brush brush = new SolidBrush(Color.Black);



            foreach (Tile tile in theMap)
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
                /*if (tile.MyWalls.HasFlag(TheWalls.End))
                {
                    if (pbExit == null)
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
                    else
                   {
                        Point exitPoint = SetLocation(tile.Coordinate, 50);
                        exitPoint.X = exitPoint.X + 5;
                        exitPoint.Y = exitPoint.Y + 5;
                        pbExit.Location = exitPoint;
                    }
                    
                }
            }*

                g.Dispose();
            }

        }*/
    }
}
