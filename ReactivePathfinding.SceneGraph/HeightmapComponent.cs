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

        //colours
        private List<KeyValuePair<float, Vector4>> ColourTemplates;

        //render data
        private float[] colors;        
        private float[] vertices;
        private uint[] triangles;
        private bool verticesCreated = false;

        public Heightmap Map
        {
            get { return map; }
            set
            {
                map = value;
                CreateRenderData();
            }
        }

        /// <summary>
        /// Set up the bands of colour used to signify height ranges in this visualisation
        /// </summary>
        private void InitialiseColourTemplates()
        {
            ColourTemplates = new List<KeyValuePair<float, Vector4>>();

            //Lowest level (grass)
            ColourTemplates.Add(new KeyValuePair<float,Vector4>(0.5f,
                new Vector4(0.1f,0.4f,0.1f,1.0f)));
            //Elevated level (hills)
            ColourTemplates.Add(new KeyValuePair<float, Vector4>(0.7f,
                new Vector4(0.6f, 0.3f, 0.1f, 1.0f)));
            //High level (mountains)
            ColourTemplates.Add(new KeyValuePair<float, Vector4>(0.9f,
                new Vector4(0.6f, 0.6f, 0.6f, 1.0f)));
            //Highest level (peaks)
            ColourTemplates.Add(new KeyValuePair<float, Vector4>(2f,
                new Vector4(0.9f, 0.9f, 0.9f, 1.0f)));

        }

        /// <summary>
        /// Create vertex buffers from the heightmap data
        /// It's ok for this to be slow because it's only done once
        /// </summary>
        private void CreateRenderData()
        {
            int w = Map.Settings.MapWidth;
            int h = Map.Settings.MapHeight;
            
            vertices = new float[w * h * 3];
            colors = new float[w * h * 4];
            triangles = new uint[(w-1) * (h-1) * 6];

            int triangle = 0;
            for (int x = 0; x < Map.Settings.MapWidth; x++)
            {
                for (int y = 0; y < Map.Settings.MapHeight; y++)
                {
                    int index = y * w + x;                    
                    float z = (Map.GetHeight(x, y) + 1f) /2f; 

                    //Create the vertex buffer by reading the heights
                    vertices[index * 3 + 0] = x; //x
                    vertices[index * 3 + 1] = y; //y
                    vertices[index * 3 + 2] = z * 7; //z * 7 - helps the visualization

                    //Create the color buffer by assigning the appropriate colour to each vertex
                    for (int i = 0; i < ColourTemplates.Count; i++)
                    {
                        if (z <= ColourTemplates[i].Key)
                        {
                            Vector4 color = ColourTemplates[i].Value;
                            colors[index * 4 + 0] = color.X; //r
                            colors[index * 4 + 1] = color.Y; //g
                            colors[index * 4 + 2] = color.Z; //b
                            colors[index * 4 + 3] = color.W; //a
                            break;
                        }
                    }

                    //Create the triangle buffer by specifying 3 vertices for each triangle
                    //Two triangles per vertex, except for the bottom and right edges
                    if (x < w - 1 && y < h - 1)
                    {
                        if (index % 2 == 0)
                        {
                            triangles[triangle + 0] = (uint)index;
                            triangles[triangle + 1] = (uint)(index + w);
                            triangles[triangle + 2] = (uint)(index + w + 1);

                            triangles[triangle + 3] = (uint)index;
                            triangles[triangle + 4] = (uint)(index + 1);
                            triangles[triangle + 5] = (uint)(index + w + 1);
                        }
                        else // draw alternating patterns of triangles, makes for refer diagonal patterns in the render
                        {
                            triangles[triangle + 0] = (uint)index;
                            triangles[triangle + 1] = (uint)(index + 1);
                            triangles[triangle + 2] = (uint)(index + w);

                            triangles[triangle + 3] = (uint)(index + w);
                            triangles[triangle + 4] = (uint)(index + 1);
                            triangles[triangle + 5] = (uint)(index + w + 1);

                        }

                        triangle += 6;
                    }                    
                }
            }

            verticesCreated = true;            
        }

        /// <summary>
        /// Render the heightmap according to the current rendering settings
        /// </summary>
        public override void Render()
        {
            if (verticesCreated)
            {                
                GL.PolygonMode(this.materialFace, this.polyMode);
                GL.VertexPointer(3, VertexPointerType.Float, 0, vertices);
                GL.ColorPointer(4, ColorPointerType.Float, 0, colors);
                GL.DrawElements(BeginMode.Triangles, triangles.Length, DrawElementsType.UnsignedInt, triangles);
            }
        }

        public HeightmapComponent()
        {
            InitialiseColourTemplates();
        }
    }
}

