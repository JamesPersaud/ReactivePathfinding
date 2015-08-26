using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    [Serializable]
    public enum CrossoverTypes
    {
        SINGLE_POINT,
        ARITHMETICAL
    }

    /// <summary>
    /// Base class for genomes - contains common code, specifies required methods and contains helper methods
    /// 
    /// The fitness of a genome is assessed by the performance of an agent using that genome in a set experiment, 
    /// therefore fitness functions do not apply directly to genomes
    /// 
    /// </summary>
    [Serializable]
    public abstract class Genome
    {
        public const bool DEBUG_MUTATION = false;
        public const bool DEBUG_CROSSOVER = false;

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
        public virtual bool Mutate(int threshold, int min, int max)
        {
            int result = rng.GetInt(min, max);

            if (DEBUG_MUTATION)
                Logging.Instance.Log(this.name + " chance to mutate, result must be " + threshold.ToString() + " or less between " + min.ToString() + " and " + max.ToString() + " result is " + result.ToString());

            if (result <= threshold)
            {
                DoMutation(rng.GetInt(0, Size() - 1));
                return true;
            }
            return false;
        }

        /// <summary>
        /// Single point crossover if the crossover condition is met
        /// </summary>        
        public virtual bool Crossover(int threshold, int min, int max, Genome other, CrossoverTypes type)
        {
            int result = rng.GetInt(min, max);

            if (DEBUG_CROSSOVER)
                Logging.Instance.Log(this.name + " chance to cross over, result must be " + threshold.ToString() + " or less between " + min.ToString() + " and " + max.ToString() + " result is " + result.ToString());

            if(result <= threshold)
            {
                if (type == CrossoverTypes.SINGLE_POINT)
                    DoCrossover(rng.GetInt(0, Size() - 1), other);
                else
                    DoArithmeticalCrossover(other);

                return true;
            }
            return false;
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
        protected abstract void DoArithmeticalCrossover(Genome other);
        public abstract Genome Clone();
        public abstract Genome Clone(Experiment ex);

        public Genome()
        {

        }
    }
}
