using Evolution.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.Resource
{
    class ResourceManager
    {
        private List<Resource> resources = new List<Resource>();
        private List<Resource> resourcesToAdd = new List<Resource>();
        private List<Resource> resourcesToRemove = new List<Resource>();
        private Game1 gameRef;

        public ResourceManager(Game1 gameRef)
        {
            this.gameRef = gameRef;
        }

        public void addResource(float x, float y)
        {
            resourcesToAdd.Add(new Resource(this, x, y));
            foreach (Resource res in resourcesToAdd)
            {
                res.LoadContent(gameRef.Content);
            }
        }

        public void addResource(Resource resource)
        {
            resourcesToAdd.Add(new Resource(this, resource.Position.X + Randomiser.nextInt(-10, 10), resource.Position.Y + Randomiser.nextInt(-10, 10), resource.Texture));
        }

        public void removeResource(Resource resource)
        {
            resourcesToRemove.Add(resource);
        }

        public void CreateResourceCluster(int amount)
        {
            Vector2 spawnPoint = new Vector2(Randomiser.nextInt((int)((Game1.ScreenBounds.Width - 20) / 2), (int)((Game1.ScreenBounds.Width + 20) / 2)), Randomiser.nextInt((int)((Game1.ScreenBounds.Height - 20) / 2), (int)((Game1.ScreenBounds.Height + 20) / 2)));

            for (int i = 0; i < amount; i++)
            {
                double angle = Randomiser.nextDouble() * Math.PI * 2;
                double radius = Math.Sqrt(Randomiser.nextDouble()) * 50;
                float x = (float)(spawnPoint.X + radius * Math.Cos(angle));
                float y = (float)(spawnPoint.Y + radius * Math.Sin(angle));
                addResource(x, y);
            }
        }

        public void LoadContent(ContentManager content)
        {
            foreach (Resource res in resources)
            {
                res.LoadContent(content);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Resource res in resources)
            {
                res.Update(gameTime);
            }
            resources.AddRange(resourcesToAdd);
            resourcesToAdd.Clear();

            foreach (Resource res in resourcesToRemove)
            {
                resources.Remove(res);
            }
            resourcesToRemove.Clear();
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (Resource res in resources)
            {
                res.Draw(spriteBatch, gameTime);
            }
        }
    }
}
