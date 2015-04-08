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
        private Random random = new Random();
        
        public void Seed(int seed)
        {
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

        public double GetDouble()
        {
            return random.NextDouble();
        }
    }
}
