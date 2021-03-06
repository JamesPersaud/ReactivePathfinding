﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    [Serializable]
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
    [Serializable]
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
            string s = "{ " + name.Substring(0, Math.Min(name.Length, 15)).PadRight(15) + ": [ ";            

            if (connectedSensor != null && ConnectedActuator != null)
            {
                s += connectedSensor.Name.Substring(0, Math.Min(connectedSensor.Name.Length,15)).PadRight(15) + " ";

                switch(this.connectionType)
                {
                    case ConnectionTypes.EXCITATORY: s += "EXC ("; break;
                    case ConnectionTypes.INHIBITORY: s += "INH ("; break;
                    case ConnectionTypes.INVERSE_EXCITATORY: s += "1/E ("; break;
                    case ConnectionTypes.INVERSE_INHIBITORY: s += "1/I ("; break;
                }

                s += weight.ToString() + ") ";                
                s += " " + connectedActuator.Name;
            }
            else
            {
                s += "unconnected";
            }

            s += " ] }";

            return s;
        }        
    }
}
