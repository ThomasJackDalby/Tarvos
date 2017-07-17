using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarvos.Core.Actions;
using Tarvos.Core.Tools;

namespace Tarvos.Core.Scripts
{
    public class Script
    {
        private List<GameAction> actions { get; } = new List<GameAction>();

        public GameAction GetNextAction() => actions.Count > 0 ? actions[0] : null;

        public void Insert(int index)
        {
            throw new NotImplementedException();
        }
        public void Edit(int index)
        {
            throw new NotImplementedException();
        }
        public void Replace(int index)
        {
            throw new NotImplementedException();
        }
        public void Swap(int index, int other)
        {
            throw new NotImplementedException();
        }
        public void Delete(int index)
        {
            throw new NotImplementedException();
        }
    }
}
