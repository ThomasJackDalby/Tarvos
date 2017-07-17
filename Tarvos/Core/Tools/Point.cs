using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarvos.Core.Tools
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"[{X}:{Y}]";

        public static Point operator+(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);

        public static Point Parse(string input)
        {
            int[] xPos = input.ToUpper().TakeWhile(c => Char.IsLetter(c)).Select(c => c-65).ToArray();
            int[] yPos = input.Skip(xPos.Length).Select(c => c -'0').ToArray();
            int x = xPos.Select((v, i) => v * (int)Math.Pow(26, i)).Sum();
            int y = yPos.Select((v, i) => v * (int)Math.Pow(10, i)).Sum();
            return new Point(x, y);
        }
    }
}
