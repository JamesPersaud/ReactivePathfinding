using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public enum SensorTypes
    {
        TARGET,
        HEIGHT,
        HEIGHTMAP_GRADIENT
    }
    
    public class Sensor
    {
        private List<Connection> connections = new List<Connection>();

        private RadialPoint location;
        private float direction;
        private SensorTypes sensorType;
        private string name = string.Empty;
        private float input;
        private int index;

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        /// <summary>
        /// The overall input to this sensor
        /// </summary>
        public float Input
        {
            get { return input; }
            set { input = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

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

        public Sensor()
        {

        }

        public virtual float Output
        {
            get
            {
                return Input;
            }
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

        public override string ToString()
        {
            return name;
        }
    }
}
