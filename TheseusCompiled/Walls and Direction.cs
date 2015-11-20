using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheseusCompiled
{
    [Flags]
    public enum TheWalls
    {
        None = 0x0,
        North = 0x1,
        East = 0x2,
        South = 0x4,
        West = 0x8,
        End = 0x10
    }

    public struct Direction
    {
        public static Point Up = new Point(0, -1);
        public static Point Down = new Point(0, 1);
        public static Point Right = new Point(1, 0);
        public static Point Left = new Point(-1, 0);
        public static Point Pass = new Point(0, 0);

        public static bool operator ==(Direction c1, Point c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Direction c1, Point c2)
        {
            return !c1.Equals(c2);
        }
    }

}
