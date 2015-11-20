using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TheseusCompiled
{
    public class Game
    {
        Minotaur minotaur;
        Theseus theseus;
        AMap currentMap;
        Tile[,] theMap;
        FileHandler theFiler;
        IView theView;
        //int currentMap;
        /*string mapOne = ".___.___.___.   .\n|     M     |    \n.   .___.   .___.\n|       |     X  \n.   .___.   .___.\n|     T     |    \n.___.___.___.   .";
        string mapTwo = ".___.___.___.___.___.___.___.\n|                           |\n.   .   .   .   .   .   .   .\n| M |   | T                 |\n.   .___.   .   .   .   .   .\n|                   |   |   |\n.   .   .   .   .   .___.   .\n|                           |\n.___.   .___.___.___.___.___.\n    | X |                    \n.   .   .   .   .   .   .   .";
        string mapThree = ".___.___.___.   .\n|     M     |    \n.   .___.   .___.\n|     T       X  \n.   .   .   .___.\n|   |       |    \n.___.   .   .   .\n|           |    \n.___.___.___.   .";
        string mapFour = ".   .   .   .   .   .\n            | X |    \n.___.___.___.   .___.\n|   | T             |\n.   .   .   .___.   .\n|       |       | M |\n.   .___.   .   .   .\n|           |       |\n.   .___.___.   .   .\n|           |   |   |\n.   .   .   .___.   .\n|                   |\n.___.___.___.___.___.\n";
        */

        /**** Import Map from Filer */


        public void Init(IView newView, FileHandler newFiler)
        {
            SetFiler(newFiler);
            SetView(newView);
        }

        public void SetMap()
        {
            currentMap = theFiler.GetMap();
            theMap = currentMap.Tiles;
            SetTheseus();
            SetMinotaur();
            SetTiles();
        }




        /*public void Restart()
        {
            theMap = theFiler.GetMap(currentMap);
            //SetTheseus(theFiler.GetTheseus());
            //SetMinotaur(theFiler.GetMinotaur());m,
            Run();
        }

        public void NextMap()
        {
            currentMap += 1;
            theMap = theFiler.GetMap(currentMap);
            //SetTheseus(theFiler.GetTheseus());
            //SetMinotaur(theFiler.GetMinotaur());
            Run();  
        }
        */
        public void SetFiler(FileHandler newFiler)
        {
            theFiler = newFiler;
        }

        protected void SetTiles()
        {
            foreach (Tile tile in currentMap.Tiles)
            {
                tile.SetGame(this);
            }
        }


        protected void SetTheseus()
        {
            theseus = currentMap.TheTheseus;
            theseus.SetGame(this);
        }
        protected void SetMinotaur()
        {
            minotaur = currentMap.TheMinotaur;
            minotaur.SetGame(this);
        }
        public AMap GetCurrentMap()
        {
            return currentMap;
        }

        /**** Get functions for Thing class */
        internal Tile[,] GetMap()
        {
            return theMap;
        }

        internal Theseus GetTheseus()
        {
            return theseus;
        }
        internal Minotaur GetMinotaur()
        {
            return minotaur;
        }

        /**** Test functions */
        /*protected String TestMap(Tile[,] aMap)
        {
            string output = "";
            foreach (Tile tile in aMap)
            {
                output += tile.Coordinate + " " + tile.MyWalls + "\n";
            }
            output += "minotaur " + minotaur.Coordinate + "\n" + "theseus " + theseus.Coordinate;
            return output;
        }*/


        /**** Game functions */

        // return the Player's move
        /*protected Point PlayersTurn()
        {
            ConsoleKeyInfo theKey = Console.ReadKey(true);

            if (theKey.Key == ConsoleKey.UpArrow)
            {
                return Direction.Up;
            }
            if (theKey.Key == ConsoleKey.DownArrow)
            {
                return Direction.Down;
            }
            if (theKey.Key == ConsoleKey.LeftArrow)
            {
                return Direction.Left;
            }
            if (theKey.Key == ConsoleKey.RightArrow)
            {
                return Direction.Right;
            }
            if (theKey.Key == ConsoleKey.A)
            {
                return Direction.Pass;
            }
            return new Point();
        }*/

        public Point PlayersTurn(Keys theKeypress)
        {
            if (theKeypress == Keys.Up)
            {
                return Direction.Up;
            }
            if (theKeypress == Keys.Down)
            {
                return Direction.Down;
            }
            if (theKeypress == Keys.Left)
            {
                return Direction.Left;
            }
            if (theKeypress == Keys.Right)
            {
                return Direction.Right;
            }
            return Direction.Pass;
        }

        /*protected Point PlayersTurn()
        {
            ConsoleKeyInfo theKey = Console.ReadKey(true);

            if (theKey.Key == ConsoleKey.UpArrow)
            {
                return Direction.Up;
            }
            if (theKey.Key == ConsoleKey.DownArrow)
            {
                return Direction.Down;
            }
            if (theKey.Key == ConsoleKey.LeftArrow)
            {
                return Direction.Left;
            }
            if (theKey.Key == ConsoleKey.RightArrow)
            {
                return Direction.Right;
            }
            if (theKey.Key == ConsoleKey.A)
            {
                return Direction.Pass;
            }
            return new Point();
        }*/

        public bool Move(Keys theKeypress)
        {
            Point direction = PlayersTurn(theKeypress);
            if (direction != null)
            {
                return (theseus.Move(direction));

            }
            return false;
        }

        protected bool IsGameOver()
        {
            if (theseus.IsFinished() || minotaur.HasEaten())
            {
                return true;
            }
            return false;
        }

        /*public int GetLevel()
        {
            return currentMap;
        }*/
        /*
        public int GetTotalMaps()
        {
            return theFiler.GetTotalMaps();
        }*/

        public void SetView(IView newView)
        {
            theView = newView;
        }

        /* The go button */
        public bool Run(Keys theKeypress)
        {
            //theView.Start();
            //theView.Display("****" + currentMap.Name + " ****\n");
            //theView.Display(MapCreator.ObjectsToString(theMap, theseus, minotaur));

            if (!IsGameOver())
            {
                Move(theKeypress);
                if (!theseus.IsFinished())
                {
                    minotaur.Hunt();
                }
            }
            
            //while (IsGameOver() == false)
           // {
                //theView.Display("\nPress Up, Down, Left, Right to move; Press A to do nothing");
                
                
                /*theView.Start();
                theView.Display("**** LEVEL " + currentMap.ToString() + " ****\n");
                theView.Display(MapCreator.ObjectsToString(theMap, theseus, minotaur));*/

          //  }
            /*if (IsGameOver() && theseus.IsFinished())
            {
                theView.Display("Congrats!");
                return false;
            }
            if (IsGameOver() && minotaur.HasEaten())
            {
                theView.Display("You were eaten by the Minotaur :(\n");
                theView.Display("Game over\n");
                return false;
            }*/
            return true;
        }


    }
}


