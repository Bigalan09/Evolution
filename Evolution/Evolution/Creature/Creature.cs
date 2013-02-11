using Evolution.Genetics;
using Evolution.Utils;
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

        private bool dead = false;

        public bool Dead
        {
            get { return dead; }
        }
        private float energy = 100f;

        public float Energy
        {
            get { return energy; }
            set { energy = value; }
        }
        private int age = 0;
        private float health = 100f;
        private CreatureGroup group;
        private bool canReproduce = false;
        private float currentTime = 0f;
        private float duration = 5f;
        private float coolDown = 0f;

        public bool CanReproduce
        {
            get { return canReproduce; }
            set { canReproduce = value; }
        }

        public Creature(CreatureGroup group, float x, float y, Chromosome chromo = null)
            : base(x, y)
        {
            this.group = group;

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
            this.Mass = chromosome.GetGene(PropertyType.Body_Mass).Value;
            this.Max_Force = (chromosome.GetGene(PropertyType.Max_Speed).Value / 1000);
            this.Max_Speed = (chromosome.GetGene(PropertyType.Max_Speed).Value / 100) + 0.1f;
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (currentTime >= duration)
            {
                currentTime -= duration;
                age++;
                if (coolDown > 0)
                    coolDown--;
            }

            energy -= Max_Speed / 100;
            if (energy <= 0)
            {
                Max_Speed -= (Max_Speed / 1000);
                if (Max_Speed < 0.1)
                    Max_Speed = 0.1f;
                health -= 0.01f;
            }
            if (health <= 0)
                dead = true;

            if (energy > 50 && age >= 5 && coolDown <= 0)
                canReproduce = true;
            else
                canReproduce = false;

            if (canReproduce)
            {
                if (group.CreaturesInRadius(6, Position).Count > 0)
                {
                    Creature c = group.CreaturesInRadius(6, Position)[0];
                    if (c.CanReproduce)
                    {
                        if (Randomiser.nextDouble() < 0.69) // Reproduction rate
                        {
                            List<Chromosome> children = chromosome.Reproduce(c.chromosome);
                            if (Randomiser.nextDouble() < 0.33) // Mutation rate
                            {
                                children[0].Mutate();
                                children[1].Mutate();
                            }
                            group.addCreature(Position.X, Position.Y, children[0]);
                            c.Energy -= 20;
                            energy -= 20;
                            coolDown = 5f;
                            if (Randomiser.nextDouble() < 0.5)
                                group.addCreature(Position.X, Position.Y, children[1]);
                        }
                    }
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw(spriteBatch, gameTime);
        }
    }
}
