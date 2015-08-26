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
    [Serializable]
    public class Agent : IComparable<Agent>
    {
        private List<Sensor> sensors = new List<Sensor>();
        private List<Actuator> actuators = new List<Actuator>();
        private Experiment currentExperiment;
        private float totalDistance =0;
        private float totalAscending =0;
        private float totalDescending =0;
        private float closestToTarget = -1;
        private float initialTargetDistance = -1;   
        private bool reachedTarget;
        private float totalTime;
        private float timeSinceLastImprovement = 0;        
        private BoundaryFloatGenome weightGenome;
        private int nextSensorIndex = 1;
        private int nextActuatorIndex = 1;
        private float timeToReachTarget = 0;
        private float totalDistanceForward = 0;        

        private string name;
        private IPosition3F position;

        private float fitness;

        public float TotalDistanceForward
        {
            get { return totalDistanceForward; }
            set { totalDistanceForward = value; }
        }

        public float TimeToReachTarget
        {
            get { return timeToReachTarget; }
            set { timeToReachTarget = value; }
        }

        public float TimeSinceLastImprovement
        {
            get { return timeSinceLastImprovement; }
            set { timeSinceLastImprovement = value; }
        }

        public float InitialTargetDistance
        {
            get { return initialTargetDistance; }
            set { initialTargetDistance = value; }
        }

        /// <summary>
        /// Score is calculated by applying the fitness function of the current experiment to the 
        /// agent's performance criteria
        /// 
        /// Agents' scores are set via the controlling object of the experiment
        /// 
        /// </summary>
        public float Fitness
        {
            get { return fitness; }
            set { fitness = value; }
        }

        public IPosition3F Position
        {
            get { return position; }
            set { position = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Connection[] Connections
        {
            get
            {
                Connection[] connections = new Connection[GenomeSize];

                int index = 0;
                for (int i = 0; i < sensors.Count; i++)
                    for (int j = 0; j < sensors[i].Connections.Count; j++)
                    {
                        connections[index] = sensors[i].Connections[j];
                        index++;
                    }                        

                return connections;
            }
        }

        public int GenomeSize
        {
            get
            {
                int count = 0;
                for (int i = 0; i < sensors.Count; i++)
                    for (int j = 0; j < sensors[i].Connections.Count; j++)
                        count++;

                return count;
            }
        }

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
        /// Is this agent still active?
        /// </summary>
        public bool IsAlive
        {
            get
            {
                //won
                if (reachedTarget)
                    return true;
                //timed out
                if (timeSinceLastImprovement >= currentExperiment.AgentFitnessImprovementTimeoutSeconds)
                    return false;
                //expired
                if (totalTime >= currentExperiment.MaxAgentLifetimeSeconds)
                    return false;

                return true;
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
        /// not relate to its visualization or its environment (i.e. updating its position or drawing it)        
        /// </summary>        
        public void Update(float deltaTime, float dx, float dy, float dz, float deltaDistance)
        {            
            if (IsAlive && !reachedTarget)
            {                
                totalTime += deltaTime;
                totalDistance += Math.Abs(deltaDistance);

                if (dz > 0)
                    totalAscending += dz;
                if (dz < 0)
                    totalDescending += Math.Abs(dz);

                if (CurrentExperiment != null)
                {
                    //distance to target
                    float distainceToTarget = Math.Max(Position.Distance(currentExperiment.CurrentTarget.Position), 0.01f);

                    //has agent reached target?
                    if (distainceToTarget <= currentExperiment.AgentRadius + currentExperiment.CurrentTarget.PhysicalRadius)
                    {
                        reachedTarget = true;
                        timeToReachTarget = totalTime;
                    }

                    if (initialTargetDistance < 0)
                    {
                        initialTargetDistance = distainceToTarget;
                        closestToTarget = distainceToTarget;
                    }
                    else
                    {
                        if (distainceToTarget < closestToTarget)
                        {
                            closestToTarget = distainceToTarget;
                            timeSinceLastImprovement = 0;
                        }
                        else
                        {
                            timeSinceLastImprovement += deltaTime;
                        }
                    }

                    //fitness function
                    if (currentExperiment.CurrentFitnessFunction != null)
                        fitness = currentExperiment.CurrentFitnessFunction.CalculateFitness(this);
                }
            }
        }

        public Agent()
        {

        }

        /// <summary>
        /// Create an agent as a copy of another agent
        /// </summary>
        /// <param name="other"></param>
        public Agent(Agent other)
        {
            //clone actuators                        
            for (int i = 0; i < other.actuators.Count; i++)
            {                
                Actuator new_actuator = other.actuators[i].Clone();                                      
                this.AddActuator(new_actuator);
                new_actuator.Index = other.actuators[i].Index;
            }
            //clone sensors            
            for (int i = 0; i < other.sensors.Count; i++)
            {                                
                //todo move cloning behaviour to the sensor class and subclasses
                Sensor old_sensor = other.sensors[i];
                Sensor new_sensor = null;

                if (old_sensor.SensorType == SensorTypes.TARGET)
                    new_sensor = new TargetSensor(old_sensor.Location);
                else if (old_sensor.SensorType == SensorTypes.HEIGHT)
                    new_sensor = new HeightSensor();
                else if (old_sensor.SensorType == SensorTypes.HEIGHTMAP_GRADIENT)
                    new_sensor = new GradientSensor(old_sensor.Location);
                else
                    new_sensor = new Sensor(old_sensor.Location, old_sensor.Direction);

                new_sensor.SensorType = old_sensor.SensorType;
                new_sensor.Name = old_sensor.Name;
                
                this.AddSensor(new_sensor);
                new_sensor.Index = old_sensor.Index;
            }
            //clone connections
            foreach(Connection old_connection in other.Connections)
            {
                Connection new_connection = new Connection(
                    this.getSensorByIndex(old_connection.ConnectedSensor.Index),
                    this.getActuatorByIndex(old_connection.ConnectedActuator.Index),
                    old_connection.Weight, old_connection.ConnectionType);
            }

            this.WeightGenome = (BoundaryFloatGenome)other.WeightGenome.Clone();
        }                

        public Actuator getActuatorByIndex(int i)
        {
            foreach (Actuator a in this.Actuators)
                if (a.Index == i) return a;

            return null;
        }

        public Sensor getSensorByIndex(int i)
        {
            foreach (Sensor s in this.Sensors)
                if (s.Index == i) return s;

            return null;
        }

        public void AddActuator(Actuator a)
        {
            if (!actuators.Contains(a))
            {
                a.Index = nextActuatorIndex++;
                actuators.Add(a);
            }
        }

        public void AddSensor(Sensor s)
        {
            if (!sensors.Contains(s))
            {
                s.Index = nextSensorIndex++;
                sensors.Add(s);
            }
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

        //sorting
        public int CompareTo(Agent other)
        {
            if (this.fitness > other.fitness)
                return -1;
            else if (this.fitness < other.fitness)
                return 1;
            else
                return 0;
        }
    }    
}
