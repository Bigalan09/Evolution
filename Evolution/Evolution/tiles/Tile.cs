using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Evolution.tiles
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public abstract class Tile : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private Texture2D spriteSheet;
        private Game1 gameRef;
        private Rectangle tileSource;

        public Rectangle TileSource
        {
            get { return tileSource; }
            set { tileSource = value; }
        }

        public Game1 GameRef
        {
            get { return gameRef; }
            set { gameRef = value; }
        }

        public Texture2D SpriteSheet
        {
            get { return spriteSheet; }
            set { spriteSheet = value; }
        }

        private Vector2 position;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Tile(Game1 game, Texture2D spriteSheet = null)
            : base(game)
        {
            GameRef = game;
            if (spriteSheet != null) SpriteSheet = spriteSheet;
            if (position == null) position = new Vector2();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteSheet = Game.Content.Load<Texture2D>("tiles");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //GameRef.SpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            GameRef.SpriteBatch.Begin(SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                null, null, null, null,
                GameRef.Cam.Transform);

            GameRef.SpriteBatch.Draw(this.spriteSheet, Position, tileSource, Color.White);
            GameRef.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
