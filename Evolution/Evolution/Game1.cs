using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using EvolutionLibrary;
using Evolution.Genetics;
using Evolution.Resources;
using Evolution.Creatures;
using Evolution.Utils;

namespace Evolution
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        static Rectangle screenBounds = new Rectangle();

        public static Rectangle ScreenBounds
        {
            get { return screenBounds; }
        }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        ResourceManager resourceManager;
        CreatureGroup HerbivoreGroup;
        CreatureGroup CarnivoreGroup;
        CreatureGroup OmnivoreGroup;

        private SpriteFont font;
        private int generation = 0;

        public Game1()
        {
            Content.RootDirectory = "Content";

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            screenBounds = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            graphics.IsFullScreen = true;

            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Randomiser.Instance(1);

            resourceManager = new ResourceManager(this);
            resourceManager.CreateResourceCluster(10);

            HerbivoreGroup = new CreatureGroup(CreatureType.Herbivore, this, resourceManager);
            CarnivoreGroup = new CreatureGroup(CreatureType.Carnivore, this, resourceManager);
            OmnivoreGroup = new CreatureGroup(CreatureType.Omnivore, this, resourceManager);

            HerbivoreGroup.CreatePopulation(20);
            CarnivoreGroup.CreatePopulation(20);
            OmnivoreGroup.CreatePopulation(20);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("arial");
            resourceManager.LoadContent(Content);

            HerbivoreGroup.LoadContent(Content);
            CarnivoreGroup.LoadContent(Content);
            OmnivoreGroup.LoadContent(Content);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                resourceManager.addResource(Mouse.GetState().X, Mouse.GetState().Y);
            }

            HerbivoreGroup.Update(gameTime);
            CarnivoreGroup.Update(gameTime);
            OmnivoreGroup.Update(gameTime);

            resourceManager.Update(gameTime);

            generation = Math.Max(HerbivoreGroup.Generation, Math.Max(CarnivoreGroup.Generation, OmnivoreGroup.Generation));
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.ForestGreen);

            spriteBatch.Begin();
            resourceManager.Draw(spriteBatch, gameTime);

            HerbivoreGroup.Draw(spriteBatch, gameTime);
            CarnivoreGroup.Draw(spriteBatch, gameTime);
            OmnivoreGroup.Draw(spriteBatch, gameTime);
            spriteBatch.DrawString(font, "Herbivore: " + HerbivoreGroup.Count, new Vector2(10, 5), Color.White);
            spriteBatch.DrawString(font, "Carnivore: " + CarnivoreGroup.Count, new Vector2(10, 30), Color.White);
            spriteBatch.DrawString(font, "Omnivore: " + OmnivoreGroup.Count, new Vector2(10, 55), Color.White);
            spriteBatch.DrawString(font, "Generation: " + generation, new Vector2(10, 80), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
