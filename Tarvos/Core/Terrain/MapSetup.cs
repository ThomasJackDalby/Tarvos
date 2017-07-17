using System;
using Tarvos.Core.Tools;

namespace Tarvos.Core.Terrain
{
    public class MapSetup
    {
        public int Height { get; set; } = 10;
        public int Width { get; set; } = 10;
        public int Seed { get; set; } = 0;

        public TileSetup[][] GetTiles()
        {
            Random r = new Random(Seed);
            MapSetup setup = new MapSetup();
            TileSetup[][] tiles = new TileSetup[setup.Width][];
            for (int x = 0; x < setup.Width; x++)
            {
                tiles[x] = new TileSetup[setup.Height];
                for (int y = 0; y < setup.Height; y++)
                {
                    if (r.NextDouble() > 0.95) tiles[x][y] = new TileSetup { Position = new Point(x, y), TerrainType = TerrainTypes.Rock };
                    else tiles[x][y] = new TileSetup { Position = new Point(x, y), TerrainType = TerrainTypes.Grass };
                }
            }
            return tiles;
        }
    }
}   