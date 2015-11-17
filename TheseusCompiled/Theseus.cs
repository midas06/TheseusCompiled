using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusCompiled
{
    class Theseus : Character
    {
        public Theseus(int x, int y) : base(x, y)
        {

        }
        internal Boolean IsFinished()
        {
            if (myGame.GetMap()[Coordinate.X, Coordinate.Y].MyWalls.HasFlag(TheWalls.End))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}