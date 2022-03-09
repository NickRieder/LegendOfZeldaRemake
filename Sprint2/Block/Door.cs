using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class Door : ISprite
    {
        public Vector2 pos { get; set; }
        public SpriteFactory spriteFactory;
        private String nextLevel; // why is the string type have "S" capitalized?
        private LevelLoader levelLoader;

        public Sprite sprite;
        public string doorType;

        public Door(string doorType, String nextLevel, LevelLoader levelLoader) 
        {
            pos = new Vector2(100, 500);
            this.nextLevel = nextLevel;
            this.levelLoader = levelLoader;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch, pos);
        }

        public void SetSpriteContent(SpriteFactory spriteFactory)
        {
            this.spriteFactory = spriteFactory;

            switch (doorType)
            {
                case "Top Door":
                    sprite = spriteFactory.getTopDoorSprite();
                    break;
                default:
                    sprite = spriteFactory.getTopDoorSprite();
                    break;

            }
        }

        public Rectangle GetSpriteRectangle()
        {
            return sprite.getDestinationRectangle();
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
