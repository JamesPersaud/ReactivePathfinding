using System;
using OpenTK;
using ReactivePathfinding.Core;

namespace ReactivePathfinding.SceneGraph
{    
    public class TargetComponent : SceneGraphComponent
    {        
        private Target currentTarget;

        public Target CurrentTarget
        {
            get { return currentTarget; }
            set
            {
                currentTarget = value;
                CreateRenderData();
            }
        }        

        public float GetIntensityAtPoint(Vector3 point)
        {
            float distance = (float)Math.Abs((point - Position).Length);
            if (currentTarget != null)
                return currentTarget.GetIntensityAtDistance(distance);
            else
                throw new Exception("No target object associated with target component");                
        }

        /// <summary>
        /// The target is a green square floating above its position in the heightmap
        /// </summary>
        private void CreateRenderData()
        {
            PolyMode = OpenTK.Graphics.OpenGL.PolygonMode.Fill;
            MeshHelper.GetCube(1, new Vector4(0,1,0,1) , out vertices, out triangles, out colors);
            RenderDataCreated = true;
        }

        public override void Update(float deltaTime)
        {
            if(currentTarget.CurrentExperiment != null)
            {
                float z = currentTarget.CurrentExperiment.CurrentHeightmap.GetSceneHeight((int)Position.X,(int)Position.Y);
                this.Position = new Vector3(Position.X, Position.Y, z * MeshHelper.HEIGHT_EXAGGERATION_FACTOR);
            }
        }
    }
}
