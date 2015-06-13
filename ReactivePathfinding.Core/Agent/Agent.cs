using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    /// <summary>
    /// 
    /// Mapping Genomes to agents in an experiment:
    /// 
    ///     In any given experiment with a set topology with n connections, an agent has connections C1 - Cn
    ///     the order of these connections is important because it maps directly to the order of values in the genome.
    ///     The agent will also have sensors S1 - Sn. Every connection must involve one sensor and one actuator
    ///     the order of the sensors is also important, every individual in an experiment must have an identical
    ///     sequence of sensors and actuators.
    ///     
    ///     Setting the genome of an agent follows the pseudocode:
    ///     
    ///         let c = 0
    ///         let G be a genome
    ///         for each sensor S    
    ///             for each connection C belonging to sensor S
    ///                 C.weight = Genome[c]
    ///                 increment c
    ///                 
    ///     Therefore, the collection of Sensor objects that is a member of Agent should be ordinal and so should the 
    ///     collection of Connection objects that is a member of Sensor
    /// 
    /// 
    /// </summary>
    public class Agent
    {
        private List<Sensor> sensors = new List<Sensor>();
        private List<Actuator> actuators = new List<Actuator>();
        private Experiment currentExperiment;
        private float totalDistance;
        private float totalAscending;
        private float totalDescending;
        private float closestToTarget;
        private bool reachedTarget;
        private float totalTime;
        private BoundaryFloatGenome weightGenome;

        /// <summary>
        /// The genome of this individual agent, setting results in altering the weights of its sensors' connections.
        /// </summary>
        public BoundaryFloatGenome WeightGenome
        {
            get { return weightGenome; }

            set
            {
                int g = 0;
                for(int i = 0; i < sensors.Count; i++)
                {
                    Sensor s = sensors[i];
                    for(int j = 0; j < s.Connections.Count ; j++)
                    {
                        s.Connections[j].Weight = value.GetGene(g);
                        g++;
                    }
                }

                weightGenome = value; 
            }
        }

        /// <summary>
        /// The total time spent by the agent 
        /// </summary>
        public float TotalTime
        {
            get { return totalTime; }
            set { totalTime = value; }
        }                

        /// <summary>
        /// Has the agent ever reached the target
        /// </summary>
        public bool ReachedTarget
        {
            get { return reachedTarget; }
            set { reachedTarget = value; }
        }

        /// <summary>
        /// What is the closest the agent has ever come to the target
        /// </summary>
        public float ClosestToTarget
        {
            get { return closestToTarget; }
            set { closestToTarget = value; }
        }

        /// <summary>
        /// The sum of all downward movement by the agent 
        /// </summary>
        public float TotalDescending
        {
            get { return totalDescending; }
            set { totalDescending = value; }
        }

        /// <summary>
        /// The sum of all upward movement by the agent
        /// </summary>
        public float TotalAscending
        {
            get { return totalAscending; }
            set { totalAscending = value; }
        }

        /// <summary>
        /// The sum of all movement by the agent
        /// </summary>
        public float TotalDistance
        {
            get { return totalDistance; }
            set { totalDistance = value; }
        }

        public Experiment CurrentExperiment
        {
            get { return currentExperiment; }
            set { currentExperiment = value; }
        }

        public List<Actuator> Actuators
        {
            get { return actuators; }
            set { actuators = value; }
        }

        public List<Sensor> Sensors
        {
            get { return sensors; }
            set { sensors = value; }
        }

        /// <summary>
        /// This update function is intended for any behaviour that the agent should have which does 
        /// not relate to its visualization or its environment (i.e. updating its position)
        /// (these are handled by the appropriate agent component in the visualization system)
        /// </summary>        
        public void Update(float deltaTime)
        {

        }

        public Agent()
        {

        }        

        public void AddActuator(Actuator a)
        {
            if (!actuators.Contains(a))
                actuators.Add(a);
        }

        public void AddSensor(Sensor s)
        {
            if(!sensors.Contains(s))
                sensors.Add(s);
        }

        public void RemoveActuator(Actuator a)
        {
            if (actuators.Contains(a))
                actuators.Remove(a);
        }

        public void RemoveSensor(Sensor s)
        {
            if (sensors.Contains(s))
                sensors.Remove(s);
        }
    }
}
