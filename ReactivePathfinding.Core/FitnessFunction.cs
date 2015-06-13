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
            f.resolver = (agent) => 
            {
                return agent.TotalDistance;
            };
            functions.Add(f);

            f = new FitnessFunction();
            f.FunctionType = FitnessFunctionType.STANDARD;
            f.name = "Closest to Target";
            f.resolver = (agent) =>
            {
                return agent.ClosestToTarget;
            };
            functions.Add(f);

            f = new FitnessFunction();
            f.functionType = FitnessFunctionType.STANDARD;
            f.name = "Time taken";
            f.resolver = (agent) =>
            {
                if (agent.ReachedTarget)
                    return agent.TotalTime;
                else
                    return 1000;
            };
            functions.Add(f);

            return functions;
        }

        public override string ToString()
        {
            return name;
        }
    }

    public delegate float StandardFitnessResolver(Agent a);

    public enum FitnessFunctionType
    {
        STANDARD, CUSTOM
    }
}
