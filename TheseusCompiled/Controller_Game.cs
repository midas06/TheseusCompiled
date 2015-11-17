using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusCompiled
{
    class Controller_Game
    {
        IView_Game view;
        Game model;

        public Controller_Game(IView_Game theView, Game theModel)
        {
            view = theView;
            model = theModel;
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


        public void Init()
        {
            view.Start();
            model.Init(view);
            view.Display("----*- THESEUS AND THE MINOTAUR -*----\n\n");
           /* while (!model.SetMap(view.SetLevel("Please choose a map")))
            {
                view.Start();
                view.Display("This map is not valid, please choose another");
            }*/
            while (!model.Run())
                {
                    /*while (model.GetTheseus().IsFinished() && model.GetLevel() < model.GetTotalMaps() || model.GetMinotaur().HasEaten())
                    {
                        //GameOver();
                    }
                    break;
                */
                }
            view.Display("Congratulations, you finished Theseus and the Minotaur!\nCredits:\nEverything: Harrison\n\nPress any key to exit");
            
            Console.ReadKey();
        }
    }
}
