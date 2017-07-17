using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarvos.Core.Factions;
using Tarvos.Core.Terrain;
using Tarvos.Core.Tools;

namespace Tarvos.Core.Actions
{
    public class UnitMoveAction : GameAction
    {
        private string factionId { get; }
        private string unitId { get; }
        private Point destination { get; }

        public UnitMoveAction(string unitId, Point point)
        {
            this.unitId = unitId;
            this.destination = this.destination;
        }

        public override bool Evaluate(Game game)
        {
            Unit unit = game.GetUnit(factionId, unitId);
            Tile oldTile = unit.Tile;
            Tile newTile = game.Map.GetTile(destination);

            if (newTile == null)
            {
                Program.Interface.WriteMessage($"There is no tile at [{destination}].");
                return false;
            }
            if (newTile.Unit != null)
            {
                Program.Interface.WriteMessage("There is already a unit at the destination tile.");
                return false;
            }
            if (newTile.TerrainType.IsSolid)
            {
                Program.Interface.WriteMessage("There is already a unit at the destination tile.");
                return false;
            }

            unit.Tile = newTile;
            oldTile.Unit = null;
            newTile.Unit = unit;
            return true;
        }
    }
}
