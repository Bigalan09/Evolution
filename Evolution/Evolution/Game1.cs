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
using Evolution.Creatures;
using Evolution.Resource;
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
        CreatureGroup redGroup;
        CreatureGroup blackGroup;

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

            resourceManager = new ResourceManager(this);
            resourceManager.CreateResourceCluster(10);

            redGroup = new CreatureGroup(CreatureType.Red, this);
            blackGroup = new CreatureGroup(CreatureType.Black, this);

            redGroup.CreatePopulation(10);
            blackGroup.CreatePopulation(10);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            resourceManager.LoadContent(Content);

            redGroup.LoadContent(Content);
            blackGroup.LoadContent(Content);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            redGroup.Update(gameTime);
            blackGroup.Update(gameTime);
            resourceManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Olive);

            spriteBatch.Begin();
            resourceManager.Draw(spriteBatch, gameTime);

            redGroup.Draw(spriteBatch, gameTime);
            blackGroup.Draw(spriteBatch, gameTime);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
