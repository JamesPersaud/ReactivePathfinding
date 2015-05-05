using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReactivePathfinding.Core;
using System.Diagnostics;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using ReactivePathfinding.SceneGraph;

namespace ReactivePathfinding.WinformsVis
{
    public partial class MainWindow : Form
    {
        //Camera controls
        private bool mouseLeftDown = false;
        private bool mouseRightDown = false;
        private Point lastMousePos = Point.Empty;        

        //Simulation scene graph
        private Scene scene = null;
        private CameraComponent camera = null;
        private HeightmapComponent heightmapComponent = null;

        //opentk control related
        private bool loadedGLContext = false;

        private int glViewportWidth;
        private int glViewportHeight;

        private double Fov = Math.PI / 4;
        private double Znear = 1.0;
        private double Zfar = 400.0;

        //timer related
        private Stopwatch timer = new Stopwatch();
        private int frames = 0;
        private double FPS = 0;
        private double fpsperiod = 0;        
        private double targetFPS = 60;
        private double frameTimer = 0;
        private bool paused = false;

        //memory related
        long totalmemory;
        double memoryCountdown = 0;

        //window display flags
        private bool ShowOutputWindow = true;
        private OutputWindow outputWindow;
        private Version version;

        //Experiment
        Experiment currentExperiment = null;

        public MainWindow()
        {
            InitializeComponent();
            version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            //initialize interface components
            CreateOutputWindow();
            Logging.Instance.Log("Application Started - running version " + version.ToString());            

            //set the mousewheel event
            glControl.MouseWheel += glControl_MouseWheel;
        }        

        /// <summary>
        /// Update the FPS value
        /// </summary>        
        private void UpdateFPS(double elapsed)
        {
            if (paused)
            {
                frames = 0;
                fpsperiod = 1;
                paused = false;
            }

            frames++;

            double seconds = fpsperiod / 1000.0;
            FPS = frames / seconds;

            lblFPS.Text =  string.Format("{0:0.00}",FPS) + " FPS  "+ totalmemory.ToString() + " KB";
            lblFPS.Top = lblFPS.Parent.Height - lblFPS.Height;

            memoryCountdown -= elapsed /1000;
            if(memoryCountdown <= 0)
            {
                totalmemory = GC.GetTotalMemory(false) / 1024;
                memoryCountdown = 2;
            }            
        }

        /// <summary>
        /// Use the timer to get the time elapsed since the last call to this function
        /// </summary>        
        private double getElapsedTime()
        {
            timer.Stop();
            double millis = timer.Elapsed.TotalMilliseconds;
            timer.Reset();
            timer.Start();
            fpsperiod += millis;
            return millis;
        }

        /// <summary>
        /// Should be called whenever something in the experiment changes that relates to the side control panel
        /// e.g. the terrain or agent population
        /// </summary>
        private void UpdateControlPanel()
        {
            if(currentExperiment != null)
            {
                //update experiment info
                lblExperimentName.Text = currentExperiment.Name;
                lblExperimentFilename.Text = currentExperiment.Filename;

                //update terrain info
                if (currentExperiment.CurrentHeightmap != null)
                    txtContext.Text = currentExperiment.CurrentHeightmap.ToString();
            }
            else
            {
                lblExperimentName.Text = "No Experiment";
                lblExperimentFilename.Text = "";
            }
        }

        private void EnableExperimentMenu()
        {
            experimentToolStripMenuItem.Enabled = true;
        }

        private void CreateOutputWindow()
        {
            outputWindow = new OutputWindow();
            outputWindow.FormClosed += outputWindow_FormClosed;            
        }

        void outputWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShowOutputWindow = false;
            outputToolStripMenuItem1.Checked = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //todo according to loaded application preferences
            SetOutputVisibility(true);
        }

        private void ToggleOutputVisibility()
        {
            SetOutputVisibility(!ShowOutputWindow);
        }

        private void SetOutputVisibility(bool show)
        {
            if (outputWindow == null || outputWindow.IsDisposed)
                CreateOutputWindow();

            if (show)
            {
                outputWindow.Show();
                Logging.Instance.Log("Output Window opened");
                this.Focus();
            }
            else
            {
                outputWindow.Hide();
                Logging.Instance.Log("Output Window closed");
            }

            ShowOutputWindow = show;
            outputToolStripMenuItem1.Checked = ShowOutputWindow;
        }                      

