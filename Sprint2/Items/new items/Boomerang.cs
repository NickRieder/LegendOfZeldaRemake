using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class Boomerang : IItem
    {
        private Vector2 itemPos;
        private int counter;
        private double speed;
        private Link link;
        private Sprite sprite;
        private string direction;

        private const int startingSpeed = 7;
        private const int frameUpdateMod = 10;
        private const double speedDecrementInterval = 0.5;

        public Boomerang(Link link, SpriteFactory spriteFactory)
        {
            this.link = link;
            counter = 0;
            itemPos = link.pos;
            speed = startingSpeed;
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

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, itemPos);
        }

        public void Update(GameTime gameTime)
        {
            switch(direction)
            {
                case "down":
                    itemPos.Y += (int) speed;
                    break;
                case "up":
                    itemPos.Y -= (int) speed;
                    break;
                case "right":
                    itemPos.X += (int) speed;
                    break;
                case "left":
                    itemPos.X -= (int) speed;
                    break;
                default:
                    break;
            }
            
            

            if (((int) gameTime.TotalGameTime.TotalMilliseconds) % frameUpdateMod == 0)
            {
                sprite.Update(gameTime);
                speed-= speedDecrementInterval;
            }
            if(sprite.getDestinationRectangle().Intersects(link.GetSpriteRectangle()))
            {
                link.item.SetNull();
            }
            counter++;
        }
    }
}
