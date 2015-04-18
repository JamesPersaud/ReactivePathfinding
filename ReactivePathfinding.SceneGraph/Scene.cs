using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

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

        public SceneGraphObject AddNewObject()
        {
            SceneGraphObject obj = new SceneGraphObject();
            objects.Add(obj);
            root.AddChild(obj);
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
            GL.LoadIdentity();

            if(currentCamera != null)
            {                
                GL.Rotate(currentCamera.Rotation.X, new OpenTK.Vector3d(1, 0, 0));
                GL.Rotate(currentCamera.Rotation.Y, new OpenTK.Vector3d(0, 1, 0));
                GL.Rotate(currentCamera.Rotation.Z, new OpenTK.Vector3d(0, 0, 1));
                GL.Translate(currentCamera.Position);
            }

            root.Render();
        }
    }
}
