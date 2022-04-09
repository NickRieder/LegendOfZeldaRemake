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

        private static int screenSizeHalf = 2;
        public StaticCamera(Camera camera, int xPos, int yPos)
        {
            this.camera = camera;
            this.xPos = xPos;
            this.yPos = yPos;
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
            FreezeCamera(xPos, yPos);
        }

        // Not necessary because there's already a spriteBatch.Begin(transformMatrix: camera.transform) in Game1.cs
        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void AnimateWinningState(string direction, SpriteFactory spriteFactory, SpriteBatch spriteBatch)
        {
            camera.currState = new MovingWinningState(camera, direction, spriteFactory, spriteBatch);
        }
    }
}
