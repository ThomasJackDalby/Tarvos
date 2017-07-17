using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarvos.Core.Actions
{
    public abstract class GameAction
    {
        public abstract bool Evaluate(Game game);
    }
}
