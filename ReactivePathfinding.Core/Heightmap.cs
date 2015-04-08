using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphics.Tools.Noise;
using Graphics.Tools.Noise.Primitive;
using Graphics.Tools.Noise.Builder;
using Graphics.Tools.Noise.Filter;

namespace ReactivePathfinding.Core
{
    [Serializable]
    public class Heightmap
    {
        private ImprovedPerlin noiseModule;
        private NoiseMap proceduralNoise;
        private NoiseMapBuilderPlane proceduralNoiseBuilder;
        private SumFractal filter;

        private HeightmapSettings settings;
        private HeightMapType type;

        private string filename;

        private float[,] heights;

        private bool isNew = true;

        public bool IsNew
        {
            get { return isNew; }
            set { isNew = value; }
        }

        public string Filename
        {
            get
            {
                if (isNew)
                    return "{New Heightmap}";
                else
                    return filename; 
            }
            set { filename = value; }
        }

        public HeightmapSettings Settings
        {
            get { return settings; }
        }

        public HeightMapType MapType
        {
            get { return type; }            
        }

        /// <summary>
        /// A heightmap in the xz plane (y is the height)
        /// </summary>
        public NoiseMap ProceduralNoise
        {
            get { return proceduralNoise; }
            set { proceduralNoise = value; }
        }

        public float GetHeight(int x, int z)
        {
            return heights[x, z];            
        }

        public static Heightmap CreateHeightmap(HeightmapSettings hms, HeightMapType t)
        {
            Heightmap map = new Heightmap();
            map.Initialise(hms,t);
            return map;
        }

        public static Heightmap CreateProceduralHeightmap(HeightmapSettings hms)
        {
            Heightmap map = new Heightmap();
            map.Initialise(hms);
            return map;
        }

        /// <summary>
        /// Initialize a predefined heightmap
        /// </summary>        
        public void Initialise(HeightmapSettings hms, HeightMapType t)
        {
            if (t == HeightMapType.PROCEDURAL)
            {
                Initialise(hms);
                return;
            }

            settings = hms;
            type = t;

            heights = new float[settings.MapWidth, settings.MapHeight];

            //values to help make a conical hill
            double mida = (double)settings.MapWidth / 2.0;
            double midb = (double)settings.MapHeight / 2.0;
            //maximum distance a point can be from the centre
            double maxdist = Math.Sqrt(mida * mida + midb * midb);

            for (int x = 0; x < settings.MapWidth; x++)
            {
                for(int z =0; z < settings.MapHeight;z++)
                {
                    if (type == HeightMapType.PLANE)
                    {
                        heights[x, z] = 0f;
                    }
                    else if (type == HeightMapType.CONICAL_HILL)
                    {
                        double a = (double)x;
                        double b = (double)z;   

                        double da = Math.Abs(a - mida);
                        double db = Math.Abs(b - midb);

                        double dist = Math.Sqrt(da * da + db * db);
                        
                        //the height at this point will be the ratio of how close it is to the centre
                        heights[x, z] = 1f - (float)(dist / maxdist *2); // *2 because the range is -1 to 1
                    }
                }
            }            
        }

        /// <summary>
        /// Initialize a procedural heightmap
        /// </summary>        
        public void Initialise(HeightmapSettings hms)
        {
            settings = hms;
            type = HeightMapType.PROCEDURAL;

            noiseModule = new SimplexPerlin(settings.Seed, NoiseQuality.Best);
            proceduralNoise = new NoiseMap();
            proceduralNoiseBuilder = new NoiseMapBuilderPlane();
            filter = new SumFractal();

            filter.OctaveCount = settings.Octaves;
            filter.Frequency = settings.Frequency;
            filter.Lacunarity = settings.Lacunarity;
            filter.Offset = settings.Offset;
            filter.Gain = settings.Gain;
            filter.SpectralExponent = settings.Spectral;
            filter.Primitive3D = noiseModule;

            proceduralNoiseBuilder.SourceModule = filter;
            proceduralNoiseBuilder.NoiseMap = proceduralNoise;
            proceduralNoiseBuilder.SetSize(settings.SampleWidth, settings.SampleHeight);
            proceduralNoiseBuilder.SetBounds(0f, 1f, 0f, 1f);
            proceduralNoiseBuilder.Build();

            heights = new float[settings.MapWidth, settings.MapHeight];

            int x_separation = settings.SampleWidth / settings.MapWidth;
            int z_separation = settings.SampleHeight / settings.MapHeight;

            for (int x = 0; x < settings.MapWidth; x++)
            {
                for (int z = 0; z < settings.MapHeight; z++)
                {
                    heights[x, z] = (proceduralNoise.GetValue(x * x_separation, z * z_separation)) / settings.Smooth;

                    if (heights[x, z] < -1) heights[x, z] = - 1;
                    if (heights[x, z] > 1) heights[x, z] = 1;                    
                }
            }
        }

        public override string ToString()
        {
            string s = string.Empty;
            s += Filename + Environment.NewLine;
            s += MapType.ToString() + Environment.NewLine;
            s += Environment.NewLine;
            s += settings.ToString();

            return s;
        }
    }

    public enum HeightMapType
    {
        PROCEDURAL,
        PLANE,
        CONICAL_HILL
    }
}
