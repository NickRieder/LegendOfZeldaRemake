using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint2
{
    public class NullSprite : ISprite
    {
        public Vector2 pos { get; set; }

        public NullSprite()
        {

        }

        public void SetSpriteContent(SpriteFactory spriteFactory)
        {

        }

        public Rectangle GetSpriteRectangle()
        {
            return new Rectangle(0, 0, 0, 0);
        }

        public NullSprite GetConcreteObject()
        {
            return this;
        }

        object ISprite.GetConcreteObject()
        {
            return this;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void SetSoundContent(SoundFactory soundFactory)
        {
            throw new System.NotImplementedException();
        }
    }
}