        /// <summary>
        /// Show version information
        /// </summary>        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reactive Pathfinding" 
                + Environment.NewLine + Environment.NewLine
                + "Copyright © 2015" + Environment.NewLine 
                + "James Persaud" + Environment.NewLine
                + "The Open University" + Environment.NewLine + Environment.NewLine
                + "Running version " + version.ToString()
                , "About Reactive Pathfinding");
        }

        /// <summary>
        /// show or hide the output window
        /// </summary>  
        private void outputToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToggleOutputVisibility();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }        

        /// <summary>
        /// Start a new experiment
        /// </summary>        
        private void newExperimentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CreateExperimentWindow createDialog = new CreateExperimentWindow())
            {
                if(createDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    currentExperiment = new Experiment(createDialog.Name);                    
                    EnableExperimentMenu();
                    UpdateControlPanel();                    
                }
            }
        }

        private void NewTerrain(HeightMapType type)
        {
            using (NewHeightmapWindow terrainDialog = new NewHeightmapWindow())
            {
                terrainDialog.initialise(currentExperiment.CurrentHeightmapSettings, type);
                if (terrainDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Logging.Instance.Log("Created New Terrain");
                    currentExperiment.CurrentHeightmap = terrainDialog.Map;                    
                    UpdateControlPanel();

                    //init the scene
                    scene = new Scene();
                    camera = scene.AddNewObject<CameraComponent>();
                    heightmapComponent = scene.AddNewObject<HeightmapComponent>();
                    heightmapComponent.Map = currentExperiment.CurrentHeightmap;                    

                    camera.Position = new Vector3(
                        -currentExperiment.CurrentHeightmap.Settings.MapWidth/2,
                        -currentExperiment.CurrentHeightmap.Settings.MapHeight/ 2
                        , -50f);
                }
            }
        }

        private void newRandomTerrainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTerrain(HeightMapType.PROCEDURAL);
        }

        private void flatPlaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTerrain(HeightMapType.PLANE);
        }

        private void conicalHillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTerrain(HeightMapType.CONICAL_HILL);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// When the OpenTK control is loaded
        /// </summary>        
        private void glControl_Load(object sender, EventArgs e)
        {
            loadedGLContext = true;

            Application.Idle += Application_Idle;
            glControl.Paint += glControl_Paint;
            glControl.Resize += glControl_Resize;

            //GL setup
            GL.Enable(EnableCap.DepthTest);
            GL.EnableClientState(EnableCap.VertexArray);
            GL.EnableClientState(EnableCap.ColorArray);

            SetupOpenGLViewport();
        }

        /// <summary>
        /// Set up the viewport for perspective 3D rendering
        /// </summary>
        private void SetupOpenGLViewport()
        {
            glViewportWidth = glControl.Width;
            glViewportHeight = glControl.Height;

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.Viewport(0, 0, glViewportWidth, glViewportHeight);
            double aspect = (double)glViewportWidth / (double)glViewportHeight;

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            //This goes the GL equivalent of gluPerspective
            double ymax = Znear * Math.Tan(Fov);
            double ymin = -ymax;
            double xmin = ymin * aspect;
            double xmax = ymax * aspect;

            GL.Frustum(xmin, xmax, ymin, ymax, Znear, Zfar);
            // end perspective

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }

        private void glControl_Resize(object sender, EventArgs e)
        {
            SetupOpenGLViewport();
            glControl.Invalidate();
        }        

        /// <summary>
        /// When the application is idle, redraw and process the timer
        /// </summary>        
        private void Application_Idle(object sender, EventArgs e)
        {
            while(glControl.IsIdle)
            {
                double elapsed = getElapsedTime();
                double elapsedSeconds = elapsed / 1000;

                frameTimer -= elapsedSeconds;

                if(frameTimer <= 0)
                {
                    UpdateFPS(elapsed);
                    RenderOpenGL();
                    frameTimer = 1 / targetFPS;
                }                                                                
            }
        }

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            RenderOpenGL();
        }

        /// <summary>
        /// 3D drawing entry point
        /// </summary>
        private void RenderOpenGL()
        {
            if (loadedGLContext)
            {
                //clear both color and depth buffers
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                GL.ClearColor(Color.CornflowerBlue);

                //draw the scene                
                if(scene != null)
                    scene.Render();

                glControl.SwapBuffers();
            }
        }

        private void resetMouseScrolling()
        {
            mouseLeftDown = false;
            mouseRightDown = false;
            lastMousePos = Point.Empty;
        }

        private void glControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                mouseLeftDown = true;
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                mouseRightDown = true;
        }        

        private void glControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (camera != null && lastMousePos != Point.Empty)
            {
                int dx = e.Location.X - lastMousePos.X;
                int dy = e.Location.Y - lastMousePos.Y;

                if (mouseLeftDown)
                {                    
                    camera.Position = new Vector3(camera.Position.X + dx, camera.Position.Y - dy, camera.Position.Z);
                }
                if(mouseRightDown)
                {
                    camera.Rotation = new Vector3(camera.Rotation.X + dy, camera.Rotation.Y, camera.Rotation.Z + dx);
                }
            }

            lastMousePos = e.Location;
        }

        void glControl_MouseWheel(object sender, MouseEventArgs e)
        {
            float dz = e.Delta / 100f;

            if (camera != null)
                camera.Position = new Vector3(camera.Position.X, camera.Position.Y, camera.Position.Z - dz);
        }

        private void glControl_MouseUp(object sender, MouseEventArgs e)
        {
            resetMouseScrolling();
        }

        private void glControl_MouseLeave(object sender, EventArgs e)
        {
            resetMouseScrolling();
        }

        private void glControl_MouseEnter(object sender, EventArgs e)
        {
            resetMouseScrolling();
        }        
    }
}

