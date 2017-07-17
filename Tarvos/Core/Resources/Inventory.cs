using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarvos.Core.Resources
{
    public class Inventory
    {
        private Dictionary<Resource, int> resources { get; } = new Dictionary<Resource, int>();

        public int GetAmount(Resource resource) => resources.ContainsKey(resource) ? resources[resource] : 0;
        public void Add(Resource resource, int amount)
        {
            if (!resources.ContainsKey(resource)) resources[resource] = 0;
            resources[resource] += amount;
        }
        public int Remove(Resource resource, int requestedAmount)
        {
            if (!resources.ContainsKey(resource)) return 0;
            int availableAmount = resources[resource];
            if (requestedAmount <= availableAmount)
            {
                resources[resource] -= requestedAmount;
                return requestedAmount;
            }
            else
            {
                resources[resource] = 0;
                return availableAmount;
            }
        }
    }
}
