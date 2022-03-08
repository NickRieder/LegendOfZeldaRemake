using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BoomerangRight : IItem
    {
        private Vector2 itemPos;
        private int counter;
        private int speed;
        private Link link;
        private Sprite Boomerang;

        public BoomerangRight(Link link, SpriteFactory spriteFactory)
        {
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
            
            itemPos.X += speed;
            
            if(counter % 10 == 0)
            {
                Boomerang.Update(gameTime);
                speed--;
            }
            if(itemPos.X <= link.pos.X)
            {
                link.item = new NullItem();
            }
            counter++;
        }
    }
}
