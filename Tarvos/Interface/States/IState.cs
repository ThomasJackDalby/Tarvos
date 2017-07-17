using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarvos.Interface.States
{
    public interface IState
    {
        string Name { get; }
		INode GetRootNode();
    }
    public interface INode
    {
        string Command { get; }
    }

    public class ChoiceNode : INode
    {
        public string Command { get; set; }
        public INode[] Nodes { get; set; }

		public ChoiceNode(string command, params INode[] nodes)
        {
            Command = command;
            Nodes = nodes.ToArray();
        }
    }

    public class ActionNode : INode
    {
        public string Command { get; private set; }
        public Action<string[]> Action { get; private set; }

		public ActionNode(string command, Action<string[]> action)
        {
            Command = command;
            Action = action;
        }
    }
}
