using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarvos.Core.Factions;
using Tarvos.Core.Terrain;
using Tarvos.Core.Tools;

namespace Tarvos.Core
{
    public class GameSetup
    {
        public MapSetup Map { get; set; } = new MapSetup();
        public List<FactionSetup> Factions { get; } = new List<FactionSetup>();

        public GameSetup()
        {
            Factions.Add(new FactionSetup() { Name = "TeamA", StartingPosition = new Point(2, 5) });
            Factions.Add(new FactionSetup() { Name = "TeamB", StartingPosition = new Point(8, 5) });
        }
    }
}
