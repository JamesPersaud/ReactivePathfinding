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
    public partial class AgentTemplateForm : Form
    {
        private AgentTemplate template;        
        private Experiment currentExperiment;
        private bool dirty = false;

        public Experiment CurrentExperiment
        {
            get { return currentExperiment; }
            set { currentExperiment = value;}
        }

        public AgentTemplate Template
        {
            get { return template; }            
        }

        /// <summary>
        /// Resets the form to the current experiment's current template, or new if one hasn't been set.
        /// </summary>
        private void Revert()
        {
            if (currentExperiment.CurrentAgentTopology != null)
            {
                template = currentExperiment.CurrentAgentTopology.Clone();
            }
            else
            {
                newTemplate();
            }

            dirty = false;
        }

        private void newTemplate()
        {
            template = AgentTemplate.Empty();
        }

        public AgentTemplateForm()
        {
            InitializeComponent();                        

            ddlConnectionType.DataSource = Enum.GetValues(typeof(ConnectionTypes));
            ddlSensorType.DataSource = Enum.GetValues(typeof(SensorTypes));            
        }

        /// <summary>
        /// Populate the fields according to the current template
        /// </summary>
        private void BindData()
        {
            if(template != null)
            {
                txtName.Text = template.Name;
                Agent a = template.TemplateAgent;

                lstSensors.Items.Clear();
                foreach (Sensor s in a.Sensors)
                    lstSensors.Items.Add(s);

                lstConnections.Items.Clear();
                lstConnections.Items.AddRange(a.Connections);
                
                object o = ddlConnectionSensor.SelectedItem;
                ddlConnectionSensor.DataSource = null;
                ddlConnectionActuator.DataSource = a.Actuators;
                ddlConnectionSensor.DataSource = a.Sensors;

                if (o != null)
                    ddlConnectionSensor.SelectedItem = o;
                else if (ddlConnectionSensor.Items.Count >0)
                    ddlConnectionSensor.SelectedIndex = 0;

                btnOk.Enabled = true;
            }
        }

        //update the template object before saving or continuing
        private void updateTemplate()
        {
            if (dirty)
            {
                template.Name = txtName.Text;
                //Create an appropriate genome for the agent
                if (template.TemplateAgent.Connections != null && template.TemplateAgent.Connections.Length > 0)
                    template.TemplateAgent.WeightGenome = new BoundaryFloatGenome(template.TemplateAgent.Connections.Length, -1, 1, null);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            updateTemplate();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }      

        private void AgentForm_Load(object sender, EventArgs e)
        {
            Revert();
            BindData();
        }        

        private void ddlAgentTemplate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //load the template, add it to the list of templates and then select it from the list.
            AgentTemplate loadedTemplate = LoadSaveInterface.LoadAgentTemplate();
            if (loadedTemplate != null)
            {
                template = loadedTemplate;
                BindData();
            }            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Don't save a template without setting the name and the genome (if possible) first
            updateTemplate();
            LoadSaveInterface.SaveAgentTemplate(template);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            newTemplate();
            BindData();
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            if(dirty)
            {
                Revert();
                BindData();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            template.Name = txtName.Text;
            dirty = true;
        }

        private void btnAddSensor_Click(object sender, EventArgs e)
        {            
            Sensor s = null;            SensorTypes type = (SensorTypes)ddlSensorType.SelectedItem;

            if (type == SensorTypes.TARGET)
                s = new TargetSensor(new RadialPoint((float)numSensorAngle.Value, (float)numSensorRadius.Value));
            else if (type == SensorTypes.HEIGHTMAP_GRADIENT)
                s = new GradientSensor(new RadialPoint((float)numSensorAngle.Value, (float)numSensorRadius.Value));

            if (s != null)
            {
                s.Name = type.ToString() + "_" + numSensorAngle.Value.ToString() + "_" + numSensorRadius.Value.ToString();
                template.TemplateAgent.AddSensor(s);
                dirty = true;
                BindData();
            }            
        }

        private void btnAddConnection_Click(object sender, EventArgs e)
        {
            ConnectionTypes type = (ConnectionTypes)ddlConnectionType.SelectedItem;
            Sensor s = (Sensor)ddlConnectionSensor.SelectedItem;
            Actuator a = (Actuator)ddlConnectionActuator.SelectedItem;

            if (s != null && a != null)
            {
                Connection c = new Connection(s, a, 1, type);
                dirty = true;
                BindData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Remove all selected sensors from the agent, and any associated connections
        /// </summary>        
        private void lstSensors_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                foreach(object o in lstSensors.SelectedItems)
                {
                    dirty = true;
                    Sensor s = (Sensor)o;
                    //remove any connections associated with this sensor
                    for(int i = s.Connections.Count-1; i>=0; i--)
                    {
                        Connection c = s.Connections[i];
                        c.ConnectedSensor.Connections.Remove(c);
                        c.ConnectedActuator.Connections.Remove(c);

                        c.ConnectedSensor = null;
                        c.ConnectedActuator = null;
                    }
                    //remove sensor from agent
                    template.TemplateAgent.Sensors.Remove(s);
                }


                if (dirty)
                    BindData();
            }
        }

        /// <summary>
        /// remove all associated connections from the agent
        /// </summary>        
        private void lstConnections_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (object o in lstConnections.SelectedItems)
                {
                    dirty = true;
                    Connection c = (Connection)o;
                    c.ConnectedSensor.Connections.Remove(c);
                    c.ConnectedActuator.Connections.Remove(c);

                    c.ConnectedSensor = null;
                    c.ConnectedActuator = null;
                }
                
                if(dirty)
                    BindData();
            }
        }
    }
}
