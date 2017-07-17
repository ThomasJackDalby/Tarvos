using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarvos.Core;
using Tarvos.Interface;
using Tarvos.Interface.States;

namespace Tarvos
{
    public class Program
    {
        public static IInterface Interface { get; }

        static Program()
        {
            Interface = new ConsoleInterface();
        }

        private Program()
        { }
        static void Main(string[] args)
        {
            Run();
        }
        private static IState currentState { get; set; }
        public static void Run()
        {
            currentState = new MainMenuState();
            while (true)
            {
                evaluateUserInput();
            }
        }

        public static void ChangeState(IState state)
        {
            currentState = state;
        }

        private static void evaluateUserInput()
        {
            INode rootNode = currentState.GetRootNode();
            INode currentNode = rootNode;
            INode previousNode = rootNode;
            List<INode> commandPath = new List<INode>();
            commandPath.Add(rootNode);
            while (currentNode is ChoiceNode)
            {
                Console.Write(String.Join(".", commandPath.Select(n => n.Command))+":");
                string fullCommand = Console.ReadLine();
                string[] fullCommandData = fullCommand.Split(' ');
                int index = 0;

                string command = fullCommandData[index];
                if (command == "..")
                {
                    commandPath.Remove(currentNode);
                    currentNode = previousNode;
                    continue;
                }
                else if (command == "?")
                {
                    listNodeOptions(currentNode);
                    continue;
                }

                while (currentNode is ChoiceNode && index < fullCommandData.Length)
                {
                    INode[] nodes = (currentNode as ChoiceNode).Nodes;
                    INode nextNode = nodes.SingleOrDefault(n => n.Command == fullCommandData[index]);
                    if (nextNode == null)
                    {
                        Console.WriteLine("Invalid option.");
                        break;
                    }
                    previousNode = currentNode;
                    currentNode = nextNode;
                    commandPath.Add(currentNode);
                    index++;
                }

                if (currentNode is ActionNode)
                {
                    string[] args = fullCommandData.Skip(index).ToArray();
                    (currentNode as ActionNode).Action(args);
                }
                else listNodeOptions(currentNode);
            }
        }
        private static void listNodeOptions(INode node)
        {
            INode[] children = (node as ChoiceNode).Nodes;
            foreach (INode child in children) Console.WriteLine("> " + child.Command);          
        }
    }
}
