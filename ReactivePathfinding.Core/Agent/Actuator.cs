using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public enum ActivationFunctionTypes
    {
        SUMMATIVE,
        MULTIPLICATIVE,
        SIGMOID,
        SUMMATIVE_CLAMPED
    }

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
        private string name = string.Empty;
        private ActivationFunctionTypes activationFunctionType = ActivationFunctionTypes.SIGMOID;

        public ActivationFunctionTypes ActivationFunctionType
        {
            get { return activationFunctionType; }
            set { activationFunctionType = value; }
        }
    
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

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

        /// <summary>
        /// The net input from all connections to this actuator
        /// </summary>
        public float NetInput
        {
            get
            {
                float nin = 0;

                foreach (Connection c in this.connections)
                    nin += c.Output;

                return nin;
            }
        }

        /// <summary>
        /// By default returns the net input
        /// </summary>
        public float Output
        {
            get
            {
                float output = 0;

                switch(activationFunctionType)
                {
                    case ActivationFunctionTypes.MULTIPLICATIVE:
                        output = 1;
                        foreach (Connection c in this.connections)
                            output *= c.Output;
                        break;
                    case ActivationFunctionTypes.SIGMOID:
                        output = Maths.Sigmoid(NetInput);
                        break;
                    case ActivationFunctionTypes.SUMMATIVE:
                        output = NetInput;
                        break;
                    case ActivationFunctionTypes.SUMMATIVE_CLAMPED:
                        output = Maths.Clamp(0,1,NetInput);
                        break;
                    default:
                        output = NetInput;
                        break;
                }

                return output;                
            }
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
