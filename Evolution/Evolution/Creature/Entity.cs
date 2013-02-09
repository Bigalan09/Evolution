using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.Creature
{
    abstract class Entity
    {

        private Texture2D texture;
        private Rectangle bounds = new Rectangle();
        private Vector2 position = new Vector2();
        private Vector2 origin = new Vector2();

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public Rectangle Bounds
        {
            get { return bounds; }
            set { bounds = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public Entity(float x, float y)
        {
            position = new Vector2(x, y);
        }

        public virtual void LoadContent(ContentManager content)
        {
            this.bounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

        }

    }
}
