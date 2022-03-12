using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class ExplosionUp : IItem
    {
        private int currFrame;
        private int totalFrames;
        private Rectangle frame1;
        private Rectangle frame2;
        private Rectangle frame3;
        private Texture2D sheet;
        private int counter;
        private Vector2 itemPos;
        private Link link;
        private Sprite Explosion;

        public ExplosionUp(Link link, SpriteFactory spriteFactory)
        {
            currFrame = 0;
            counter = 0;
            totalFrames = 3;
            this.link = link;
            Explosion = spriteFactory.getExplosionSprite();
            itemPos.X = this.link.pos.X;
            itemPos.Y = this.link.pos.Y - 15;
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
            if (Explosion.GetTotalFrames() <= currFrame)
            {
                link.item = new NullItem();
            }
            counter++;
        }
    }
}
