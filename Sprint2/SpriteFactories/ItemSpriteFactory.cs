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
        private static Texture2D linkSheet;
        private static Texture2D itemSheet;
        private ContentManager content;

        public ItemSpriteFactory(ContentManager content)
        {
            this.content = content;
        }

        public void LoadSpriteSheet()
        {
            linkSheetFlipped = content.Load<Texture2D>("Sheets/LinkSheetUpsideDown");
            linkSheet = content.Load<Texture2D>("Sheets/LinkSheet");
            itemSheet = content.Load<Texture2D>("Sheets/ItemSheet");
        }

        public Texture2D getLinkSheetFlipped()
        {
            return linkSheetFlipped;
        }

        public Texture2D getLinkSheet()
        {
            return linkSheet;
        }

        public Texture2D getItemSheet()
        {
            return itemSheet;
        }

        public static Rectangle ARROWORBOOMERANG_HIT = new Rectangle(89, 189, 7, 7);
        public static Rectangle ARROW_RIGHT = new Rectangle(9, 185, 15, 15);
        public static Rectangle ARROW_UP = new Rectangle(1, 185, 7, 15);
        public static Rectangle ARROW_UPSIDEDOWN_DOWN = new Rectangle(360, 108, 7, 7);
        public static Rectangle ARROW_MIRRORED_LEFT = new Rectangle(345, 185, 15, 15);
        

        public static Rectangle BOOMERANG_1 = new Rectangle(65, 189, 7, 7);
        public static Rectangle BOOMERANG_2 = new Rectangle(73, 189, 7, 7);
        public static Rectangle BOOMERANG_3 = new Rectangle(81, 189, 7, 7);

        public static Rectangle EXPLOSION_1 = new Rectangle(138, 185, 16, 16);
        public static Rectangle EXPLOSION_2 = new Rectangle(155, 185, 16, 16);
        public static Rectangle EXPLOSION_3 = new Rectangle(172, 185, 16, 16);

        // on ItemSheet
        public static Rectangle HEART_CANISTER = new Rectangle(25, 1, 14, 14);
        public static Rectangle WOODEN_SWORD = new Rectangle(104, 0, 8, 16);
        public static Rectangle MAGIC_SWORD = new Rectangle(104, 16, 8, 16);
        public static Rectangle BOW = new Rectangle(136, 16, 9, 17);
        public static Rectangle BOMB = new Rectangle(136, 0, 9, 14);
        public static Rectangle BOOMERANG = new Rectangle(129, 3, 6, 8);
        public static Rectangle RED_CANDLE = new Rectangle(160, 0, 8, 16);
        public static Rectangle BLUE_CANDLE = new Rectangle(160, 16, 8, 16);
        public static Rectangle ORANGE_RUBY = new Rectangle(71, 0, 9, 16);
        public static Rectangle BLUE_RUBY = new Rectangle(71, 16, 9, 16);


    }
}
