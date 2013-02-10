using Evolution.Genetics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.Creature
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

        public CreatureGroup(CreatureType type, Game1 gameRef)
        {
            this.gameRef = gameRef;
            this.type = type;
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
    }
}
