using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    [Serializable]
    public enum EmitterTypes
    {        
        INVERSE_SQUARE
    }

    /// <summary>
    /// Represents the target for an agent based on a point that radiates a signal of
    /// intensity proportional to the distance between the agent and the target
    /// </summary>
    [Serializable]
    public class Target
    {
        private float baseIntensity = 1;
        private EmitterTypes emitterType = EmitterTypes.INVERSE_SQUARE;
        private float radius = 0;
        private float physicalRadius = 1;     
        private Experiment currentExperiment;
        private IPosition3F position;

        public IPosition3F Position
        {
            get { return position; }
            set { position = value; }
        }

        public Experiment CurrentExperiment
        {
            get { return currentExperiment; }
            set { currentExperiment = value; }
        }
        
        /// <summary>
        /// The effective radius is a means by which to control the falloff of the intensity of the target.
        /// </summary>
        public float EffectiveRadius
        {
            get { return radius; }
            set { radius = value; }
        }

        /// <summary>
        /// The actual radius of the target area 
        /// </summary>
        public float PhysicalRadius
        {
            get { return physicalRadius; }
            set { physicalRadius = value; }
        }

        public EmitterTypes EmitterType
        {
            get { return emitterType; }
            set { emitterType = value; }
        }

        public float BaseIntensity
        {
            get { return baseIntensity; }
            set { baseIntensity = value; }
        }

        public Target(float baseintensity, float rad, EmitterTypes type)
        {
            this.BaseIntensity = baseintensity;
            this.radius = rad;
            this.EmitterType = type;
        }

        public float GetIntensityAtDistance(float distance)
        {
            distance = (distance +1) / radius;

            if (emitterType == EmitterTypes.INVERSE_SQUARE)
                distance *= distance;

            return baseIntensity * 1 / distance;
        }
    }
}
