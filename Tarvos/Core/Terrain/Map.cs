using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarvos.Core.Factions;
using Tarvos.Core.Tools;

namespace Tarvos.Core.Terrain
{
    public class Map
    {
        public int Width => Size.Width;
        public int Height => Size.Height;
        public Size Size { get; }

        private Tile[][] tiles { get; }

        public Map(MapSetup setup)
        {
            Size = new Size(setup.Width, setup.Height);
            tiles = setup.GetTiles().Select(c => c?.Select(t => new Tile(t, this)).ToArray()).ToArray();
        }

        public Tile GetTile(Tile tile, Direction direction) => GetTile(tile.Position, direction);
        public Tile GetTile(Point position, Direction direction) {
            Point relative = direction.GetRelativePosition();
            Point newPosition = position + relative;
            return GetTile(newPosition);
        }
        public Tile GetTile(Point position) => GetTile(position.X,position.Y);
        public Tile GetTile(int x, int y) => tiles[x][y];

        public Unit GetUnit(Point point) => GetUnit(point.X, point.Y);
        public Unit GetUnit(int x, int y) => tiles[x][y].Unit;
        public Structure GetStructure(Point point) => GetStructure(point.X, point.Y);
        public Structure GetStructure(int x, int y) => tiles[x][y].Structure;
    }
}
