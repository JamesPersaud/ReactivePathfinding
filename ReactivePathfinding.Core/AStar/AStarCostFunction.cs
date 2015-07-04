using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public enum AStarHeuristicTypes
    {
        MANHATTAN_HORIZONTAL,
        VECTOR_DISTANCE
    }

    public class AStarCostFunction
    {
        private int distanceMultiplier = 1;
        private int ascendingMultiplier = 0;
        private int descendingMultiplier = 0;
        private AStarHeuristicTypes aStarHeuristic = AStarHeuristicTypes.VECTOR_DISTANCE;

        public int DescendingMultiplier
        {
            get { return descendingMultiplier; }
            set { descendingMultiplier = value; }
        }

        public int AscendingMultiplier
        {
            get { return ascendingMultiplier; }
            set { ascendingMultiplier = value; }
        }

        public int DistanceMultiplier
        {
            get { return distanceMultiplier; }
            set { distanceMultiplier = value; }
        }

        /// <summary>
        /// returns the cost of traversal from one node to another + the heuristic
        /// </summary>        
        public float GetCost(AStarNode from, AStarNode to)
        {
            float dist = from.Position.Distance(to.Position);
            float dz = to.Position.Z - from.Position.Z;

            return dist * DistanceMultiplier + Math.Max(dz, 0) * ascendingMultiplier + Math.Min(dz, 0) * descendingMultiplier;
        }

        public float GetHeuristic(AStarNode n, AStarNode endNode)
        {
            return n.Position.Distance(endNode.Position);
        }
    }
}
