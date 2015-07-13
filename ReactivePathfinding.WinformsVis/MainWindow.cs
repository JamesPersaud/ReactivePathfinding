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
using System.IO;

namespace ReactivePathfinding.WinformsVis
{    
    public enum SimulationControlStates
    {
        READY,
        PLAY,
        PAUSE,        
        STOP,        
    }

    public partial class MainWindow : Form
    {                
        //simulation control
        public SimulationControlStates SimState = SimulationControlStates.STOP;        

        //warning/help labels        
        private Label lblWarnNoExperiment = new Label();
        private Label lblWarnNoHeightmap = new Label();
        private Label lblWarnNoAgent = new Label();
        private Label lblWarnNoStart = new Label();
        private Label lblWarnNoTarget = new Label();
        private Label lblWarnNoFitness = new Label();
        private Label lblWarnNoPath = new Label();

        //warning label properties
        private const int LABEL_GAP = 8;
        private const int LABEL_HEIGHT = 24;

        //simulation debug
        private bool debugMode = false;
        private bool cleverAgents = false;
        private int numAgents = 50;
        private bool debugPause = false;
        private float stepSize = 0.25f;
        private float dtLast = 0;
        private float dtMin = 100000;
        private float dtMax = 0;
        private double msSinceLastStep = 0;

        //projection/unprojection help
        private Matrix4 projection_matrix;

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
        private bool timerPaused = false;

        //memory related
        long totalmemory;
        double memoryCountdown = 0;

        //window display flags
        private bool ShowOutputWindow = true;
        private OutputWindow outputWindow;
        private Version version;

        //Experiment
        Experiment currentExperiment = null;        

        private void initWarningLabels()
        {            
            lblWarnNoAgent.Height = LABEL_HEIGHT;
            lblWarnNoExperiment.Height = LABEL_HEIGHT;
            lblWarnNoFitness.Height = LABEL_HEIGHT;
            lblWarnNoHeightmap.Height = LABEL_HEIGHT;
            lblWarnNoStart.Height = LABEL_HEIGHT;
            lblWarnNoTarget.Height = LABEL_HEIGHT;
            lblWarnNoPath.Height = LABEL_HEIGHT;

            lblWarnNoAgent.Text = "Agent topology and genome undefined";
            lblWarnNoExperiment.Text = "No current experiment";
            lblWarnNoFitness.Text = "Fitness criteria and function undefined";
            lblWarnNoHeightmap.Text = "Heightmap undefined";
            lblWarnNoStart.Text = "Start location undefined";
            lblWarnNoTarget.Text = "Target undefined";
            lblWarnNoPath.Text = "Best path undefined";

            lblWarnNoAgent.BackColor = Color.Black;
            lblWarnNoExperiment.BackColor = Color.Black;
            lblWarnNoFitness.BackColor = Color.Black;
            lblWarnNoHeightmap.BackColor = Color.Black;
            lblWarnNoStart.BackColor = Color.Black;
            lblWarnNoTarget.BackColor = Color.Black;
            lblWarnNoPath.BackColor = Color.Black;

            lblWarnNoAgent.ForeColor = Color.White;
            lblWarnNoExperiment.ForeColor = Color.White;
            lblWarnNoFitness.ForeColor = Color.White;
            lblWarnNoHeightmap.ForeColor = Color.White;
            lblWarnNoStart.ForeColor = Color.White;
            lblWarnNoTarget.ForeColor = Color.White;
            lblWarnNoPath.ForeColor = Color.White;

            lblWarnNoAgent.AutoSize = true;
            lblWarnNoExperiment.AutoSize = true;
            lblWarnNoFitness.AutoSize = true;
            lblWarnNoHeightmap.AutoSize = true;
            lblWarnNoStart.AutoSize = true;
            lblWarnNoTarget.AutoSize = true;
            lblWarnNoPath.AutoSize = true;
        }

