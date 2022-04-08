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

        private const int arrowSpeed = 5;

        public Arrow(Link link, SpriteFactory spriteFactory)
        {
            itemPos.X = link.pos.X;
            itemPos.Y = link.pos.Y;
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

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, itemPos);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            switch (direction)
            {
                case "down":
                    itemPos.Y += arrowSpeed;
                    break;
                case "up":
                    itemPos.Y -= arrowSpeed;
                    break;
                case "right":
                    itemPos.X += arrowSpeed;
                    break;
                case "left":
                    itemPos.X -= arrowSpeed;
                    break;
                default:
                    break;
            }
        }
    }
}
