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
    public partial class TargetForm : Form
    {
        private Experiment currentExperiment;
        private Scene currentScene;
        private Target chosenTarget;
        private float baseIntensity;
        private float radius;
        private EmitterTypes emitterType;
        
        public EmitterTypes EmitterType
        {
            get { return emitterType; }
            set { emitterType = value; }
        }
        
        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public float BaseIntensity
        {
            get { return baseIntensity; }
            set { baseIntensity = value; }
        }

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
                numRadius.Minimum = 0;
                numIntensity.Minimum = 0;
                numRadius.Increment = 1;
                numIntensity.Increment = 0.1M;
                numX.Increment = 0.1M;
                numY.Increment = 0.1M;

                if (currentExperiment.CurrentHeightmap != null)
                {
                    numX.Maximum = currentExperiment.CurrentHeightmap.Settings.MapWidth;
                    numY.Maximum = currentExperiment.CurrentHeightmap.Settings.MapHeight;

                    numRadius.Maximum = Math.Max(currentExperiment.CurrentHeightmap.Settings.MapWidth, currentExperiment.CurrentHeightmap.Settings.MapHeight) * 2;
                    numIntensity.Maximum = 1;

                    lblMaxX.Text = "( map width: " + numX.Maximum.ToString() + " )";
                    lblMaxY.Text = "( map width: " + numY.Maximum.ToString() + " )";

                    if (currentExperiment.CurrentTarget != null)
                    {
                        numX.Value = (Decimal)currentExperiment.CurrentTarget.Position.X;
                        numY.Value = (Decimal)currentExperiment.CurrentTarget.Position.Y;
                        numRadius.Value = (Decimal)currentExperiment.CurrentTarget.EffectiveRadius;
                        numIntensity.Value = (Decimal)currentExperiment.CurrentTarget.BaseIntensity;                        
                        chosenTarget = currentExperiment.CurrentTarget;
                    }
                    else
                    {
                        numRadius.Value = Math.Max(currentExperiment.CurrentHeightmap.Settings.MapWidth, currentExperiment.CurrentHeightmap.Settings.MapHeight) / 2;
                        numIntensity.Value = 1;
                    }
                }
                else
                {
                    throw new Exception("Tried to set a start location for an experiment with no heightmap");
                }
            }
        }

        public Target ChosenTarget
        {
            get { return chosenTarget; }
            set
            {
                chosenTarget = value;
            }
        }

        public TargetForm()
        {
            InitializeComponent();
            ddlType.DataSource = Enum.GetValues(typeof(EmitterTypes));      
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
            baseIntensity = (float)numIntensity.Value;
            radius = (float)numRadius.Value;
            emitterType = (EmitterTypes)ddlType.SelectedItem;

            if (currentScene == null)
            {
                throw new Exception("Tried to set a target location for an experiment with no current scene");
            }

            //If there isn't already a target - create one with the appropriate component
            if (chosenTarget == null)
            {
                chosenTarget = new Target(baseIntensity,radius,emitterType);
                TargetComponent component = currentScene.AddNewObject<TargetComponent>();
                component.Position = new OpenTK.Vector3((float)numX.Value, (float)numY.Value, 0); // z will be set in the component's update loop
                component.CurrentTarget = chosenTarget;
                CurrentExperiment.CurrentTarget = chosenTarget;
                chosenTarget.CurrentExperiment = CurrentExperiment;
            }

            //adjust the position and attributes of the target component
            chosenTarget.EffectiveRadius = radius;
            chosenTarget.EmitterType = emitterType;
            chosenTarget.BaseIntensity = baseIntensity;
            ((TargetComponent)chosenTarget.Position).Position = new OpenTK.Vector3((float)numX.Value, (float)numY.Value, 0); // z will be set in the component's update loop

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }        

        /// <summary>
        /// centre
        /// </summary>        
        private void btnCentre_Click(object sender, EventArgs e)
        {
            numX.Value = currentExperiment.CurrentHeightmap.Settings.MapWidth / 2;
            numY.Value = currentExperiment.CurrentHeightmap.Settings.MapHeight / 2;
        }

        private void TargetForm_Load(object sender, EventArgs e)
        {
            if (chosenTarget != null)
            {
                switch (chosenTarget.EmitterType)
                {
                    case EmitterTypes.INVERSE_SQUARE:
                        ddlType.SelectedItem = EmitterTypes.INVERSE_SQUARE;
                        break;
                }
            }

            ddlType.SelectedItem = EmitterTypes.INVERSE_SQUARE;
        }
    }
}
