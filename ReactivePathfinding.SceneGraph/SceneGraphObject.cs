using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace ReactivePathfinding.SceneGraph
{
    /// <summary>
    /// Represents any object in the scene, including the camera and agents
    /// </summary>
    public class SceneGraphObject
    {
        private Matrix4 transform;        

        private Vector3 position = Vector3.Zero;        
        private Vector3 forwards = Vector3.UnitY;
        private Vector3 up = Vector3.UnitZ;

        private SceneGraphObject parent;
        private List<SceneGraphObject> children = new List<SceneGraphObject>();
        private List<SceneGraphComponent> components = new List<SceneGraphComponent>();        

        private bool isRoot = false;

        public Matrix4 Transform
        {
            get { return transform; }
            set { transform = value; }
        }

        public Vector3 Forwards
        {
            get { return forwards; }
            set { forwards = value; }
        }
        
        public Vector3 Up
        {
            get { return up; }
            set { up = value; }
        }        

        public Vector3 Position
        {
            get { return position; }
            set { position = value; }
        }        

        public bool IsRoot
        {
            get { return isRoot; }            
        }        

        public List<SceneGraphComponent> Components
        {
            get { return components; }
        }

        public List<SceneGraphObject> Children
        {
            get { return children; }            
        }

        public SceneGraphObject Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        /// <summary>
        /// rotate this object by the specified number of degrees around the z axis in local space
        /// </summary>        
        public void RotateLocalAroundZ(float degrees)
        {
            float theta = MathHelper.DegreesToRadians(degrees);
            Matrix4 rot = Matrix4.Identity;
            rot *= Matrix4.CreateRotationZ(theta);
            Forwards = Vector3.Transform(Forwards, rot).Normalized();
        }

        /// <summary>
        /// Move the object along its forward trajectory by the specified amount.
        /// </summary>        
        public void GoForwards(float mag)
        {
            Position += Forwards * mag;            
        }

        public void AddChild(SceneGraphObject child)
        {
            children.Add(child);
            child.parent = this;
        }

        /// <summary>
        /// Get the first component of a type belonging to a graph object
        /// </summary>        
        public T Getcomponent<T>() where T : SceneGraphComponent
        {
            foreach(SceneGraphComponent component in components)
            {
                if (component.GetType() == typeof(T))
                    return (T)component;
            }
            return null;
        }

        /// <summary>
        /// Create and add a new component by its type
        /// </summary>        
        public T AddComponent<T>() where T : SceneGraphComponent, new()
        {
            T component = new T();
            components.Add(component);
            component.ParentObject = this;
            return component;                
        }

        public void AddComponent(SceneGraphComponent component)
        {
            components.Add(component);            
        }

        public SceneGraphObject()
        {

        }

        public static SceneGraphObject GetRootObject()
        {
            SceneGraphObject o = new SceneGraphObject();
            o.isRoot = true;
            return o;
        }

        /// <summary>
        /// Render this object and all its children until the end of the graph
        /// </summary>
        public void Render()
        {
            foreach (SceneGraphComponent comp in components)
                comp.Render();

            foreach (SceneGraphObject child in children)
                child.Render();
        }

        /// <summary>
        /// Run update logic for all its children until the end of the graph
        /// </summary>
        public void Update(float deltaTime)
        {
            foreach (SceneGraphComponent comp in components)
                comp.Update(deltaTime);

            foreach (SceneGraphObject child in children)
                child.Update(deltaTime);
        }
    }
}
