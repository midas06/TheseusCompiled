using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheseusCompiled
{
    class Tile : Thing
    {
        public Tile(int x, int y) : base(x, y)
        {

        }
        internal TheWalls MyWalls { get; set; }

    }
}
