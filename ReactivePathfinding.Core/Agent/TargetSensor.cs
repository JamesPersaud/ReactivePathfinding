using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    /// <summary>
    /// This type of sensor detects the target in the same way a light sensor would detect light.
    /// 
    /// The input to the sensor is defined as the linear sum of magnitudes of all emitting targets within range of the sensor.
    /// Target emissions obay the inverse square law.
    /// 
    /// </summary>
    [Serializable]
    public class TargetSensor : Sensor
    {
        public TargetSensor(RadialPoint loc)
        {
            SensorType = SensorTypes.TARGET;
            Location = loc;
            Direction = 0.0f;
        }

        /// <summary>
        /// Returns the magnitude of the target's intensity
        /// </summary>        
        public override float Output
        {
            get
            {
                return Input;
            }
        }
    }
}
