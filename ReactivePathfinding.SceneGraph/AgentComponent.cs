using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactivePathfinding.Core;

namespace ReactivePathfinding.SceneGraph
{
    public class AgentComponent : SceneGraphComponent
    {
        Agent currentAgent;

        public Agent CurrentAgent
        {
            get { return currentAgent; }
            set { currentAgent = value; }
        }
    }
}
