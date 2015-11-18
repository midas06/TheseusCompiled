using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TheseusCompiled
{
    static class MapCreator
    {
        internal static Tile[,] CreateMap(int newWidth, int newHeight)
        {
            Tile[,] Map;
            int width = newWidth, height = newHeight;
            Map = new Tile[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Map[x, y] = new Tile(x, y);
                }
            }
            return Map;
        }

        internal static String ObjectsToString(Tile[,] theMap, Theseus theTheseus, Minotaur theMinotaur)
        {
            string output = "";
            int width = theMap.GetLength(0);
            int height = theMap.GetLength(1);


            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    output += ".";
                    if (theMap[x, y].MyWalls.HasFlag(TheWalls.North))
                    {
                        output += "___";
                    }
                    else
                    {
                        output += "   ";
                    }

                }
                output += ".\n";



                for (int x = 0; x < width; x++)
                {
                    if (x != width - 1)
                    {
                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "|   ";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "    ";
                        }

                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "| X ";
                        }
                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "| X ";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "  X ";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "  X ";
                        }
                    }

                    if (x == width - 1)
                    {
                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "|    ";
                        }
                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "|   |";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "    |";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && !theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "     ";
                        }

                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "| X  ";
                        }
                        if (theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "| X  ";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "  X  ";
                        }
                        if (!theMap[x, y].MyWalls.HasFlag(TheWalls.West) && !theMap[x, y].MyWalls.HasFlag(TheWalls.East) && theMap[x, y].MyWalls.HasFlag(TheWalls.End))
                        {
                            output += "  X  ";
                        }
                    }

                    /*** NB:
                        fixed bad spacing when T & M on same row
                        */
                    if (x == theMinotaur.Coordinate.X && y == theMinotaur.Coordinate.Y)
                    {

                        StringBuilder minoPosition = new StringBuilder(output);
                        if (OnSameLine(theTheseus, theMinotaur) && theTheseus.Coordinate.X < theMinotaur.Coordinate.X)
                        {
                            minoPosition[output.Length - 3] = 'M';
                        }
                        else
                        {
                            minoPosition[output.Length - 2] = 'M';
                        }

                        output = minoPosition.ToString();
                    }
                    if (x == theTheseus.Coordinate.X && y == theTheseus.Coordinate.Y)
                    {
                        StringBuilder thesPosition = new StringBuilder(output);
                        if (OnSameLine(theTheseus, theMinotaur) && theTheseus.Coordinate.X > theMinotaur.Coordinate.X)
                        {
                            thesPosition[output.Length - 3] = 'T';
                        }
                        else
                        {
                            thesPosition[output.Length - 2] = 'T';
                        }

                        output = thesPosition.ToString();
                    }
                }
                output += "\n";

            }

            // lowest row of map
            for (int x = 0; x < width; x++)
            {
                output += ".";
                if (theMap[x, height - 1].MyWalls.HasFlag(TheWalls.South))
                {
                    output += "___";
                }
                else
                {
                    output += "   ";
                }
            }
            output += ".";

            return output;
        }

        internal static bool OnSameLine(Theseus theTheseus, Minotaur theMinotaur)
        {
            if (theTheseus.Coordinate.Y == theMinotaur.Coordinate.Y)
            {
                return true;
            }
            return false;

        }

        internal static String[] ConvertToStringArray(string ascii)
        {
            string[] mapArray = Regex.Split(ascii, "\n");

            return mapArray;
        }

    }
}