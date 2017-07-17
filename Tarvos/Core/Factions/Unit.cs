using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarvos.Core.Actions;
using Tarvos.Core.Scripts;
using Tarvos.Core.Terrain;
using Tarvos.Core.Tools;

namespace Tarvos.Core.Factions
{
    public class Unit
    {
        public string Id { get; }
        public Faction Faction { get; }
        public Script Script { get; } = new Script();

        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Priority { get; set; }
        public Tile Tile { get; set; }

        public Point Position => Tile.Position;

        internal GameAction GetAction() => Script.GetNextAction();
    }
}
