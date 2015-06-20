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
        private int populationSize;
        private float crossoverRate;
        private float mutationRate;
        private float elitismThreshold;        

        private List<Generation> previousGenerations = new List<Generation>();
        private Generation currentGeneration;

        //parameters related to cost of movement
        private float baseMovementCostMultiplier = 1;        
        private float descendingbaseMovementCostMultiplier = 0;
        private float ascendingMovementCostMultiplier = 0;

        //agent parameters
        private float agentMaxMovementSpeed = 4f;
        private float agentRadius = 0.5f;
        private float agentMaxTurnSpeed = 360;
        private float agentMinTurnSpeed = 5;

        //sensor parameters
        private float sensorHorizontalFOV = 90f;

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
        /// max number of degrees the agent can turn through in one second (if one motor is at 1 while the other is at 0)
        /// </summary>
        public float AgentMaxTurnSpeed
        {
            get { return agentMaxTurnSpeed; }
            set { agentMaxTurnSpeed = value; }
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

        public float ElitismThreshold
        {
            get { return elitismThreshold; }
            set { elitismThreshold = value; }
        }

        public float CrossoverRate
        {
            get { return crossoverRate; }
            set { crossoverRate = value; }
        }

        public float MutationRate
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
        /// Reset the current random terrain to a new random terrain
        /// </summary>
        public void NewRandomTerrain()
        {
            if (currentHeightmap == null)
                currentHeightmap = Heightmap.CreateProceduralHeightmap(currentHeightmapSettings);

            currentHeightmap.Initialise(currentHeightmapSettings);
            
        }

        public Experiment(string n)
        {
            random = new PRNG();
            name = n;

            Logging.Instance.Log("Created new Experiment called " + name);
            currentHeightmapSettings = new HeightmapSettings();            
        }

        public Experiment()
        {

        }
    }
}
