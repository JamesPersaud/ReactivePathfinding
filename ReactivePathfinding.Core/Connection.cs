using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public class Connection
    {
        private float weight;
        private Sensor connectedSensor;
        private Actuator connectedActuator;

        public Actuator ConnectedActuator
        {
            get { return connectedActuator; }
            set { connectedActuator = value; }
        }

        public Sensor ConnectedSensor
        {
            get { return connectedSensor; }
            set { connectedSensor = value; }
        }

        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }
    }
}
