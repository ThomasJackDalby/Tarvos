using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarvos.Core.Terrain
{
    public static class TerrainTypes
    {
        public static TerrainType Grass { get; } = new TerrainType("Grass", false);
        public static TerrainType Rock { get; } = new TerrainType("Rock", true);
    }
}
