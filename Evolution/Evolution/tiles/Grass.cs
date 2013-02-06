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
    class Grass : Tile
    {
        public Grass(Game1 game, float x, float y, Texture2D spriteSheet = null)
            : base(game)
        {
            TileSource = new Rectangle(0, 0, 5, 5);
            Position = new Vector2(x, y);
        }
    }
}
