using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class MovingCamera : ICameraState
    {
        //We will have to write the raw size of sprites somewhere for easy access.
        private const int START_ANIMATION = 0;
        private const int STOP_VERTICAL_ANIMATION = 500;    // Raw height of room sprite is 176, so 176 * 3 = 528
        private const int STOP_HORIZONTAL_ANIMATION = 700;    // Raw width of room sprite is 256, so 256 * 3 = 768

        private const int cameraMovementAmount = 5;
        Camera camera;
        private int xPos;
        private int yPos;
        string direction;
        bool canContinue;

        public MovingCamera(Camera camera, string direction)
        {
            this.camera = camera;
            xPos = START_ANIMATION;
            yPos = START_ANIMATION;
            this.direction = direction;
            canContinue = true;
        }

        public void FreezeCamera(int xPos, int yPos)
        {
            camera.currState = new StaticCamera(camera, xPos, yPos);
        }
        public void AnimateRoomTransition(string direction)
        {
            switch (direction)
            {
                case "Up":
                    yPos += cameraMovementAmount;
                    if (yPos >= STOP_VERTICAL_ANIMATION)
                    {
                        canContinue = false;
                    }
                    break;
                case "Down":
                    yPos -= cameraMovementAmount;
                    if (yPos <= -STOP_VERTICAL_ANIMATION)
                    {
                        canContinue = false;
                    }
                    break;
                case "Left":
                    xPos += cameraMovementAmount;
                    if (xPos >= STOP_HORIZONTAL_ANIMATION)
                    {
                        canContinue = false;
                    }
                    break;
                case "Right":
                    xPos -= cameraMovementAmount;
                    if (xPos <= -STOP_HORIZONTAL_ANIMATION)
                    {
                        canContinue = false;
                    }
                    break;
                default:
                    break;
            }
            var position = Matrix.CreateTranslation(xPos, yPos, 0);

            //var offset = Matrix.CreateTranslation(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2, 0);

            camera.transform = position;
        }

        public void Update(GameTime gameTime)
        {
            if (canContinue)
            {
                AnimateRoomTransition(direction);
            }
            else
            {
                FreezeCamera(xPos, yPos);
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}
