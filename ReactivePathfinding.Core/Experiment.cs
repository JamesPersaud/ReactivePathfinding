using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphics.Tools.Noise.Builder;

namespace ReactivePathfinding.Core
{
    public class Experiment
    {        
        private PRNG random = null;
        private string name = string.Empty;

        private Heightmap currentHeightmap = null;
        private HeightmapSettings currentHeightmapSettings = null;

        public HeightmapSettings CurrentHeightmapSettings
        {
            get { return currentHeightmapSettings; }
        }

        public Heightmap CurrentHeightmap
        {
            get { return currentHeightmap; }            
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
