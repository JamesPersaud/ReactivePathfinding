using System;
using System.Collections.Generic;
using ReactivePathfinding.Core;
using OpenTK;

namespace ReactivePathfinding.SceneGraph
{
    public class AgentComponent : SceneGraphComponent
    {
        public static bool DEBUG_AGENT_UPDATE = false;        

        private Agent currentAgent;

        private WheelComponent leftWheel;
        private WheelComponent rightWheel;

        public WheelComponent RightWheel
        {
            get { return rightWheel; }
            set { rightWheel = value; }
        }

        public WheelComponent LeftWheel
        {
            get { return leftWheel; }
            set { leftWheel = value; }
        }

        public Agent CurrentAgent
        {
            get { return currentAgent; }
            set 
            { 
                currentAgent = value;
                currentAgent.Position = this;
                CreateRenderData();
            }
        }

        private void Debug(string s)
        {
            if (DEBUG_AGENT_UPDATE)
                Logging.Instance.Log(currentAgent.Name + " : " + s);
        }

        public Vector3 GetGlobalSensorPosition(Vector3 agentStartPosition, Sensor sensor, bool horizontal)
        {
            RadialPoint rotatedSensorLocation = new RadialPoint(sensor.Location.Angle + ParentObject.Rotation.Z, sensor.Location.Displacement);

            float x = agentStartPosition.X + rotatedSensorLocation.X * currentAgent.CurrentExperiment.AgentRadius;
            float y = agentStartPosition.Y + rotatedSensorLocation.Y * currentAgent.CurrentExperiment.AgentRadius;
            float z = agentStartPosition.Z;
            if(!horizontal)
                z = CurrentAgent.CurrentExperiment.CurrentHeightmap.GetSceneHeight(x, y);

            return new Vector3(x,y,z);
        }

