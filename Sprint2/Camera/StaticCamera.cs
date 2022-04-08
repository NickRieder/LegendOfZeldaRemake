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
        private int xPos;
        private int yPos;

        public StaticCamera(Camera camera, int xPos, int yPos)
        {
            this.camera = camera;
            this.xPos = xPos;
            this.yPos = yPos;
        }

        public void FreezeCamera(int xPos, int yPos)
        {
            var position = Matrix.CreateTranslation(xPos, yPos, 0);

            var offset = Matrix.CreateTranslation(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2, 0);

            camera.transform = position;
        }
        public void AnimateRoomTransition(string direction)
        {
            camera.currState = new MovingCamera(camera, direction);
        }

        public void Update(GameTime gameTime)
        {
            FreezeCamera(xPos, yPos);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}
