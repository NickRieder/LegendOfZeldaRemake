using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class Background : ISprite
    {
        public Vector2 pos { get; set; }
        private string roomName;
        private Sprite sprite;
        

        public Background()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, new Vector2(0, 0));
        }

        public Rectangle GetSpriteRectangle()
        {
            return sprite.getDestinationRectangle();
        }

        public void SetRoomName(string roomName)
        {
            this.roomName = roomName;
        }

        public void SetSpriteContent(SpriteFactory spriteFactory)
        {
            switch (roomName)
            {
                case "room1":
                    sprite = spriteFactory.getRoom1Sprite();
                    break;
                case "bridge":
                    sprite = spriteFactory.getBrickBlockSprite();
                    break;
                case "itemRoom":
                    sprite = spriteFactory.getItemRoomSprite();
                    break;
                case "itemRoomFlipped":
                    sprite = spriteFactory.getItemRoomFlippedSprite();
                    break;
                default:
                    sprite = spriteFactory.getRoom1Sprite();
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public Background GetConcreteObject()
        {
            return this;
        }

        object ISprite.GetConcreteObject()
        {
            return this;
        }
    }
}
