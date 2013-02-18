using Evolution.Creatures;
using Evolution.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution
{
    class GameWorld
    {
        private ResourceManager resourceManager;
        private CreatureGroup HerbivoreGroup;
        private CreatureGroup CarnivoreGroup;
        private CreatureGroup OmnivoreGroup;
        private Game1 gameRef;

        public ResourceManager ResourceManager
        {
            get { return resourceManager; }
        }

        public GameWorld(Game1 gameRef)
        {
            this.gameRef = gameRef;
        }

        public void Initialise()
        {
            resourceManager = new ResourceManager(gameRef);
            resourceManager.CreateResourceCluster(10, 150, new Vector2(150, 150));
            resourceManager.CreateResourceCluster(10, 150, new Vector2(Game1.ScreenBounds.Width - 150, 150));
            resourceManager.CreateResourceCluster(10, 150, new Vector2(150, Game1.ScreenBounds.Height - 150));
            resourceManager.CreateResourceCluster(10, 150, new Vector2(Game1.ScreenBounds.Width - 150, Game1.ScreenBounds.Height - 150));

            HerbivoreGroup = new CreatureGroup(CreatureType.Herbivore, gameRef, resourceManager);
            CarnivoreGroup = new CreatureGroup(CreatureType.Carnivore, gameRef, resourceManager);
            OmnivoreGroup = new CreatureGroup(CreatureType.Omnivore, gameRef, resourceManager);

            HerbivoreGroup.CreatePopulation(5);
            CarnivoreGroup.CreatePopulation(5);
            OmnivoreGroup.CreatePopulation(5);
        }

        public void LoadContent(ContentManager content)
        {
            HerbivoreGroup.LoadContent(content);
            CarnivoreGroup.LoadContent(content);
            OmnivoreGroup.LoadContent(content);
        }

        public void Update(GameTime gameTime)
        {
            resourceManager.Update(gameTime);

            HerbivoreGroup.Update(gameTime);
            CarnivoreGroup.Update(gameTime);
            OmnivoreGroup.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            resourceManager.Draw(spriteBatch, gameTime);

            HerbivoreGroup.Draw(spriteBatch, gameTime);
            CarnivoreGroup.Draw(spriteBatch, gameTime);
            OmnivoreGroup.Draw(spriteBatch, gameTime);
        }

    }
}
