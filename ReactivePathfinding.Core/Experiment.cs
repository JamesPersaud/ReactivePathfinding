using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphics.Tools.Noise.Builder;

namespace ReactivePathfinding.Core
{
    [Serializable]
    public class Experiment
    {
        //time parameters
        private int stepPeriodMilliseconds = 16;
        private float stepPeriodSeconds = 1f / 60f;

        //basic attributes
        private string name = string.Empty;

        //random number generator
        private PRNG random = null;        

        //Height map
        private Heightmap currentHeightmap = null;
        private HeightmapSettings currentHeightmapSettings = null;

        //File system settings
        private string filename;
        private string heightmapFilename;
        //load/save flag
        private bool isNew = true;

        //GA parameters
        private int populationSize = 20;
        private int crossoverRate = 50;
        private int mutationRate = 20;
        private int elites = 0;
        private bool mutateOnSelection = true;
        private bool mutateDuringCrossover = true;

        //generations
        private int generationIndex = 0;
        private List<Generation> previousGenerations = new List<Generation>();
        private Generation currentGeneration;

        //parameters related to cost of movement
        private float baseMovementCostMultiplier = 1;
        private float descendingbaseMovementCostMultiplier = 0;
        private float ascendingMovementCostMultiplier = 0;

        //agent parameters
        private float agentMaxMovementSpeed = 4f;
        private float agentRadius = 0.5f;        
        private float agentMinTurnSpeed = 5;
        private float maxAgentLifetimeSeconds = 30; //The number of seconds to allow an agent to exist for before declaring it dead
        private float agentFitnessImprovementTimeoutSeconds = 15; //The number of seconds to wait for an agent to improve on its fitness score before declaring it dead

        //sensor parameters
        private float sensorHorizontalFOV = 90f;

        //agent tolpology
        private AgentTemplate currentTopology = null;

        //start and target positions for agents
        private Target currentTarget = null;
        private Startpoint currentStartpoint = null;

        //fitness
        private FitnessFunction currentFitnessFunction = null;

        //pathfinding
        private AStarPath bestPath = null;

        public AStarPath BestPath
        {
            get { return bestPath; }
            set { bestPath = value; }
        }

        public float MaxAgentLifetimeSeconds
        {
            get { return maxAgentLifetimeSeconds; }
            set { maxAgentLifetimeSeconds = value; }
        }

        public float AgentFitnessImprovementTimeoutSeconds
        {
            get { return agentFitnessImprovementTimeoutSeconds; }
            set { agentFitnessImprovementTimeoutSeconds = value; }
        }

        public List<Generation> PreviousGenerations
        {
            get { return previousGenerations; }            
        }

        public Generation CurrentGeneration
        {
            get { return currentGeneration; }
        }

        public bool MutateDuringCrossover
        {
            get { return mutateDuringCrossover; }
            set { mutateDuringCrossover = value; }
        }

        public bool MutateOnSelection
        {
            get { return mutateOnSelection; }
            set { mutateOnSelection = value; }
        }

        public int GenerationIndex
        {
            get { return generationIndex; }
            set { generationIndex = value; }
        }

        public float StepPeriodSeconds
        {
            get { return stepPeriodSeconds; }
            set { stepPeriodSeconds = value; }
        }

        public int StepPeriodMilliseconds
        {
            get { return stepPeriodMilliseconds; }
            set { stepPeriodMilliseconds = value; }
        }

        public FitnessFunction CurrentFitnessFunction
        {
            get { return currentFitnessFunction; }
            set { currentFitnessFunction = value; }
        }

        public Startpoint CurrentStartpoint
        {
            get { return currentStartpoint; }
            set { currentStartpoint = value; }
        }

        public Target CurrentTarget
        {
            get { return currentTarget; }
            set { currentTarget = value; }
        }

        public AgentTemplate CurrentAgentTopology
        {
            get { return currentTopology; }
            set { currentTopology = value; }
        }

        public float SensorHorizontalFOV
        {
            get { return sensorHorizontalFOV; }
            set { sensorHorizontalFOV = value; }
        }

        /// <summary>
        /// min number of degrees the agent can turn through in one second 
        /// avoids the situation where no sensor has line of sight to the emitter and the difference between
        /// residual readings is minute
        /// </summary>
        public float AgentMinTurnSpeed
        {
            get { return agentMinTurnSpeed; }
            set { agentMinTurnSpeed = value; }
        }        

        /// <summary>
        /// agent radius in units
        /// </summary>
        public float AgentRadius
        {
            get { return agentRadius; }
            set { agentRadius = value; }
        }        

        /// <summary>
        /// max agent units per second
        /// </summary>
        public float AgentMaxMovementSpeed
        {
            get { return agentMaxMovementSpeed; }
            set { agentMaxMovementSpeed = value; }
        }

