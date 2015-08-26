using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphics.Tools.Noise;
using Graphics.Tools.Noise.Primitive;
using Graphics.Tools.Noise.Builder;
using Graphics.Tools.Noise.Filter;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

        /// <summary>
        /// Load a previously saved heightmap by filename
        /// </summary>        
        public static Heightmap LoadFromFile(string fullpath)
        {
            Heightmap map = null;
            FileStream stream = null;            

            if(File.Exists(fullpath))
            {                
                try
                {
                    Logging.Instance.Log("Loading Heightmap from " + fullpath);
                    stream = File.OpenRead(fullpath);
                    BinaryFormatter formatter = new BinaryFormatter();
                    map = (Heightmap)formatter.Deserialize(stream);
                }
                catch(Exception ex)
                {
                    Logging.Instance.Log("Failed to read file " + fullpath + " because: " + ex.Message);
                }
                finally
                {
                    if (stream != null)
                        stream.Close();
                }
            }            
            else
            {
                Logging.Instance.Log("File not found " + fullpath);
            }

            return map;
        }                

        /// <summary>
        /// Serialize the heightmap to file
        /// </summary>
        public void Save(string fullpath)
        {            
            if(File.Exists(fullpath))
            {
                File.Delete(fullpath);
                Logging.Instance.Log("Deleting old file " + fullpath);
            }

            Logging.Instance.Log("Saving Heightmap to " + fullpath);
            FileStream stream = null;
            try
            {
                stream = File.Create(fullpath);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);                
            }
            catch(Exception ex)
            {
                Logging.Instance.Log("Failed to write file " + fullpath + " because: " + ex.Message);
            }
            finally
            {
                if(stream != null)
                    stream.Close();
            }
        }
        public void SaveAs(string newname, string fullpath)
        {
            filename = newname;
            Save(fullpath);
        }

        //convert height into scene graph range
        public float GetSceneHeight(float x, float z)
        {
            return (GetHeight(x, z) + 1) / 2;
        }        
        public float GetSceneHeight(int x, int z)
        {
            return (GetHeight(x, z) + 1) / 2;
        }

        /// <summary>
        /// Gets a height value, bilinearly interpolating between the nearest known values
        /// </summary>        
        public float GetHeight(float x, float z)
        {
            int floorx = (int)Math.Floor((double)x);
            int floorz = (int)Math.Floor((double)z);
            int ceilx = floorx+1;
            int ceilz = floorz+1;            

            //get the heights at the four surrounding points
            float q11 = GetHeight(floorx, floorz);
            float q21 = GetHeight(ceilx, floorz);
            float q12 = GetHeight(floorx, ceilz);
            float q22 = GetHeight(ceilx, ceilz);            

            //billinear interpolation
            return Maths.BLerp(x,z,floorx,ceilx,floorz,ceilz,q11,q21,q12,q22);
        }

        public float GetHeight(int x, int z)
        {
            if (x < 0) x = 0;
            if (z < 0) z = 0;
            if (x > heights.GetUpperBound(0)) x = heights.GetUpperBound(0);
            if (z > heights.GetUpperBound(1)) z = heights.GetUpperBound(1);

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
