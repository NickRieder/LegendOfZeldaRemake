using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public interface ISprite
    {
        public Vector2 pos { get; set; }
        public void SetSpriteContent(SpriteFactory spriteFactory);
        public void SetSoundContent(SoundFactory soundFactory);
        public Rectangle GetSpriteRectangle();
        public void Draw(SpriteBatch spritebatch);
        public void Update(GameTime gameTime);
        public object GetConcreteObject();
    }
}
