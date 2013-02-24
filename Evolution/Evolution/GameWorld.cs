using Evolution.Creatures;
using Evolution.Resources;
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
    class GameWorld
    {
        private ResourceManager resourceManager;
        private CreatureGroup HerbivoreGroup;
        private CreatureGroup CarnivoreGroup;
        private CreatureGroup OmnivoreGroup;

        private EntityManager entityManager;
        private Game1 gameRef;

        public Game1 GameRef
        {
            get { return gameRef; }
            set { gameRef = value; }
        }

        public EntityManager EntityManager
        {
            get { return entityManager; }
        }

        public ResourceManager ResourceManager
        {
            get { return resourceManager; }
        }

        public GameWorld(Game1 gameRef)
        {
            this.gameRef = gameRef;
            entityManager = new EntityManager(this);

            resourceManager = new ResourceManager(this);
            HerbivoreGroup = new CreatureGroup(CreatureType.Herbivore, this);
            CarnivoreGroup = new CreatureGroup(CreatureType.Carnivore, this);
            OmnivoreGroup = new CreatureGroup(CreatureType.Omnivore, this);

            // Create entities
            resourceManager.CreateResourceCluster(5, 50, new Vector2(150, 150));
            resourceManager.CreateResourceCluster(5, 50, new Vector2(Game1.ScreenBounds.Width - 150, 150));
            resourceManager.CreateResourceCluster(5, 50, new Vector2(150, Game1.ScreenBounds.Height - 150));
            resourceManager.CreateResourceCluster(5, 50, new Vector2(Game1.ScreenBounds.Width - 150, Game1.ScreenBounds.Height - 150));
            resourceManager.CreateResourceCluster(5, 50, new Vector2((Game1.ScreenBounds.Width - 150) / 2, (Game1.ScreenBounds.Height - 150) / 2));

            HerbivoreGroup.CreatePopulation(20);
            CarnivoreGroup.CreatePopulation(20);
            OmnivoreGroup.CreatePopulation(20);

            entityManager.LoadContent(gameRef.Content);

        }

        public void LoadContent(ContentManager content)
        {
            entityManager.LoadContent(content);
        }

        public void Update(GameTime gameTime)
        {
            entityManager.Update(gameTime);
            entityManager.AddEntities();
            entityManager.RemoveEntities();
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            entityManager.Draw(spriteBatch, gameTime);
        }

    }
}
