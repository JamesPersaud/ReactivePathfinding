using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    /// <summary>
    /// A vector to use internally by the AStar classes - needs converting to an OpenGL Vector3 for use with an OpenGL visualization
    /// </summary>
    public struct AStarVector3
    {
        public float X;
        public float Y;
        public float Z;

        public AStarVector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Ge the distance between two vectors
        /// </summary>        
        public float Distance(AStarVector3 other)
        {
            float dx = other.X - this.X;
            float dy = other.Y - this.Y;
            float dz = other.Z - this.Z;

            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }
    }
}
