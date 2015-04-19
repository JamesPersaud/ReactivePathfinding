using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public class RadialPoint
    {
        public float Angle;
        public float Displacement;

        public RadialPoint(float angle, float displacement)
        {
            Angle = angle;
            Displacement = displacement;
        }

        public static RadialPoint Center
        {
            get
            {
                return new RadialPoint(0f,0f);
            }
        }
    }
}
