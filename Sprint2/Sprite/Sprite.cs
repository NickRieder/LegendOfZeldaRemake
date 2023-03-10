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
        public int scaleMultiplier;
        private const int frameUpdateMod = 10;
        private int counter;

        public Sprite(Texture2D spriteSheet, params Rectangle[] frames)
        {
            counter = 0;
            this.spriteSheet = spriteSheet;
            currFrame = 0;
            totalFrames = frames.Length;
            frameList = new List<Rectangle>();
            destinationRectangle = new Rectangle();
            foreach (Rectangle frame in frames)
            {
                frameList.Add(frame);
            }
            currRectangle = frameList[currFrame];

            scaleMultiplier = 3;
        }

        public void Update(GameTime gameTime)
        {
            if (counter % frameUpdateMod == 0)
            {
                currFrame++;
            }
            
            if (currFrame == totalFrames)
            {
                currFrame = 0;
            }
            counter++;
            currRectangle = frameList[currFrame];
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            // This Link Sword thing needs to be refactored because it messed up with the sprite position when i use link.GetSpriteRectangle (it's drawing in the wrong spots)

            if (frameList[0] == new Rectangle(18, 97, 16, 28)) // LINK_USESWORD_UP
            {
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y - 28, scaleMultiplier * currRectangle.Width, scaleMultiplier * currRectangle.Height);
            }
            else if (frameList[0] == new Rectangle(326, 78, 27, 16)) // LINK_USESWORD_MIRROR_LEFT
            {
                destinationRectangle = new Rectangle((int)location.X - 27, (int)location.Y, scaleMultiplier * currRectangle.Width, scaleMultiplier * currRectangle.Height);
            }
            else
            {
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, scaleMultiplier * currRectangle.Width, scaleMultiplier * currRectangle.Height);
            }
            spriteBatch.Draw(spriteSheet, destinationRectangle, frameList[currFrame], Color.White);
        }

        public Rectangle getDestinationRectangle()
        {
            return destinationRectangle;
        }

        public Rectangle getCurrentFrameRectangle()
        {
            Rectangle result = frameList[currFrame];
            result.Width *= scaleMultiplier;
            result.Height *= scaleMultiplier;
            return result;
        }

        public int GetTotalFrames()
        {
            return totalFrames;
        }
    }
}
