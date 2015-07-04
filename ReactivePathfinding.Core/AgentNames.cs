using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    /// <summary>
    /// This class is intended to add some richness to the front end of an application it is not strictly part of 
    /// the core behaviour of the application but it is helpful to assign distinguishable monikers to agents based
    /// on their genomes.
    /// </summary>
    public class AgentNames
    {
        public static string[] firstnames = new string[] { "Gregor","Charles","Edsger","Isaac", "Jean-Baptiste", "Ken", "Joseph","Valentino","Marvin", "Frank", "Patrick", "John"};
        public static string[] lastnames = new string[] { "Mendel", "Darwin", "Dijkstra", "Asimov","Lamarck", "Perlin", "Kruskal","Braitenberg", "Minsky", "Rosenblatt", "Hayes", "Searle"};
        public static string[] ordinals = new string[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII", "XIII", "XIV", "XV", "XVI", "XVII", "XVIII", "XIX", "XX" };

        /// <summary>
        /// Names agents with a firstname based on the first half of their genome
        /// and a lastname based on the second half of their genome.
        /// In the case of duplicate names, ordinal numerals are added
        /// </summary>
        public static void NameAgents(Generation g)
        {
            Dictionary<string, int> instanceCount = new Dictionary<string, int>();

            foreach(Agent a in g.Population)
            {
                //split the genome in two
                int mid = a.GenomeSize /2;

                float range = a.WeightGenome.UpperBoundary - a.WeightGenome.LowerBoundary;
                float first = 0;
                float last = 0;
                float firstmax = 0;
                float lastmax = 0;

                for (int i = 0; i < a.WeightGenome.Size(); i++ )
                {
                    if (i < mid)
                    {
                        first += a.WeightGenome.GetGene(i) - a.WeightGenome.LowerBoundary;
                        firstmax += range;
                    }
                    else
                    {
                        last += a.WeightGenome.GetGene(i) - a.WeightGenome.LowerBoundary;
                        lastmax += range;
                    }
                }

                //get an appropriate name for the agent
                int firstindex = (int)Math.Floor(first / firstmax * firstnames.Length);
                int lastindex = (int)Math.Floor(last / lastmax * firstnames.Length);

                if (firstindex == lastindex)
                    lastindex = (lastindex + 1) % lastnames.Length;

                string basename = firstnames[firstindex] + " " + lastnames[lastindex];
                string ordinal = string.Empty;

                //add an ordinal to the name if it is a duplicate
                if (instanceCount.ContainsKey(basename))
                {
                    int count = instanceCount[basename] + 1;
                    
                    if(count <= ordinals.Length)
                    {
                        ordinal = ordinals[count - 1];
                    }
                    else
                    {
                        ordinal = count.ToString();
                    }

                    instanceCount[basename] = count;
                }                
                else
                {
                    instanceCount.Add(basename, 1);
                }

                //assign name to agent (plus ordinal if defined)
                a.Name = basename + ((ordinal != string.Empty) ? ordinal : " " + ordinal);
            }
        }        
    }
}
