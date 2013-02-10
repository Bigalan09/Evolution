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
        }

        private void SetProperties()
        {
            this.Mass = (1 / ((Gene)chromosome.GetGene(PropertyType.Body_Mass)).Value);
            this.Max_Force = this.Mass + 0.2f;
            this.Max_Force = (1 / ((Gene)chromosome.GetGene(PropertyType.Max_Speed)).Value);
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
