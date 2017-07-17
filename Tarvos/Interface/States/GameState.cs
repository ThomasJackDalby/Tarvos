using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarvos.Core;
using Tarvos.Core.Factions;
using Tarvos.Core.Tools;

namespace Tarvos.Interface.States
{
    public class GameState : IState
    {
        public string Name { get; set; }
        public Game Game { get; set; }

        public GameState(Game game)
        {
            Game = game;
        }

        public INode GetRootNode()
        {
            INode infoUnit = new ActionNode("unit", s => infoUnitAction(s));
            INode infoTile = new ActionNode("tile", s => infoTileAction(s));
            INode info = new ChoiceNode("info", infoUnit, infoTile);
            INode edit = new ActionNode("edit", editAction);
            INode view = new ActionNode("view", s => Renderer.Render(Game));
            INode end = new ActionNode("end", endAction);
            INode root = new ChoiceNode("$", info, view, edit, end);
            return root;
        }

        private void infoUnitAction(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Need to provide a position.");
                return;
            }
            string position = args[0];
            Unit unit = Game.CurrentFaction.GetUnit(position);
            if (unit == null)
            {
                Console.WriteLine("No unit at that position.");
                return;
            }
            Console.WriteLine("Unit");
            Console.WriteLine("------------");
            Console.WriteLine("Id: {0}", unit.Id);
            Console.WriteLine("Pos: {0}", unit.Position);
            Console.WriteLine("Att: {0}", unit.Attack);
            Console.WriteLine("Def: {0}", unit.Defence);
        }
        private void infoTileAction(string[] args)
        {

        }
        private void endAction(string[] args)
        {
            Game.Evaluate();
            Console.WriteLine($"Turn: {Game.CurrentTurnIndex}");
        }
        private void editAction(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Need to provide a position.");
                return;
            }
            string position = args[0];
            Point point = Point.Parse(position); 
            Unit unit = Game.GetUnit(point);
            if (unit == null)
            {
                Console.WriteLine("No unit at that position.");
                return;
            }
            Program.ChangeState(new EditState(unit.Script));
        }
    }
}