        /// <summary>
        /// movements up a gradient will be multiplied
        /// </summary>
        public float AscendingMovementCostMultiplier
        {
            get { return ascendingMovementCostMultiplier; }
            set { ascendingMovementCostMultiplier = value; }
        }

        public float DescendingbaseMovementCostMultiplier
        {
            get { return descendingbaseMovementCostMultiplier; }
            set { descendingbaseMovementCostMultiplier = value; }
        }

        public float BaseMovementCostMultiplier
        {
            get { return baseMovementCostMultiplier; }
            set { baseMovementCostMultiplier = value; }
        }

        public int Elites
        {
            get { return elites; }
            set { elites = value; }
        }

        public int CrossoverRate
        {
            get { return crossoverRate; }
            set { crossoverRate = value; }
        }

        public int MutationRate
        {
            get { return mutationRate; }
            set { mutationRate = value; }
        }       

        public int PopulationSize
        {
            get { return populationSize; }
            set { populationSize = value; }
        }

        public bool IsNew
        {
            get { return isNew; }
            set { isNew = value; }
        }

        /// <summary>
        /// Used to save a link between experiment and heightmap
        /// </summary>
        public string HeightmapFilename
        {
            get { return heightmapFilename; }
            set { heightmapFilename = value; }
        }

        public KeyValuePair<int, float> LifetimeBestAvgFitness
        {
            get
            {
                if (previousGenerations == null || previousGenerations.Count < 1) return new KeyValuePair<int,float>(0,0);

                float max = -float.MaxValue;
                int id = 0;

                foreach (Generation g in previousGenerations)
                {
                    if (g.FinalAvgFitness > max)
                    {
                        max = g.FinalAvgFitness;
                        id = g.GenerationID;
                    }
                }

                return new KeyValuePair<int, float>(id, max);
            }
        }

        public KeyValuePair<int,float> LifetimeBestMinFitness
        {
            get
            {
                if (previousGenerations == null || previousGenerations.Count < 1) return new KeyValuePair<int,float>(0,0);

                float max = -float.MaxValue;
                int id = 0;

                foreach (Generation g in previousGenerations)
                {
                    if (g.FinalMinFitness > max)
                    {
                        max = g.FinalMinFitness;
                        id = g.GenerationID;
                    }
                }
                
                return new KeyValuePair<int,float>(id,max);
            }
        }

        public KeyValuePair<int, float> LifetimeMaxFitness
        {
            get
            {
                if (previousGenerations == null || previousGenerations.Count < 1) return new KeyValuePair<int,float>(0,0);

                float max = -float.MaxValue;
                int id = 0;

                foreach (Generation g in previousGenerations)
                {
                    if (g.FinalMaxFitness > max)
                    {
                        max = g.FinalMaxFitness;
                        id = g.GenerationID;
                    }
                }

                return new KeyValuePair<int, float>(id, max);
            }        
        }

        public string Filename
        {
            get
            {
                if (isNew)
                    return "{Not Saved}";
                else
                    return filename;
            }
            set { filename = value; }
        }

        public HeightmapSettings CurrentHeightmapSettings
        {
            get { return currentHeightmapSettings; }
        }

        public Heightmap CurrentHeightmap
        {
            get { return currentHeightmap; }
            set
            {
                currentHeightmap = value;
            }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public PRNG Random
        {
            get { return random; }
        }

        /// <summary>
        /// Update anything not related to the position of things in the scene or otherwise tied to a scene component
        /// </summary>
        public void Update()
        {
            if (currentGeneration != null)
                currentGeneration.Update(stepPeriodSeconds);
        }

        /// <summary>
        /// Advances the experiment to the next generation.
        /// </summary>
        public void NextGeneration()
        {            
            if(currentGeneration == null)
            {
                //first generation
                currentGeneration = Generation.GetInitialGeneration(this);
            }
            else
            {
                if (previousGenerations == null)
                    previousGenerations = new List<Generation>();

                previousGenerations.Add(currentGeneration);
                currentGeneration = currentGeneration.EvolveNextGeneration();
            }
            
            currentGeneration.GenerationID = ++GenerationIndex;
        }

        /// <summary>
        /// Reset the current random terrain to a new random terrain
        /// </summary>
        public void NewRandomTerrain()
        {
            if (currentHeightmap == null)
                currentHeightmap = Heightmap.CreateProceduralHeightmap(currentHeightmapSettings);

            currentHeightmap.Initialise(currentHeightmapSettings);
            
        }

        private void Init(string n, int seed)
        {            
            random = new PRNG();
            if (seed >= 0)
                random.Seed(seed);

            name = n;

            Logging.Instance.Log("Created new Experiment called " + name);
            currentHeightmapSettings = new HeightmapSettings();                  
        }

        public Experiment(string n)
        {
            Init(n, -1);
        }        

        public Experiment()
        {
            Init("Unnamed Experiment", -1);
        }

        public Experiment(string n, int seed)
        {
            Init(n, seed);
        }
    }
}
