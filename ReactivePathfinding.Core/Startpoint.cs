using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public class Startpoint
    {
        private IPosition3F position;
        private Experiment currentExperiment;

        public Experiment CurrentExperiment
        {
            get { return currentExperiment; }
            set { currentExperiment = value; }
        }

        public IPosition3F Position
        {
          get { return position; }
          set { position = value; }
        }
    }
}
