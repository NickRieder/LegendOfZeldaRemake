using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class ExplosionRight : IItem
    {
        private int currFrame;
        private int totalFrames;
        private Rectangle frame1;
        private Rectangle frame2;
        private Rectangle frame3;
        private Texture2D sheet;
        private int counter;
        private Vector2 itemPos;
        private Link link;

        public ExplosionRight(Link link, LinkSpriteFactory spriteFactory)
        {
            currFrame = 0;
            counter = 0;
            totalFrames = 3;
            this.link = link;
            frame1 = ItemSpriteFactory.EXPLOSION_1;
            frame2 = ItemSpriteFactory.EXPLOSION_2;
            frame3 = ItemSpriteFactory.EXPLOSION_3;
            this.sheet = spriteFactory.getLinkSheet();
            itemPos.X = this.link.pos.X + 15;
            itemPos.Y = this.link.pos.Y;
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
            if (currFrame == totalFrames)
            {
                link.item = new NullItem();
            }
            if (counter % 10 == 0)
            {
                currFrame++;
            }
            counter++;
        }
    }
}

