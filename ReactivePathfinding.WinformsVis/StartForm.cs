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
using ReactivePathfinding.SceneGraph;

namespace ReactivePathfinding.WinformsVis
{
    public partial class StartForm : Form
    {
        private Experiment currentExperiment;
        private Scene currentScene;
        private Startpoint chosenStartpos;

        public Scene CurrentScene
        {
            get { return currentScene; }
            set { currentScene = value; }
        }

        public Experiment CurrentExperiment
        {
            get { return currentExperiment; }
            set
            {
                currentExperiment = value;
                numX.Minimum = 0;
                numY.Minimum = 0;
                numX.Increment = 0.1M;
                numY.Increment = 0.1M;

                if(currentExperiment.CurrentHeightmap != null)
                {
                    numX.Maximum = currentExperiment.CurrentHeightmap.Settings.MapWidth;
                    numY.Maximum = currentExperiment.CurrentHeightmap.Settings.MapHeight;

                    lblMaxX.Text = "( map width: " + numX.Maximum .ToString()+ " )";
                    lblMaxY.Text = "( map width: " + numY.Maximum.ToString() + " )";

                    if (currentExperiment.CurrentStartpoint != null)
                    {
                        numX.Value = (Decimal)currentExperiment.CurrentStartpoint.Position.X;
                        numY.Value = (Decimal)currentExperiment.CurrentStartpoint.Position.Y;
                        chosenStartpos = currentExperiment.CurrentStartpoint;
                    }
                }
                else
                {
                    throw new Exception("Tried to set a start location for an experiment with no heightmap");
                }                
            }
        }        

        public Startpoint ChosenStartpos
        {
            get { return chosenStartpos; }
            set
            {
                chosenStartpos = value;
            }
        }

        public StartForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Cancel
        /// </summary>        
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (currentScene == null)
            {
                throw new Exception("Tried to set a start location for an experiment with no current scene");
            }

            //If there isn't already a startpos - create one with the appropriate component            
            if(chosenStartpos == null)
            {
                chosenStartpos = new Startpoint();
                StartComponent component = currentScene.AddNewObject<StartComponent>();
                component.Position = new OpenTK.Vector3((float)numX.Value,(float)numY.Value,0); // z will be set in the component's update loop
                component.CurrentStartpoint = chosenStartpos;
                CurrentExperiment.CurrentStartpoint = chosenStartpos;
                chosenStartpos.CurrentExperiment = CurrentExperiment;
            }

            //adjust the position of the start component
            ((StartComponent)chosenStartpos.Position).Position = new OpenTK.Vector3((float)numX.Value, (float)numY.Value, 0); // z will be set in the component's update loop

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// centre
        /// </summary>        
        private void button2_Click(object sender, EventArgs e)
        {
            numX.Value = currentExperiment.CurrentHeightmap.Settings.MapWidth /2;
            numY.Value = currentExperiment.CurrentHeightmap.Settings.MapHeight /2;
        }
    }
}
