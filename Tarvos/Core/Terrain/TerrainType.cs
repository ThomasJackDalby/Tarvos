using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarvos.Core.Terrain
{
    public class TerrainType
    {
        public string Name { get; }
        public bool IsSolid { get; }

        public TerrainType(string name, bool isSolid)
        {
            Name = name;
            IsSolid = isSolid;
        }
    }
}
