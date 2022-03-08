using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class Door : ISprite
    {
        private Sprite sprite;
        private Vector2 pos;
        private String nextLevel;
        private LevelLoader levelLoader;
        public Door(Sprite sprite, Vector2 pos, String nextLevel, LevelLoader levelLoader) 
        {
            this.sprite = sprite;
            this.pos = pos;
            this.nextLevel = nextLevel;
            this.levelLoader = levelLoader;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch, pos);
        }

        public void SetSpriteContent(SpriteFactory spriteFactory)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void LoadNextLevel()
        {
            levelLoader.LoadLevel(nextLevel);
        }
    }
}
