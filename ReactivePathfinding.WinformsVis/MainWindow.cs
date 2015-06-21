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
        //simulation debug
        private bool debugMode = true;
        private bool cleverAgents = false;
        private int numAgents = 50;
        private bool debugPause = false;
        private float stepSize = 0.25f;

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

            RunInitialTests();
        }

        /// <summary>
        /// Use this method to run any tests of new classes 
        /// 
        /// TODO - proper unit tests
        /// 
        /// </summary>
        private void RunInitialTests()
        {
            //test genomes

            PRNG rng = new PRNG();

            Genome genome1 = new BoundaryFloatGenome(8, 0, 1, rng); genome1.Name = "genome1";
            Genome genome2 = new BoundaryFloatGenome(8, 0, 1, rng); genome2.Name = "genome2";

            Logging.Instance.Log(genome1.ToString());
            Logging.Instance.Log(genome2.ToString());

            Logging.Instance.Log("mutating both");

            genome1.Mutate(0, 0, 1);
            genome2.Mutate(0, 0, 1);

            Logging.Instance.Log(genome1.ToString());
            Logging.Instance.Log(genome2.ToString());

            Logging.Instance.Log("cloning");

            Genome genome3 = genome1.Clone(); genome3.Name = "genome3";
            Genome genome4 = genome2.Clone(); genome4.Name = "genome4";

            Logging.Instance.Log(genome3.ToString());
            Logging.Instance.Log(genome4.ToString());

            Logging.Instance.Log("crossing over");            

            genome3.Crossover(0, 0, 1, genome4);

            Logging.Instance.Log(genome1.ToString());
            Logging.Instance.Log(genome2.ToString());

            Logging.Instance.Log(genome3.ToString());
            Logging.Instance.Log(genome4.ToString());            

            //testing sigmoid activation function                                                                        
            testSigmoid(-1000f);
            testSigmoid(-100f);
            testSigmoid(-10f);
            testSigmoid(-5f);            
            testSigmoid(-1f);            
            testSigmoid(-0.5f);            
            testSigmoid(0);            
            testSigmoid(0.5f);            
            testSigmoid(1);            
            testSigmoid(5f);
            testSigmoid(10f);
            testSigmoid(100f);
            testSigmoid(1000f);

            //vector maths
            SceneGraphObject o = new SceneGraphObject();
            Logging.Instance.Log("Up " + o.Up.ToString());
            Logging.Instance.Log("Down " + o.Down.ToString());
            Logging.Instance.Log("Left " + o.Left.ToString());
            Logging.Instance.Log("Right " + o.Right.ToString());
            Logging.Instance.Log("Forwards " + o.Forwards.ToString());
            Logging.Instance.Log("Backwards " + o.Backwards.ToString());
        }

        private void testSigmoid(float i)
        {
            try
            {
                float s = Maths.Sigmoid(i);
                Logging.Instance.Log("Sigmoid of " + i.ToString() + " is " + s.ToString());
            }
            catch(Exception ex)
            {
                Logging.Instance.Log(" Can't do sigmoid of " + i.ToString() + " " + ex.Message);
            }
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

                    if(debugMode)
                    {                        
                        //Scene testing
                        PRNG rng = new PRNG();

                        Target t = new Target(1, currentExperiment.CurrentHeightmap.Settings.MapWidth / 2, EmitterTypes.INVERSE_SQUARE);
                        t.CurrentExperiment = currentExperiment;

                        TargetComponent tcomp = scene.AddNewObject<TargetComponent>();
                        tcomp.CurrentTarget = t;

                        tcomp.Position = new Vector3(
                            currentExperiment.CurrentHeightmapSettings.MapWidth / 2,
                            currentExperiment.CurrentHeightmapSettings.MapWidth / 2, 
                            currentExperiment.CurrentHeightmap.GetSceneHeight(
                                currentExperiment.CurrentHeightmapSettings.MapWidth / 2,
                                currentExperiment.CurrentHeightmapSettings.MapWidth / 2)
                        );

                        for (int agentindex = 1; agentindex < numAgents + 1; agentindex++)
                        {
                            Agent a = new Agent();
                            a.Name = "Agent" + agentindex.ToString();
                            a.CurrentExperiment = currentExperiment;

                            Sensor leftsensor = new TargetSensor(new RadialPoint(90f, 1f)); leftsensor.Name = "Sleft";
                            Sensor rightsensor = new TargetSensor(new RadialPoint(270f, 1f)); rightsensor.Name = "Sright";
                            Sensor forwardsensor = new TargetSensor(new RadialPoint(0f, 1f)); forwardsensor.Name = "Sfront";
                            Sensor frontleftsensor = new TargetSensor(new RadialPoint(45f, 1f)); forwardsensor.Name = "Sfrontleft";
                            Sensor frontrightsensor = new TargetSensor(new RadialPoint(315f, 1f)); forwardsensor.Name = "Sfrontright";
                            Sensor backleftsensor = new TargetSensor(new RadialPoint(135f, 1f)); forwardsensor.Name = "Sbackleft";
                            Sensor backtrightsensor = new TargetSensor(new RadialPoint(225f, 1f)); forwardsensor.Name = "Sbackright";

                            Actuator leftmotor = new MotorActuator(MotorTypes.LEFT); leftmotor.Name = "Mleft";
                            Actuator rightmotor = new MotorActuator(MotorTypes.RIGHT); rightmotor.Name = "Mright";

                            a.AddSensor(leftsensor);
                            a.AddSensor(rightsensor);
                            a.AddSensor(forwardsensor);
                            a.AddSensor(frontleftsensor);
                            a.AddSensor(frontrightsensor);
                            a.AddSensor(backleftsensor);
                            a.AddSensor(backtrightsensor);

                            a.AddActuator(leftmotor);
                            a.AddActuator(rightmotor);                            

                            Connection c1 = new Connection(leftsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c1.Name = "Sleft_excites_Mright";
                            Connection c2 = new Connection(rightsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c2.Name = "Sright_excites_Mleft";
                            Connection c3 = new Connection(forwardsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c3.Name = "Sfront_excites_Mleft";
                            Connection c4 = new Connection(forwardsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c4.Name = "Sfront_excites_Mright";
                            Connection c5 = new Connection(frontleftsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c5.Name = "Sfrontleft_excites_Mright";
                            Connection c6 = new Connection(frontrightsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c6.Name = "Sfrontright_excites_Mleft";
                            Connection c7 = new Connection(backleftsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c7.Name = "Sbackleft_excites_Mright";
                            Connection c8 = new Connection(backtrightsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c8.Name = "Sbackright_excites_Mleft";

                            if(!cleverAgents)
                            {
                                Connection c9 = new Connection(leftsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c9.Name = "Sleft_excites_Mleft";
                                Connection c10 = new Connection(rightsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c10.Name = "Sright_excites_Mright";
                                Connection c11 = new Connection(frontleftsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c11.Name = "Sfrontleft_excites_Mleft";
                                Connection c12 = new Connection(frontrightsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c12.Name = "Sfrontright_excites_Mright";
                                Connection c13 = new Connection(backleftsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c13.Name = "Sbackleft_excites_Mleft";
                                Connection c14 = new Connection(backtrightsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c14.Name = "Sbackright_excites_Mright";
                            }

                            BoundaryFloatGenome g;

                            if(cleverAgents)
                                g = new BoundaryFloatGenome(8, 1f, 1f, rng);
                            else
                                g = new BoundaryFloatGenome(14, -1f, 1f, rng);

                            a.WeightGenome = g;

                            Logging.Instance.Log(a.Name + ": Assigning genome " + g.ToString() + " to agent");
                            Logging.Instance.Log(a.Name + ": Weights set to " + c1.ToString() + " " + c2.ToString());
                            
                            AgentComponent acomp = scene.AddNewObject<AgentComponent>();
                            acomp.CurrentAgent = a;

                            float agentx = rng.GetFloat(0, currentExperiment.CurrentHeightmap.Settings.MapWidth);
                            float agenty = rng.GetFloat(0, currentExperiment.CurrentHeightmap.Settings.MapWidth);

                            acomp.Position = new Vector3(agentx, agenty, currentExperiment.CurrentHeightmap.GetSceneHeight(agentx, agenty)); 
                        }                                                                                                                                                
                    }                                        
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
            GL.DepthFunc(DepthFunction.Less);
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
                
                if(scene != null && !debugPause)
                {
                    scene.Update((float)elapsedSeconds);
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

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {            
        }

        private void glControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (debugPause && e.KeyCode == Keys.S && scene != null)
            {
                scene.Update(stepSize);
            }
        }        
    }
}




