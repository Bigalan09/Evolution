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

using ProjectMercury;
using ProjectMercury.Emitters;
using ProjectMercury.Modifiers;
using ProjectMercury.Renderers;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Text;
using System.Collections;

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

        public static Dictionary<string, ParticleEffect> particleEffects = new Dictionary<string, ParticleEffect>(StringComparer.Ordinal);
        Renderer particleRenderer;
        public static Params Parameters;

        public Game1()
        {
            Content.RootDirectory = "Content";

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 10;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 10;
            graphics.PreferMultiSampling = true;
            screenBounds = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            graphics.IsFullScreen = true;

            this.IsMouseVisible = true;

            particleEffects.Add("Heart", null);
            particleEffects.Add("Sword", null);
            particleEffects.Add("Death", null);

            particleRenderer = new SpriteBatchRenderer
            {
                GraphicsDeviceService = graphics
            };

            Parameters = Serialiser.DeserialiseFromFile<Params>("./params.xml");
            Parameters.Growth = Parameters.Growth / 100;
            Parameters.Mutation = Parameters.Mutation / 100;
            Parameters.Reproduction = Parameters.Reproduction / 100;
        }

        protected override void Initialize()
        {
            Randomiser.Instance(Parameters.Seed);
            world = new GameWorld(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("arial");

            ArrayList modified = new ArrayList();

            foreach (KeyValuePair<string, ParticleEffect> particle in particleEffects)
            {
                ParticleEffect particleEffect = particle.Value;
                particleEffect = Content.Load<ParticleEffect>(particle.Key);
                particleEffect.LoadContent(Content);
                particleEffect.Initialise();
                modified.Add(new KeyValuePair<string, ParticleEffect>(particle.Key, particleEffect));
            }

            foreach (KeyValuePair<string, ParticleEffect> p in modified)
            {
                particleEffects[p.Key] = p.Value;
            }
            modified.Clear();

            particleRenderer.LoadContent(Content);
            
            world.LoadContent(Content);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                world.ResourceManager.addResource(Mouse.GetState().X, Mouse.GetState().Y);

            float deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (KeyValuePair<string, ParticleEffect> particle in particleEffects)
            {
                ParticleEffect particleEffect = particle.Value;
                particleEffect.Update(deltaSeconds);
            }

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
            spriteBatch.DrawString(font, "Crossover: " + Parameters.Crossover, new Vector2(10, 80), Color.White);
            spriteBatch.End();

            foreach (KeyValuePair<string, ParticleEffect> particle in particleEffects)
            {
                ParticleEffect particleEffect = particle.Value;
                particleRenderer.RenderEffect(particleEffect);
            }

            base.Draw(gameTime);
        }
    }
}
