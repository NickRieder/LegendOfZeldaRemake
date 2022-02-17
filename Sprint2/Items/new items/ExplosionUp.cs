using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2.Items
{
    public class ExplosionUp : IItem
    {
        private Item item;
        private int currFrame;
        private int totalFrames;
        private Rectangle frame1;
        private Rectangle frame2;
        private Rectangle frame3;
        private Texture2D sheet;
        private int counter;

        public ExplosionUp()
        {
            currFrame = 0;
            counter = 0;
            totalFrames = 3;
            frame1 = ItemSpriteFactory.EXPLOSION_1;
            frame2 = ItemSpriteFactory.EXPLOSION_2;
            frame3 = ItemSpriteFactory.EXPLOSION_3;
            this.sheet = item.spriteFactory.getLinkSheet();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangleFrame1 = new Rectangle((int)item.itemPos.X, (int)item.itemPos.Y, frame1.Width, frame1.Height);
            Rectangle destinationRectangleFrame2 = new Rectangle((int)item.itemPos.X, (int)item.itemPos.Y, frame2.Width, frame2.Height);
            Rectangle destinationRectangleFrame3 = new Rectangle((int)item.itemPos.X, (int)item.itemPos.Y, frame3.Width, frame3.Height);

            if (currFrame == 0)
            {
                spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
            }
            else if (currFrame == 1)
            {
                spriteBatch.Draw(sheet, destinationRectangleFrame2, frame2, Color.White);
            }
            else
            {
                spriteBatch.Draw(sheet, destinationRectangleFrame3, frame3, Color.White);
            }
        }

        public void Update()
        {
            item.itemPos.Y -= 5;
            if (++currFrame == totalFrames)
            {
                currFrame = 0;
            }
        }
    }
}
