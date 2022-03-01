using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BoomerangUp : IItem
    {
        private int currFrame;
        private int totalFrames;
        private Rectangle frame1;
        private Rectangle frame2;
        private Rectangle frame3;
        private Texture2D sheet;
        private Vector2 itemPos;
        private int counter;
        private int speed;
        private Link link;

        public BoomerangUp(Link link, SpriteFactory spriteFactory)
        {
            currFrame = 0;
            counter = 0;
            totalFrames = 3;
            frame1 = SpriteFactory.BOOMERANG_1;
            frame2 = SpriteFactory.BOOMERANG_2;
            frame3 = SpriteFactory.BOOMERANG_3;
            this.sheet = spriteFactory.getLinkSheet();
            itemPos.X = link.pos.X;
            itemPos.Y = link.pos.Y;
            speed = 5;
            this.link = link;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangleFrame1 = new Rectangle((int)itemPos.X, (int)itemPos.Y, frame1.Width, frame1.Height);
            Rectangle destinationRectangleFrame2 = new Rectangle((int)itemPos.X, (int)itemPos.Y, frame2.Width, frame2.Height);
            Rectangle destinationRectangleFrame3 = new Rectangle((int)itemPos.X, (int)itemPos.Y, frame3.Width, frame3.Height);

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
            itemPos.Y -= speed;
            if (currFrame == totalFrames)
            {
                currFrame = 0;
            }
            if (counter % 10 == 0)
            {
                currFrame++;
                speed--;
            }
            if (itemPos.Y >= link.pos.Y)
            {
                link.item = new NullItem();
            }
            counter++;
        }
    }
}
