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

        /// <summary>
        /// Interpolates a value given by an offset dx,dy in the range 0..1 bounded by values at points 00, 01, 10 and 11
        /// </summary>        
        public static float BLerp(float dx, float dy, float f00, float f01, float f10, float f11)
        {
            return (1 - dx) *
                        ((1 - dy) * f00 +
                        dy * f01) +
                    dx *
                        ((1 - dy) * f10 +
                        dy * f11);   
        }        

        /// <summary>
        /// utility function to convert from degrees to radians
        /// </summary>        
        public static float DegToRad(float degrees)
        {
            while (degrees < 0)
                degrees += 360;

            while (degrees > 360)
                degrees -= 360;

            return degrees * (float)Math.PI / 180;
        }
    }
}
