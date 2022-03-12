using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class ExplosionRight : IItem
    {
        private int currFrame;
        private int counter;
        private Vector2 itemPos;
        private Link link;
        private Sprite Explosion;
        public ExplosionRight(Link link, SpriteFactory spriteFactory)
        {
            currFrame = 0;
            counter = 0;
            Explosion = spriteFactory.getExplosionSprite();
            this.link = link;
            itemPos.X = this.link.pos.X + 15;
            itemPos.Y = this.link.pos.Y;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Explosion.Draw(spriteBatch, itemPos);
        }

        public void Update(GameTime gameTime)
        {
            if (counter % 10 == 0)
            {
                Explosion.Update(gameTime);
                currFrame++;
            }
            if(Explosion.GetTotalFrames() <= currFrame)
            {
                link.item = new NullItem();
            }
            counter++;
        }
    }
}

