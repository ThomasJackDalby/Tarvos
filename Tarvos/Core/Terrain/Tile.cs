using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarvos.Core.Factions;
using Tarvos.Core.Tools;

namespace Tarvos.Core.Terrain
{
    public class Tile
    {
        public Map Map { get; }
        public Point Position { get; }
        public TerrainType TerrainType { get; }

        public Unit Unit { get; set; }
        public Structure Structure { get; set; }

        public Tile(TileSetup setup, Map map)
        {
            Map = map;
            Position = setup.Position;
            TerrainType = setup.TerrainType;
        }
    }
}
