using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Sprint2
{
    public class LinkSpriteFactory : ISpriteFactory
    {
        private static Texture2D linkSheet;
        private static Texture2D linkSheetMirrored;
        private ContentManager content;

        // Kevin: Added a constructor so that we don't have the problem stated on line 42 in the Game1.cs file.
        public LinkSpriteFactory(ContentManager content)
        {
            this.content = content;
        }

        public void LoadSpriteSheet()
        {
            linkSheet = content.Load<Texture2D>("Sheets/LinkSheet");
            linkSheetMirrored = content.Load<Texture2D>("Sheets/LinkSheetMirror");
        }

        public Texture2D getLinkSheet()
        {
            return linkSheet;
        }

        public Texture2D getLinkSheetMirrored()
        {
            return linkSheetMirrored;
        }

        public static Rectangle LINK_MOVE_DOWN_1 = new Rectangle(1, 11, 16, 16);
        public static Rectangle LINK_MOVE_DOWN_2 = new Rectangle(18, 11, 16, 16);
        public static Rectangle LINK_MOVE_RIGHT_1 = new Rectangle(35, 11, 16, 16);
        public static Rectangle LINK_MOVE_RIGHT_2 = new Rectangle(52, 11, 16, 16);
        public static Rectangle LINK_MOVE_UP_1 = new Rectangle(69, 11, 16, 16);
        public static Rectangle LINK_MOVE_UP_2 = new Rectangle(86, 11, 16, 16);
        public static Rectangle LINK_MOVE_MIRROR_LEFT_1 = new Rectangle(320, 11, 16, 16);
        public static Rectangle LINK_MOVE_MIRROR_LEFT_2 = new Rectangle(303, 11, 16, 16);

        public static Rectangle LINK_PICKUP_ITEM_1 = new Rectangle(231, 11, 16, 16);
        public static Rectangle LINK_PICKUP_ITEM_2 = new Rectangle(248, 11, 16, 16);

        public static Rectangle LINK_USEITEM_DOWN = new Rectangle(107, 11, 16, 16);
        public static Rectangle LINK_USEITEM_RIGHT = new Rectangle(124, 11, 16, 16);
        public static Rectangle LINK_USEITEM_UP = new Rectangle(141, 11, 16, 16);
        public static Rectangle LINK_USEITEM_MIRROR_LEFT = new Rectangle(232, 11, 16, 16);

        public static Rectangle LINK_USESWORD_DOWN = new Rectangle(18, 47, 16, 27);
        public static Rectangle LINK_USESWORD_RIGHT = new Rectangle(18, 78, 27, 16);
        public static Rectangle LINK_USESWORD_UP = new Rectangle(18, 97, 16, 28);
        public static Rectangle LINK_USESWORD_MIRROR_LEFT = new Rectangle(326, 78, 27, 16);

    }
}
