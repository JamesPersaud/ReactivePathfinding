using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public class AStarPath
    {        
        public const bool DEBUG_PATH = true;

        private AStarNode endNode;
        private AStarNode startNode;
        private AStarGraph graph;
        private AStarCostFunction costFunction;
        private List<AStarNode> openList;
        private List<AStarNode> closedList;
        private bool pathFound = false;
        private bool finished = false;
        private int pathSize = 0;
        private float pathCost = 0;
        private List<AStarNode> finalPath;

        public List<AStarNode> FinalPath
        {
            get { return finalPath; }            
        }

        public float PathCost
        {
            get { return pathCost; }            
        }

        public int PathSize
        {
            get { return pathSize; }
        }

        public bool PathFound
        {
            get { return pathFound; }
            set { pathFound = value; }
        }        

        public bool Finished
        {
            get { return finished; }            
        }

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
            //the heuristic should be the actual cost of moving square by square in a manhattan way to the target?

            graph = gr;
            costFunction = func;
            startNode = graph.getNode(start.X, start.Y);
            endNode = graph.getNode(end.X, end.Y);

            openList = new List<AStarNode>();
            closedList = new List<AStarNode>();  

            //begin A*           
            startNode.Heuristic = costFunction.GetHeuristic(startNode, endNode);
            openList.Add(startNode);

            while (!finished)
            {
                if(openList.Count ==0)
                {
                    finished = true;
                    pathFound = false;
                    Logging.Instance.Log("Pathfinding ended but couldn't find a path");
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
                    pathCost = endNode.GetFitness(costFunction);
                    pathSize = 0;
                    
                    finalPath = new List<AStarNode>();
                    AStarNode p = EndNode;

                    while(p != null)
                    {
                        finalPath.Add(p);
                        pathSize++;
                        p = p.Parent;
                    }

                    Logging.Instance.Log("Pathfinding ended and found a path costing " + pathCost.ToString());
                    if(DEBUG_PATH)
                    {
                        Logging.Instance.Log("Back tracing path");
                        AStarNode n = endNode;
                        while(n != null)
                        {
                            Logging.Instance.Log(n.Position.X.ToString() + ", " + n.Position.Y.ToString());
                            n = n.Parent;
                        }
                    }
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
