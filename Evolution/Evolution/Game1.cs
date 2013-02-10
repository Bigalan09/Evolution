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
using Evolution.Creature;
using Evolution.Resource;
using Evolution.Utils;

namespace Evolution
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        Vector2 screenBounds = Vector2.Zero;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        ResourceManager resourceManager;
        CreatureGroup redGroup;
        CreatureGroup blackGroup;

        public Game1()
        {
            Content.RootDirectory = "Content";

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 100;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 100;

            screenBounds = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            graphics.IsFullScreen = false;

            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            resourceManager = new ResourceManager(this);
            resourceManager.addResource(Randomiser.nextInt(10, (int)screenBounds.X), Randomiser.nextInt(10, (int)screenBounds.Y));

            redGroup = new CreatureGroup(CreatureType.Red, this);
            blackGroup = new CreatureGroup(CreatureType.Black, this);

            redGroup.addCreature(Randomiser.nextInt(10, (int)screenBounds.X), Randomiser.nextInt(10, (int)screenBounds.Y));
            blackGroup.addCreature(Randomiser.nextInt(10, (int)screenBounds.X), Randomiser.nextInt(10, (int)screenBounds.Y));

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
            redGroup.Update(gameTime);
            blackGroup.Update(gameTime);
            resourceManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.OliveDrab);

            spriteBatch.Begin();
            redGroup.Draw(spriteBatch, gameTime);
            blackGroup.Draw(spriteBatch, gameTime);
            resourceManager.Draw(spriteBatch, gameTime);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
