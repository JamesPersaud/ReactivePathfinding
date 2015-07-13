using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using ReactivePathfinding.Core;

namespace ReactivePathfinding.SceneGraph
{
    public abstract class SceneGraphComponent : IPosition3F
    {
        private SceneGraphObject parentObject;

        //render data
        protected float[] colors;
        protected float[] vertices;
        protected uint[] triangles;
        private bool renderDataCreated = false;
        private float[] lineVertices = null;
        private float[] lineColors = null;
        private uint[] lineIndices = null;
        private float lineThickness = 10;
        private ushort lineStipple = 43690; // (Creates the line pattern corresponding to binary 1010101010101010)
        private int lineStippleFactor = 1;
        private bool lineDrawing = false;        

        //render settings
        private PolygonMode polyMode = PolygonMode.Line;
        private MaterialFace materialFace = MaterialFace.FrontAndBack;

        public bool LineDrawing
        {
            get { return lineDrawing; }
            set { lineDrawing = value; }
        }

        public int LineStippleFactor
        {
            get { return lineStippleFactor; }
            set { lineStippleFactor = value; }
        }

        public ushort LineStipple
        {
            get { return lineStipple; }
            set { lineStipple = value; }
        }

        public float LineThickness
        {
            get { return lineThickness; }
            set { lineThickness = value; }
        }

        public uint[] LineIndices
        {
            get { return lineIndices; }
            set { lineIndices = value; }
        }

        public float[] LineColors
        {
            get { return lineColors; }
            set { lineColors = value; }
        }

        public float[] LineVertices
        {
            get { return lineVertices; }
            set { lineVertices = value; }
        }

        public float X
        {
            get { return Position.X; }
        }

        public float Y
        {
            get { return Position.Y; }
        }

        public float Z
        {
            get { return Position.Z; }
        }

        public float Distance(IPosition3F other)
        {
            Vector3 v = new Vector3(other.X,other.Y,other.Z);            
            return Vector3.Subtract(Position, v).Length;
        }

        public PolygonMode PolyMode
        {
            get { return polyMode; }
            set { polyMode = value; }
        }        

        public MaterialFace MaterialFace
        {
            get { return materialFace; }
            set { materialFace = value; }
        }

        public float[] Colors
        {
            get { return colors; }
            set { colors = value; }
        }        

        public float[] Vertices
        {
            get { return vertices; }
            set { vertices = value; }
        }        

        public uint[] Triangles
        {
            get { return triangles; }
            set { triangles = value; }
        }

        public bool RenderDataCreated
        {
            get { return renderDataCreated; }
            set { renderDataCreated = value; }
        }

        public SceneGraphObject ParentObject
        {
            get { return parentObject; }
            set { parentObject = value; }
        }

        public Matrix4 Transform
        {
            get { return this.ParentObject.Transform; }            
        }

        public Vector3 Position
        {
            get { return this.ParentObject.Position; }
            set { this.parentObject.Position = value;  }
        }

        public Vector3 Rotation
        {
            get { return this.ParentObject.Rotation; }
            set { this.parentObject.Rotation = value; }
        }

        public Vector3 Up
        {
            get { return this.ParentObject.Up; }
            set { this.parentObject.Up = value; }
        }

        public Vector3 Down
        {
            get { return this.ParentObject.Down; }            
        }

        public Vector3 Left
        {
            get { return this.ParentObject.Left; }            
        }

        public Vector3 Right
        {
            get { return this.ParentObject.Right; }            
        }

        public Vector3 Backwards
        {
            get { return this.ParentObject.Backwards; }            
        }

        public Vector3 Forwards
        {
            get { return this.ParentObject.Forwards; }
            set { this.parentObject.Forwards = value; }
        }

        public Matrix4 GetCopyOfTransform()
        {
            return parentObject.GetCopyOfTransform();
        }

        /// <summary>
        /// Render the component according to the current rendering settings
        /// </summary>
        public void Render()
        {
            if (RenderDataCreated)
            {                
                Matrix4 translate = this.GetCopyOfTransform();
                GL.MultMatrix(ref translate);

                if (lineDrawing)
                {
                    lineDrawing = false;
                    GL.LineWidth(1);
                    GL.LineStipple(ushort.MaxValue, 1);
                }

                GL.PolygonMode(this.materialFace, this.polyMode);
                GL.VertexPointer(3, VertexPointerType.Float, 0, Vertices);
                GL.ColorPointer(4, ColorPointerType.Float, 0, Colors);
                GL.DrawElements(BeginMode.Triangles, Triangles.Length, DrawElementsType.UnsignedInt, Triangles);

                if(lineVertices != null)
                {
                    lineDrawing = true;
                    GL.LineWidth(lineThickness);
                    GL.LineStipple(lineStippleFactor, LineStipple);
                    GL.VertexPointer(3, VertexPointerType.Float, 0, lineVertices);
                    GL.ColorPointer(4, ColorPointerType.Float, 0, lineColors);
                    GL.DrawElements(BeginMode.LineStrip, lineIndices.Length, DrawElementsType.UnsignedInt, lineIndices);                    
                }
            }
        }

        public virtual void Update(float deltaTime)
        {

        }
    }
}
