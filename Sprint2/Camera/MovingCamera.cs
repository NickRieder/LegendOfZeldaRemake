﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class MovingCamera : ICameraState
    {
        Camera camera;
        private int xPos;
        private int yPos;
        string direction;
        bool canContinue;

        public MovingCamera(Camera camera, string direction)
        {
            this.camera = camera;
            xPos = (int)Camera.CAMERA_SETTING.START_ANIMATION;
            yPos = (int)Camera.CAMERA_SETTING.START_ANIMATION;
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
                    yPos += 5;
                    if (yPos >= (int)Camera.CAMERA_SETTING.STOP_VERTICAL_ANIMATION)
                    {
                        canContinue = false;
                    }
                    break;
                case "Down":
                    yPos -= 5;
                    if (yPos <= -(int)Camera.CAMERA_SETTING.STOP_VERTICAL_ANIMATION)
                    {
                        canContinue = false;
                    }
                    break;
                case "Left":
                    xPos += 5;
                    if (xPos >= (int)Camera.CAMERA_SETTING.STOP_HORIZONTAL_ANIMATION)
                    {
                        canContinue = false;
                    }
                    break;
                case "Right":
                    xPos -= 5;
                    if (xPos <= -(int)Camera.CAMERA_SETTING.STOP_HORIZONTAL_ANIMATION)
                    {
                        canContinue = false;
                    }
                    break;
                default:
                    break;
            }
            camera.xPos = -xPos;
            camera.yPos = -yPos;
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
                // We know this looks bad with all the dots, but we will refactor this once our door collision works
                camera.gom.mouseController.door.LoadNextRoom();

                // Reset camera position back to the center playable room and freeze it there.
                camera.xPos = (int)Camera.CAMERA_SETTING.STARTING_X_POS;
                camera.yPos = (int)Camera.CAMERA_SETTING.STARTING_Y_POS;
                FreezeCamera(camera.xPos, camera.yPos);
            }
            
        }

        // Not necessary because there's already a spriteBatch.Begin(transformMatrix: camera.transform) in Game1.cs
        public void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}
