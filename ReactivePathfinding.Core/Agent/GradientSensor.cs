using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    /// <summary>
    /// This type of sensor detects the difference in height between the centre of the agent and the position of the sensor        
    /// </summary>
    public class GradientSensor : Sensor
    {
        public GradientSensor(RadialPoint loc)
        {
            SensorType = SensorTypes.HEIGHTMAP_GRADIENT;
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
