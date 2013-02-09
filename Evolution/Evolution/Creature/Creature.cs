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
        private Chromosome chromosome = new Chromosome();

        public Creature(float x, float y, float mass, float max_force = 0.3f, float max_speed = 0.93f)
            : base(x, y, mass, max_force, max_speed)
        {
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
