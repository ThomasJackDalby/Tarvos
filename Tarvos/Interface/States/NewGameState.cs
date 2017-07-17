using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarvos.Core;
using Tarvos.Core.Factions;
using Tarvos.Core.Terrain;

namespace Tarvos.Interface.States
{
    public class NewGameState : IState
    {
        public string Name { get; } = "New Game";

        private GameSetup gameSetup { get; set; } = new GameSetup();

        public INode GetRootNode()
        {
            INode startNode = new ActionNode("start", startGame);
            INode addFactionNode = new ActionNode("add_faction", addFaction);
            INode infoNode = new ActionNode("info", info);
            INode setNode = new ActionNode("set", setParameter);
            INode rootNode = new ChoiceNode("$", infoNode, setNode, addFactionNode, startNode);
            return rootNode;
        }

        private void info(string[] args)
        {
            Console.WriteLine($"Game Setup");
            Console.WriteLine($"Map");
            Console.WriteLine($"//////////////////////");
            Console.WriteLine($"Width: {gameSetup.Map.Width}");
            Console.WriteLine($"Height: {gameSetup.Map.Height}");
            Console.WriteLine($"Factions");
            Console.WriteLine($"//////////////////////");
            Console.WriteLine($"Name | Other");
            gameSetup.Factions.ForEach(f => Console.WriteLine($"{f.Name}"));
        }
        private void setParameter(string[] args)
        {
            if (args.Length != 2) throw new ArgumentException("A parameter name and value must be provided.");
            string parameter = args[0];
            string value = args[1];

            switch (parameter)
            {
                case "map_width":
                    gameSetup.Map.Width = Int32.Parse(value);
                    break;
                case "map_height":
                    gameSetup.Map.Height = Int32.Parse(value);
                    break;
                default: throw new ArgumentException($"Parameter [{parameter}] is not part of a game setup.");
            }


        }
        private void addFaction(string[] args)
        {
            if (args.Length != 1) throw new ArgumentException("A name must be provided to add a faction.");
            string name = args[0];

            FactionSetup setup = new FactionSetup();
            setup.Name = name; 
            gameSetup.Factions.Add(setup);
        }
        private void startGame(string[] args)
        {
            Game game = new Game(gameSetup);
            Program.ChangeState(new GameState(game));
        }
    }
}
