using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BoomerangUp : IItem
    {
        private Vector2 itemPos;
        private int counter;
        private int speed;
        private Link link;
        private Sprite Boomerang;

        public BoomerangUp(Link link, SpriteFactory spriteFactory)
        {
            this.link = link;
            counter = 0;
            this.link = link;
            itemPos.X = link.pos.X;
            itemPos.Y = link.pos.Y;
            speed = 5;


            Boomerang = spriteFactory.getBoomerangSprite();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Boomerang.Draw(spriteBatch, itemPos);
        }

        public void Update(GameTime gameTime)
        {
            itemPos.Y -= speed;
            
            if (counter % 10 == 0)
            {
                Boomerang.Update(gameTime);
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
