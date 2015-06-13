using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace ReactivePathfinding.SceneGraph
{
    public abstract class SceneGraphComponent
    {
        private SceneGraphObject parentObject;

        public SceneGraphObject ParentObject
        {
            get { return parentObject; }
            set { parentObject = value; }
        }

        public Vector3 Position
        {
            get { return this.ParentObject.Position; }
            set { this.parentObject.Position = value;  }
        }        

        public Vector3 Up
        {
            get { return this.ParentObject.Up; }
            set { this.parentObject.Up = value; }
        }

        public Vector3 Forwards
        {
            get { return this.ParentObject.Forwards; }
            set { this.parentObject.Forwards = value; }
        }

        public virtual void Render()
        {

        }

        public virtual void Update(float deltaTime)
        {

        }
    }
}
