using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution
{
    public class Params
    {
        public int Seed = 0;
        public int Reproduction = 0;
        public int Mutation = 0;
        public int Growth = 0;
        public string Crossover = "";

        public Params()
        {
        }

        public Params(int seed, int reproduction, int mutation, string crossover, int growth)
        {
            Seed = seed;
            Reproduction = reproduction;
            Mutation = mutation;
            Crossover = crossover;
            Growth = growth;
        }

        public override string ToString()
        {
            return "[ Params ][ Seed:" + Seed + ", Reproduction: " + Reproduction + ", Mutation: " + Mutation + ", Growth: " + Growth + ", Crossover: " + Crossover + " ]";
        }
    }
}
