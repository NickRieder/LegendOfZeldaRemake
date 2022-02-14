using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Sprint2
{
    public class ItemSpriteFactory : ISpriteFactory
    {
        private static Texture2D linkSheetFlipped;
        private ContentManager content;

        public ItemSpriteFactory(ContentManager content)
        {
            this.content = content;
        }

        public void LoadSpriteSheet()
        {
            linkSheetFlipped = content.Load<Texture2D>("Sheets/LinkSheetUpsideDown");
        }

        public Texture2D getLinkSheetFlipped()
        {
            return linkSheetFlipped;
        }

        public static Rectangle ARROWORBOOMERANG_HIT = new Rectangle(89, 189, 7, 7);
        public static Rectangle ARROW_RIGHT = new Rectangle(9, 185, 15, 15);
        public static Rectangle ARROW_UP = new Rectangle(1, 185, 7, 15);
        public static Rectangle ARROW_UPSIDEDOWN_DOWN = new Rectangle(360, 108, 7, 7);
        public static Rectangle ARROW_MIRRORED_LEFT = new Rectangle(345, 185, 15, 15);
        public static Rectangle BOMB_ITEM = new Rectangle(129, 189, 8, 14);

        public static Rectangle BOOMERANG_1 = new Rectangle(65, 189, 7, 7);
        public static Rectangle BOOMERANG_2 = new Rectangle(73, 189, 7, 7);
        public static Rectangle BOOMERANG_3 = new Rectangle(81, 189, 7, 7);

        public static Rectangle EXPLOSION_1 = new Rectangle(138, 185, 16, 16);
        public static Rectangle EXPLOSION_2 = new Rectangle(155, 185, 16, 16);
        public static Rectangle EXPLOSION_3 = new Rectangle(172, 185, 16, 16);
    }
}
