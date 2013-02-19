using Evolution.Creatures;
using Evolution.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.Resources
{
    class ResourceManager
    {
        private List<Entity> resources = new List<Entity>();
        private GameWorld gameWorld;

        public ResourceManager(GameWorld gameWorld)
        {
            this.gameWorld = gameWorld;
        }

        public void addResource(float x, float y)
        {
            Resource res = new Resource(this, x, y);
            resources.Add(res);
            gameWorld.EntityManager.AddEntity(res);
        }

        public void addResource(Resource resource)
        {
            Resource res = new Resource(this, resource.Position.X + Randomiser.nextInt(-10, 10), resource.Position.Y + Randomiser.nextInt(-10, 10), resource.Texture);
            resources.Add(res);
            gameWorld.EntityManager.AddEntity(res);
        }

        public void removeResource(Resource resource)
        {
            resources.Remove(resource);
            gameWorld.EntityManager.RemoveEntity(resource);
        }

        public List<Entity> CreateResourceCluster(int amount, int rad, Vector2 point)
        {
            Vector2 spawnPoint = point;//new Vector2(Randomiser.nextInt((int)((Game1.ScreenBounds.Width - 20) / 2), (int)((Game1.ScreenBounds.Width + 20) / 2)), Randomiser.nextInt((int)((Game1.ScreenBounds.Height - 20) / 2), (int)((Game1.ScreenBounds.Height + 20) / 2)));

            for (int i = 0; i < amount; i++)
            {
                double angle = Randomiser.nextDouble() * Math.PI * 2;
                double radius = Math.Sqrt(Randomiser.nextDouble()) * rad;
                float x = (float)(spawnPoint.X + radius * Math.Cos(angle));
                float y = (float)(spawnPoint.Y + radius * Math.Sin(angle));
                addResource(x, y);
            }
            return resources;
        }

        public void LoadContent(ContentManager content)
        {
            foreach (Resource res in resources)
            {
                res.LoadContent(content);
            }
        }
    }
}
