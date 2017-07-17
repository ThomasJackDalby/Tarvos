using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarvos.Core;
using Tarvos.Core.Terrain;

namespace Tarvos.Interface
{
    public static class Renderer
    {
        public static Dictionary<TerrainType, char> tiles { get; set; }

        static Renderer()
        {
            tiles = new Dictionary<TerrainType, char>();
            Register(TerrainTypes.Grass, '.');
            Register(TerrainTypes.Rock, '^');
        }

        public static void Register(TerrainType type, char symbol)
        {
            tiles[type] = symbol;
        }

        public static void Render(Game game)
        {
            if (game == null)
            {
                Console.WriteLine("Cannot render a null game.");
                return;
            }
            int digits = 2;
            Console.Write(new string(' ', digits+1));
            for (int x = 0; x < game.Map.Width; x++) Console.Write("{0}", (char)(x+65));
            Console.WriteLine();
            Console.WriteLine(new string('-', digits) + "#" + new string('-', game.Map.Width));
            for (int y = 0; y < game.Map.Height; y++)
            {
                Console.Write("{0,"+digits+"}|",y);
                for (int x = 0; x < game.Map.Width; x++)
                {
                    Tile tile = game.Map.GetTile(x, y);
                    if (tile.Unit != null) Console.Write('G');
                    else Console.Write(tiles[tile.TerrainType]);
                }
                Console.WriteLine();
            }
        }
    }
}