        /// <summary>
        /// Here the actual movement of the agent is processed
        /// </summary>
        public override void Update(float deltaTime)
        {
            if (currentAgent != null && currentAgent.IsAlive && !currentAgent.ReachedTarget)
            {
                Vector3 startPosition = new Vector3(Position.X, Position.Y, currentAgent.CurrentExperiment.CurrentHeightmap.GetSceneHeight(Position.X, Position.Y));
                MotorActuator left = null, right = null;
                float mag = 0; // magnitude of horizontal displacement
                float v_angular = 0;

                Debug("Update Called: dt: " + deltaTime.ToString() + " seconds");

                Debug("Start position: " + startPosition.ToString());

                //calculate the input(s) to the sensors

                //get target(s)
                List<TargetComponent> targets = ParentObject.CurrentScene.GetAllComponentsByType<TargetComponent>();
                Debug("Found: " + targets.Count.ToString() + " targets");
                int sensorindex = 0;

                //process sensors
                foreach (Sensor sensor in currentAgent.Sensors)
                {                    
                    //target sensors
                    if (sensor.SensorType == SensorTypes.TARGET)
                    {
                        sensorindex++;
                        //get global position                    
                        Vector3 sensorPosition = GetGlobalSensorPosition(startPosition, sensor,true);

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
                            //target sensors have a 90 degree horizontal field of view and 180 degree vertical field of view

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
                            if (diff <= currentAgent.CurrentExperiment.SensorHorizontalFOV / 2)
                                totalinput += i;
                        }

                        sensor.Input = totalinput;
                        Debug(sensor.Name + ": input: " + totalinput.ToString());
                    }
                    //gradient sensors
                    else if(sensor.SensorType == SensorTypes.HEIGHTMAP_GRADIENT)
                    {                        
                        Vector3 sensorPosition = GetGlobalSensorPosition(startPosition, sensor,false);
                        sensor.Input = sensorPosition.Z - startPosition.Z;
                        if (sensor.Input > 0) sensor.Input *= currentAgent.CurrentExperiment.SearchCostFunction.AscendingMultiplier;
                        if (sensor.Input < 0) sensor.Input *= currentAgent.CurrentExperiment.SearchCostFunction.DescendingMultiplier;
                        Debug(sensor.Name + ": input: " + sensor.Input.ToString());
                    }
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

                if (leftWheel != null)
                    leftWheel.LinearVelocity = left.Output;

                if (rightWheel != null)
                    rightWheel.LinearVelocity = right.Output;

                //angular accelleration is given by the linear tangential accelleration divided by the radius.
                v_angular = MathHelper.RadiansToDegrees(v_diff / CurrentAgent.CurrentExperiment.AgentRadius);
                Debug("Degrees per second: " + v_angular.ToString());

                //fix the situation where the agent is not moving forward and not turning (it must be out of rang of all sensors) by turning it
                if (v_angular == 0 && mag == 0)
                    v_angular = currentAgent.CurrentExperiment.AgentMinTurnSpeed;

                
                float unitsPerSecond = CurrentAgent.CurrentExperiment.AgentMaxMovementSpeed;
                // reverse movement happens at half the speed of forward movement - this helps evolve agents that favor forward motion
                //if(mag <0)                
                  //  unitsPerSecond /= 2;                

                //factor in time
                mag *= unitsPerSecond * deltaTime; // calculate mag for a flat plane
                v_angular *= deltaTime;

                //rotate the agent
                this.ParentObject.RotateLocalAroundZ(v_angular);

                //Now adjust the magnitude of movement according to the average gradient covered
                if (mag != 0)
                {
                    float m = Math.Abs(mag);
                    Vector3 targetPosition = startPosition + (this.Forwards * mag);
                    float d = Math.Abs((targetPosition - startPosition).Length);


                    if (d != 0)
                    {
                        //Get the approximate actual horizontal displacement based on the average gradient
                        //See the relevant section in the project report for the maths behind this.
                        if (mag > 0)
                            mag = (m * m) / d;
                        else
                            mag = -((m * m) / d);
                    }
                    else
                    {                        
                        mag = 0;
                    }
                }

                //TODO rotate agent according to gradient (only affects visualization)

                Debug("Angular Displacement " + v_angular.ToString());
                Debug("Horizontal Displacement " + mag.ToString());

                //move the agent
                this.ParentObject.GoForwards(mag);

                //adjust the height of the agent according to the height at the current location
                float newz = this.currentAgent.CurrentExperiment.CurrentHeightmap.GetSceneHeight(this.Position.X, this.Position.Y);
                Position = new Vector3(Position.X, Position.Y, newz);

                //get the actual distance moved
                Vector3 displacement = Position - startPosition;
                float deltaDistance = displacement.Length;

                Debug("End Position " + Position.ToString());

                //update the agent 
                this.currentAgent.Update(deltaTime, displacement.X, displacement.Y, displacement.Z,deltaDistance);
            }
            else
            {
                //if agent is not moving, update its wheels
                leftWheel.LinearVelocity = 0;
                rightWheel.LinearVelocity = 0;
            }
        }

        /// <summary>
        /// TODO indicate agent facing
        /// </summary>
        private void CreateRenderData()
        {
            PolyMode = OpenTK.Graphics.OpenGL.PolygonMode.Fill;
            MeshHelper.GetAgent(currentAgent.CurrentExperiment.AgentRadius*2, new Vector4(0.5f,0,0,1), new Vector4(1,0,0,1), out vertices, out triangles, out colors);
            RenderDataCreated = true;

            //create wheels
            if(leftWheel == null && rightWheel == null)
            {
                leftWheel = ParentObject.AddChild<WheelComponent>();
                rightWheel = ParentObject.AddChild<WheelComponent>();

                leftWheel.Position = new Vector3(0, currentAgent.CurrentExperiment.AgentRadius, 0);
                rightWheel.Position = new Vector3(0, -currentAgent.CurrentExperiment.AgentRadius, 0);

                leftWheel.Agent = currentAgent;
                rightWheel.Agent = currentAgent;
            }
        }
    }
}