        /// <summary>
        /// Show the appropriate warning/help labels
        /// </summary>
        private void setWarningLabels()
        {
            int labelcount = 0;

            //no experiment
            if(currentExperiment == null)
            {
                if (!glControl.Controls.Contains(lblWarnNoExperiment))                
                    glControl.Controls.Add(lblWarnNoExperiment);                    
                
                lblWarnNoExperiment.Top = getNextLabelPosition(ref labelcount);
            }            
            else
            {
                if (glControl.Controls.Contains(lblWarnNoExperiment))
                    glControl.Controls.Remove(lblWarnNoExperiment);

                //no heightmap
                if(currentExperiment.CurrentHeightmap == null)
                {
                    if(!glControl.Controls.Contains(lblWarnNoHeightmap))                    
                        glControl.Controls.Add(lblWarnNoHeightmap);

                    lblWarnNoHeightmap.Top = getNextLabelPosition(ref labelcount);
                }
                else
                {
                    if (glControl.Controls.Contains(lblWarnNoHeightmap))
                        glControl.Controls.Remove(lblWarnNoHeightmap);
                }

                //no agent
                if (currentExperiment.CurrentAgentTopology == null)
                {
                    if (!glControl.Controls.Contains(lblWarnNoAgent))
                        glControl.Controls.Add(lblWarnNoAgent);

                    lblWarnNoAgent.Top = getNextLabelPosition(ref labelcount);
                }
                else
                {
                    if (glControl.Controls.Contains(lblWarnNoAgent))
                        glControl.Controls.Remove(lblWarnNoAgent);
                }

                //no start position set                
                if (currentExperiment.CurrentStartpoint == null)
                {
                    if (!glControl.Controls.Contains(lblWarnNoStart))
                        glControl.Controls.Add(lblWarnNoStart);

                    lblWarnNoStart.Top = getNextLabelPosition(ref labelcount);
                }
                else
                {
                    if (glControl.Controls.Contains(lblWarnNoStart))
                        glControl.Controls.Remove(lblWarnNoStart);
                }

                //no target set
                if (currentExperiment.CurrentTarget == null)
                {
                    if (!glControl.Controls.Contains(lblWarnNoTarget))
                        glControl.Controls.Add(lblWarnNoTarget);

                    lblWarnNoTarget.Top = getNextLabelPosition(ref labelcount);
                }
                else
                {
                    if (glControl.Controls.Contains(lblWarnNoTarget))
                        glControl.Controls.Remove(lblWarnNoTarget);
                }

                //no fitness function
                if (currentExperiment.CurrentFitnessFunction == null)
                {
                    if (!glControl.Controls.Contains(lblWarnNoFitness))
                        glControl.Controls.Add(lblWarnNoFitness);

                    lblWarnNoFitness.Top = getNextLabelPosition(ref labelcount);
                }
                else
                {
                    if (glControl.Controls.Contains(lblWarnNoFitness))
                        glControl.Controls.Remove(lblWarnNoFitness);
                }

                //no best path
                if (currentExperiment.BestPath == null)
                {
                    if (!glControl.Controls.Contains(lblWarnNoPath))
                        glControl.Controls.Add(lblWarnNoPath);

                    lblWarnNoPath.Top = getNextLabelPosition(ref labelcount);
                }
                else
                {
                    if (glControl.Controls.Contains(lblWarnNoPath))
                        glControl.Controls.Remove(lblWarnNoPath);
                }
            }

            if (labelcount == 0 && SimState != SimulationControlStates.PLAY && SimState != SimulationControlStates.PAUSE)
                SimState = SimulationControlStates.READY;

            if (currentExperiment != null && currentExperiment.CurrentTarget != null && currentExperiment.CurrentStartpoint != null)            
                calculateBestPathToolStripMenuItem.Enabled = true;            
            else            
                calculateBestPathToolStripMenuItem.Enabled = false;            
        }

        /// <summary>
        /// get the next position at which to draw a warning/help label
        /// </summary>        
        private int getNextLabelPosition(ref int count)
        {
            return LABEL_GAP + ((LABEL_HEIGHT + LABEL_GAP) * count++);
        }

