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

        public static void GetCube(float size, Vector4 colour, out float[] vertices, out uint[] triangles, out float[] colors)
        {
            vertices = new float[8 * 3];
            triangles = new uint[6 * 2 * 3];
            colors = new float[8 * 4];
            float halfsize = size / 2f;

            //near bottom left 0
            vertices[0] = -halfsize; vertices[1] = -halfsize; vertices[2] = -halfsize;
            //near bottom right 1
            vertices[3] = -halfsize; vertices[4] = halfsize; vertices[5] = -halfsize;
            //near top left 2
            vertices[6] = -halfsize; vertices[7] = -halfsize; vertices[8] = halfsize;
            //near top right 3
            vertices[9] = -halfsize; vertices[10] = halfsize; vertices[11] = halfsize;

            //far bottom left 4
            vertices[12] = halfsize; vertices[13] = -halfsize; vertices[14] = -halfsize;
            //far bottom right 5
            vertices[15] = halfsize; vertices[16] = halfsize; vertices[17] = -halfsize;
            //far top left 6
            vertices[18] = halfsize; vertices[19] = -halfsize; vertices[20] = halfsize;
            //far top right 7
            vertices[0] = halfsize; vertices[1] = halfsize; vertices[2] = halfsize;

            //front
            triangles[0] = 0; triangles[1] = 1; triangles[2] = 2;
            triangles[3] = 1; triangles[4] = 3; triangles[5] = 2;
            //rear
            triangles[6] = 4; triangles[7] = 5; triangles[8] = 6;
            triangles[9] = 5; triangles[10] = 7; triangles[11] = 6;
            //left
            triangles[12] = 6; triangles[13] = 4; triangles[14] = 0;
            triangles[15] = 0; triangles[16] = 2; triangles[17] = 6;
            //right
            triangles[18] = 7; triangles[19] = 5; triangles[20] = 1;
            triangles[21] = 1; triangles[22] = 3; triangles[23] = 7;
            //top
            triangles[24] = 2; triangles[25] = 3; triangles[26] = 6;
            triangles[27] = 6; triangles[28] = 7; triangles[29] = 3;
            //bottom
            triangles[30] = 0; triangles[31] = 4; triangles[32] = 1;
            triangles[33] = 1; triangles[34] = 5; triangles[35] = 4;

            for(int i =0; i < colors.Length ; i+=8)
            {
                colors[i + 0] = colour.X;
                colors[i + 1] = colour.Y;
                colors[i + 2] = colour.Z;
                colors[i + 3] = colour.W;
            }
        }
    }
}
