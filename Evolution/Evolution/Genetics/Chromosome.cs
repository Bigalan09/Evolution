﻿using Evolution.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.Genetics
{
    public enum PropertyType
    {
        Max_Speed,
        Defence,
        Strength,
        Resource_Capacity,
        Body_Mass,
        Aquatic,
        Age_Death,
        Gather_Rate
    }

    class Chromosome
    {
        private List<Gene> genes = new List<Gene>();
        private string binaryString = "";

        public string BinaryString
        {
            get { return binaryString; }
        }

        public Chromosome()
        {
            CreateRandomChromosome();
        }

        public Chromosome(List<Gene> genes)
        {
            genes = new List<Gene>(genes);
        }

        public void addGene(Gene gene)
        {
            if (!genes.Contains(gene))
            {
                genes.Add(gene);
            }
            binaryString = GenesToBinary();
        }

        public void addGene(PropertyType type, string binaryString)
        {
            Gene g = new Gene(type, binaryString);
            this.addGene(g);
        }

        public void addGene(PropertyType type, int value)
        {
            Gene g = new Gene(type, value);
            this.addGene(g);
        }

        private void CreateRandomChromosome()
        {
            addGene(PropertyType.Max_Speed, Randomiser.nextInt(0, 100));
            addGene(PropertyType.Body_Mass, Randomiser.nextInt(0, 100));
            addGene(PropertyType.Aquatic, Randomiser.nextInt(0, 1));
        }

        private string GenesToBinary()
        {
            string b = "";
            foreach (Gene g in genes)
            {
                b += g.BinaryString;
            }
            return b;
        }

        public void Mutate()
        {
            int p = Randomiser.nextInt(0, genes.Count - 1);
            genes[p].Mutate();
            binaryString = GenesToBinary();
        }

        public List<Chromosome> Reproduce(Chromosome partner)
        {
            List<Chromosome> children = new List<Chromosome>();
            Chromosome child1 = new Chromosome();
            Chromosome child2 = new Chromosome();
            int half = genes.Count / 2;

            // Get first and second half of 1st parent Genes
            for (int i = 0; i < half; i++)
            {
                child1.addGene(genes[i]);
            }
            for (int i = half; i < genes.Count; i++)
            {
                child2.addGene(genes[i]);
            }

            // Get first and second hald of 2nd parent Genes;
            for (int i = 0; i < half; i++)
            {
                child2.addGene(partner.genes[i]);
            }
            for (int i = half; i < genes.Count; i++)
            {
                child1.addGene(partner.genes[i]);
            }

            children.Add(child1);
            children.Add(child2);

            return children;
        }

        public Gene GetGene(PropertyType property)
        {
            foreach (Gene g in genes)
            {
                if (g.Type == property)
                    return g;
            }
            return null;
        }
    }
}