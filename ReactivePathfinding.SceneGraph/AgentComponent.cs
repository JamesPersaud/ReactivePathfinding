using System;
using System.Collections.Generic;
using ReactivePathfinding.Core;
using OpenTK;

namespace ReactivePathfinding.SceneGraph
{
    public class AgentComponent : SceneGraphComponent
    {
        public static bool DEBUG_AGENT_UPDATE = false;
        Agent currentAgent;

        public Agent CurrentAgent
        {
            get { return currentAgent; }
            set 
            { 
                currentAgent = value;
                CreateRenderData();
            }
        }

        private void Debug(string s)
        {
            if (DEBUG_AGENT_UPDATE)
                Logging.Instance.Log(currentAgent.Name + " : " + s);
        }

        /// <summary>
        /// Here the actual movement of the agent is processed
        /// </summary>
        public override void Update(float deltaTime)
        {
            Vector3 start = this.Position;
            MotorActuator left = null, right = null;
            float mag = 0;
            float v_angular = 0;

            Debug("Update Called: dt: " + deltaTime.ToString() + " seconds");

            Debug("Start position: " + start.ToString());

            //calculate the input(s) to the sensors

            //get target(s)
            List<TargetComponent> targets = ParentObject.CurrentScene.GetAllComponentsByType<TargetComponent>();
            Debug("Found: " + targets.Count.ToString() + " targets");
            int sensorindex = 0;

            //foreach target sensor
            foreach(TargetSensor sensor in currentAgent.Sensors)
            {
                sensorindex++;
                //get global position
                RadialPoint rotatedSensorLocation = new RadialPoint(sensor.Location.Angle + ParentObject.Rotation.Z, sensor.Location.Displacement);
                Vector3 sensorPosition = new Vector3(
                    Position.X + rotatedSensorLocation.X * currentAgent.CurrentExperiment.AgentRadius,
                    Position.Y + rotatedSensorLocation.Y * currentAgent.CurrentExperiment.AgentRadius,
                    Position.Z);

                Debug(sensor.Name + ": " + sensorPosition.ToString());

                float totalinput = 0;
                int targetindex = 0;
                //get sum intensity of target emissions at the sensor's position
                foreach (TargetComponent t in targets)
                {                
                    targetindex++;                    
                    float i = t.GetIntensityAtPoint(sensorPosition);                    

                    Debug("Target" + targetindex.ToString() + ": position : " + t.Position.ToString());
                    Debug("Target" + targetindex.ToString() + ": intensity: " + i.ToString());

                    //do a line of sight test
                    //sensors have a 90 degree horizontal field of view and 180 degree vertical field of view
                    
                    //get the angle between the sensor and the target
                    float target_theta = MathHelper.RadiansToDegrees((float)Math.Atan2(t.Position.Y - sensorPosition.Y, t.Position.X - sensorPosition.X));
                    Debug("Target" + targetindex.ToString() + ": Target theta:" + target_theta.ToString());
                    //get the angle of the sensor based on the current rotation of the agent
                    float sensor_theta = this.ParentObject.Rotation.Z + sensor.Location.Angle;
                    Debug("Target" + targetindex.ToString() + ": Sensor theta:" + sensor_theta.ToString());
                    //if these angles are within horizontal field of view of eachother, the target is in the sensor's field of view
                    float diff = Math.Abs(target_theta - sensor_theta) % 360;
                    diff = diff > 180 ? 360 - diff : diff;

                    Debug("Target" + targetindex.ToString() + ": FOV diff:" + diff.ToString());

                    //Add the target's contribution
                    if(diff <= currentAgent.CurrentExperiment.SensorHorizontalFOV/2)
                        totalinput += i;
                }

                sensor.Input = totalinput;
                Debug(sensor.Name + ": input: " + totalinput.ToString());
            }
            
            //calculate the contribution to movement of the motors
            float motors = 0;
            foreach (MotorActuator motor in this.currentAgent.Actuators)
            {
                motors++;
                Debug(motor.ToString());
                mag += motor.Output;

                if (motor.MotorType == MotorTypes.LEFT)
                    left = motor;
                else if (motor.MotorType == MotorTypes.RIGHT)
                    right = motor;
            }
            
            float v_diff = right.Output - left.Output;

            //angular accelleration is given by the linear tangential accelleration divided by the radius.           
            Debug("Diff in output: " + v_diff.ToString());
            v_angular = MathHelper.RadiansToDegrees(v_diff / CurrentAgent.CurrentExperiment.AgentRadius);
            Debug("Degrees per second: " + v_angular.ToString());

            //fix the situation where the agent is not moving forward and not turning (it must be out of rang of all sensors) by turning it
            if (v_angular == 0 && mag == 0)
                v_angular = currentAgent.CurrentExperiment.AgentMinTurnSpeed;

            //factor in time
            mag *= CurrentAgent.CurrentExperiment.AgentMaxMovementSpeed * deltaTime;
            v_angular *= deltaTime;            

            Debug("Angular Displacement " + v_angular.ToString());
            Debug("Horizontal Displacement " + mag.ToString());

            //rotate the agent
            this.ParentObject.RotateLocalAroundZ(v_angular);

            //TODO adjust the amount of horizontal movement experienced by the agent according to the gradient of terrain traversed

            //move the agent
            this.ParentObject.GoForwards(mag);

            //adjust the height of the agent according to the height at the current location
            float newz = this.currentAgent.CurrentExperiment.CurrentHeightmap.GetSceneHeight(this.Position.X, this.Position.Y);
            Position = new Vector3(Position.X, Position.Y, newz * MeshHelper.HEIGHT_EXAGGERATION_FACTOR);

            Debug("End Position " + Position.ToString());
        }

        /// <summary>
        /// TODO indicate agent facing
        /// </summary>
        private void CreateRenderData()
        {
            PolyMode = OpenTK.Graphics.OpenGL.PolygonMode.Fill;
            MeshHelper.GetCube(1, new Vector4(1,0,0,1), out vertices, out triangles, out colors);
            RenderDataCreated = true;
        }
    }
}
