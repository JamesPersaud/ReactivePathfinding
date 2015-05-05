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

        public static List<FitnessFunction> GetStandardFunctions()
        {
            List<FitnessFunction> functions = new List<FitnessFunction>();

            FitnessFunction f = new FitnessFunction();
            f.name = "Total Distance";

            functions.Add(f);

            return functions;
        }

        public override string ToString()
        {
            return name;
        }
    }

    public enum FitnessFunctionType
    {
        STANDARD, CUSTOM
    }
}
