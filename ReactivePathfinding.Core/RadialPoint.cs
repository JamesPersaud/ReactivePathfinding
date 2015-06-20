using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public class RadialPoint
    {
        private float angle;
        private float displacement;
        private float x;
        private float y;

        public float X
        {
            get { return x; }
            set { x = value; }
        }        

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public float Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                while (angle < 0) angle += 360;
                while (angle > 360) angle -= 360;
                recalcXandY();
            }
        }        

        public float Displacement
        {
            get { return displacement; }
            set { displacement = value; recalcXandY(); }
        }        

        public RadialPoint(float ang, float disp)
        {
            angle = ang;
            displacement = disp;

            while (angle < 0) angle += 360;
            while (angle > 360) angle -= 360;

            recalcXandY();
        }

        private void recalcXandY()
        {
            x = displacement * (float)Math.Cos((float)Maths.DegToRad(angle));
            y = displacement * (float)Math.Sin((float)Maths.DegToRad(angle));
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
