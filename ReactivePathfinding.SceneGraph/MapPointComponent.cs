using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactivePathfinding.Core;

namespace ReactivePathfinding.SceneGraph
{
    public class MapPointComponent : SceneGraphComponent
    {
        private Point2f point;

        public Point2f Point
        {
            get { return point; }
            set { point = value; }
        }
    }
}