        public MainWindow()
        {
            InitializeComponent();
            version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            //initialize interface components
            CreateOutputWindow();
            Logging.Instance.Log("Application Started - running version " + version.ToString());

            //set the mousewheel event
            glControl.MouseWheel += glControl_MouseWheel;

            //set control buttons click events
            icnPlay.Click += icnPlay_Click;
            icnPause.Click += icnPause_Click;
            icnSlower.Click += icnSlower_Click;
            icnFaster.Click += icnFaster_Click;
            icnStop.Click += icnStop_Click;

            //set control buttons mouse events
            icnPlay.MouseEnter += SimControlMouseEnter;
            icnPause.MouseEnter += SimControlMouseEnter;
            icnSlower.MouseEnter += SimControlMouseEnter;
            icnFaster.MouseEnter += SimControlMouseEnter;
            icnStop.MouseEnter += SimControlMouseEnter;
            icnPlay.MouseLeave += SimControlMouseLeave;
            icnPause.MouseLeave += SimControlMouseLeave;
            icnSlower.MouseLeave += SimControlMouseLeave;
            icnFaster.MouseLeave += SimControlMouseLeave;
            icnStop.MouseLeave += SimControlMouseLeave;

            //set visibility
            RunInitialTests();
            initWarningLabels();
            setWarningLabels();

            //bind dropdowns
            ddlFitness.DataSource = FitnessFunction.GetStandardFunctions();
            ddlFitness.SelectedIndex = -1;

            HideExperiment();
        }

        void SimControlMouseLeave(object sender, EventArgs e)
        {
            if (sender == icnPlay && SimState == SimulationControlStates.PLAY)
                return;

            if (sender == icnPause && SimState == SimulationControlStates.PAUSE)
                return;

            ((PictureBox)sender).BackColor = Color.White;
        }        

        void SimControlMouseEnter(object sender, EventArgs e)
        {
            if (sender == icnPlay && SimState == SimulationControlStates.PLAY)
                return;

            if (sender == icnPause && SimState == SimulationControlStates.PAUSE)
                return;

            ((PictureBox)sender).BackColor = Color.LightGray;
        }

        void icnFaster_Click(object sender, EventArgs e)
        {
            
        }

        void icnStop_Click(object sender, EventArgs e)
        {
            SimState = SimulationControlStates.STOP;            
            currentExperiment.EndExperiment();
            ExportExperimentDataToFiles();
        }

        void icnSlower_Click(object sender, EventArgs e)
        {
            
        }

        void icnPause_Click(object sender, EventArgs e)
        {
            if (SimState == SimulationControlStates.PLAY)
            {
                SimState = SimulationControlStates.PAUSE;
                icnPause.BackColor = Color.DimGray;
                icnPlay.BackColor = Color.White;
            }
        }

