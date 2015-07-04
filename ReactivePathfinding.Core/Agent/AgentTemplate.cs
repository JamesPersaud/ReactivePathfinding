using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public class AgentTemplate
    {
        private Agent templateAgent;
        private string name;

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

        public static List<AgentTemplate> AllTemplates()
        {
            List<AgentTemplate> templates = new List<AgentTemplate>();
            templates.Add(EightTargetSensors());
            return templates;
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
            a.Name = "8T2";            

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

            //create appropriate genome - one bounded float for the weight of each connection.
            BoundaryFloatGenome g = new BoundaryFloatGenome(16, -1, 1, null);
            a.WeightGenome = g;

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
    }
}
