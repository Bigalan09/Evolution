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

namespace Evolution
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        RedCreature rCreature;
        BlackCreature bCreature;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            rCreature = new RedCreature(30, 30, 0.5f, new Chromosome());
            bCreature = new BlackCreature(60, 30, 0.5f, new Chromosome());
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            rCreature.LoadContent(Content);
            bCreature.LoadContent(Content);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            rCreature.Update(gameTime);
            bCreature.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.OliveDrab);

            spriteBatch.Begin();
            rCreature.Draw(spriteBatch, gameTime);
            bCreature.Draw(spriteBatch, gameTime);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
