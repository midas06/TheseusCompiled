using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheseusCompiled;
using System.Windows.Forms;
using System.Drawing;

namespace TheseusFormed
{
    class FormController
    {
        IView view;
        Game game;
        FileHandler filer;
        LevelBuilder builder;


        public FormController(IView theView, Game theGame, FileHandler thefiler, LevelBuilder thebuilder)
        {
            view = theView;
            game = theGame;
            filer = thefiler;
            builder = thebuilder;
        }

        public void Init()
        {
            Application.Run(new FrmFilerLoad());
        }

        public Point UserKeyPress(Keys theKeypress)
        {
            if (theKeypress == Keys.Up)
            {
                return Direction.Up;
            }
            if (theKeypress == Keys.Down)
            {
                return Direction.Down;
            }
            if (theKeypress == Keys.Up)
            {
                return Direction.Up;
            }
            if (theKeypress == Keys.Up)
            {
                return Direction.Up;
            }
            return Direction.Pass;
        }
    }
}
