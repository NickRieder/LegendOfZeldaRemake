using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Sprint2
{
    class BlockSpriteFactory : ISpriteFactory
    {
        private static Texture2D tileSheet;
        public void LoadSpriteSheet(ContentManager content)
        {
            tileSheet = content.Load<Texture2D>("Sheets/TileSheet");
        }

        public Texture2D getTileSheet()
        {
            return tileSheet;
        }

        public static Rectangle TILE_DOOR = new Rectangle(881, 25, 32, 18);
        public static Rectangle TILE_STAIRS = new Rectangle(1035, 28, 16, 16);
        public static Rectangle TILE_FLATBLOCK = new Rectangle(984, 11, 16, 16);
        public static Rectangle TILE_NONFLAT_BLOCK = new Rectangle(1001, 11, 16, 16);
        public static Rectangle TILE_BRICK_BLOCK = new Rectangle(984, 45, 16, 16);
        
    }
}
