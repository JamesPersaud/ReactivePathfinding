using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    /// <summary>
    /// Represents a unique generation of agents belonging to an experiment
    /// </summary>
    public class Generation
    {
        public static bool DEBUG_EVOLUTION = false;
        public static bool DEBUG_CHEAT_HEIGHT_SENSORS = false;

        private Experiment currentExperiment;        
        private List<Agent> population;        
        private int generationID;
        private Generation previousGeneration;
        private BoundaryFloatGenome templateGenome;

        private float finalMinFitness;
        private float finalMaxFitness;
        private float finalAvgFitness;

        private int finalExpired;
        private int finalReachedTarget;

        private float age;

        public float Age
        {
            get { return age; }
        }

        public int FinalReachedTarget
        {
            get { return finalReachedTarget; }            
        }

        public int FinalExpired
        {
            get { return finalExpired; }            
        }

        public float FinalAvgFitness
        {
            get { return finalAvgFitness; }            
        }

        public float FinalMaxFitness
        {
            get { return finalMaxFitness; }            
        }

        public float FinalMinFitness
        {
            get { return finalMinFitness; }            
        }

        public BoundaryFloatGenome TemplateGenome
        {
            get { return templateGenome; }
            set { templateGenome = value; }
        }

        public Generation PreviousGeneration
        {
            get { return previousGeneration; }
            set { previousGeneration = value; }
        }

        public int GenerationID
        {
          get { return generationID; }
          set { generationID = value; }
        }        

        public List<Agent> Population
        {
            get { return population; }
            set { population = value; }
        }

        public Experiment CurrentExperiment
        {
            get { return currentExperiment; }
            set { currentExperiment = value; }
        }

        private PRNG random
        {
            get
            {
                return currentExperiment.Random;
            }
        }

        public Generation(Experiment ex)
        {
            currentExperiment = ex;            
        }

        public bool HasEnded
        {
            get
            {
                return NumActive < 1;
            }
        }        

        /// <summary>
        /// The current minimum fitness
        /// </summary>
        public float MinFitness
        {
            get
            {
                if (population.Count < 1) return 0;

                float min = float.MaxValue;
                foreach(Agent a in this.population)
                {
                    if (a.Fitness < min)
                        min = a.Fitness;
                }
                finalMinFitness = min;
                return min;
            }
        }

        /// <summary>
        /// The current maximum fitness
        /// </summary>
        public float MaxFitness
        {
            get
            {
                if (population.Count < 1) return 0;

                float max = -float.MaxValue;
                foreach(Agent a in this.population)
                {
                    if (a.Fitness > max)
                        max = a.Fitness;
                }
                finalMaxFitness = max;
                return max;
            }
        }

        /// <summary>
        /// The current average fitness
        /// </summary>
        public float AverageFitness
        {
            get
            {
                if (population.Count < 1) return 0;

                float total = 0;
                foreach (Agent a in this.population)                
                    total += a.Fitness;
                                
                float avg = total / (float)population.Count;
                finalAvgFitness = avg;
                return avg;
            }
        }

        public int NumReachedTarget
        {
            get
            {
                int i = 0;
                foreach (Agent a in this.population)
                {
                    if (a.ReachedTarget)
                        i++;
                }
                finalReachedTarget = i;
                return i;
            }
        }

        public int NumExpired
        {
            get
            {
                int i = 0;
                foreach (Agent a in this.population)
                {
                    if (!a.IsAlive && !a.ReachedTarget)
                        i++;
                }
                finalExpired = i;
                return i;
            }
        }

        public int NumActive
        {
            get
            {
                int i = 0;
                foreach (Agent a in this.population)
                {
                    if (a.IsAlive && !a.ReachedTarget)
                        i++;
                }
                return i;
            }
        }

        public List<Agent> ActiveAgents
        {
            get
            {
                List<Agent> l = new List<Agent>();
                foreach(Agent a in this.population)
                {
                    if (a.IsAlive && !a.ReachedTarget)
                        l.Add(a);
                }
                return l;
            }
        }

        /// <summary>
        /// Update generation age
        /// </summary>
        public void Update(float deltaTime)
        {
            age += deltaTime;
        }

        /// <summary>
        /// Debug function, helps to debug the evolution of new generations 
        /// </summary>
        public void SetRandomFitnesses()
        {
            foreach (Agent a in population)
                a.Fitness = currentExperiment.Random.GetFloat(0, 100);
        }

        /// <summary>
        /// Set up an initial generation by getting the agent template from the current
        /// experiment and setting genomes for a fixed size population accordingly
        /// 
        /// or evolve this generation based on its previous generation;
        /// </summary>
        private void Generate()
        {
            if(previousGeneration == null)
            {
                this.population = new List<Agent>();
                for(int i =0; i < currentExperiment.PopulationSize; i++)
                {
                    Agent a = currentExperiment.CurrentAgentTopology.GetAgentFromTemplate();
                    a.WeightGenome = this.templateGenome.GetNewGenomeLikeThis();
                    a.Name = "Agent " + i.ToString();
                    a.CurrentExperiment = currentExperiment;
                    population.Add(a);
                }
            }
            else
            {
                Evolve();
            }

            AgentNames.NameAgents(this);
        }    
   
        private void Debug(string s)
        {
            if(DEBUG_EVOLUTION)
                Logging.Instance.Log("Generation " + this.generationID.ToString() + ": " + s);
        }
 
        /// <summary>
        /// Using experimental parameters and the previous generation, populate this generation with new agents.
        /// </summary>
        private void Evolve()
        {            
            previousGeneration.population.Sort();
            List<Genome> genepool = new List<Genome>();       
            List<Genome> nextGenerationGenomes = new List<Genome>();            
            int popcount = previousGeneration.population.Count;
            float totalFitness =0;
            PRNG rng = currentExperiment.Random;

            //get total fitness
            foreach(Agent a in previousGeneration.population)            
                totalFitness += a.Fitness;
            
            Debug("Total fitness: " + totalFitness.ToString());

            //add elites to next generation list
            //there MUST be an even number of elites
            //Once all selection mutation and crossover is done, an unmodified clone of
            //each elite will be added to the next generation
            for(int i = 0; i < popcount && i < currentExperiment.Elites; i++)            
                nextGenerationGenomes.Add(previousGeneration.population[i].WeightGenome.Clone());
            
            Debug("Added " + currentExperiment.Elites.ToString() + " elites, next gen count is now " + nextGenerationGenomes.Count.ToString());

            //set up the roulette wheel
            float[] roulette = new float[popcount];
            float runningFitnessProp =0;
            for (int i = 0; i < popcount; i++ )
            {
                runningFitnessProp += previousGeneration.population[i].Fitness / totalFitness;
                roulette[i] = runningFitnessProp;
                       
                Debug("Roulette wheel " + i.ToString() + " : " + runningFitnessProp.ToString());                
            }

            //spin the wheel until the pool is full
            while (genepool.Count + nextGenerationGenomes.Count < popcount)
            {
                float selection = rng.GetFloat(0, 1);
                
                Debug("Spin: " + selection.ToString());

                for(int i =0; i < roulette.Length; i++)
                {
                    if(selection <= roulette[i] || i == roulette.Length-1)
                    {                        
                        Genome g = previousGeneration.population[i].WeightGenome.Clone();
                        
                        Debug("Selected " + selection.ToString() + " : " + g.ToString());

                        //mutation?     
                        bool mutated = false;
                        if (currentExperiment.MutateOnSelection)
                        {                            
                            mutated = g.Mutate(currentExperiment.MutationRate, 0, 100);

                            if (mutated)
                                Debug("Mutated on selection, result : " + g.ToString());
                        }
                        genepool.Add(g);
                        break;
                    }
                }
            }

            if (DEBUG_EVOLUTION)
            {
                Debug("Genepool after selection");
                for(int i = 0 ; i < genepool.Count; i++)
                    Debug(i.ToString() + " : " + genepool[i].ToString());
            }
                 

            //select pairs for crossover
            List<Genome> crossoverpairs = new List<Genome>();
            for(int i =0; i< genepool.Count; i+=2)
            {
                int firstIndex = rng.GetInt(0,genepool.Count-1);
                int secondIndex = firstIndex;
                int tries = 0;

                while (firstIndex == secondIndex && tries < 50)
                {
                    secondIndex = rng.GetInt(0, genepool.Count - 1);
                    tries++;
                }

                crossoverpairs.Add(genepool[firstIndex]);
                crossoverpairs.Add(genepool[secondIndex]);

                Debug("Crossover pair selected");
                Debug(firstIndex.ToString() + " : " + genepool[firstIndex].ToString());
                Debug(secondIndex.ToString() + " : " + genepool[secondIndex].ToString());
            }

            //perform crossover
            for(int i =0; i< genepool.Count; i+=2)
            {
                Genome c1 = crossoverpairs[i];
                Genome c2 = crossoverpairs[i + 1];

                Debug("Pair " + i.ToString() + " : " + c1.ToString() + " ; " +(i+1).ToString() + " : " + c2.ToString());

                bool crossed = c1.Crossover(currentExperiment.CrossoverRate, 0, 100, c2, currentExperiment.CrossoverType);

                if (crossed)
                    Debug("Crossed to " + i.ToString() + " : " + c1.ToString() + " ; " + (i + 1).ToString() + " : " + c2.ToString());
                else
                    Debug("uncrossed");

                if(currentExperiment.MutateDuringCrossover)
                {
                    bool mutated = c1.Mutate(currentExperiment.MutationRate, 0, 100);
                    if(mutated)
                        Debug("Mutated first crossover result : " + c1.ToString());
                    mutated = c2.Mutate(currentExperiment.MutationRate, 0, 100);
                    if (mutated)
                        Debug("Mutated second crossover result : " + c2.ToString());

                }

                nextGenerationGenomes.Add(c1.Clone());
                nextGenerationGenomes.Add(c2.Clone());
            }

            if(DEBUG_EVOLUTION)
            {
                Debug("Next generation");
                for (int i = 0; i < nextGenerationGenomes.Count; i++)
                    Debug(i.ToString() + " : " + nextGenerationGenomes[i].ToString());
            }

            //construct the next generation of agents
            this.population = new List<Agent>();

            for (int i = 0; i < nextGenerationGenomes.Count; i++)
            {
                Agent a = currentExperiment.CurrentAgentTopology.GetAgentFromTemplate();
                a.Name = "Agent " + i.ToString();
                a.CurrentExperiment = currentExperiment;

                if (DEBUG_CHEAT_HEIGHT_SENSORS && nextGenerationGenomes[i].Size() > 16)
                {
                    //to debug the height sensors of an agent where the last 8 genes correspond to height sensor connection weights

                    //frontleft to left - turn more if high                    
                    ((BoundaryFloatGenome)nextGenerationGenomes[i]).SetGene(16, 1);
                    //frontleft to right - turn less if high
                    ((BoundaryFloatGenome)nextGenerationGenomes[i]).SetGene(17, 0);

                    //frontright to left - turn less if high
                    ((BoundaryFloatGenome)nextGenerationGenomes[i]).SetGene(18, 0);
                    //frontright to right - turn more if high
                    ((BoundaryFloatGenome)nextGenerationGenomes[i]).SetGene(19, 1);

                    //rearleft to left - turn more if high
                    ((BoundaryFloatGenome)nextGenerationGenomes[i]).SetGene(20, 1);
                    //rearleft to right - turn less if high
                    ((BoundaryFloatGenome)nextGenerationGenomes[i]).SetGene(21, 0);

                    //rearright to left - turn less if high
                    ((BoundaryFloatGenome)nextGenerationGenomes[i]).SetGene(22, 0);
                    //rearright to right - turn more if high
                    ((BoundaryFloatGenome)nextGenerationGenomes[i]).SetGene(23,1);

                }
                a.WeightGenome = (BoundaryFloatGenome)nextGenerationGenomes[i];

                population.Add(a);
            }
        }        

        /// <summary>
        /// Evolve a sibsequent generation from this generation
        /// </summary>
        public Generation EvolveNextGeneration()
        {
            Generation next = new Generation(currentExperiment);
            next.generationID = this.generationID + 1;
            next.templateGenome = (BoundaryFloatGenome)currentExperiment.CurrentAgentTopology.TemplateAgent.WeightGenome.Clone();
            next.previousGeneration = this;
            next.Generate();
            return next;
        }

        public static Generation GetInitialGeneration(Experiment ex)
        {
            Generation g = new Generation(ex);
            g.templateGenome = (BoundaryFloatGenome)ex.CurrentAgentTopology.TemplateAgent.WeightGenome.Clone(ex);
            g.Generate();            
            return g;
        }        
    }
}
