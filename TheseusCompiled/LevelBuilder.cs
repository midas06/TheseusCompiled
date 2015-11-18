using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheseusCompiled
{
    class LevelBuilder
    {
     int horizontal, vertical;
        Tile[,] theMap;
        Tile theTile;
        Theseus theseus;
        Minotaur minotaur;

        public void Init(Point newDimensions) //(int newHorizontal, int newVertical)
        {
            horizontal = (newDimensions.X) - 1;
            vertical = (newDimensions.Y) - 1;

            theMap = MapCreator.CreateMap(newDimensions.X, newDimensions.Y);
        }

        public void SelectTile(Point newTile) //int theX, int theY)
        {
            theTile = theMap[newTile.X, newTile.Y];
        }

        protected bool HasExit()
        {
            foreach (Tile tile in theMap)
            {
                if (tile.MyWalls.HasFlag(TheWalls.End))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsNorthmost()
        {
            if (theTile.Coordinate.Y == 0)
            {
                return true;
            }
            return false;
        }

        public bool IsSouthmost()
        {
            if (theTile.Coordinate.Y == vertical)
            {
                return true;
            }
            return false;
        }

        public bool IsWestmost()
        {
            if (theTile.Coordinate.X == 0)
            {
                return true;
            }
            return false;
        }

        public bool IsEastmost()
        {
            if (theTile.Coordinate.X == horizontal)
            {
                return true;
            }
            return false;
        }

        public void SetTheseus()
        {
            int x = theTile.Coordinate.X;
            int y = theTile.Coordinate.Y;

            if ((Object)theseus == null)
            {
                theseus = new Theseus(x, y);
            }

            // catch: minotaur/exit on same tile
        }

        public void SetMinotaur()
        {
            int x = theTile.Coordinate.X;
            int y = theTile.Coordinate.Y;

            if ((Object)minotaur == null)
            {
                minotaur = new Minotaur(x, y);
            }

            // catch: theseus on same tile
        }

        public void NorthWall()
        {
            Tile adjTile;


            if (theTile.MyWalls.HasFlag(TheWalls.North))
            {
                theTile.MyWalls &= ~TheWalls.North;

                if (!IsNorthmost())
                {
                    adjTile = theMap[theTile.Coordinate.X, theTile.Coordinate.Y - 1];
                    adjTile.MyWalls &= ~TheWalls.South;
                }
            }
            else
            {
                theTile.MyWalls |= TheWalls.North;

                if (!IsNorthmost())
                {
                    adjTile = theMap[theTile.Coordinate.X, theTile.Coordinate.Y - 1];
                    adjTile.MyWalls |= TheWalls.South;
                }
            }
        }

        public void SouthWall()
        {
            Tile adjTile;
            if (theTile.MyWalls.HasFlag(TheWalls.South))
            {
                theTile.MyWalls &= ~TheWalls.South;

                if (!IsSouthmost())
                {
                    adjTile = theMap[theTile.Coordinate.X, theTile.Coordinate.Y + 1];
                    adjTile.MyWalls &= ~TheWalls.North;
                }
            }
            else
            {
                theTile.MyWalls |= TheWalls.South;

                if (!IsSouthmost())
                {
                    adjTile = theMap[theTile.Coordinate.X, theTile.Coordinate.Y + 1];
                    adjTile.MyWalls |= TheWalls.North;
                }
            }
        }

        public void EastWall()
        {
            Tile adjTile;


            if (theTile.MyWalls.HasFlag(TheWalls.East))
            {
                theTile.MyWalls &= ~TheWalls.East;

                if (!IsEastmost())
                {
                    adjTile = theMap[theTile.Coordinate.X + 1, theTile.Coordinate.Y];
                    adjTile.MyWalls &= ~TheWalls.West;
                }
            }
            else
            {
                theTile.MyWalls |= TheWalls.East;

                if (!IsEastmost())
                {
                    adjTile = theMap[theTile.Coordinate.X + 1, theTile.Coordinate.Y];
                    adjTile.MyWalls |= TheWalls.West;
                }
            }
        }

        public void WestWall()
        {
            Tile adjTile;


            if (theTile.MyWalls.HasFlag(TheWalls.West))
            {
                theTile.MyWalls &= ~TheWalls.West;

                if (!IsWestmost())
                {
                    adjTile = theMap[theTile.Coordinate.X - 1, theTile.Coordinate.Y];
                    adjTile.MyWalls &= ~TheWalls.East;
                }
            }
            else
            {
                theTile.MyWalls |= TheWalls.West;

                if (!IsWestmost())
                {
                    adjTile = theMap[theTile.Coordinate.X - 1, theTile.Coordinate.Y];
                    adjTile.MyWalls |= TheWalls.East;
                }
            }
        }

        public void Exit()
        {
            if (theTile.MyWalls.HasFlag(TheWalls.End))
            {
                theTile.MyWalls &= ~TheWalls.End;
            }
            else
            {
                if (!HasExit())
                {
                    theTile.MyWalls |= TheWalls.End;
                }

            }
        }

        public string[] Export()
        {
            string theString = MapCreator.ObjectsToString(theMap, theseus, minotaur);
            return MapCreator.ConvertToStringArray(theString);         
        }
                
        public bool IsValid()
        {
            if (theseus == null || minotaur == null || !ExitExists())
            {
                return false;
            }
            return true;
        }

        protected bool ExitExists()
        {
            bool exists = false;
            foreach (Tile tile in theMap)
            {
                if (tile.MyWalls.HasFlag(TheWalls.End))
                {
                    exists = true;
                }
            }
            return exists;
        }








        public Tile[,] GetMap()
        {
            return theMap;
        }
        public Theseus GetTheseus()
        {
            return theseus;
        }
        public Minotaur GetMinotaur()
        {
            return minotaur;
        }

   



        public void Test()
        {
            foreach (Tile tile in theMap)
            {
                Console.WriteLine("{0}, walls: {1}", tile.Coordinate, tile.MyWalls);
            }
            if (HasExit())
            {
                Console.WriteLine("Has end");
            }
            else
            {
                Console.WriteLine("no exit");
            }
            if ((Object)theseus != null)
            {
                Console.WriteLine("Theseus: {0}", theseus.Coordinate);
            }

        }




    }
}