using Evolution.Genetics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.Creatures
{
    class Creature : Vehicle
    {
        private Chromosome chromosome;

        internal Chromosome Chromosome
        {
            get { return chromosome; }
            set { chromosome = value; SetProperties(); }
        }

        private bool dead = false;

        public bool Dead
        {
            get { return dead; }
        }
        private float energy = 100f;
        private float health = 100f;

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
            this.Mass = chromosome.GetGene(PropertyType.Body_Mass).Value * 2;
            this.Max_Force = 1;
            this.Max_Speed = chromosome.GetGene(PropertyType.Max_Speed).Value / 5;
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            energy -= Max_Speed / 10;
            if (energy <= 0)
            {
                Max_Speed -= (Max_Speed / 1000);
                if (Max_Speed < 0.1)
                    Max_Speed = 0.1f;
                health -= 0.01f;
            }
            if (health <= 0)
                dead = true;

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw(spriteBatch, gameTime);
        }
    }
}
