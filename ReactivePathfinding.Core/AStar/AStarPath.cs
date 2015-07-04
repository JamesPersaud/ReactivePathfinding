using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public class AStarPath
    {        
        private AStarNode endNode;
        private AStarNode startNode;
        private AStarGraph graph;
        private AStarCostFunction costFunction;
        private List<AStarNode> openList;
        private List<AStarNode> closedList;

        public List<AStarNode> ClosedList
        {
            get { return closedList; }
            set { closedList = value; }
        }

        public List<AStarNode> OpenList
        {
            get { return openList; }
            set { openList = value; }
        }        

        public AStarCostFunction CostFunction
        {
            get { return costFunction; }
            set { costFunction = value; }
        }

        public AStarGraph Graph
        {
            get { return graph; }
            set { graph = value; }
        }

        public AStarNode StartNode
        {
          get { return startNode; }
          set { startNode = value; }
        }

        public AStarNode EndNode
        {
          get { return endNode; }
          set { endNode = value; }
        }        

        /// <summary>
        /// construct a new path from one node to another in a given graph using a given cost function
        /// </summary>        
        public AStarPath(AStarGraph gr, AStarVector3 start, AStarVector3 end, AStarCostFunction func)
        {
            graph = gr;
            costFunction = func;
            startNode = graph.getNode(start.X, start.Y);
            endNode = graph.getNode(end.X, end.Y);

            openList = new List<AStarNode>();
            closedList = new List<AStarNode>();            

            bool pathFound = false;
            bool finished = false;

            //begin A*           
            startNode.Heuristic = costFunction.GetHeuristic(startNode, endNode);
            openList.Add(startNode);

            while (!pathFound)
            {
                if(openList.Count ==0)
                {
                    finished = true;
                    pathFound = false;
                    break;
                }                

                AStarNode best = openList[0];
                foreach (AStarNode n in openList)
                {
                    if (n.GetFitness(costFunction) < best.GetFitness(costFunction))
                        best = n;
                }

                openList.Remove(best);
                closedList.Add(best);

                if(closedList.Contains(endNode))
                {
                    pathFound = true;
                    finished = true;
                }

                foreach (AStarNode n in best.Edges)
                {
                    if (!closedList.Contains(n) && !openList.Contains(n))
                    {
                        openList.Add(n);
                        n.Heuristic = costFunction.GetHeuristic(n, endNode);
                        n.Parent = best;
                    }
                    else if (openList.Contains(n))
                    {
                        AStarNode currentParent = n.Parent;
                        float currentScore = n.GetPathCost(costFunction);
                        n.Parent = best;
                        if (n.GetPathCost(costFunction) >= currentScore)
                        {
                            n.Parent = currentParent;
                        }
                    }
                }
            }
        }
    }
}
