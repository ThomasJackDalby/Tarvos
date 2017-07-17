using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarvos.Core.Terrain;

namespace Tarvos.Interface.States
{
    public class MainMenuState : IState
    {
        public string Name { get; }

        public INode GetRootNode()
        {
            INode newNode = new ActionNode("new", s => Program.ChangeState(new NewGameState()));
            INode loadNode = new ActionNode("load", s => { });
            INode quitNode = new ActionNode("quit", s => { });
            INode root = new ChoiceNode("$", newNode, loadNode, quitNode);
            return root;
        }
    }
}
