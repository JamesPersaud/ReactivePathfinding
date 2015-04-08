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
        //Simulation scene graph
        private Scene scene = null;
        private CameraComponent camera = null;
        private HeightmapComponent heightmapComponent = null;

        //opentk control related
        private bool loadedGLContext = false;

        private int glViewportWidth;
        private int glViewportHeight;

        private double Fov = Math.PI / 3;
        private double Znear = 1.0;
        private double Zfar = 400.0;

        //timer related
        private Stopwatch timer = new Stopwatch();
        private int frames = 0;
        private double FPS = 0;
        private double lifetime = 0;

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
        }

        /// <summary>
        /// Update the FPS value
        /// </summary>        
        private void UpdateFPS(double elapsed)
        {
            lifetime += elapsed;
            frames++;

            double seconds = lifetime / 1000.0;
            FPS = frames / seconds;

            lblFPS.Text =  string.Format("{0:0.00}",FPS) + " FPS";
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
            lifetime += millis;
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

                    camera.Position = new Vector3(0, 0, -5f);
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
                UpdateFPS(getElapsedTime());
                RenderOpenGL();
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
    }
}

