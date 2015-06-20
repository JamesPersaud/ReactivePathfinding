using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    public enum EmitterTypes
    {        
        INVERSE_SQUARE
    }

    /// <summary>
    /// Represents the target for an agent based on a point that radiates a signal of
    /// intensity proportional to the distance between the agent and the target
    /// </summary>
    public class Target
    {
        private float baseIntensity;
        private EmitterTypes emitterType;
        private float radius;
        private Experiment currentExperiment;

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
