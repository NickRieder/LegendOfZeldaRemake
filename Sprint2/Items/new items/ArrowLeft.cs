using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class ArrowLeft : IItem
    {
        private Rectangle frame1;
        private Texture2D sheet;
        private Vector2 itemPos;

        public ArrowLeft(Link link, LinkSpriteFactory spriteFactory)
        {
            frame1 = ItemSpriteFactory.ARROW_UPSIDEDOWN_DOWN;
            this.sheet = spriteFactory.getLinkSheet();
            itemPos.X = link.pos.X;
            itemPos.Y = link.pos.Y;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangleFrame1 = new Rectangle((int)itemPos.X, (int)itemPos.Y, frame1.Width, frame1.Height);
            spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
        }

        public void Update()
        {
            itemPos.X -= 5;
        }
    }
}
