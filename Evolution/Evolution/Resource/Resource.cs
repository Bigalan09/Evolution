using Evolution.Creature;
using Evolution.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.Resource
{
    class Resource : Entity
    {
        private float duration = 10.0f;
        private float currentTime = 0f;
        private int age = 0;
        private float amount = 1f;
        private ResourceManager resManager;

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
            duration = (float)Randomiser.nextInt(10, 20);
        }

        public override void LoadContent(ContentManager content)
        {
            this.Texture = content.Load<Texture2D>("resource");
            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (currentTime >= duration)
            {
                currentTime -= duration;
                if (Randomiser.nextDouble() < 0.3)
                {
                    resManager.addResource(this);
                }
                amount += 2.0f;
                age++;
            }

            if (age >= 5 || amount<= 0)
            {
                resManager.removeResource(this);
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
