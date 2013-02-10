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
    class BlackCreature : Creature
    {
        public BlackCreature(float x, float y, Chromosome chromo = null)
            : base(x, y)
        {
        }

        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>("blackcreature");
            base.LoadContent(content);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
            base.Draw(spriteBatch, gameTime);
        }
    }
}
