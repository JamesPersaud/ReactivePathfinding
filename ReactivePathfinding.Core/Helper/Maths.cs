using System;

namespace ReactivePathfinding.Core
{
    public class Maths
    {        
        /// <summary>
        /// Returns the unipolar sigmoid function of the given net input
        /// </summary>        
        public static float Sigmoid(float input)
        {
            return 1 / (1 + (float)Math.Pow(Math.E, -input));
        }

        /// <summary>
        /// Clamps a float
        /// </summary>        
        public static float Clamp(float min, float max, float value)
        {
            if (value < min)
                return min;
            else if (value > max)
                return max;
            else
                return value;
        }
    }
}
