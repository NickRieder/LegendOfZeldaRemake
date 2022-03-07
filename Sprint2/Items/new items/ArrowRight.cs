using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class ArrowRight : IItem
    {
        private Vector2 itemPos;
        private Sprite arrow;

        public ArrowRight(Link link, SpriteFactory spriteFactory)
        {
            arrow = spriteFactory.getArrowSpriteRight();
            itemPos.X = link.pos.X;
            itemPos.Y = link.pos.Y;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            arrow.Draw(spriteBatch, itemPos);
        }

        public void Update(GameTime gameTime)
        {
            // throw new NotImplementedException();
            arrow.Update(gameTime);
            itemPos.X += 5;
        }
    }
}
