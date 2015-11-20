using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheseusCompiled
{
    public class Tile : Thing
    {
        public Tile(int x, int y) : base(x, y)
        {

        }
        public TheWalls MyWalls { get; set; }

        public bool IsOuter(Point theDirection)
        {
            if (theDirection == Direction.Up && Coordinate.Y == 0)
            {
                return true;
            }
            if (theDirection == Direction.Left && Coordinate.X == 0)
            {
                return true;
            }
            if (theDirection == Direction.Down && Coordinate.Y == (myGame.GetMap().GetLength(1) - 1))
            {
                return true;
            }
            if (theDirection == Direction.Right && (Coordinate.X == (myGame.GetMap().GetLength(0) - 1)))
            {
                return true;
            }
            return false;
        }

    }
}
