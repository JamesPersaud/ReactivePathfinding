using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public class Sensor
    {
        private List<Connection> connections;

        public List<Connection> Connections
        {
            get { return connections; }
            set { connections = value; }
        }
    }
}
