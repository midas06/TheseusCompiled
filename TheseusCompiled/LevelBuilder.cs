using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheseusCompiled
{
    public class LevelBuilder
    {
        int horizontal, vertical;
        AMap theMap;
        //Tile[,] theMap;
        Tile theTile;
        Theseus theseus;
        Minotaur minotaur;
        string mapName;

        public void Init(Point newDimensions) //(int newHorizontal, int newVertical)
        {
            theMap = new AMap();
            horizontal = (newDimensions.X) - 1;
            vertical = (newDimensions.Y) - 1;

            theMap.Tiles = MapCreator.CreateMap(newDimensions.X, newDimensions.Y);
            

        }

        public void LoadUserMap(AMap userMap)
        {
            theMap = userMap;
            theseus = userMap.TheTheseus;
            minotaur = userMap.TheMinotaur;
            mapName = userMap.Name;
            horizontal = userMap.Tiles.GetLength(0) - 1;
            vertical = userMap.Tiles.GetLength(1) - 1;
        }


        public void SelectTile(Point newTile) //int theX, int theY)
        {
            theTile = theMap.Tiles[newTile.X, newTile.Y];
        }

        protected bool HasExit()
        {
            foreach (Tile tile in theMap.Tiles)
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

            if (theMap.TheMinotaur == null || theMap.TheMinotaur != null && theMap.TheMinotaur.Coordinate != theTile.Coordinate)
            {
                if (theMap.TheTheseus == null)
                {
                    theMap.TheTheseus = new Theseus(x, y);
                }
                else
                {
                    theMap.TheTheseus.Coordinate = theTile.Coordinate;
                }
            }
        }

        public void SetMinotaur()
        {
            int x = theTile.Coordinate.X;
            int y = theTile.Coordinate.Y;

            if (theMap.TheTheseus == null || theMap.TheTheseus != null && theMap.TheTheseus.Coordinate != theTile.Coordinate)
            {
                if (theMap.TheMinotaur == null)
                {
                    theMap.TheMinotaur = new Minotaur(x, y);
                }
                else
                {
                    theMap.TheMinotaur.Coordinate = theTile.Coordinate;
                }
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
                    adjTile = theMap.Tiles[theTile.Coordinate.X, theTile.Coordinate.Y - 1];
                    adjTile.MyWalls &= ~TheWalls.South;
                }
            }
            else
            {
                theTile.MyWalls |= TheWalls.North;

                if (!IsNorthmost())
                {
                    adjTile = theMap.Tiles[theTile.Coordinate.X, theTile.Coordinate.Y - 1];
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
                    adjTile = theMap.Tiles[theTile.Coordinate.X, theTile.Coordinate.Y + 1];
                    adjTile.MyWalls &= ~TheWalls.North;
                }
            }
            else
            {
                theTile.MyWalls |= TheWalls.South;

                if (!IsSouthmost())
                {
                    adjTile = theMap.Tiles[theTile.Coordinate.X, theTile.Coordinate.Y + 1];
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
                    adjTile = theMap.Tiles[theTile.Coordinate.X + 1, theTile.Coordinate.Y];
                    adjTile.MyWalls &= ~TheWalls.West;
                }
            }
            else
            {
                theTile.MyWalls |= TheWalls.East;

                if (!IsEastmost())
                {
                    adjTile = theMap.Tiles[theTile.Coordinate.X + 1, theTile.Coordinate.Y];
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
                    adjTile = theMap.Tiles[theTile.Coordinate.X - 1, theTile.Coordinate.Y];
                    adjTile.MyWalls &= ~TheWalls.East;
                }
            }
            else
            {
                theTile.MyWalls |= TheWalls.West;

                if (!IsWestmost())
                {
                    adjTile = theMap.Tiles[theTile.Coordinate.X - 1, theTile.Coordinate.Y];
                    adjTile.MyWalls |= TheWalls.East;
                }
            }
        }

        public void Exit()
        {
            if (ExitExists())
            {
                foreach (Tile t in theMap.Tiles)
                {
                    if (t.MyWalls.HasFlag(TheWalls.End))
                    {
                        t.MyWalls &= ~TheWalls.End;
                    }
                }

            }
            theTile.MyWalls |= TheWalls.End;
        }
            

        public string[] Export()
        {
            string theString = MapCreator.ObjectsToString(theMap.Tiles, theMap.TheTheseus, theMap.TheMinotaur);
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
            foreach (Tile tile in theMap.Tiles)
            {
                if (tile.MyWalls.HasFlag(TheWalls.End))
                {
                    return true;
                }
            }
            return false;
        }


        public Tile[,] GetTiles()
        {
            return theMap.Tiles;
        }
        public Theseus GetTheseus()
        {
            return theMap.TheTheseus;
        }
        public Minotaur GetMinotaur()
        {
            return theMap.TheMinotaur;
        }
        public Tile GetTheTile()
        {
            return theTile;
        }
        public string GetTheName()
        {
            return mapName;
        }


        public Tile GetExit()
        {
            foreach (Tile t in theMap.Tiles)
            {
                if (t.MyWalls.HasFlag(TheWalls.End))
                {
                    return t;
                }
            }
            return null;
        }

        public string Test()
        {
            string test = "";
            foreach (Tile t in theMap.Tiles)
            {
                test += t.Coordinate.ToString() + " " + t.MyWalls.ToString() + "\n";
            }
            if (theMap.TheTheseus != null)
            {
                test += "Theseus " + theMap.TheTheseus.Coordinate.ToString() + "\n";
            }
            if (theMap.TheMinotaur != null)
            {
                test += "Minotaur " + theMap.TheMinotaur.Coordinate.ToString() + "\n";
            }


            return test;
        }

        public void Clear()
        {
            int x, y;
            x = theMap.Tiles.GetLength(0);
            y = theMap.Tiles.GetLength(1);

            theMap = new AMap();
            theMap.Tiles = MapCreator.CreateMap(x, y);
            theMap.TheTheseus = null;
            theMap.TheMinotaur = null;
        
        }

    }
}