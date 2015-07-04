using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    /// <summary>
    /// Represents a fitness function for use by a genetic algorithm
    /// 
    /// Also contains static methods to return standard fitness functions
    /// 
    /// </summary>
    public class FitnessFunction
    {
        private string name;
        private string explanation;        
        private FitnessFunctionType functionType;
        private StandardFitnessResolver resolver;

        /// <summary>
        /// Specifies the function to resolve the fitness of an agent
        /// </summary>
        public StandardFitnessResolver Resolver
        {
            get { return resolver; }
            set { resolver = value; }
        }

        public string Explanation
        {
            get { return explanation; }
            set { explanation = value; }
        }

        public FitnessFunctionType FunctionType
        {
            get { return functionType; }
            set { functionType = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }        

        public float CalculateFitness(Agent a)
        {            
            if(functionType == FitnessFunctionType.STANDARD)
            {
                return resolver(a);
            }
            else
            {
                //run user specified function
                return 0;
            }            
        }

        public static List<FitnessFunction> GetStandardFunctions()
        {
            List<FitnessFunction> functions = new List<FitnessFunction>();

            FitnessFunction f = new FitnessFunction();
            f.FunctionType = FitnessFunctionType.STANDARD;
            f.name = "Total moved";
            f.explanation = "Fitness depends on distance travelled, target and height is ignored";
            f.resolver = (agent) => 
            {
                return agent.TotalDistance;
            };
            functions.Add(f);

            f = new FitnessFunction();
            f.FunctionType = FitnessFunctionType.STANDARD;
            f.name = "Target";
            f.explanation = "Fitness depends on closest approach to target + success factor + average speed.";
            f.resolver = (agent) =>
            {
                return DistanceToTarget(agent) + ReachedTarget(agent) + AverageSpeed(agent);
            };
            functions.Add(f);

            f = new FitnessFunction();
            f.FunctionType = FitnessFunctionType.STANDARD;
            f.name = "Target - path(0,0)";
            f.explanation = "Fitness depends on closest approach to target + success factor + average speed - base cost of path";
            f.resolver = (agent) =>
            {
                return DistanceToTarget(agent) + ReachedTarget(agent) + AverageSpeed(agent) - CostOfPath(agent,0,0);
            };
            functions.Add(f);

            f = new FitnessFunction();
            f.FunctionType = FitnessFunctionType.STANDARD;
            f.name = "Target - path(1,0)";
            f.explanation = "Fitness depends on closest approach to target + success factor + average speed - (base cost of path + cost of ascending movement * 1)";
            f.resolver = (agent) =>
            {
                return DistanceToTarget(agent) + ReachedTarget(agent) + AverageSpeed(agent) - CostOfPath(agent, 1, 0);
            };
            functions.Add(f);

            f = new FitnessFunction();
            f.FunctionType = FitnessFunctionType.STANDARD;
            f.name = "Target - path(0,1)";
            f.explanation = "Fitness depends on closest approach to target + success factor + average speed - (base cost of path + cost of descending movement * 1)";
            f.resolver = (agent) =>
            {
                return DistanceToTarget(agent) + ReachedTarget(agent) + AverageSpeed(agent) - CostOfPath(agent, 0, 1);
            };
            functions.Add(f);

            f = new FitnessFunction();
            f.FunctionType = FitnessFunctionType.STANDARD;
            f.name = "Target - path(1,1)";
            f.explanation = "Fitness depends on closest approach to target + success factor + average speed - (base cost of path + cost of descending movement * 1 + cost of ascending movement * 1)";
            f.resolver = (agent) =>
            {
                return DistanceToTarget(agent) + ReachedTarget(agent) + AverageSpeed(agent) - CostOfPath(agent, 1, 1);
            };
            functions.Add(f);     

            return functions;
        }

        public override string ToString()
        {
            return name;
        }

        /// <summary>
        /// Standard fitness function helper function returns a value between 0 and InitialTargetDistance
        /// gets the average speed of the agent as a fraction of its max speed and multiplies by InitialTargetDistance
        /// </summary>        
        public static float AverageSpeed(Agent a)
        {
            return ((a.TotalDistance / a.TotalTime) / a.CurrentExperiment.AgentMaxMovementSpeed) * a.InitialTargetDistance;
        }

        /// <summary>
        /// Standard fitness function helper function returns a value between 1 and InitialTargetDistance 
        /// depending on how cose to the target the agent came.
        /// </summary>        
        public static float DistanceToTarget(Agent a)
        {
            if (a.ReachedTarget)
                return a.InitialTargetDistance;

            return a.InitialTargetDistance / (float)Math.Max(a.ClosestToTarget,1);
        }

        /// <summary>
        /// Standard fitness function helper function returns 0 if the agent did not reach the target and InitialTargetDistance if it did
        /// </summary>        
        public static float ReachedTarget(Agent a)
        {
            if (a.ReachedTarget)
                return a.InitialTargetDistance;
            else
                return 0;
        }

        /// <summary>
        /// The total cost of the path including adjustment to penalize height changes
        /// </summary>
        public static float CostOfPath(Agent a, int penalizeAscending, int penalizeDescending)
        {
            float cost = a.TotalDistance;
            cost += penalizeDescending * a.TotalDescending;            
            cost += penalizeAscending * a.TotalAscending;

            return cost;
        }
    }    

    public delegate float StandardFitnessResolver(Agent a);

    public enum FitnessFunctionType
    {
        STANDARD, CUSTOM
    }
}
