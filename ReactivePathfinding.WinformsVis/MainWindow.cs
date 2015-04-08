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

namespace ReactivePathfinding.WinformsVis
{
    public partial class MainWindow : Form
    {
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
    }
}

