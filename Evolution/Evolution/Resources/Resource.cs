using Evolution.Creatures;
using Evolution.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.Resources
{
    class Resource : Entity
    {
        private int age = 0;
        private float amount = 10f;

        public float Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private ResourceManager resManager;
        private Regulator reg;
        private Regulator regAge;
        private int max_age;

        public Resource(ResourceManager resManager, float x, float y)
            : base(x, y)
        {
            this.resManager = resManager;
            Initialiser();
        }

        public Resource(ResourceManager resManager, float x, float y, Texture2D texture)
            : base(x, y)
        {
            this.resManager = resManager;
            this.Texture = texture;
            Initialiser();
        }

        private void Initialiser()
        {
            reg = new Regulator(Randomiser.nextInt(10, 20), 0);
            regAge = new Regulator(Randomiser.nextInt(2, 5), 0);
            max_age = Randomiser.nextInt(5, 15);
        }

        public override void LoadContent(ContentManager content)
        {
            this.Texture = content.Load<Texture2D>("resource");
            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            if (age >= max_age || amount <= 0)
            {
                resManager.removeResource(this);
            }
            if (regAge.IsReady(gameTime))
            {
                amount++;
                age++;
            }
            if (reg.IsReady(gameTime)) {
                if (Randomiser.nextDouble() < Game1.Parameters.Growth)
                {
                    resManager.addResource(this);
                }
                
            }
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (Texture != null) spriteBatch.Draw(Texture, Position, Color.White);
            base.Draw(spriteBatch, gameTime);
        }
    }
}
