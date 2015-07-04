using System;
using OpenTK;
using ReactivePathfinding.Core;

namespace ReactivePathfinding.SceneGraph
{
    public class WheelComponent : SceneGraphComponent
    {        
        private static Vector4 forwardColour = new Vector4(0, 1, 1, 1);    //cyan
        private static Vector4 reverseColour = new Vector4(1, 1, 0, 1); //yellow
        private static Vector4 stationaryColour = new Vector4(0, 0, 0, 1); //black

        private float linearVelocity = 0;
        private Agent agent;

        public Agent Agent
        {
            get { return agent; }
            set { agent = value; }
        }

        public float LinearVelocity
        {
            get { return linearVelocity; }
            set
            {                
                if (RenderDataCreated)
                {
                    if (value == 0 && linearVelocity !=0)
                        setColour(stationaryColour);
                    else if (value < 0 && linearVelocity >=0)
                        setColour(reverseColour);
                    else if (value > 0 && linearVelocity <=0)
                        setColour(forwardColour);

                    linearVelocity = value;
                }                
            }
        }

        private void setColour(Vector4 c)
        {
            for (int i = 0; i < colors.Length; i += 4)
            {
                colors[i + 0] = c.X;
                colors[i + 1] = c.Y;
                colors[i + 2] = c.Z;
                colors[i + 3] = c.W;
            }
        }

        public override void Update(float deltaTime)
        {
            if (!RenderDataCreated)
                CreateRenderData();

            //the radius of the wheel is half the radius of the agent            
            float circumference = agent.CurrentExperiment.AgentRadius * (float)Math.PI;
            float angular_velocity = linearVelocity / circumference * 360;

            ParentObject.RotateLocalAroundY(angular_velocity * deltaTime);
        }        

        /// <summary>
        /// TODO indicate agent facing
        /// </summary>
        private void CreateRenderData()
        {
            PolyMode = OpenTK.Graphics.OpenGL.PolygonMode.Fill;
            MeshHelper.GetWheel(agent.CurrentExperiment.AgentRadius*2, stationaryColour, out vertices, out triangles, out colors);
            RenderDataCreated = true;
        }        
    }
}
