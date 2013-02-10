using Evolution.Genetics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.Creature
{
    class Creature : Vehicle
    {
        private Chromosome chromosome;

        internal Chromosome Chromosome
        {
            get { return chromosome; }
            set { chromosome = value; SetProperties(); }
        }

        public Creature(float x, float y, Chromosome chromo = null)
            : base(x, y)
        {
            if (chromo != null)
            {
                chromosome = chromo;
            }
            else
            {
                chromosome = new Chromosome();
            }
            SetProperties();
        }

        private void SetProperties()
        {
            this.Mass = ((Gene)chromosome.GetGene(PropertyType.Body_Mass)).Value / 25;
            this.Max_Force = 0.001f;
            this.Max_Speed = ((Gene)chromosome.GetGene(PropertyType.Max_Speed)).Value / 25;
            Console.Write(Mass);
            Console.Write(":");
            Console.Write(Max_Speed);
            Console.WriteLine("");
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw(spriteBatch, gameTime);
        }
    }
}
