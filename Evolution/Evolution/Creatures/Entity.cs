using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.Creatures
{
    abstract class Entity
    {
        private static int next_id = 0;
        private string id = "entity";

        private Texture2D texture;
        private Rectangle bounds = new Rectangle();
        private Vector2 position = new Vector2();
        private Vector2 origin = new Vector2();
        private bool alive = true;

        public bool Alive
        {
            get { return alive; }
            set { alive = value; }
        }
        
        public Texture2D Texture
        {
            get { return texture; }
            set
            {
                texture = value;
                this.bounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
                this.origin = new Vector2(this.bounds.Width / 2, this.bounds.Height / 2);
            }
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

        public string ID
        {
            get { return this.id; }
        }

        public Entity(float x, float y)
        {
            position = new Vector2(x, y);
            this.id += next_id.ToString();
            next_id++;
        }

        public virtual void LoadContent(ContentManager content)
        {
            this.bounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            this.origin = new Vector2(this.bounds.Width / 2, this.bounds.Height / 2);
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

        }

    }
}
