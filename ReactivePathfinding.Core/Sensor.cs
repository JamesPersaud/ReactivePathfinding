using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public enum SensorTypes
    {
        DISTANCE_TO_POINT,
        HEIGHT,
        HEIGHTMAP_GRADIENT
    }

    public class Sensor
    {
        private List<Connection> connections = new List<Connection>();

        private RadialPoint location;
        private float direction;
        private SensorTypes sensorType;

        public SensorTypes SensorType
        {
            get { return sensorType; }
            set { sensorType = value; }
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

        public Sensor(RadialPoint loc, float dir)
        {
            location = loc;
            direction = dir;
        }

        public void RemoveConnection(Connection c)
        {
            if (connections.Contains(c))
                this.connections.Remove(c);
        }

        public void AddConnection(Connection c)
        {
            if (!connections.Contains(c))
                this.connections.Add(c);
        }
    }
}
