﻿using Evolution.Genetics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.Creatures
{
    class Herbivore : Creature
    {
        public Herbivore(CreatureGroup group, float x, float y, Chromosome chromo = null)
            : base(group, x, y)
        {
        }

        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>("redcreature");
            base.LoadContent(content);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //spriteBatch.Draw(Texture, Position, Color.White);
            base.Draw(spriteBatch, gameTime);
        }
    }
}
