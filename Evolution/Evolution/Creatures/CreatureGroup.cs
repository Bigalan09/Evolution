using Evolution.Genetics;
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
        Black,
        Red
    }

    class CreatureGroup
    {
        private List<Creature> creatures = new List<Creature>();
        private List<Creature> creaturesToAdd = new List<Creature>();
        private List<Creature> creaturesToRemove = new List<Creature>();
        private CreatureType type;
        private Game1 gameRef;
        private Vector2 spawnPoint;

        private static int next_id = 0;
        private int id = 0;

        public CreatureGroup(CreatureType type, Game1 gameRef)
        {
            this.gameRef = gameRef;
            this.type = type;
            this.id = next_id;
            next_id++;
        }

        public void addCreature(float x, float y, Chromosome chromosome = null)
        {
            if (type == CreatureType.Black)
                creaturesToAdd.Add(new BlackCreature(x, y, chromosome));
            else
                creaturesToAdd.Add(new RedCreature(x, y, chromosome));

            foreach (Creature c in creaturesToAdd)
            {
                c.LoadContent(gameRef.Content);
            }
        }

        public void addCreature(Creature creature)
        {
            if (!creatures.Contains(creature))
                creaturesToAdd.Add(creature);
        }

        public void removeCreature(Creature creature)
        {
            if (creatures.Contains(creature))
                creaturesToRemove.Add(creature);
        }

        public void LoadContent(ContentManager content)
        {
            foreach (Creature c in creatures)
            {
                c.LoadContent(content);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Creature c in creatures)
            {
                if (c.Dead)
                    removeCreature(c);
                else
                    c.Update(gameTime);
            }
            creatures.AddRange(creaturesToAdd);
            creaturesToAdd.Clear();

            foreach (Creature c in creaturesToRemove)
            {
                creatures.Remove(c);
            }
            creaturesToRemove.Clear();
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (Creature c in creatures)
            {
                c.Draw(spriteBatch, gameTime);
            }
        }

        public void CreatePopulation(int populationSize)
        {
            if (id > 0)
                spawnPoint = new Vector2(Randomiser.nextInt(10, (int)((Game1.ScreenBounds.Width - 200) / 2)), Randomiser.nextInt(10, (int)((Game1.ScreenBounds.Height - 200) / 2)));
            else
                spawnPoint = new Vector2(Randomiser.nextInt((int)((Game1.ScreenBounds.Width - 200) / 2), (int)(Game1.ScreenBounds.Width - 200)), Randomiser.nextInt((int)((Game1.ScreenBounds.Height - 200) / 2), (int)(Game1.ScreenBounds.Height - 200)));

            for (int i = 0; i < populationSize; i++)
            {
                double angle = Randomiser.nextDouble() * Math.PI * 2;
                double radius = Math.Sqrt(Randomiser.nextDouble()) * 100;
                float x = (float)(spawnPoint.X + radius * Math.Cos(angle));
                float y = (float)(spawnPoint.Y + radius * Math.Sin(angle));
                addCreature(x, y);
            }
        }
    }
}
