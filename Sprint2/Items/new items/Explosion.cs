using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class Explosion : IItem
    {
        private int currFrame;
        private int counter;
        private Vector2 itemPos;
        private Link link;
        private Sprite sprite;
        private string direction;

        public Explosion(Link link, SpriteFactory spriteFactory)
        {
            direction = link.GetDirection();
            currFrame = 0;
            counter = 0;
            this.link = link;
            sprite = spriteFactory.getExplosionSprite();
            itemPos.X = this.link.pos.X;
            itemPos.Y = this.link.pos.Y + 15;

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
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, itemPos);
        }

        public void Update(GameTime gameTime)
        {
            if (counter % 10 == 0)
            {
                sprite.Update(gameTime);
                currFrame++;
            }
            if (sprite.GetTotalFrames() <= currFrame)
            {
                link.item = new NullItem();
            }
            counter++;
        }
    }
}
