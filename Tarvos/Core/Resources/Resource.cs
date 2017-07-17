using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarvos.Core.Resources
{
    public class Resource
    {
        public string Name { get; }
        public Trait[] Traits { get; }

        public Resource(string name, IEnumerable<Trait> traits)
        {
            Name = name;
            Traits = traits.ToArray();
        }
    }
}