/*public bool Run(Keys theKeypress)
        {
            //theView.Start();
            //theView.Display("****" + currentMap.Name + " ****\n");
            //theView.Display(MapCreator.ObjectsToString(theMap, theseus, minotaur));
            while (IsGameOver() == false)
            {
                //theView.Display("\nPress Up, Down, Left, Right to move; Press A to do nothing");
                while (!Move(theKeypress))
                {
                    /*theView.Start();
                    theView.Display("**** LEVEL " + currentMap.ToString() + " ****\n");
                    theView.Display(MapCreator.ObjectsToString(theMap, theseus, minotaur));
                    theView.Display("\nPress Up, Down, Left, Right to move; Press A to do nothing");
                    theView.Display("blocked");
                }
                if (!theseus.IsFinished())
                {
                    minotaur.Hunt();

                }
                /*theView.Start();
                theView.Display("**** LEVEL " + currentMap.ToString() + " ****\n");
                theView.Display(MapCreator.ObjectsToString(theMap, theseus, minotaur));*/

          //  }
            /*if (IsGameOver() && theseus.IsFinished())
            {
                theView.Display("Congrats!");
                return false;
            }
            if (IsGameOver() && minotaur.HasEaten())
            {
                theView.Display("You were eaten by the Minotaur :(\n");
                theView.Display("Game over\n");
                return false;
            }
            return true;
        }*/