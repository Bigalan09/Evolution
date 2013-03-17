using Evolution.Creatures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution
{
    class EntityManager
    {
        private List<Entity> entities = new List<Entity>();
        private List<Entity> newEntities = new List<Entity>();
        private GameWorld gameWorld;

        public EntityManager(GameWorld gameWorld)
        {
            this.gameWorld = gameWorld;
        }

        public void AddEntity(Entity entity)
        {
            if (!newEntities.Contains(entity))
                newEntities.Add(entity);
        }

        public void Update(GameTime gameTime)
        {
            try
            {
                foreach (Entity entry in entities)
                {
                    entry.Update(gameTime);
                }
            }
            catch (Exception) { }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (Entity entry in entities)
            {
                entry.Draw(spriteBatch, gameTime);
            }
        }

        public void LoadContent(ContentManager content)
        {
            foreach (Entity entry in entities)
            {
                entry.LoadContent(content);
            }
        }

        public Entity GetEntity(string id)
        {
            foreach (Entity entry in entities)
            {
                if (entry.ID == id)
                    return entry;
            }
            return null;
        }

        public List<Entity> GetAll(Type type)
        {
            List<Entity> list = new List<Entity>();

            foreach (Entity ent in entities)
            {
                if (ent.GetType().Equals(type))
                    list.Add(ent);
            }

            return list;
        }

        public void AddEntities()
        {
            foreach (Entity entry in newEntities)
            {
                entities.Add(entry);
            }
            this.LoadContent(gameWorld.GameRef.Content);
            newEntities.Clear();
        }

        public void AddListOfEntities(List<Entity> entities)
        {
            foreach (Entity entity in entities)
            {
                this.AddEntity(entity);
            }
        }

        public void RemoveEntities()
        {

            for (int i = entities.Count - 1; i >= 0; i--)
            {
                if (!entities[i].Alive)
                    entities.RemoveAt(i);
            }
        }

        internal void RemoveEntity(Entity creature)
        {
            creature.Alive = false;
        }

        public void RemoveAll(Type type)
        {
            for (int i = entities.Count - 1; i >= 0; i--)
            {
                if (entities[i].GetType().Equals(type))
                    entities.RemoveAt(i);
            }
        }

        public List<Entity> InRadius(float radius, Vector2 position)
        {
            return this.InRadius(radius, position, typeof(Entity));
        }

        public List<Entity> InRadius(float radius, Vector2 position, Type type)
        {
            List<Entity> inRadius = new List<Entity>();
            foreach (Entity ent in entities)
            {
                if ((ent.Position + ent.Origin - position).Length() <= radius && ent.GetType().Equals(type))
                    inRadius.Add(ent);
            }
            return inRadius;
        }
    }
}
