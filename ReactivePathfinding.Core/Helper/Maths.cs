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
        public static float BLerp(float x, float y, float x1, float x2, float y1, float y2, float q11, float q21, float q12, float q22)
        {
            float denom = (x2-x1) * (y2-y1);

            float result = 0;
            result += ( ((x2 -x) * (y2 - y)) / denom) * q11;
            result += ( ((x - x1) * (y2 - y)) / denom) * q21;
            result += ( ((x2 - x) * (y - y1)) / denom) * q12;
            result += ( ((x - x1) * (y - y1)) / denom) * q22;

            return result;
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