        void icnPlay_Click(object sender, EventArgs e)
        {
            if (SimState == SimulationControlStates.READY || SimState == SimulationControlStates.PAUSE)
            {
                SimState = SimulationControlStates.PLAY;
                msSinceLastStep = 0;
                icnPlay.BackColor = Color.DimGray;
                icnPause.BackColor = Color.White;
            }
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

            //population/generation tests
            Logging.Instance.Log("Creating Test Experiment");
            Experiment e = new Experiment("Test experiment", 10);
            e.PopulationSize = 4;
            e.Elites = 0;
            Logging.Instance.Log("Setting test ex topology");
            e.CurrentAgentTopology = AgentTemplate.EightTargetSensors();
            Logging.Instance.Log("Generating initial generation");
            e.NextGeneration();
            Logging.Instance.Log("Setting random fitnesses");
            e.CurrentGeneration.SetRandomFitnesses();
            Logging.Instance.Log("Moving to next generation");
            e.NextGeneration();

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
        /// Position controls that should be positioned around the edges of the main viewport.
        /// </summary>
        private void PositionControls()
        {
            //position the simulation state controls            
            pnlSimControls.Left = glControl.Width - pnlSimControls.Width;
            pnlSimControls.Top = glControl.Height - pnlSimControls.Height;
        }

        /// <summary>
        /// Update the FPS value
        /// </summary>        
        private void UpdateFPS(double elapsed)
        {
            if (timerPaused)
            {
                frames = 0;
                fpsperiod = 1;
                timerPaused = false;
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

                lblSeed.Text = currentExperiment.Random.GetSeed().ToString();
                lblGeneration.Text = currentExperiment.GenerationIndex.ToString();

                numElites.Value = currentExperiment.Elites;
                numPopSize.Value = currentExperiment.PopulationSize;
                numMutation.Value = currentExperiment.MutationRate;
                numCrossover.Value = currentExperiment.CrossoverRate;

                chkMutCross.Checked = currentExperiment.MutateDuringCrossover;
                chkMutSelect.Checked = currentExperiment.MutateOnSelection;

                ddlFitness.SelectedItem = currentExperiment.CurrentFitnessFunction;

                numtimeout.Value = (Decimal)currentExperiment.AgentFitnessImprovementTimeoutSeconds;
                numLifetime.Value = (Decimal)currentExperiment.MaxAgentLifetimeSeconds;

                //update terrain info
                //if (currentExperiment.CurrentHeightmap != null)
                  //  txtContext.Text = currentExperiment.CurrentHeightmap.ToString();
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
            setTargetToolStripMenuItem.Enabled = currentExperiment.CurrentHeightmap != null && scene != null;
            setStartPositionToolStripMenuItem.Enabled = currentExperiment.CurrentHeightmap != null && scene != null;
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
                    currentExperiment = new Experiment(createDialog.Name,createDialog.Seed);
                    EnableExperimentMenu();
                    ShowExperiment();
                    UpdateControlPanel();
                    setWarningLabels();
                }
            }
        }

        private void NewTerrain(HeightMapType type)
        {
            using (NewHeightmapWindow terrainDialog = new NewHeightmapWindow())
            {
                terrainDialog.initialise(currentExperiment, currentExperiment.CurrentHeightmapSettings, type);
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
                        , -50f / MeshHelper.HEIGHT_EXAGGERATION_FACTOR);

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

                        SimState = SimulationControlStates.READY;                  
                    }

                    setWarningLabels();
                    EnableExperimentMenu();
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
            GL.Enable(EnableCap.LineStipple);
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

            //This does the GL equivalent of gluPerspective
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
        /// 
        /// Manage simulation state and execute Main update loop *****************************************************************************************************************************
        /// 
        /// </summary>        
        private void Application_Idle(object sender, EventArgs e)
        {
            while(glControl.IsIdle)
            {
                //timer
                double elapsed = getElapsedTime();
                double elapsedSeconds = elapsed / 1000;

                frameTimer -= elapsedSeconds;

                if(frameTimer <= 0)
                {
                    UpdateFPS(elapsed);
                    RenderOpenGL();
                    frameTimer = 1 / targetFPS;
                }

                PositionControls();

                //simulation controls
                pnlSimControls.Visible = SimState != SimulationControlStates.STOP;

                //main update
                if(scene != null && !debugPause)
                {
                    float dt = (float)elapsedSeconds;

                    dtLast = dt;
                    if (dt > dtMax) dtMax = dt;
                    if (dt < dtMin) dtMin = dt;
                    
                    msSinceLastStep += elapsed;

                    //to enforce a fixed delta time, for deterministic behaviour
                    if (SimState == SimulationControlStates.PLAY && msSinceLastStep >= currentExperiment.StepPeriodMilliseconds)
                    {                        
                        //update the scene, and consequently, the experiment
                        int wholemillis = (int)Math.Floor(msSinceLastStep);
                        int updates = wholemillis / currentExperiment.StepPeriodMilliseconds;

                        while (updates > 0)
                        {
                            // update the scene - also updates the agents
                            scene.Update(currentExperiment.StepPeriodSeconds);
                            //update the experiment
                            currentExperiment.Update();

                            updates--;
                        }

                        msSinceLastStep = wholemillis % currentExperiment.StepPeriodMilliseconds;

                        //take any experimental control actions required
                        if(currentExperiment.GenerationIndex ==0)
                        {
                            MoveToNextGeneration();
                        }
                        else
                        {
                            if(currentExperiment.CurrentGeneration.HasEnded)
                            {
                                if (currentExperiment.GenerationIndex < numGenerations.Value)
                                {
                                    MoveToNextGeneration();          
                                }
                                else
                                {
                                    //experiment over
                                    SimState = SimulationControlStates.STOP;
                                    currentExperiment.EndExperiment();
                                    ExportExperimentDataToFiles();
                                }
                            }    
                        }
                    
                        //update any UI
                        UpdateFitnessLabels();
                    }
                }
            }
        }

