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

        GameWorld world;

        private SpriteFont font;

        public Game1()
        {
            Content.RootDirectory = "Content";

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            screenBounds = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            //graphics.IsFullScreen = true;

            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Randomiser.Instance(-1);
            world = new GameWorld(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("arial");
            
            world.LoadContent(Content);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            world.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.ForestGreen);

            spriteBatch.Begin();
            world.Draw(spriteBatch, gameTime);
            spriteBatch.DrawString(font, "Herbivore: " + world.EntityManager.GetAll(typeof(Herbivore)).Count, new Vector2(10, 5), Color.White);
            spriteBatch.DrawString(font, "Carnivore: " + world.EntityManager.GetAll(typeof(Carnivore)).Count, new Vector2(10, 30), Color.White);
            spriteBatch.DrawString(font, "Omnivore: " + world.EntityManager.GetAll(typeof(Omnivore)).Count, new Vector2(10, 55), Color.White);
            //spriteBatch.DrawString(font, "Generation: " + generation, new Vector2(10, 80), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
