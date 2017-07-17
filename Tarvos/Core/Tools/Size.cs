using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarvos.Core.Tools
{
    public class Size
    {
        public int Width { get; }
        public int Height { get; }

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public bool Contains(Point point) => Contains(point.X, point.Y);
        public bool Contains(int x, int y) => x < 0 || x >= Width || y < 0 || y >= Height;
        
    }
}
