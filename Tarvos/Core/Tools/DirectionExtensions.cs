using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarvos.Core.Tools
{
    public static class DirectionExtensions
    {
        public static Point GetRelativePosition(this Direction self)
        {
            switch (self)
            {
                case Direction.Up: return new Point(0, 1);
                case Direction.Down: return new Point(0, -1);
                case Direction.Left: return new Point(-1, 0);
                case Direction.Right: return new Point(1, 0);
                default: throw new ArgumentException("Unknown direction.");
            }
        }
    }
}