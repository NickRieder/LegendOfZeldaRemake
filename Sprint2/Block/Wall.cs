using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class Wall : ISprite
    {
        public Vector2 pos { get; set; }
        private Sprite sprite;

        public Wall(Sprite sprite, Vector2 pos)
        {
            this.sprite = sprite;
            this.pos = pos;
        }

        

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch, pos);
        }

        public Rectangle GetSpriteRectangle()
        {
            return sprite.getDestinationRectangle();
        }

        public void SetSpriteContent(SpriteFactory spriteFactory)
        {
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public Wall GetConcreteObject()
        {
            return this;
        }

        object ISprite.GetConcreteObject()
        {
            return this;
        }

        public void SetSoundContent(SoundFactory soundFactory)
        {
            
        }
    }
}
