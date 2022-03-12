using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class ArrowLeft : IItem
    {
        private Vector2 itemPos;
        private Sprite arrow;

        public ArrowLeft(Link link, SpriteFactory spriteFactory)
        {
            arrow = spriteFactory.getArrowSpriteLeft();
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
            itemPos.X -= 5;
        }
    }
}
