using Evolution.Genetics;
using Evolution.Resources;
using Evolution.Utils;
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
        private float energy = 50f;
        private int age = 0;
        private int strength = 0;
        private int defence = 0;
        private float health = 100f;
        private CreatureGroup group;
        private Vector2 memory = Vector2.Zero;
        private bool canReproduce = false;
        private int carrying = 0;
        private int carryingCapacity = 0;
        private int sight = 0;
        private int gatherRate = 0;

        public int GatherRate
        {
            get { return gatherRate; }
            set { gatherRate = value; }
        }

        public int Sight
        {
            get { return sight; }
            set { sight = value; }
        }

        public int CarryingCapacity
        {
            get { return carryingCapacity; }
            set { carryingCapacity = value; }
        }

        public Chromosome Chromosome
        {
            get { return chromosome; }
            set { chromosome = value; SetProperties(); }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public float Energy
        {
            get { return energy; }
            set { energy = value; }
        }

        public Vector2 Memory
        {
            get { return memory; }
            set { memory = value; }
        }

        public CreatureGroup Group
        {
            get { return group; }
        }

        public float Health
        {
            get { return health; }
            set { health = value; }
        }

        public int Strength
        {
            get { return strength; }
        }

        public int Defence
        {
            get { return defence; }
        }

        public int Carrying
        {
            get { return carrying; }
            set { carrying = ((carrying + value) < CarryingCapacity) ? value : CarryingCapacity - Carrying; }
        }

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
            this.Mass = chromosome.GetGene(PropertyType.Defence).Value;
            this.Max_Force = 0.6f;
            this.strength = (int)chromosome.GetGene(PropertyType.Strength).Value;
            this.defence = (int)chromosome.GetGene(PropertyType.Defence).Value;
            this.CarryingCapacity = (int)chromosome.GetGene(PropertyType.Resource_Capacity).Value;
            this.Sight = (int)chromosome.GetGene(PropertyType.Sight_Radius).Value;
            this.GatherRate = (int)chromosome.GetGene(PropertyType.Gather_Rate).Value;

            this.Max_Speed = (1 / Mass * 2) + 0.5f;
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
