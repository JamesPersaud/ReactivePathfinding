using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    /// <summary>
    /// The graph should be populated with heightmap values
    /// </summary>
    [Serializable]
    public class AStarGraph
    {
        //8 way adjacency matrix to ensure nodes have all the appropriate edges
        private static int[] adjacency_x = new int[] {-1,  0,  1, -1, 1, -1, 0, 1};
        private static int[] adjacency_y = new int[] {-1, -1, -1,  0, 0,  1, 1, 1};

        private AStarNode[,] nodes;
        private Heightmap currentHeightmap = null;

        public Heightmap CurrentHeightmap
        {
            get { return currentHeightmap; }
            set { currentHeightmap = value; }
        }

        public AStarNode[,] Nodes
        {
            get { return nodes; }
            set { nodes = value; }
        }

        /// <summary>
        /// Instantiate the graph based on a given heightmap
        /// </summary>        
        public AStarGraph(Heightmap map)
        {
            currentHeightmap = map;
            int width = map.Settings.MapWidth;
            int height = map.Settings.MapHeight;

            Nodes = new AStarNode[width, height];

            //create nodes and set adjacency
            for(int x = 0; x < width; x++)
            {
                for(int y =0; y < height; y++)
                {
                    //create and add node
                    AStarNode n = new AStarNode();
                    n.Position = new AStarVector3(x, y, map.GetSceneHeight(x, y));
                    Nodes[x, y] = n;
                    
                    //adjacency
                    for(int i = 0; i < adjacency_x.Length ; i++)
                    {
                        int ax = x + adjacency_x[i];
                        int ay = y + adjacency_y[i];

                        if(ax >= 0 && ay >=0 && ax < width && ay < height)
                        {
                            if (Nodes[ax, ay] != null)
                                n.connectNode(Nodes[ax, ay]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get the node closest to the given position
        /// </summary>        
        public AStarNode getNode(float x, float y)
        {
            int ix = (int)Math.Floor(x + 0.5f);
            int iy = (int)Math.Floor(y + 0.5f);

            if (ix < 0) ix = 0;
            if (iy < 0) iy = 0;
            if (ix >= currentHeightmap.Settings.MapWidth) ix = currentHeightmap.Settings.MapWidth;
            if (iy >= currentHeightmap.Settings.MapHeight) iy = currentHeightmap.Settings.MapHeight;

            return Nodes[ix, iy];
        }
    }
}
