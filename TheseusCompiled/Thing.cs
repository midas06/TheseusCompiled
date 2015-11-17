using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheseusCompiled
{
    class Thing
    {
        public Point Coordinate;
        public Game myGame;

        public Thing(int x, int y)
        {
            Coordinate = new Point(x, y);
        }
        internal void SetGame(Game aGame)
        {
            myGame = aGame;
        }
    }
}
