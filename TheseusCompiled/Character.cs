using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheseusCompiled
{
    public class Character : Thing
    {
        public Character(int x, int y) : base(x, y)
        {

        }

        internal bool IsBlocked(Point direction)
        {
            Point intendedTile = new Point(Coordinate.X + direction.X, Coordinate.Y + direction.Y);


            if (intendedTile.X != Coordinate.X)
            {
                // wanting to move left
                if (intendedTile.X < Coordinate.X)
                {
                    if (myGame.GetMap()[Coordinate.X, Coordinate.Y].MyWalls.HasFlag(TheWalls.West))
                    {
                        return true;
                    }
                }

                // wanting to move right
                if (intendedTile.X > Coordinate.X)
                {
                    if (myGame.GetMap()[Coordinate.X, Coordinate.Y].MyWalls.HasFlag(TheWalls.East))
                    {
                        return true;
                    }
                }
            }
            else if (intendedTile.Y != Coordinate.Y)
            {
                // wanting to move up
                if (intendedTile.Y < Coordinate.Y)
                {
                    if (myGame.GetMap()[Coordinate.X, Coordinate.Y].MyWalls.HasFlag(TheWalls.North))
                    {
                        return true;
                    }
                }

                // wanting to move down
                if (intendedTile.Y > Coordinate.Y)
                {
                    if (myGame.GetMap()[Coordinate.X, Coordinate.Y].MyWalls.HasFlag(TheWalls.South))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        public bool Move(Point direction)
        {
            if (!IsBlocked(direction))
            {
                Coordinate.Offset(direction);
                return true;
            }
            return false;
        }
    }
}
