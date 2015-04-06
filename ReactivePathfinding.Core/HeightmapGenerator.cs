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
    public class HeightmapGenerator
    {
        private ImprovedPerlin noiseModule;
        private NoiseMap heightMap;
        private NoiseMapBuilderPlane heightMapBuilder;
        private SumFractal filter;

        private HeightmapSettings settings;

        /// <summary>
        /// A heightmap in the xz plane (y is the height)
        /// </summary>
        public NoiseMap HeightMap
        {
            get { return heightMap; }
            set { heightMap = value; }
        }

        public void Initialise(HeightmapSettings hms)
        {
            settings = hms;

            noiseModule = new SimplexPerlin(settings.Seed, NoiseQuality.Best);
            heightMap = new NoiseMap();
            heightMapBuilder = new NoiseMapBuilderPlane();
            filter = new SumFractal();

            filter.OctaveCount = settings.Octaves;
            filter.Lacunarity = settings.Lacunarity;
            filter.Offset = settings.Offset;
            filter.Gain = settings.Gain;
            filter.SpectralExponent = settings.Spectral;
            filter.Primitive3D = noiseModule;

            heightMapBuilder.SourceModule = filter;
            heightMapBuilder.NoiseMap = heightMap;
            heightMapBuilder.SetSize(settings.SampleWidth, settings.SampleHeight);
            heightMapBuilder.SetBounds(0f, 1f, 0f, 1f);
            heightMapBuilder.Build();
        }
    }
}
