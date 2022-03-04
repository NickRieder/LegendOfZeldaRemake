using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class ArrowUp : IItem
    {
        private Vector2 itemPos;
        private Sprite arrow;

        public ArrowUp(Link link, SpriteFactory spriteFactory)
        {
            arrow = spriteFactory.getArrowSpriteUp();
            itemPos.X = link.pos.X;
            itemPos.Y = link.pos.Y;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            arrow.Draw(spriteBatch, itemPos);
        }

        public void Update(GameTime gameTime)
        {
            arrow.Update(gameTime);
            itemPos.Y -= 5;
        }
    }
}
