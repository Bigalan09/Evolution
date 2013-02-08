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

namespace Evolution
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private double mutateRate = 0.85;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            base.Initialize();

            Chromosome c = new Chromosome();
            c.addGene("life", 5);
            c.addGene("speed", 10);
            c.addGene("attack", 15);
            c.addGene("lol", 20);

            Chromosome c1 = new Chromosome();
            c1.addGene("life", 25);
            c1.addGene("speed", 30);
            c1.addGene("attack", 35);
            c1.addGene("lol", 40);

            Console.WriteLine("Parent 1:\t\t" + c.BinaryString);
            Console.WriteLine("Parent 2:\t\t" + c1.BinaryString);

            List<Chromosome> children = c1.Reproduce(c);
            foreach (Chromosome child in children)
            {
                double r = Randomiser.nextDouble();
                Console.WriteLine("Child:\t\t\t" + child.BinaryString);
                if (r < mutateRate)
                {
                    child.Mutate();
                    Console.WriteLine("Child Mutation: " + child.BinaryString);
                }
                
            }
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
       
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
