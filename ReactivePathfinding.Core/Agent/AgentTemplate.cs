using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ReactivePathfinding.Core
{
    [Serializable]
    public class AgentTemplate
    {
        private Agent templateAgent;
        private string name = "{New template}";
        private string filename = "{Unsaved}";
        private bool isNew = true;

        public bool IsNew
        {
            get { return isNew; }
            set { isNew = value; }
        }

        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Agent TemplateAgent
        {
            get { return templateAgent; }
            set { templateAgent = value; }
        }

        public bool IsValid(out string error)
        {
            if(templateAgent == null)
            {
                error = "Template agent undefined";
                return false;
            }
            else if (templateAgent.Sensors.Count < 1)
            {                                
                error = "Template has too few sensors";
                return false;
            }
            else if (templateAgent.Connections.Length <1)
            {
                error = "Template has too few connections";
                return false;
            }

            error = "none";
            return true;
        }

        public static List<AgentTemplate> AllTemplates()
        {
            List<AgentTemplate> templates = new List<AgentTemplate>();
            templates.Add(EightTargetSensors());
            templates.Add(EightTargetSensorsAndFourGradient());
            return templates;
        }

        /// <summary>
        /// Load a previously saved template by filename
        /// </summary>        
        public static AgentTemplate LoadFromFile(string fullpath)
        {
            AgentTemplate temp = null;
            FileStream stream = null;

            if (File.Exists(fullpath))
            {
                try
                {
                    Logging.Instance.Log("Loading Template from " + fullpath);
                    stream = File.OpenRead(fullpath);
                    BinaryFormatter formatter = new BinaryFormatter();
                    temp = (AgentTemplate)formatter.Deserialize(stream);
                    temp.isNew = false;
                }
                catch (Exception ex)
                {
                    Logging.Instance.Log("Failed to read file " + fullpath + " because: " + ex.Message);
                }
                finally
                {
                    if (stream != null)
                        stream.Close();
                }
            }
            else
            {
                Logging.Instance.Log("File not found " + fullpath);
            }

            return temp;
        }

        /// <summary>
        /// Serialize the template to file
        /// </summary>
        public bool Save(string fullpath)
        {
            bool success = false;

            if (File.Exists(fullpath))
            {
                File.Delete(fullpath);
                Logging.Instance.Log("Deleting old file " + fullpath);
            }

            Logging.Instance.Log("Saving Template to " + fullpath);
            FileStream stream = null;
            try
            {
                stream = File.Create(fullpath);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                success = true;
            }
            catch (Exception ex)
            {
                Logging.Instance.Log("Failed to write file " + fullpath + " because: " + ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            return success;
        }
        public bool SaveAs(string newname, string fullpath)
        {
            string oldname = filename;
            filename = newname;
            bool success = Save(fullpath);

            if (!success)
                filename = oldname;

            return success;
        }

        /// <summary>
        /// This agent has 8 target sensors, at 0, 45, 90, 135, 180, 225, 270 and 315 degrees all positioned 
        /// at the edge of the agent's radius
        /// each sensor is connected to both motor actuators
        /// </summary>
        public static AgentTemplate EightTargetSensors()
        {
            AgentTemplate t = new AgentTemplate();

            Agent a = new Agent();                     

            Sensor leftsensor = new TargetSensor(new RadialPoint(90f, 1f)); leftsensor.Name = "target_90_1";
            Sensor rightsensor = new TargetSensor(new RadialPoint(270f, 1f)); rightsensor.Name = "target_270_1";
            Sensor forwardsensor = new TargetSensor(new RadialPoint(0f, 1f)); forwardsensor.Name = "target_0_1";
            Sensor frontleftsensor = new TargetSensor(new RadialPoint(45f, 1f)); frontleftsensor.Name = "target_45_1";
            Sensor frontrightsensor = new TargetSensor(new RadialPoint(315f, 1f)); frontrightsensor.Name = "target_315_1";
            Sensor backleftsensor = new TargetSensor(new RadialPoint(135f, 1f)); backleftsensor.Name = "target_135_1";
            Sensor backtrightsensor = new TargetSensor(new RadialPoint(225f, 1f)); backtrightsensor.Name = "target_225_1";
            Sensor backsensor = new TargetSensor(new RadialPoint(180f, 1f)); backsensor.Name = "target_180_1";

            Actuator leftmotor = new MotorActuator(MotorTypes.LEFT); leftmotor.Name = "Mleft";
            Actuator rightmotor = new MotorActuator(MotorTypes.RIGHT); rightmotor.Name = "Mright";

            a.AddSensor(leftsensor);
            a.AddSensor(rightsensor);
            a.AddSensor(forwardsensor);
            a.AddSensor(frontleftsensor);
            a.AddSensor(frontrightsensor);
            a.AddSensor(backleftsensor);
            a.AddSensor(backtrightsensor);
            a.AddSensor(backsensor);

            a.AddActuator(leftmotor);
            a.AddActuator(rightmotor);

            Connection c1 = new Connection(leftsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c1.Name = "c1";
            Connection c2 = new Connection(leftsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c2.Name = "c2";

            Connection c3 = new Connection(rightsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c3.Name = "c3";
            Connection c4 = new Connection(rightsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c4.Name = "c4";

            Connection c5 = new Connection(forwardsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c5.Name = "c5";
            Connection c6 = new Connection(forwardsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c6.Name = "c6";

            Connection c7 = new Connection(frontleftsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c7.Name = "c7";
            Connection c8 = new Connection(frontleftsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c8.Name = "c8";

            Connection c9 = new Connection(frontrightsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c9.Name = "c9";
            Connection c10 = new Connection(frontrightsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c10.Name = "c10";

            Connection c11 = new Connection(backleftsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c11.Name = "c11";
            Connection c12 = new Connection(backleftsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c12.Name = "c12";

            Connection c13 = new Connection(backtrightsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c13.Name = "c13";
            Connection c14 = new Connection(backtrightsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c14.Name = "c14";

            Connection c15 = new Connection(backsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c15.Name = "c15";
            Connection c16 = new Connection(backsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c16.Name = "c16";
            
            t.TemplateAgent = a;
            t.Name = "8 Target sensor dual connections";
            t.filename = "{Unsaved}";

            //create appropriate genome - one bounded float for the weight of each connection.
            BoundaryFloatGenome g = new BoundaryFloatGenome(16, -1, 1, null);
            a.WeightGenome = g;

            return t;
        }

        /// <summary>
        /// This agent has 8 target sensors, at 0, 45, 90, 135, 180, 225, 270 and 315 degrees all positioned 
        /// at the edge of the agent's radius
        /// each sensor is connected to both motor actuators
        /// </summary>
        public static AgentTemplate EightTargetSensorsAndFourGradient()
        {
            AgentTemplate t = new AgentTemplate();

            Agent a = new Agent();            

            Sensor leftsensor = new TargetSensor(new RadialPoint(90f, 1f)); leftsensor.Name = "target_90_1";
            Sensor rightsensor = new TargetSensor(new RadialPoint(270f, 1f)); rightsensor.Name = "target_270_1";
            Sensor forwardsensor = new TargetSensor(new RadialPoint(0f, 1f)); forwardsensor.Name = "target_0_1";
            Sensor frontleftsensor = new TargetSensor(new RadialPoint(45f, 1f)); frontleftsensor.Name = "target_45_1";
            Sensor frontrightsensor = new TargetSensor(new RadialPoint(315f, 1f)); frontrightsensor.Name = "target_315_1";
            Sensor backleftsensor = new TargetSensor(new RadialPoint(135f, 1f)); backleftsensor.Name = "target_135_1";
            Sensor backtrightsensor = new TargetSensor(new RadialPoint(225f, 1f)); backtrightsensor.Name = "target_225_1";
            Sensor backsensor = new TargetSensor(new RadialPoint(180f, 1f)); backsensor.Name = "target_180_1";

            Sensor frontleftGradient = new GradientSensor(new RadialPoint(45f, 1f)); frontleftGradient.Name = "gradient_45_1";
            Sensor frontrightGradient = new GradientSensor(new RadialPoint(315f, 1f)); frontrightGradient.Name = "gradient_315_1";
            Sensor backleftGradient = new GradientSensor(new RadialPoint(45f, 1f)); backleftGradient.Name = "gradient_135_1";
            Sensor backrightGradient = new GradientSensor(new RadialPoint(45f, 1f)); backrightGradient.Name = "gradient_225_1";

            Actuator leftmotor = new MotorActuator(MotorTypes.LEFT); leftmotor.Name = "Mleft";
            Actuator rightmotor = new MotorActuator(MotorTypes.RIGHT); rightmotor.Name = "Mright";

            a.AddSensor(leftsensor);
            a.AddSensor(rightsensor);
            a.AddSensor(forwardsensor);
            a.AddSensor(frontleftsensor);
            a.AddSensor(frontrightsensor);
            a.AddSensor(backleftsensor);
            a.AddSensor(backtrightsensor);
            a.AddSensor(backsensor);

            a.AddSensor(frontleftGradient);
            a.AddSensor(frontrightGradient);
            a.AddSensor(backleftGradient);
            a.AddSensor(backrightGradient);

            a.AddActuator(leftmotor);
            a.AddActuator(rightmotor);

            //connect target sensors
            Connection c1 = new Connection(leftsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c1.Name = "c1";
            Connection c2 = new Connection(leftsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c2.Name = "c2";

            Connection c3 = new Connection(rightsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c3.Name = "c3";
            Connection c4 = new Connection(rightsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c4.Name = "c4";

            Connection c5 = new Connection(forwardsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c5.Name = "c5";
            Connection c6 = new Connection(forwardsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c6.Name = "c6";

            Connection c7 = new Connection(frontleftsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c7.Name = "c7";
            Connection c8 = new Connection(frontleftsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c8.Name = "c8";

            Connection c9 = new Connection(frontrightsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c9.Name = "c9";
            Connection c10 = new Connection(frontrightsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c10.Name = "c10";

            Connection c11 = new Connection(backleftsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c11.Name = "c11";
            Connection c12 = new Connection(backleftsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c12.Name = "c12";

            Connection c13 = new Connection(backtrightsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c13.Name = "c13";
            Connection c14 = new Connection(backtrightsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c14.Name = "c14";

            Connection c15 = new Connection(backsensor, leftmotor, 1, ConnectionTypes.EXCITATORY); c15.Name = "c15";
            Connection c16 = new Connection(backsensor, rightmotor, 1, ConnectionTypes.EXCITATORY); c16.Name = "c16";

            //connect gradient sensors
            Connection c17 = new Connection(frontleftGradient, leftmotor, 1, ConnectionTypes.EXCITATORY); c17.Name = "c17";
            Connection c18 = new Connection(frontleftGradient, rightmotor, 1, ConnectionTypes.EXCITATORY); c18.Name = "c18";

            Connection c19 = new Connection(frontrightGradient, leftmotor, 1, ConnectionTypes.EXCITATORY); c19.Name = "c19";
            Connection c20 = new Connection(frontrightGradient, rightmotor, 1, ConnectionTypes.EXCITATORY); c20.Name = "c20";

            Connection c21 = new Connection(backleftGradient, leftmotor, 1, ConnectionTypes.EXCITATORY); c21.Name = "c21";
            Connection c22 = new Connection(backleftGradient, rightmotor, 1, ConnectionTypes.EXCITATORY); c22.Name = "c22";

            Connection c23 = new Connection(backrightGradient, leftmotor, 1, ConnectionTypes.EXCITATORY); c23.Name = "c23";
            Connection c24 = new Connection(backrightGradient, rightmotor, 1, ConnectionTypes.EXCITATORY); c24.Name = "c24";

            t.TemplateAgent = a;
            t.Name = "8 Target & 4 gradient all dual conn.";
            t.filename = "{Unsaved}";

            //create appropriate genome - one bounded float for the weight of each connection.
            BoundaryFloatGenome g = new BoundaryFloatGenome(24, -1, 1, null);
            a.WeightGenome = g;

            return t;
        }

        /// <summary>
        /// Get a new agent template with no sensors or connections
        /// </summary>        
        public static AgentTemplate Empty()
        {
            AgentTemplate t = new AgentTemplate();

            Agent a = new Agent();                        

            Actuator leftmotor = new MotorActuator(MotorTypes.LEFT); leftmotor.Name = "Mleft";
            Actuator rightmotor = new MotorActuator(MotorTypes.RIGHT); rightmotor.Name = "Mright";            

            a.AddActuator(leftmotor);
            a.AddActuator(rightmotor);            

            t.TemplateAgent = a;
            t.Name = "New Unsaved Agent";
            t.filename = "{Unsaved}";            

            return t;
        }

        public Agent GetAgentFromTemplate()
        {
            return new Agent(TemplateAgent);
        }        

        public override string ToString()
        {
            return name;
        }

        public AgentTemplate Clone()
        {
            AgentTemplate clone = new AgentTemplate();
            clone.Filename = "{New Clone}";
            clone.name = this.name;
            clone.isNew = false;
            clone.templateAgent = new Agent(this.templateAgent);
            return clone;
        }
    }
}
