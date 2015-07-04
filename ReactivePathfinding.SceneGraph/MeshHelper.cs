using System;
using OpenTK;

namespace ReactivePathfinding.SceneGraph
{
    /// <summary>
    /// Static methods to generate a variety of shapes of mesh used in the project
    /// </summary>
    public class MeshHelper
    {
        public static float HEIGHT_EXAGGERATION_FACTOR = 8;

        public static void GetWheel(float size, Vector4 colour, out float[] vertices, out uint[] triangles, out float[] colors)
        {
            //size is the agent diameter            

            float quatersize = size / 4f;
            float eighthsize = size / 8f;

            vertices = new float[] {
                //cube verts
                -quatersize,  eighthsize,  quatersize, // vertex[0]
			    quatersize,  eighthsize,  quatersize, // vertex[1]
			    quatersize, -eighthsize,  quatersize, // vertex[2]
			    -quatersize, -eighthsize,  quatersize, // vertex[3]
			    -quatersize,  eighthsize, -quatersize, // vertex[4]
			    quatersize,  eighthsize, -quatersize, // vertex[5]
			    quatersize, -eighthsize, -quatersize, // vertex[6]
			    -quatersize, -eighthsize, -quatersize, // vertex[7]
            };

            triangles = new uint[] {
                //cube
                1, 0, 2, // front
			    3, 2, 0,
			    6, 4, 5, // back
			    4, 6, 7,
			    4, 7, 0, // left
			    7, 3, 0,
			    1, 2, 5, //right
			    2, 6, 5,
			    0, 1, 5, // top
			    0, 5, 4,
			    2, 3, 6, // bottom
			    3, 7, 6,                
            };

            colors = new float[8 * 4];

            for (int i = 0; i < colors.Length; i += 4)
            {
                colors[i + 0] = colour.X;
                colors[i + 1] = colour.Y;
                colors[i + 2] = colour.Z;
                colors[i + 3] = colour.W;
            }
        }

        public static void GetAgent(float size, Vector4 bodycolour, Vector4 headcolour, out float[] vertices, out uint[] triangles, out float[] colors)
        {
            //size is the agent diameter

            float halfsize = size / 2f;
            float quatersize = halfsize / 2f;

            vertices = new float[] {
                //cubeoid verts
                -halfsize,  quatersize,  quatersize, // vertex[0]
			    halfsize,  quatersize,  quatersize, // vertex[1]      right far top
			    halfsize, -quatersize,  quatersize, // vertex[2]      right near top
			    -halfsize, -quatersize,  quatersize, // vertex[3]
			    -halfsize,  quatersize, -quatersize, // vertex[4]
			    halfsize,  quatersize, -quatersize, // vertex[5]      right far bottom
			    halfsize, -quatersize, -quatersize, // vertex[6]      right near bottom
			    -halfsize, -quatersize, -quatersize, // vertex[7]
                //beak vert (initial forwards is unit x)
                halfsize*2, 0,0 // vertex [8]
            };

            triangles = new uint[] {
                //cube
                1, 0, 2, // front
			    3, 2, 0,
			    6, 4, 5, // back
			    4, 6, 7,
			    4, 7, 0, // left
			    7, 3, 0,
			    1, 2, 5, //right (actual front)
			    2, 6, 5,
			    0, 1, 5, // top
			    0, 5, 4,
			    2, 3, 6, // bottom
			    3, 7, 6,
                //point
                1,8,2,
                5,8,6,
                2,8,6,
                1,8,5,
            };

            colors = new float[9 * 4];

            //colour body
            for (int i = 0; i < 32; i += 4)
            {                                                                
                colors[i + 0] = bodycolour.X;
                colors[i + 1] = bodycolour.Y;
                colors[i + 2] = bodycolour.Z;
                colors[i + 3] = bodycolour.W;
            }

            colors[32] = headcolour.X;
            colors[33] = headcolour.Y;
            colors[34] = headcolour.Z;
            colors[35] = headcolour.W;
        }

        public static void GetCube(float size, Vector4 colour, out float[] vertices, out uint[] triangles, out float[] colors)
        {
            float halfsize = size / 2f;

            vertices = new float[] {
                //cube verts
                -halfsize,  halfsize,  halfsize, // vertex[0]
			    halfsize,  halfsize,  halfsize, // vertex[1]
			    halfsize, -halfsize,  halfsize, // vertex[2]
			    -halfsize, -halfsize,  halfsize, // vertex[3]
			    -halfsize,  halfsize, -halfsize, // vertex[4]
			    halfsize,  halfsize, -halfsize, // vertex[5]
			    halfsize, -halfsize, -halfsize, // vertex[6]
			    -halfsize, -halfsize, -halfsize, // vertex[7]                
            };

            triangles = new uint[] {
                //cube
                1, 0, 2, // front
			    3, 2, 0,
			    6, 4, 5, // back
			    4, 6, 7,
			    4, 7, 0, // left
			    7, 3, 0,
			    1, 2, 5, //right
			    2, 6, 5,
			    0, 1, 5, // top
			    0, 5, 4,
			    2, 3, 6, // bottom
			    3, 7, 6,                
            };            
            
            colors = new float[8 * 4];                        

            for(int i =0; i < colors.Length ; i+=4)
            {
                colors[i + 0] = colour.X;
                colors[i + 1] = colour.Y;
                colors[i + 2] = colour.Z;
                colors[i + 3] = colour.W;
            }
        }
    }
}
