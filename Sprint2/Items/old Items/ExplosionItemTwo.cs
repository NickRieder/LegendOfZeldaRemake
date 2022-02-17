using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2.Items
{
    public class ExplosionItemTwo : IItem
    {
        public Texture2D Texture { get; set; }
        private int spriteFrames;
        private int currentFrame;
        private int width;
        private int height;
        private int counter;


        public ExplosionItemTwo(Texture2D texture)
        {
            this.Texture = texture;
            width = this.Texture.Width / 4;
            height = this.Texture.Height;
            spriteFrames = 4;
            counter = 0;
            currentFrame = 0;
        }

        public void Update()
        {
            if (counter % 10 == 0)
            {
                currentFrame++;
                currentFrame %= spriteFrames;
                counter = 0;
            }
            counter++;
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new((currentFrame * width), 0, width, height);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, width, height);
        }
    }
}
