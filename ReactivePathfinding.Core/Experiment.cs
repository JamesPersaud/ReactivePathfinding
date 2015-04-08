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
        private PRNG random = null;
        private string name = string.Empty;

        private Heightmap currentHeightmap = null;
        private HeightmapSettings currentHeightmapSettings = null;

        private string filename;
        private string heightmapFilename;

        private bool isNew = true;

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
