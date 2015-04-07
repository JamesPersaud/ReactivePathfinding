﻿using System;
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
    public class Heightmap
    {
        private ImprovedPerlin noiseModule;
        private NoiseMap proceduralNoise;
        private NoiseMapBuilderPlane proceduralNoiseBuilder;
        private SumFractal filter;

        private HeightmapSettings settings;
        private HeightMapType type;

        private float[,] heights;

        public HeightMapType Type
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
                for(int y =0; y < settings.MapHeight;y++)
                {
                    if (type == HeightMapType.PLANE)
                    {
                        heights[x, y] = 0f;
                    }
                    else if (type == HeightMapType.CONICAL_HILL)
                    {
                        double a = (double)x;
                        double b = (double)y;                        

                        double da = Math.Abs(a - mida);
                        double db = Math.Abs(b - midb);

                        double dist = Math.Sqrt(da * da + db * db);
                        
                        //the height at this point will be the ratio of how close it is to the centre
                        heights[x, y] = 1f - (float)(dist / maxdist);
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
        }
    }

    public enum HeightMapType
    {
        PROCEDURAL,
        PLANE,
        CONICAL_HILL
    }
}