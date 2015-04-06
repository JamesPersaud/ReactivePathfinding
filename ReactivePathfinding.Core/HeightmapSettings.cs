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
    public class HeightmapSettings
    {
        public const int DEFAULT_SAMPLEWIDTH = 120;
        public const int DEFAULT_SAMPLEHEIGHT = 120;
        public const int DEFAULT_SEED = 6587687;

        public const float DEFAULT_OCTAVES = 6f;
        public const float DEFAULT_LACUNARITY = 2f;
        public const float DEFAULT_OFFSET = 1f;
        public const float DEFAULT_GAIN = 2f;
        public const float DEFAULT_SPECTRAL = 0.9f;

        private int sampleWidth;
        private int sampleHeight;
        private int seed;

        private float octaves;
        private float lacunarity;
        private float offset;
        private float gain;
        private float spectral;            

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
        }        
    }
}
