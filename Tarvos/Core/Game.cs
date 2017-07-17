using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarvos.Core.Factions;
using Tarvos.Core.Terrain;
using Tarvos.Core.Tools;
using Tarvos.Tools;

namespace Tarvos.Core
{
    public class Game
    {
        public Map Map { get; }
        public List<Faction> Factions { get; } = new List<Faction>();
        public int CurrentTurnIndex { get; set; }
        public int CurrentFactionIndex { get; set; }

        public Faction CurrentFaction => Factions.Count > 0 ? Factions[CurrentFactionIndex] : null;

        public Game(GameSetup setup)
        {
            if (setup == null) throw new ArgumentException("Cannot create game from null setup.");
            if (setup.Factions.Count < 1) throw new ArgumentException("Cannot create a game with no factions.");

            Map = new Map(setup.Map);
            Factions.AddRange(setup.Factions.Select(f => new Faction(f, Map)));

            CurrentFactionIndex++;
        }
        public Unit GetUnit(string factionName, string unitId) => GetFaction(factionName)?.GetUnit(unitId);
        public Unit GetUnit(Point point) => Map.GetUnit(point);
        public Faction GetFaction(string factionName) => Factions.FirstOrDefault(f => f.Name == factionName);

        public void Evaluate()
        {
            CurrentFaction.Units.OrderBy(unit => unit.Priority).Select(unit => unit.GetAction()).ForEach(action => action.Evaluate(this));

            CurrentTurnIndex++;
            CurrentFactionIndex++;
            if (CurrentFactionIndex >= Factions.Count) CurrentFactionIndex = 0;
        }
    }
}
