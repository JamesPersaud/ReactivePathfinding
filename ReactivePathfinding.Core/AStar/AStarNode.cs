using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public class AStarNode 
    {
        private AStarVector3 position;
        private List<AStarNode> edges = new List<AStarNode>();        
        private float heuristic;
        private AStarNode parent;

        public AStarNode Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        /// <summary>
        /// The heuristic cost of movement from this node to the end node
        /// </summary>
        public float Heuristic
        {
            get { return heuristic; }
            set { heuristic = value; }
        }        

        public AStarVector3 Position
        {
            get { return position; }
            set { position = value; }
        }        

        public List<AStarNode> Edges
        {
            get { return edges; }
            set { edges = value; }
        }

        /// <summary>
        /// Get the total cost of moving to this node through the entire path
        /// </summary>
        public float GetPathCost(AStarCostFunction function)
        {
            return function.GetCost(this, parent) + parent.GetPathCost(function);
        }

        /// <summary>
        /// The sum of the cost of traversing the path to this node and the heuristic
        /// </summary>
        public float GetFitness(AStarCostFunction function)
        {
            return GetPathCost(function) + heuristic;
        }

        /// <summary>
        /// Connects a node to this node
        /// </summary>
        public void connectNode(AStarNode other)
        {
            if(!this.edges.Contains(other))
            {
                this.edges.Add(other);
                other.connectNode(this);                    
            }
        }
    }
}
