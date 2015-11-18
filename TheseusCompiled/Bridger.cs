using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TheseusCompiled
{
    class Bridger
    {
        //Tile[,] theMap;
        AMap theMap;
        // Theseus theseus;
        //Minotaur minotaur;
        string[] mapArray;
        int x, y;




        public void Init(AMap newMap)
        {
            /***
             * Initialise map variables - width & height
             * */
            theMap = newMap;
            int length;

            mapArray = theMap.Map;

            length = mapArray[0].Length;

            //Console.WriteLine("the longest line is {0} characters", longest);
            x = (length - 1) / 4;

            //Console.WriteLine("# of line breaks = {0}", Regex.Matches(ascii, "\n").Count);
            //y = Regex.Matches(ascii, "\n").Count / 2;
            y = (mapArray.Length - 1) / 2;

            Console.WriteLine("x = {0}, y = {1}", x, y);

            newMap.Tiles = MapCreator.CreateMap(x, y);

        }

        public void ConvertToObjects(int startingPoint)
        {
            Tile theTile;

            // for every horizontal tile, check characters in string array to see if a wall is present
            for (int xTiles = 0; xTiles < x; xTiles++)
            {
                theTile = theMap.Tiles[xTiles, startingPoint];
                int startingCharX = (xTiles * 4);
                int startingCharY = startingPoint * 2;
                int north, south, east, west, centre;
                north = startingCharX + 2;
                west = startingCharX;
                east = startingCharX + 4;
                south = startingCharX + 2;
                centre = startingCharX + 2;


                if (mapArray[startingCharY][north] == '_')
                {
                    theTile.MyWalls |= TheWalls.North;
                }
                if (mapArray[startingCharY + 1][west] == '|')
                {
                    theTile.MyWalls |= TheWalls.West;
                }
                if (mapArray[startingCharY + 1][east] == '|')
                {
                    theTile.MyWalls |= TheWalls.East;
                }
                if (mapArray[startingCharY + 2][south] == '_')
                {
                    theTile.MyWalls |= TheWalls.South;
                }
                if (mapArray[startingCharY + 1][centre] == 'X')
                {
                    theTile.MyWalls |= TheWalls.End;
                }
                if (mapArray[startingCharY + 1][centre] == 'T')
                {
                    theMap.TheTheseus = new Theseus(theTile.Coordinate.X, theTile.Coordinate.Y);
                    //SetTheseus(theTile.Coordinate.X, theTile.Coordinate.Y);
                }
                if (mapArray[startingCharY + 1][centre] == 'M')
                {
                    theMap.TheMinotaur = new Minotaur(theTile.Coordinate.X, theTile.Coordinate.Y);
                    //SetMinotaur(theTile.Coordinate.X, theTile.Coordinate.Y);
                }
            }
        }


        public void ObjectifyMap()
        {
            for (int row = 0; row < y; row++)
            {
                ConvertToObjects(row);
            }
        }


        public AMap Convert(AMap theMap)
        {
            Init(theMap);
            ObjectifyMap();
            return theMap;
        }

    }
}
