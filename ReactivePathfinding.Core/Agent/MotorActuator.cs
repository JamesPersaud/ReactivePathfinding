using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    [Serializable]
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
    [Serializable]
    public class MotorActuator : Actuator
    {
        private MotorTypes motorType;

        public MotorTypes MotorType
        {
            get { return motorType; }
            set { motorType = value; }
        }        

        public float Output
        {
            get
            {
                /// For a motor actuator the output must be in the range -1 .. 1
                /// Sigmoid returns a value 0 .. 1 where a netinput of 0 results in an output of 0.5
                float output = base.Output;
                //transpose this to the range -1 .. 1
                output -= 0.5f;
                return output * 2f;
            }
        }

        public override Actuator Clone()
        {
            MotorActuator new_actuator = new MotorActuator(this.motorType);
            CopyTo(new_actuator);
            return new_actuator;
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

        public override string ToString()
        {
            return "Motor: "+this.Name + " Type: "+motorType.ToString()+" Output:" + Output.ToString();
        }
    }
}
