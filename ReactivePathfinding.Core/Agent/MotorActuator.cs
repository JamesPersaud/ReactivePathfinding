using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{    
    public enum MotorTypes
    {
        LEFT,RIGHT
    }

    /// <summary>
    /// 
    /// A motor will exert a force from a displacement from the centre of gravity of the agent, towards a given direction.
    /// An equal force acts to propel the agent in the opposite direction from which the motor faces.
    /// 
    /// </summary>
    public class MotorActuator : Actuator
    {
        private MotorTypes motorType;

        public MotorTypes MotorType
        {
            get { return motorType; }
            set { motorType = value; }
        }

        public MotorActuator(MotorTypes t)
        {
            this.motorType = t;
            this.Direction = 180;
            if(t == MotorTypes.LEFT)
                this.Location = new RadialPoint(90, 1);
            else
                this.Location = new RadialPoint(270, 1);
            this.ActuatorType = ActuatorTypes.MOTOR;
        }                
    }
}
