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
    [Serializable]
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
            f.name = "Target - Path";
            f.explanation = "Fitness depends on (initial dist / closest approach) + success factor of (initial dist * 2) - (path cost/bestPath cost * initial dist.)";
            f.resolver = (agent) =>
            {
                float fitness = DistanceToTarget(agent) + ReachedTarget(agent);

                if (agent.ReachedTarget)
                    fitness -= CostOfPath(agent, agent.CurrentExperiment.SearchCostFunction.AscendingMultiplier, agent.CurrentExperiment.SearchCostFunction.DescendingMultiplier);

                return fitness;
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
        /// 
        /// The value is returned as a proportion of the best path cost, multiplied by the initial target distance
        /// 
        /// </summary>
        public static float CostOfPath(Agent a, int penalizeAscending, int penalizeDescending)
        {
            float cost = a.TotalDistance;
            cost += penalizeDescending * a.TotalDescending;
            cost += penalizeAscending * a.TotalAscending;

            cost = cost / a.CurrentExperiment.BestPath.PathCost;

            return cost * a.InitialTargetDistance;
        }
    }

    [Serializable]
    public delegate float StandardFitnessResolver(Agent a);

    [Serializable]
    public enum FitnessFunctionType
    {
        STANDARD, CUSTOM
    }
}
