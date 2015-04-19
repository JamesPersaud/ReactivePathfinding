using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public class Agent
    {
        private List<Sensor> sensors = new List<Sensor>();
        private List<Actuator> actuators = new List<Actuator>();        

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

        public Agent()
        {

        }

        public void AddActuator(Actuator a)
        {
            if (!actuators.Contains(a))
                actuators.Add(a);
        }

        public void AddSensor(Sensor s)
        {
            if(!sensors.Contains(s))
                sensors.Add(s);
        }

        public void RemoveActuator(Actuator a)
        {
            if (actuators.Contains(a))
                actuators.Remove(a);
        }

        public void RemoveSensor(Sensor s)
        {
            if (sensors.Contains(s))
                sensors.Remove(s);
        }
    }
}
