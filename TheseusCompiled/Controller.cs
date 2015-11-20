using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusCompiled
{
    public class Controller
    {
        IView view;
        Game game;
        FileHandler filer;
        LevelBuilder builder;
        int mapPool;

        public Controller(IView theView, Game theGame, FileHandler theFiler, LevelBuilder theBuilder)
        {
            view = theView;
            game = theGame;
            filer = theFiler;
            builder = theBuilder;

            filer.Init();
            game.Init(view, filer);
        }

        


       /* public void SetMapPool(int thePool)
        {
            mapPool = thePool;
        }

        public void ChooseYourAdventure(int theChoice)
        {
            view.Display("Press 'D' to design your own level, 'L' to load a level, or 'Q' to quit");
            ConsoleKeyInfo theKey = Console.ReadKey();
            if (theKey.Key == ConsoleKey.D)
            {
                LevelBuild();
            }
            if (theKey.Key == ConsoleKey.L)
            {
                GameOn();
            }
            if (theKey.Key == ConsoleKey.Q)
            {
                // new stop method in controller
                System.Environment.Exit(-1);
            }

        }

        public void LevelBuild()
        {
            builder.Init(view.SetDimensions("Choose how large you want the map to be"));
            while (!FinishedBuilding())
            {
                builder.SelectTile(view.SetDimensions("Choose the tile to modify"));
                ModifyTile();
            }

        }

        public bool FinishedBuilding()// keep looping tile modifier
        {
            ConsoleKeyInfo theKey = Console.ReadKey();
            while (theKey.Key != ConsoleKey.A)
            {
                return false;
            }
            return true;
        }

        public void ModifyTile()
        {
            ConsoleKeyInfo theKey = Console.ReadKey();
            view.Start();
            view.Display("Press Up, down, left, right to add/remove walls");
            view.Display("Press 'T', 'M', 'X' to add/remove theseus, minotaur, exit");
            view.Display("Press 'O' to select a different tile");

            while (theKey.Key != ConsoleKey.O)
            {
                switch (theKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        builder.NorthWall();
                        ModifyTile();
                        break;
                    case ConsoleKey.LeftArrow:
                        builder.WestWall();
                        ModifyTile();
                        break;
                    case ConsoleKey.RightArrow:
                        builder.EastWall();
                        ModifyTile();
                        break;
                    case ConsoleKey.DownArrow:
                        builder.SouthWall();
                        ModifyTile();
                        break;
                    case ConsoleKey.T:
                        builder.SetTheseus();
                        ModifyTile();
                        break;
                    case ConsoleKey.M:
                        builder.SetMinotaur();
                        ModifyTile();
                        break;
                    case ConsoleKey.X:
                        builder.Exit();
                        ModifyTile();
                        break;
                    default:
                        ModifyTile();
                        break;
                }
            }
        }

        public void GameOn()
        {


            SetMapPool(view.ChoosePool("Please choose a collection\n 0 = inbuilt, 1 = user created"));
            view.Display(filer.GetMapList(mapPool));
            view.Display("Please choose a map");
            filer.SetMap(mapPool, Console.ReadLine());
            game.SetMap();
  
            while (!game.Run())
            {
               
            }
            view.Display("Congratulations, you finished Theseus and the Minotaur!\nCredits:\nEverything: Harrison\n\nPress any key to exit");

        }

        public void Init()
        {
            view.Start();

            view.Display("----*- THESEUS AND THE MINOTAUR -*----\n\n");

            SetMapPool(view.ChoosePool("Please choose a collection\n 0 = inbuilt, 1 = user created"));
            view.Display(filer.GetMapList(mapPool));
            view.Display("Please choose a map");
            filer.SetMap(mapPool, Console.ReadLine());
            game.SetMap();
           
            while (!game.Run())
            {
             
            }
            view.Display("Congratulations, you finished Theseus and the Minotaur!\nCredits:\nEverything: Harrison\n\nPress any key to exit");

            Console.ReadKey();
        }*/
    }
}


/*public void GameOver()
        {
            view.Display("Press 'R' to restart, \npress 'N' to go to the next level, \npress 'L' to select a level, \npress 'X' to quit");
            ConsoleKeyInfo theKey = Console.ReadKey();
            if (theKey.Key == ConsoleKey.R)
            {
                model.Restart();
            }
            if (theKey.Key == ConsoleKey.N)
            {
                model.NextMap();
            }
            if (theKey.Key == ConsoleKey.L)
            {
                Init();
            }
            if (theKey.Key == ConsoleKey.X)
            {
                // new stop method in controller
                System.Environment.Exit(-1);
            }
        }*/


 /*while (!game.Run())
            {
                /*while (model.GetTheseus().IsFinished() && model.GetLevel() < model.GetTotalMaps() || model.GetMinotaur().HasEaten())
                {
                    //GameOver();
                }
                break;
            */

 /*game.SetMap();
            /* while (!model.SetMap(view.SetLevel("Please choose a map")))
             {
                 view.Start();
                 view.Display("This map is not valid, please choose another");
             }*/
           /* while (!game.Run())
            {
                /*while (model.GetTheseus().IsFinished() && model.GetLevel() < model.GetTotalMaps() || model.GetMinotaur().HasEaten())
                {
                    //GameOver();
                }
                break;
            */