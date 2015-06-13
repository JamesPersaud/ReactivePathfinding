using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    /// <summary>
    /// Base class for genomes - contains common code, specifies required methods and contains helper methods
    /// 
    /// The fitness of a genome is assessed by the performance of an agent using that genome in a set experiment, 
    /// therefore fitness functions do not apply directly to genomes
    /// 
    /// </summary>
    public abstract class Genome
    {
        public const bool DEBUG_MUTATION = true;
        public const bool DEBUG_CROSSOVER = true;

        protected PRNG rng;
        protected string name;

        /// <summary>
        /// Optional identifier for use in debugging.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        /// <summary>
        /// Mutate if the mutation condition is met
        /// </summary>        
        public virtual void Mutate(int threshold, int min, int max)
        {
            int result = rng.GetInt(min, max);

            if (DEBUG_MUTATION)
                Logging.Instance.Log(this.name + " chance to mutate, result must be " + threshold.ToString() + " or more between " + min.ToString() + " and " + max.ToString() + " result is " + result.ToString());

            if(result >= threshold)            
                DoMutation(rng.GetInt(0, Size() - 1));
        }

        /// <summary>
        /// Single point crossover if the crossover condition is met
        /// </summary>        
        public virtual void Crossover(int threshold, int min, int max, Genome other)
        {
            int result = rng.GetInt(min, max);

            if (DEBUG_CROSSOVER)
                Logging.Instance.Log(this.name + " chance to cross over, result must be " + threshold.ToString() + " or more between " + min.ToString() + " and " + max.ToString() + " result is " + result.ToString());

            if(result >= threshold)
            {
                DoCrossover(rng.GetInt(0, Size() - 1), other);
            }
        }

        /// <summary>
        /// Crosses over two lists, should be used to produce children from copies of parents selected for crossover
        /// </summary>        
        public static void CrossLists<T>(List<T> a, List<T> b, int position)
        {
            //if the crossover position is at the beginning or at the end, simply swap the lists
            if (position == 0 || position == a.Count - 1)
            {
                List<T> c = a.GetRange(0, a.Count);
                a.Clear();
                a.AddRange(b);
                b.Clear();
                b.AddRange(c);
            }
            else
            {
                // c is the first part of a and the second part of b
                List<T> c = a.GetRange(0, position);
                c.AddRange(b.GetRange(position, b.Count - position));
                // d is the first part of b and the second part of a
                List<T> d = b.GetRange(0, position);
                d.AddRange(a.GetRange(position, a.Count - position));

                a.Clear();
                b.Clear();
                a.AddRange(c);
                b.AddRange(d);
            }
        }

        //Methods which must be implemented by subclasses        
        public abstract int Size();
        protected abstract void DoMutation(int position);
        protected abstract void DoCrossover(int position, Genome other);
        public abstract Genome Clone();

        public Genome()
        {

        }
    }
}
