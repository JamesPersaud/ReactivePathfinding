using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    /// <summary>
    /// Responsible for delivering random numbers to the other parts of the application
    /// </summary>
    [Serializable]
    public class PRNG
    {
        private int savedSeed = 0;
        private Random random = new Random();
        
        public int GetSeed()
        {
            return savedSeed;
        }

        public void Seed(int seed)
        {
            savedSeed = seed;
            random = new Random(seed);
        }

        public int GetInt(int min_inclusive, int max_inclusive)
        {
            return random.Next(min_inclusive, max_inclusive + 1);
        }

        public float GetFloat()
        {
            return (float)random.NextDouble();
        }

        public float GetFloat(float lowerBoundary, float upperBoundary)
        {
            return GetFloat() * (upperBoundary - lowerBoundary) + lowerBoundary;
        }

        public double GetDouble()
        {
            return random.NextDouble();
        }
    }
}
