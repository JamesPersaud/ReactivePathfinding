using System;
using System.Collections.Generic;

namespace ReactivePathfinding.Core
{
    /// <summary>
    /// TODO
    /// 
    /// Save/load settings
    /// 
    /// </summary>
    [Serializable]
    public class HeightmapSettings
    {        
        public const int DEFAULT_MAP_WIDTH = 128;
        public const int DEFAULT_MAP_HEIGHT = 128;

        public const int DEFAULT_SAMPLEWIDTH = 256;
        public const int DEFAULT_SAMPLEHEIGHT = 256;
        public const int DEFAULT_SEED = 6587687;

        public const float DEFAULT_OCTAVES = 6f;
        public const float DEFAULT_FREQUENCY = 2f;
        public const float DEFAULT_LACUNARITY = 2f;
        public const float DEFAULT_OFFSET = 1f;
        public const float DEFAULT_GAIN = 2f;
        public const float DEFAULT_SPECTRAL = 0.9f;
        public const float DEFAULT_SMOOTH = 1f;

        private int sampleWidth;
        private int sampleHeight;
        private int seed;

        private float octaves;
        private float lacunarity;
        private float offset;
        private float gain;
        private float spectral;
        private float frequency;
        private float smooth;

        private int mapHeight;
        private int mapWidth;

        public float Smooth
        {
            get { return smooth; }
            set { smooth = value; }
        }                

        public float Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

        public int MapWidth
        {
            get { return mapWidth; }
            set { mapWidth = value; }
        }

        public int MapHeight
        {
            get { return mapHeight; }
            set { mapHeight = value; }
        }

        public float Spectral
        {
            get { return spectral; }
            set { spectral = value; }
        }

        public float Gain
        {
            get { return gain; }
            set { gain = value; }
        }

        public float Offset
        {
            get { return offset; }
            set { offset = value; }
        }

        public float Lacunarity
        {
            get { return lacunarity; }
            set { lacunarity = value; }
        }

        public float Octaves
        {
            get { return octaves; }
            set { octaves = value; }
        }

        public int Seed
        {
            get { return seed; }
            set { seed = value; }
        }

        public int SampleWidth
        {
            get { return sampleWidth; }
            set { sampleWidth = value; }
        }

        public int SampleHeight
        {
            get { return sampleHeight; }
            set { sampleHeight = value; }
        }

        public HeightmapSettings()
        {
            sampleWidth = DEFAULT_SAMPLEWIDTH;
            sampleHeight = DEFAULT_SAMPLEHEIGHT;
            seed = DEFAULT_SEED;

            octaves = DEFAULT_OCTAVES;
            lacunarity = DEFAULT_LACUNARITY;
            offset = DEFAULT_OFFSET;
            gain = DEFAULT_GAIN;
            spectral = DEFAULT_SPECTRAL;
            frequency = DEFAULT_FREQUENCY;

            mapHeight = DEFAULT_MAP_HEIGHT;
            mapWidth = DEFAULT_MAP_WIDTH;

            smooth = DEFAULT_SMOOTH;
        }

        public override string ToString()
        {
            string s = string.Empty;

            s += "Seed         " + seed.ToString() + Environment.NewLine;
            s += Environment.NewLine;
            s += "Map Size     " + mapWidth.ToString() + "x" + mapHeight.ToString() + Environment.NewLine;
            s += "Sample Size  " + sampleWidth.ToString() + "x" + sampleHeight.ToString() + Environment.NewLine;
            s += Environment.NewLine;
            s += "Octaves      " + Octaves.ToString() + Environment.NewLine;
            s += "Frequency    " + Frequency.ToString() + Environment.NewLine; 
            s += "Lacunarity   " + Lacunarity.ToString() + Environment.NewLine;
            s += "Spectral Exp " + Spectral.ToString() + Environment.NewLine;
            s += Environment.NewLine;
            s += "Smoothness   " + Smooth.ToString() + Environment.NewLine;
            s += Environment.NewLine;
            s += "Gain         " + Gain.ToString() + Environment.NewLine;
            s += "Offset       " + Offset.ToString();

            return s;
        }
    }
}
