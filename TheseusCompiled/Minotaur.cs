using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusCompiled
{
    public class Minotaur : Character
    {
        public Minotaur(int x, int y) : base(x, y)
        {

        }

        protected void HuntHorizontal()
        {
            Theseus theseus = myGame.GetTheseus();

            // if Theseus is to the left
            if (Coordinate.X > theseus.Coordinate.X)
            {
                if (!Move(Direction.Left))
                {
                    HuntVertical();
                }
            }
            if (Coordinate.X < theseus.Coordinate.X)
            {
                if (!Move(Direction.Right))
                {
                    HuntVertical();
                }
            }
        }

        protected void HuntVertical()
        {
            Theseus theseus = myGame.GetTheseus();

            if (Coordinate.Y > theseus.Coordinate.Y)
            {
                if (!Move(Direction.Up))
                {
                    //trapped, do nothing
                }
            }
            if (Coordinate.Y < theseus.Coordinate.Y)
            {
                if (!Move(Direction.Down))
                {
                    //trapped, do nothing
                }
            }
        }

        public void Hunt()
        {
            Theseus theseus = myGame.GetTheseus();
            for (int i = 0; i < 2; i++)
            {
                // if minotaur's X value isn't the same as theseus'
                if (Coordinate.X != theseus.Coordinate.X)
                {
                    HuntHorizontal();
                }
                else if (Coordinate.X == theseus.Coordinate.X)
                {
                    HuntVertical();
                }
            }
        }


        internal Boolean HasEaten()
        {
            Theseus theseus = myGame.GetTheseus();
            if (Coordinate == theseus.Coordinate)
            {
                return true;
            }
            return false;
        }

    }
}


