using System;
using System.Collections.Generic;
using OpenTK;
using ReactivePathfinding.Core;

namespace ReactivePathfinding.SceneGraph
{
    public enum SceneGraphMovementDirection
    {
        LEFT,UP,RIGHT,DOWN,
        FORWARDS, BACKWARDS
    }

    /// <summary>
    /// Represents any object in the scene, including the camera and agents
    /// </summary>
    public class SceneGraphObject
    {
        public static bool DEBUG_ROTATION_AND_TRANSLATION = false;

        private Matrix4 transform;
        private bool transformDirty = true;

        private Vector3 rotation = Vector3.Zero;        
        private Vector3 position = Vector3.Zero;        
        private Vector3 forwards = Vector3.UnitX;
        private Vector3 up = Vector3.UnitZ;

        private Scene currentScene;        
        private SceneGraphObject parent;
        private List<SceneGraphObject> children = new List<SceneGraphObject>();
        private List<SceneGraphComponent> components = new List<SceneGraphComponent>();

        private bool isRoot = false;

        public Vector3 Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                rotation = value;
                transformDirty = true;
            }
        }

        public Scene CurrentScene
        {
            get { return currentScene; }
            set { currentScene = value; }
        }

        public Matrix4 Transform
        {
            get
            {
                if(transformDirty)
                {                    
                    Matrix4 roll = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Rotation.X));
                    Matrix4 pitch = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Rotation.Y));
                    Matrix4 yaw = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Rotation.Z));                    
                    Matrix4 translate = Matrix4.CreateTranslation(position);

                    transform = yaw * pitch * roll * translate;
                }

                return transform;
            }            
        }

        public Vector3 Forwards
        {
            get { return forwards; }
            set { forwards = value; }
        }

        public Vector3 Backwards
        {
            get
            {
                return -forwards;
            }
        }
        
        public Vector3 Up
        {
            get { return up; }
            set { up = value; }
        }

        public Vector3 Down
        {
            get
            {
                return -up;
            }
        }

        public Vector3 Left
        {
            get
            {
                return Vector3.Cross(Up, Forwards);
            }
        }

        public Vector3 Right
        {
            get
            {
                return -Vector3.Cross(Up, Forwards);
            }
        }

        public Vector3 Position
        {
            get
            {
                return position;
                transformDirty = true;
            }
            set
            {
                position = value;
            }
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

        public Matrix4 GetCopyOfTransform()
        {
            return new Matrix4(Transform.Row0, Transform.Row1, Transform.Row2, Transform.Row3);
        }

        private void Debug(string s)
        {
            if (DEBUG_ROTATION_AND_TRANSLATION)
                Logging.Instance.Log(s);
        }

        /// <summary>
        /// rotate this object by the specified number of degrees around the z axis in local space
        /// </summary>        
        public void RotateLocalAroundZ(float degrees)
        {
            float theta = MathHelper.DegreesToRadians(degrees);            
            Matrix4 rot = Matrix4.Identity * Matrix4.CreateRotationZ(theta);

            Debug("About to rotate " + Forwards.ToString() + " by " + degrees.ToString() + " (" + theta.ToString() + ")");
            Forwards = Vector3.Transform(Forwards, rot).Normalized();
            Debug("New Vector " + Forwards.ToString());

            float newrotation = this.rotation.Z + degrees;
            
            while (newrotation < 0) newrotation += 360;
            while (newrotation > 360) newrotation -= 360;

            this.rotation = new Vector3(this.rotation.X, this.rotation.Y, newrotation);
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
