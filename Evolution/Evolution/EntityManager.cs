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
        private Hashtable entities = new Hashtable();
        private Hashtable newEntities = new Hashtable();
        private GameWorld gameWorld;

        public EntityManager(GameWorld gameWorld)
        {
            this.gameWorld = gameWorld;
        }

        public void AddEntity(Entity entity)
        {
            if (!newEntities.ContainsKey(entity.ID))
                newEntities.Add(entity.ID, entity);
        }

        public void Update(GameTime gameTime)
        {
            foreach (DictionaryEntry entry in entities)
            {
                ((Entity)(entry.Value)).Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (DictionaryEntry entry in entities)
            {
                ((Entity)(entry.Value)).Draw(spriteBatch, gameTime);
            }
        }

        public void LoadContent(ContentManager content)
        {
            foreach (DictionaryEntry entry in entities)
            {
                ((Entity)(entry.Value)).LoadContent(content);
            }
        }

        public Entity GetEntity(string id)
        {
            return (Entity)entities[id];
        }

        public List<Entity> GetAll(Type type)
        {
            List<Entity> list = new List<Entity>();

            foreach (DictionaryEntry entry in entities)
            {
                Entity ent = ((Entity)(entry.Value));
                if (ent.GetType().Equals(type))
                    list.Add(ent);
            }

            return list;
        }

        public void AddEntities()
        {
            foreach (DictionaryEntry entry in newEntities)
            {
                entities.Add(entry.Key, entry.Value);
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
            object[] keys = new object[entities.Count];
            entities.Keys.CopyTo(keys, 0);

            for (int index = keys.Length - 1; index >= 0; --index)
            {
                if (!((Entity)entities[keys[index]]).Alive)
                    entities.Remove(keys[index]);
            }
        }

        internal void RemoveEntity(Entity creature)
        {
            object[] keys = new object[this.entities.Count];
            this.entities.Keys.CopyTo(keys, 0);

            for (int index = keys.Length - 1; index >= 0; --index)
            {
                if (entities[keys[index]] == creature)
                    entities.Remove(keys[index]);
            }
        }

        public void RemoveAll(Type type)
        {
            object[] keys = new object[this.entities.Count];
            this.entities.Keys.CopyTo(keys, 0);

            for (int index = keys.Length - 1; index >= 0; --index)
            {
                if (entities[keys[index]].GetType().Equals(type))
                    entities.Remove(keys[index]);
            }
        }

        public List<Entity> InRadius(float radius, Vector2 position)
        {
            List<Entity> inRadius = new List<Entity>();
            foreach (Entity ent in entities)
            {
                if ((ent.Position + ent.Origin - position).Length() <= radius)
                    inRadius.Add(ent);
            }
            return inRadius;
        }

    }
}
