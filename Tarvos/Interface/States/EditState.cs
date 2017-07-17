using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarvos.Core.Scripts;

namespace Tarvos.Interface.States
{
    public class EditState : IState
    {
        public string Name { get { return "Edit"; } }
        private Script script { get; }

        public EditState(Script script)
        {
            this.script = script;
        }

        public INode GetRootNode()
        {
            throw new NotImplementedException();
        }

        INode IState.GetRootNode()
        {
            throw new NotImplementedException();
        }
    }
}
