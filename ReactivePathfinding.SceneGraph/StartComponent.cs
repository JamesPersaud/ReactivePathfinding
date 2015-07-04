using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactivePathfinding.Core;
using OpenTK;

namespace ReactivePathfinding.SceneGraph
{
    public class StartComponent : SceneGraphComponent
    {
        private Startpoint currentStartpoint;
        private float lifetime = 0;

        public Startpoint CurrentStartpoint
        {
            get { return currentStartpoint; }
            set
            {
                currentStartpoint = value;
                currentStartpoint.Position = this;
                CreateRenderData();
            }
        }

        /// <summary>
        /// The start pos is a blue square floating above its position in the heightmap
        /// </summary>
        private void CreateRenderData()
        {
            PolyMode = OpenTK.Graphics.OpenGL.PolygonMode.Fill;
            MeshHelper.GetCube(1, new Vector4(0, 0, 1, 1), out vertices, out triangles, out colors);
            RenderDataCreated = true;
        }

        public override void Update(float deltaTime)
        {
            if (currentStartpoint.CurrentExperiment != null)
            {
                float z = currentStartpoint.CurrentExperiment.CurrentHeightmap.GetSceneHeight((int)Position.X, (int)Position.Y);
                this.Position = new Vector3(Position.X, Position.Y, z);
                this.ParentObject.RotateLocalAroundZ(180 * deltaTime);
                lifetime += deltaTime;
            }
        }
    }
}
