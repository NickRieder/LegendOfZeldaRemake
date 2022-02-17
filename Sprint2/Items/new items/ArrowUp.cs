using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2.Items
{
    public class ArrowUp : IItem
    {
        private Item item;
        private Rectangle frame1;
        private Texture2D sheet;

        public ArrowUp()
        {
            frame1 = ItemSpriteFactory.ARROW_UP;
            this.sheet = item.spriteFactory.getLinkSheet();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangleFrame1 = new Rectangle((int)item.itemPos.X, (int)item.itemPos.Y, frame1.Width, frame1.Height);
            spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
        }

        public void Update()
        {
            // throw new NotImplementedException();
            item.itemPos.Y -= 5;
        }
    }
}
