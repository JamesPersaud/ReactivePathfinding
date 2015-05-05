using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public abstract class Point2f
    {
        public float X;
        public float Y;

        public Point2f(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point2f()
        {

        }
    }
}
