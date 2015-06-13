using System;
using System.Collections.Generic;
using ReactivePathfinding.Core;
using OpenTK;

namespace ReactivePathfinding.SceneGraph
{
    public class AgentComponent : SceneGraphComponent
    {
        Agent currentAgent;

        public Agent CurrentAgent
        {
            get { return currentAgent; }
            set { currentAgent = value; }
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

            //calculate the input(s) to the sensors

            //get targets

            //foreach target sensor
            //get global position
            //get distance between
            //get intensity at distance and input to sensor

            //calculate the contribution to movement of the motors
            foreach (MotorActuator motor in this.currentAgent.Actuators)
            {
                mag += motor.Output;

                if (motor.MotorType == MotorTypes.LEFT)
                    left = motor;
                else if (motor.MotorType == MotorTypes.RIGHT)
                    right = motor;
            }

            if (left != null && right != null)            
                v_angular = right.Output - left.Output;            
            else
                throw new Exception("Could not find one or more motors for agent " +currentAgent.ToString());            

            mag *= CurrentAgent.CurrentExperiment.AgentMaxMovementSpeed * deltaTime; // transform into a magnitude of units
            v_angular *= CurrentAgent.CurrentExperiment.AgentMaxTurnSpeed * deltaTime; //transform into an angle in degrees

            if (v_angular < 0)
                v_angular += 360;

            //move the agent
            this.ParentObject.RotateLocalAroundZ(v_angular);
            this.ParentObject.GoForwards(mag); // TODO adjust for gradient

        }
    }
}