        /// <summary>
        /// Continue the experiment by moving to the next generation
        /// </summary>
        private void MoveToNextGeneration()
        {
            Stopwatch utilityTimer = new Stopwatch();
            utilityTimer.Start();
            //move to the next generation
            currentExperiment.NextGeneration();
            utilityTimer.Stop();
            Logging.Instance.Log("Generating next population took " + utilityTimer.ElapsedMilliseconds.ToString());
            utilityTimer.Reset();
            utilityTimer.Start();
            RefreshSceneAgentPopulation();
            utilityTimer.Stop();
            Logging.Instance.Log("refreshing agents took " + utilityTimer.ElapsedMilliseconds.ToString());
            UpdateControlPanel();

            //prevent the next generation from jumping ahead.
            msSinceLastStep = 0;
            timer.Stop();
            timer.Reset();
        }

        /// <summary>
        /// Ensure the scene contains only the agents of the current generation
        /// </summary>
        private void RefreshSceneAgentPopulation()
        {
            //clear the scene of previous generations.
            scene.RemoveAllComponentsByType<AgentComponent>();
            //add the new generation's agents
            foreach(Agent a in currentExperiment.CurrentGeneration.Population)
            {
                AgentComponent acomp = scene.AddNewObject<AgentComponent>();
                acomp.CurrentAgent = a;
                acomp.Position = ((StartComponent)currentExperiment.CurrentStartpoint.Position).Position;
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
            if (e.KeyCode == Keys.T)
            {
                Logging.Instance.Log("DTlst: " + dtLast.ToString());
                Logging.Instance.Log("DTmin: " + dtMin.ToString());
                Logging.Instance.Log("DTmax: " + dtMax.ToString());
            }
        }

        private void setTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TargetForm targetDialog = new TargetForm())
            {
                targetDialog.CurrentExperiment = currentExperiment;
                targetDialog.CurrentScene = scene;

                if (targetDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    UpdateControlPanel();
                    setWarningLabels();
                    EnableExperimentMenu();
                }
            }
        }

