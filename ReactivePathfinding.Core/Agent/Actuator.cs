using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public enum ActuatorTypes
    {
        MOTOR
    }

    public class Actuator
    {
        private List<Connection> connections = new List<Connection>();
        private RadialPoint location;
        private float direction;
        private ActuatorTypes actuatorType;

        public ActuatorTypes ActuatorType
        {
            get { return actuatorType; }
            set { actuatorType = value; }
        }

        public float Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public RadialPoint Location
        {
            get { return location; }
            set { location = value; }
        }

        public List<Connection> Connections
        {
            get { return connections; }
            set { connections = value; }
        }

        public Actuator(RadialPoint loc, float dir)
        {
            location = loc;
            direction = dir;
        }

        public Actuator()
        {

        }

        public void RemoveConnection(Connection c)
        {
            if(connections.Contains(c))
                this.connections.Remove(c);
        }

        public void AddConnection(Connection c)
        {
            if (!connections.Contains(c))                
                this.connections.Add(c);
        }
    }
}
