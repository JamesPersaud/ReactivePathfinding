using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public enum ConnectionTypes
    {
        EXCITATORY, 
        INHIBITORY,
        INVERSE_EXCITATORY,
        INVERSE_INHIBITORY
    }

    /// <summary>
    /// The connection determines what effect a sensor's output has on the actuator to which it is connected
    ///         
    /// Excitatory connections feed forward the value from the sensor to the actuator i.e. connection.output = sensor.output
    /// Inhibitory connections feed forward the opposite of the value from the sensor, i.e. connection.output = -sensor.output
    /// 
    /// Inverse connections feed forward the same as above except the magnitude is inverted i.e. connection.output = 1 / (sensor.output OR -sensor.output)
    /// 
    /// </summary>
    public class Connection
    {        
        private float weight;
        private Sensor connectedSensor;
        private Actuator connectedActuator;
        private string name = string.Empty;
        private ConnectionTypes connectionType;
        private bool excitatory;
        private bool inverse;

        public bool Excitatory
        {
            get { return excitatory; }
            set { excitatory = value; }
        }        

        public bool Inverse
        {
            get { return inverse; }
            set { inverse = value; }
        }

        public ConnectionTypes ConnectionType
        {
            get { return connectionType; }
            set { connectionType = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

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

        public float Output
        {
            get
            {
                float output = ConnectedSensor.Output * this.weight;

                if (this.inverse) 
                    output = 1 - output;

                if (this.excitatory)
                    return output;
                else
                    return -output;
            }
        }

        public Connection(Sensor s, Actuator a, float initialWeight, ConnectionTypes t)
        {
            this.weight = initialWeight;
            this.connectedActuator = a;
            this.connectedSensor = s;
            this.connectionType = t;

            this.excitatory = (this.ConnectionType == ConnectionTypes.INVERSE_EXCITATORY || this.connectionType == ConnectionTypes.EXCITATORY);
            this.inverse = (this.ConnectionType == ConnectionTypes.INVERSE_EXCITATORY || this.connectionType == ConnectionTypes.INVERSE_INHIBITORY);

            a.AddConnection(this);
            s.AddConnection(this);
        }

        public override string ToString()
        {
            string s = "{ " + string.Copy(name) + ": [";
            if (connectedSensor != null)
                s += connectedSensor.Name + " <= ";

            s += weight.ToString();

            if (ConnectedActuator != null)
                s += " => " + connectedActuator.Name;

            s += "] }";

            return s;
        }        
    }
}
