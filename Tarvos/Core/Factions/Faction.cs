using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarvos.Core.Terrain;
using Tarvos.Core.Tools;

namespace Tarvos.Core.Factions
{
    public class Faction
    {
        public string Name { get; }
        public List<Unit> Units { get; } = new List<Unit>();
        public List<Structure> Structures { get; } = new List<Structure>();

        public Faction(FactionSetup setup, Map map)    
        {
            Name = setup.Name;
        }

        public bool Contains(Unit unit) => Units.Contains(unit);
        public bool Contains(Structure structure) => Structures.Contains(structure);
        public Unit GetUnit(string id) => Units.FirstOrDefault(u => u.Id == id);
        public Structure GetStructure(string id) =>Structures.FirstOrDefault(u => u.Id == id);
        public Structure GetStructure(Point position) => GetStructure(position.X, position.Y);
        public Structure GetStructure(int x, int y) => Structures.FirstOrDefault(s => s.Position.X == x && s.Position.Y == y);
    }
}
