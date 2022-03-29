using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class Arrow : IItem
    {
        private Vector2 itemPos;
        private Sprite sprite;
        private string direction;
        private int speed;

        public Arrow(Link link, SpriteFactory spriteFactory)
        {
            itemPos.X = link.pos.X;
            itemPos.Y = link.pos.Y;
            speed = 5;
            direction = link.GetDirection();
            switch (direction)
            {
                case "down":
                    sprite = spriteFactory.getArrowSpriteDown();
                    itemPos.Y = link.pos.Y + link.GetSpriteRectangle().Height;
                    break;
                case "up":
                    sprite = spriteFactory.getArrowSpriteUp();
                    itemPos.Y = link.pos.Y - link.GetSpriteRectangle().Height;
                    break;
                case "right":
                    sprite = spriteFactory.getArrowSpriteRight();
                    itemPos.X = link.pos.X + link.GetSpriteRectangle().Width;
                    break;
                case "left":
                    sprite = spriteFactory.getArrowSpriteLeft();
                    itemPos.X = link.pos.X - link.GetSpriteRectangle().Width;
                    break;
                default:
                    break;
            }
            
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, itemPos);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            switch (direction)
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
        }
    }
}
