using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    /// <summary>
    /// Represents a genome where the genes are single bits (encoded as an array of ints that may be 1 or 0)
    /// </summary>
    [Serializable]
    public class BitstringGenome : Genome
    {

        public override int Size()
        {
            throw new NotImplementedException();
        }

        protected override void DoMutation(int position)
        {
            throw new NotImplementedException();
        }

        protected override void DoCrossover(int position, Genome other)
        {
            throw new NotImplementedException();
        }

        protected override void DoArithmeticalCrossover(Genome other)
        {
            throw new NotImplementedException();
        }

        public override Genome Clone()
        {
            throw new NotImplementedException();
        }

        public override Genome Clone(Experiment ex)
        {
            throw new NotImplementedException();
        }
    }
}
