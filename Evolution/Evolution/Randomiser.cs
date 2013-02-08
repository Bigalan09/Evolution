using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution
{
    class Randomiser
    {
        private static bool canInitalise = false;
        private static Randomiser instance;
        private Random rand;

        private Randomiser(int seed)
        {
            if (canInitalise)
            {
                rand = new Random(seed);
            }
        }

        public static int nextInt()
        {
            return Instance().getNextInt();
        }

        public static int nextInt(int min, int max)
        {
            return Instance().getNextInt(min, max);
        }

        public static double nextDouble()
        {
            return Instance().getNextDouble();
        }

        private int getNextInt()
        {
            return rand.Next();
        }

        private int getNextInt(int min, int max)
        {
            return rand.Next(min, max);
        }

        private double getNextDouble()
        {
            return rand.NextDouble();
        }

        public static Randomiser Instance(int seed = 0) {
            if (instance == null)
            {
                canInitalise = true;
                instance = new Randomiser(seed);
                canInitalise = false;
            }
            return instance;
        }
    }
}
