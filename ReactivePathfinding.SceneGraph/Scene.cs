using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace ReactivePathfinding.SceneGraph
{
    public class Scene
    {
        private List<SceneGraphObject> objects = new List<SceneGraphObject>();
        private SceneGraphObject root = new SceneGraphObject();

        private CameraComponent currentCamera = null;

        public CameraComponent CurrentCamera 
        {
            get { return currentCamera; }
            set { currentCamera = value; }
        }

        public List<SceneGraphObject> Objects
        {
            get { return objects; }            
        }

        public Scene()
        {
            root = SceneGraphObject.GetRootObject();        
        }

        /// <summary>
        /// Get all the components of a given type that are in the current scene
        /// </summary>        
        public List<T> GetAllComponentsByType<T>(SceneGraphObject parent) where T: SceneGraphComponent
        {
            if(parent == null)
                parent = root;

            List<T> components = new List<T>();

            SceneGraphComponent component = parent.Getcomponent<T>();
            if (component != null)
                components.Add((T)component);

            foreach (SceneGraphObject obj in parent.Children)                     
                components.AddRange(GetAllComponentsByType<T>(obj));

            return components;
        }
        public List<T> GetAllComponentsByType<T>() where T: SceneGraphComponent
        {
            return GetAllComponentsByType<T>(null);
        }

        public SceneGraphObject AddNewObject()
        {
            SceneGraphObject obj = new SceneGraphObject();
            objects.Add(obj);
            root.AddChild(obj);
            obj.CurrentScene = this;

            return obj;
        }

        /// <summary>
        /// Add a new scene graph object with the specified component
        /// </summary>        
        public T AddNewObject<T>() where T : SceneGraphComponent, new()
        {
            SceneGraphObject obj = AddNewObject();
            T component = obj.AddComponent<T>();            

            if (component.GetType() == typeof(CameraComponent) && currentCamera == null)
                currentCamera = component as CameraComponent;

            return component;
        }

        /// <summary>
        /// Render the entire scene
        /// </summary>
        public void Render()
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();            

            if(currentCamera != null)
            {                                                        
                Matrix4 t = currentCamera.GetCopyOfTransform();
                GL.MultMatrix(ref t);
                GL.PushMatrix();
            }
            
            root.Render();
        }

        /// <summary>
        /// Update the entire scene
        /// </summary>        
        public void Update(float deltaTime)
        {
            root.Update(deltaTime);
        }
    }
}