        private void setStartPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StartForm startDialog = new StartForm())
            {
                startDialog.CurrentExperiment = currentExperiment;
                startDialog.CurrentScene = scene;

                if (startDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {          
                    UpdateControlPanel();
                    setWarningLabels();
                    EnableExperimentMenu();
                }                
            }
        }

        private void newAgentTopologyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AgentForm agentDialog = new AgentForm())
            {
                agentDialog.CurrentExperiment = currentExperiment;                

                if (agentDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    UpdateControlPanel();
                    setWarningLabels();
                    EnableExperimentMenu();
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }                     

        private void HideExperiment()
        {
            foreach (Control c in pnlControls.Controls)
                c.Visible = false;
            lblExperimentName.Visible = true;
        }

        private void ShowExperiment()
        {
            foreach (Control c in pnlControls.Controls)
                c.Visible = true;            
        }

        private void MainWindow_SizeChanged(object sender, EventArgs e)
        {
            MainViewContainer.SplitterDistance = MainViewContainer.Width - 200;
        }

        private void numPopSize_ValueChanged(object sender, EventArgs e)
        {
            currentExperiment.PopulationSize = (int)numPopSize.Value;
        }

        private void numElites_ValueChanged(object sender, EventArgs e)
        {
            currentExperiment.Elites = (int)numElites.Value;
        }

        private void numCrossover_ValueChanged(object sender, EventArgs e)
        {
            currentExperiment.CrossoverRate = (int)numCrossover.Value;
        }

        private void numMutation_ValueChanged(object sender, EventArgs e)
        {
            currentExperiment.MutationRate = (int)numMutation.Value;
        }

        private void chkMutSelect_CheckedChanged(object sender, EventArgs e)
        {
            currentExperiment.MutateOnSelection = chkMutSelect.Checked;
        }

        private void chkMutCross_CheckedChanged(object sender, EventArgs e)
        {
            currentExperiment.MutateDuringCrossover = chkMutCross.Checked;
        }        

        private void ddlFitness_SelectionChangeCommitted(object sender, EventArgs e)
        {
            currentExperiment.CurrentFitnessFunction = (FitnessFunction)ddlFitness.SelectedItem;
            txtFitnessExplanation.Text = currentExperiment.CurrentFitnessFunction.Explanation;
            setWarningLabels();
        }

        private void numLifetime_ValueChanged(object sender, EventArgs e)
        {
            currentExperiment.MaxAgentLifetimeSeconds = (float)numLifetime.Value;
            currentExperiment.AgentFitnessImprovementTimeoutSeconds = (float)numtimeout.Value;
        }

        private void UpdateFitnessLabels()
        {
            if(currentExperiment != null && currentExperiment.CurrentGeneration != null)
            {
                //age
                lblGenAge.Text = currentExperiment.CurrentGeneration.Age.ToString();
                //fitness
                lblGenMax.Text = currentExperiment.CurrentGeneration.MaxFitness.ToString();
                lblGenMin.Text = currentExperiment.CurrentGeneration.MinFitness.ToString();
                lblGenAvg.Text = currentExperiment.CurrentGeneration.AverageFitness.ToString();
                //agent state
                lblGenAct.Text = currentExperiment.CurrentGeneration.NumActive.ToString();
                lblGenExp.Text = currentExperiment.CurrentGeneration.NumExpired.ToString();
                lblGenWon.Text = currentExperiment.CurrentGeneration.NumReachedTarget.ToString();
                //experiment fitness
                KeyValuePair<int, float> pair;

                pair = currentExperiment.LifetimeMaxFitness;
                lblBestMax.Text = pair.Key.ToString() + " : " + pair.Value.ToString();

                pair = currentExperiment.LifetimeBestMinFitness;
                lblBestMin.Text = pair.Key.ToString() + " : " + pair.Value.ToString();

                pair = currentExperiment.LifetimeBestAvgFitness;
                lblBestAvg.Text = pair.Key.ToString() + " : " + pair.Value.ToString();

                //best path
                lblBestPathCost.Text = currentExperiment.BestPath.PathCost.ToString();
            }
        }

        private void calculateBestPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BestPathForm pathDialog = new BestPathForm())
            {
                pathDialog.CurrentExperiment = currentExperiment;

                if (pathDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    UpdateControlPanel();
                    setWarningLabels();  
                  
                    if(currentExperiment.BestPath.PathFound)
                    {
                        this.heightmapComponent.BestPath = currentExperiment.BestPath;
                    }
                }
            }
        }

        private void ExportExperimentDataToFiles()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            Logging.Instance.Log("Going to export to: " + path);

            string fitnessFile = path + currentExperiment.Name + "_fitness.txt";
            string agentsFile = path + currentExperiment.Name + "_agents.txt";
            string paramsFile = path + currentExperiment.Name + "_params.txt";

            int count = 0;
            while (File.Exists(fitnessFile))
            {
                count++;
                fitnessFile = path + currentExperiment.Name + count.ToString() + "_fitness.txt";
            }
            count = 0;
            while (File.Exists(agentsFile))
            {
                count++;
                agentsFile = path + currentExperiment.Name + count.ToString() + "_agents.txt";
            }                            

            File.WriteAllText(fitnessFile, currentExperiment.GetFitnessReport());
            File.WriteAllText(agentsFile, currentExperiment.GetAgentReport());
            File.WriteAllText(paramsFile, currentExperiment.GetSettingsReport());
        }
    }
}







