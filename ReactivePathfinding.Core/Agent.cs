using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public class Agent
    {
        private List<Sensor> sensors;
        private List<Actuator> actuators;

        public List<Actuator> Actuators
        {
            get { return actuators; }
            set { actuators = value; }
        }

        public List<Sensor> Sensors
        {
            get { return sensors; }
            set { sensors = value; }
        }

    }
}
