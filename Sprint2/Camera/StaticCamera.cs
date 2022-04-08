using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class StaticCamera : ICameraState
    {
        Camera camera;
        private int xCount;
        private int yCount;

        private static int screenSizeHalf = 2;

        public StaticCamera(Camera camera, int xCount, int yCount)
        {
            this.camera = camera;
            this.xCount = xCount;
            this.yCount = yCount;
        }

        public void FreezeCamera(int xPos, int yPos)
        {
            var position = Matrix.CreateTranslation(xPos, yPos, 0);

            var offset = Matrix.CreateTranslation(Game1.ScreenWidth / screenSizeHalf, Game1.ScreenHeight / screenSizeHalf, 0);

            camera.transform = position;
        }
        public void AnimateRoomTransition(string direction)
        {
            camera.currState = new MovingCamera(camera, direction);
        }

        public void Update(GameTime gameTime)
        {
            FreezeCamera(xCount, yCount);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}
