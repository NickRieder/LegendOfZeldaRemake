using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class Boomerang : IItem
    {
        private Vector2 itemPos;
        private int counter;
        private int speed;
        private Link link;
        private Sprite sprite;
        private string direction;

        public Boomerang(Link link, SpriteFactory spriteFactory)
        {
            this.link = link;
            counter = 0;
            itemPos = link.pos;
            speed = 7;
            direction = link.GetDirection();
            switch (direction)
            {
                case "down":
                    itemPos.Y = link.pos.Y + link.GetSpriteRectangle().Height;
                    break;
                case "up":
                    itemPos.Y = link.pos.Y - link.GetSpriteRectangle().Height;
                    break;
                case "right":
                    itemPos.X = link.pos.X + link.GetSpriteRectangle().Width;
                    break;
                case "left":
                    itemPos.X = link.pos.X - link.GetSpriteRectangle().Width;
                    break;
                default:
                    break;
            }


            sprite = spriteFactory.getBoomerangSprite();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, itemPos);
        }

        public void Update(GameTime gameTime)
        {
            switch(direction)
            {
                case "down":
                    itemPos.Y += speed;
                    break;
                case "up":
                    itemPos.Y -= speed;
                    break;
                case "right":
                    itemPos.X += speed;
                    break;
                case "left":
                    itemPos.X -= speed;
                    break;
                default:
                    break;
            }
            
            if (counter % 5 == 0)
            {
                sprite.Update(gameTime);
                speed--;
            }
            if(sprite.getDestinationRectangle().Intersects(link.GetSpriteRectangle()))
            {
                link.item = new NullItem();
            }
            counter++;
        }
    }
}
