using Evolution.Genetics;
using Evolution.Resources;
using Evolution.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.Creatures
{
    public enum CreatureType
    {
        Herbivore,
        Carnivore,
        Omnivore
    }

    class CreatureGroup
    {
        private List<Entity> creatures = new List<Entity>();

        public int Count
        {
            get { return creatures.Count; }
        }

        private CreatureType type;
        private Vector2 spawnPoint;

        private static int next_id = 0;
        private int id = 0;

        private int generation = 0;
        private GameWorld gameWorld;

        internal GameWorld GameWorld
        {
            get { return gameWorld; }
        }

        public int Generation
        {
            get { return generation; }
            set { generation = value; }
        }

        public CreatureGroup(CreatureType type, GameWorld gameWorld)
        {
            this.gameWorld = gameWorld;
            this.type = type;
            this.id = next_id;
            next_id++;
        }

        public void addCreature(float x, float y, Chromosome chromosome = null)
        {
            Creature creature = null;
            if (type == CreatureType.Carnivore)
                creature = new Carnivore(this, x, y, chromosome);
            else if (type == CreatureType.Herbivore)
                creature = new Herbivore(this, x, y, chromosome);
            else
                creature = new Omnivore(this, x, y, chromosome);

            creatures.Add(creature);
            gameWorld.EntityManager.AddEntity(creature);
        }

        public void addCreature(Creature creature)
        {
            if (!creatures.Contains(creature))
                creatures.Add(creature);
            gameWorld.EntityManager.AddEntity(creature);
        }

        public void removeCreature(Creature creature)
        {
            if (creatures.Contains(creature))
                creatures.Remove(creature);

            gameWorld.EntityManager.RemoveEntity(creature);
        }

        public List<Entity> CreatePopulation(int populationSize)
        {
            if (id > 0)
                spawnPoint = new Vector2(Randomiser.nextInt(10, (int)((Game1.ScreenBounds.Width - 20) / 2)), Randomiser.nextInt(10, (int)((Game1.ScreenBounds.Height - 20) / 2)));
            else
                spawnPoint = new Vector2(Randomiser.nextInt((int)((Game1.ScreenBounds.Width - 20) / 2), (int)(Game1.ScreenBounds.Width - 20)), Randomiser.nextInt((int)((Game1.ScreenBounds.Height - 20) / 2), (int)(Game1.ScreenBounds.Height - 20)));

            for (int i = 0; i < populationSize; i++)
            {
                double angle = Randomiser.nextDouble() * Math.PI * 2;
                double radius = Math.Sqrt(Randomiser.nextDouble()) * 100;
                float x = (float)(spawnPoint.X + radius * Math.Cos(angle));
                float y = (float)(spawnPoint.Y + radius * Math.Sin(angle));
                addCreature(x, y);
            }

            return creatures;
        }

        internal void IncreaseGeneration()
        {
            generation++;
        }
    }
}
