using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionLibrary
{
    class MapGenerator
    {
        private PerlinNoise perlinNoise;
        public void GeneratePerlinNoise()
        {
            int seed = 0;
            perlinNoise = new PerlinNoise(seed);
        }
    }
}
