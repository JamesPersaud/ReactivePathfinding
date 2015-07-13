using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    /// <summary>
    /// Represents a genome where the genes are floating point numbers with a commmon boundary
    /// </summary>
    public class BoundaryFloatGenome : Genome
    {        
        private List<float> values;        
        private float upperBoundary;
        private float lowerBoundary;

        public float LowerBoundary
        {
            get { return lowerBoundary; }
            set { lowerBoundary = value; }
        }

        public float UpperBoundary
        {
            get { return upperBoundary; }
            set { upperBoundary = value; }
        }

        public override int Size()
        {
            return values.Count;
        }

        /// <summary>
        /// Returns the value of the gene at a specified point in the genome
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public float GetGene(int i)
        {
            return values[i];
        }

        public void SetGene(int i, float v)
        {
            values[i] = v;
        }

        /// <summary>
        /// Replace the value at the specified position with a random float between 
        /// the lower and upper boundaries
        /// </summary>        
        protected override void DoMutation(int position)
        {
            if(DEBUG_MUTATION)            
                Logging.Instance.Log(this.name + " mutating at point " + position.ToString());
            
            values[position] = rng.GetFloat(lowerBoundary, upperBoundary);
        }

        /// <summary>
        /// Single point crossover using the genome helper
        /// </summary>        
        protected override void DoCrossover(int position, Genome other)
        {
            if (DEBUG_CROSSOVER)
                Logging.Instance.Log(this.name + " crossing over with "+other.Name+" at point " + position.ToString());

            Genome.CrossLists<float>(this.values, ((BoundaryFloatGenome)other).values,position);
        }        

        /// <summary>
        /// Copy this genome - for use as a child or in the gene pool
        /// </summary>        
        public override Genome Clone()
        {
            BoundaryFloatGenome other = new BoundaryFloatGenome(this);     
            return other;
        }

        public override Genome Clone(Experiment ex)
        {
            BoundaryFloatGenome other = new BoundaryFloatGenome(this);
            other.rng = ex.Random;
            return other;
        }

        public override string ToString()
        {
            string s = this.name + ": ";

            for (int i = 0; i < values.Count; i++ )
            {
                s += values[i].ToString();
                if (i < values.Count - 1)
                    s += " ";
            }

            return s;
        }        

        /// <summary>
        /// A genome that uses floating point values as the genes and performs mutation by generating a new value
        /// between a lower and an upper boundary
        /// </summary>
        /// <param name="size"></param>
        /// <param name="lowerbound"></param>
        /// <param name="upperbound"></param>
        public BoundaryFloatGenome(int size, float lowerbound, float upperbound, PRNG rng)
        {
            this.rng = rng;

            lowerBoundary = lowerbound;
            upperBoundary = upperbound;

            values = new List<float>();

            for (int i = 0; i < size; i++)
            {
                if (rng != null)
                    values.Add(rng.GetFloat(lowerBoundary, upperBoundary));
                else
                    values.Add(lowerbound);
            }
        }

        /// <summary>
        /// returns a new genome of the same size and bounds as this one
        /// </summary>        
        public BoundaryFloatGenome GetNewGenomeLikeThis()
        {
            return new BoundaryFloatGenome(this.Size(), this.lowerBoundary, this.upperBoundary, this.rng);
        }

        /// <summary>
        /// Copy constructor
        /// </summary>        
        public BoundaryFloatGenome(BoundaryFloatGenome other)
        {
            this.rng = other.rng;

            lowerBoundary = other.lowerBoundary;
            upperBoundary = other.upperBoundary;

            values = new List<float>();

            values.AddRange(other.values);
        }
    }
}
