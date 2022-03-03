using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint2
{
    public class Sprite
    {
        private Texture2D spriteSheet;
        private int currFrame;
        private int totalFrames;
        private Rectangle currRectangle;
        private List<Rectangle> frameList;
        private Rectangle destinationRectangle;

        public Sprite(Texture2D spriteSheet, params Rectangle[] frames)
        {
            this.spriteSheet = spriteSheet;
            currFrame = 0;
            totalFrames = frames.Length;
            frameList = new List<Rectangle>();
            destinationRectangle = new Rectangle();
            foreach(Rectangle frame in frames)
            {
                frameList.Add(frame);
            }
        }

        public void Update(GameTime gameTime)
        {
            currFrame++;
            if (currFrame == totalFrames)
            {
                currFrame = 0;
            }
            currRectangle = frameList[currFrame];
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, currRectangle.Width, currRectangle.Height);

            spriteBatch.Draw(spriteSheet, destinationRectangle, frameList[currFrame], Color.White);
        }

        public Rectangle getDestinationRectangle()
        {
            return destinationRectangle;
        }
    }
}
