using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactivePathfinding.Core;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ReactivePathfinding.SceneGraph
{
    /// <summary>
    /// A component to represent a heightmap
    /// </summary>
    public class HeightmapComponent : SceneGraphComponent
    {
        private Heightmap map;
        private PolygonMode polyMode = PolygonMode.Line;
        private MaterialFace materialFace = MaterialFace.FrontAndBack;

        public Heightmap Map
        {
            get { return map; }
            set { map = value; }
        }

        /// <summary>
        /// Render the heightmap according to the current rendering settings
        /// </summary>
        public override void Render()
        {
            GL.PolygonMode(this.materialFace, this.polyMode);
            GL.Color3(0, 0, 0);

            GL.Begin(PrimitiveType.Triangles);

            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 1, 0);
            GL.Vertex3(1, 1, 0);

            GL.Vertex3(0, 0, 0);
            GL.Vertex3(1, 0, 0);
            GL.Vertex3(1, 1, 0);

            GL.End();
        }
    }
}
