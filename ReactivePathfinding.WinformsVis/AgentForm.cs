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
    public partial class AgentForm : Form
    {        
        private List<AgentTemplate> templates;
        private Experiment currentExperiment;

        public Experiment CurrentExperiment
        {
            get { return currentExperiment; }
            set
            {                
                currentExperiment = value;                
                if (currentExperiment.CurrentAgentTopology != null)
                {
                    //If this experiment has a set topology and it is not a standard template or the templates list is empty/null
                    if (templates != null)
                    {
                        if(!templates.Contains(currentExperiment.CurrentAgentTopology))
                        {
                            templates.Add(currentExperiment.CurrentAgentTopology);
                        }
                    }
                    else
                    {
                        templates = new List<AgentTemplate>();
                        templates.Add(currentExperiment.CurrentAgentTopology);
                    }
                }
            }
        }

        public AgentForm()
        {
            InitializeComponent();
            //populate static dropdowns
            templates = AgentTemplate.AllTemplates();
            ddlAgentTemplate.DataSource = templates;

            ddlConnectionType.DataSource = Enum.GetValues(typeof(ConnectionTypes));
            ddlSensorType.DataSource = Enum.GetValues(typeof(SensorTypes));

            ddlAgentTemplate.SelectedIndex = -1;
        }

        /// <summary>
        /// Populate the sensor and connection dropdowns according to the current template
        /// </summary>
        private void BindDropdowns()
        {
            if(ddlAgentTemplate.SelectedItem != null)
            {
                Agent a = ((AgentTemplate)ddlAgentTemplate.SelectedItem).TemplateAgent;

                lstSensors.Items.Clear();
                foreach (Sensor s in a.Sensors)
                    lstSensors.Items.Add(s);

                lstConnections.Items.Clear();
                lstConnections.Items.AddRange(a.Connections);

                btnOk.Enabled = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            currentExperiment.CurrentAgentTopology = (AgentTemplate)ddlAgentTemplate.SelectedItem;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ddlConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ddlConnectionSensor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ddlConnectionActuator_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddConnection_Click(object sender, EventArgs e)
        {

        }

        private void btnAddSensor_Click(object sender, EventArgs e)
        {

        }

        private void AgentForm_Load(object sender, EventArgs e)
        {
            if (currentExperiment.CurrentAgentTopology != null)
            {
                ddlAgentTemplate.SelectedItem = currentExperiment.CurrentAgentTopology;
                BindDropdowns();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void ddlAgentTemplate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BindDropdowns();
        }
    }
}
