﻿using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using ReactivePathfinding.Core;

namespace ReactivePathfinding.SceneGraph
{    
    public class TargetComponent : SceneGraphComponent
    {        
        private Target currentTarget;
        private float lifetime = 0;

        public Target CurrentTarget
        {
            get { return currentTarget; }
            set
            {
                currentTarget = value;
                currentTarget.Position = this;
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
                this.Position = new Vector3(Position.X, Position.Y, z);
                this.ParentObject.RotateLocalAroundZ(180 * deltaTime);
            }

            lifetime += deltaTime;
        }
    }
}
