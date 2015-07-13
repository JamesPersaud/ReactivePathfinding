using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReactivePathfinding.Core;

namespace ReactivePathfinding.WinformsVis
{
    public partial class BestPathForm : Form
    {
        private Experiment currentExperiment;
        
        public Experiment CurrentExperiment
        {
            get { return currentExperiment; }
            set
            {
                currentExperiment = value;
                if(currentExperiment.SearchCostFunction != null)
                {
                    numDistance.Value = currentExperiment.SearchCostFunction.DistanceMultiplier;
                    numUp.Value = currentExperiment.SearchCostFunction.AscendingMultiplier;
                    numDown.Value = currentExperiment.SearchCostFunction.DescendingMultiplier;
                }
            }
        }        

        public BestPathForm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (CurrentExperiment != null)
            {
                Startpoint start = CurrentExperiment.CurrentStartpoint;
                Target end = CurrentExperiment.CurrentTarget;

                AStarCostFunction cost = new AStarCostFunction();
                cost.DistanceMultiplier = (int)this.numDistance.Value;
                cost.AscendingMultiplier = (int)this.numUp.Value;
                cost.DescendingMultiplier = (int)this.numDown.Value;

                AStarGraph graph = new AStarGraph(CurrentExperiment.CurrentHeightmap);
                AStarPath path = new AStarPath(graph,
                    new AStarVector3(start.Position.X, start.Position.Y, start.Position.Z),
                    new AStarVector3(end.Position.X, end.Position.Y, end.Position.Z), cost);

                CurrentExperiment.SearchCostFunction = cost;
                CurrentExperiment.BestPath = path;

                if(!path.PathFound)
                    throw new Exception("A* could not find a path");
            }


            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
