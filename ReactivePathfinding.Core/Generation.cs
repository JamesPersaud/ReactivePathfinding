using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public class Generation
    {
        private List<Agent> population;

        public List<Agent> Population
        {
            get { return population; }
            set { population = value; }
        }
    }
}
