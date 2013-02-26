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
        private GameWorld gameWorld;

        public ResourceManager(GameWorld gameWorld)
        {
            this.gameWorld = gameWorld;
        }

        public void addResource(float x, float y)
        {
            if (gameWorld.EntityManager.GetAll(typeof(Resource)).Count <= 1000)
            {
                Resource res = new Resource(this, x, y);
                res.LoadContent(gameWorld.GameRef.Content);
                gameWorld.EntityManager.AddEntity(res);
            }
        }

        public void addResource(Resource resource)
        {
            if (gameWorld.EntityManager.GetAll(typeof(Resource)).Count <= 1000)
            {
                float x = resource.Position.X + Randomiser.nextInt(-25, 25);
                float y = resource.Position.Y + Randomiser.nextInt(-25, 25);
                if (!Game1.ScreenBounds.Contains((int)x, (int)y))
                {
                    addResource(resource);
                }
                else
                {

                    Resource res = new Resource(this, x, y, resource.Texture);
                    res.LoadContent(gameWorld.GameRef.Content);
                    gameWorld.EntityManager.AddEntity(res);
                }
            }
        }

        public void removeResource(Resource resource)
        {
            resource.Alive = false;
            gameWorld.EntityManager.RemoveEntity(resource);
            if (gameWorld.EntityManager.GetAll(typeof(Resource)).Count == 0)
            {
                CreateResourceCluster(2, 150, new Vector2(150, 150));
                CreateResourceCluster(2, 150, new Vector2(Game1.ScreenBounds.Width - 150, 150));
                CreateResourceCluster(2, 150, new Vector2(150, Game1.ScreenBounds.Height - 150));
                CreateResourceCluster(2, 150, new Vector2(Game1.ScreenBounds.Width - 150, Game1.ScreenBounds.Height - 150));
                CreateResourceCluster(2, 150, new Vector2((Game1.ScreenBounds.Width - 150) / 2, (Game1.ScreenBounds.Height - 150) / 2));
            }
        }

        public List<Entity> CreateResourceCluster(int amount, int rad, Vector2 point)
        {
            Vector2 spawnPoint = point;//new Vector2(Randomiser.nextInt((int)((Game1.ScreenBounds.Width - 20) / 2), (int)((Game1.ScreenBounds.Width + 20) / 2)), Randomiser.nextInt((int)((Game1.ScreenBounds.Height - 20) / 2), (int)((Game1.ScreenBounds.Height + 20) / 2)));
            List<Entity> resources = new List<Entity>();
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
        }
    }
}
