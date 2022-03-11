using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using Microsoft.Xna.Framework;
using System.Linq;

namespace Sprint2
{
    public class MouseController : IController
    {

        private Door door;
        public MouseState pastState;

        public MouseController(Door door)
        {
            this.door = door;
        }



        public void Update(GameTime gameTime)
        {
            MouseState newState = Mouse.GetState();

            if ((newState.LeftButton == ButtonState.Pressed) && (pastState.LeftButton == ButtonState.Released))
            {
                door.LoadPreviousRoom();
            }
            else if ((newState.RightButton == ButtonState.Pressed) && (pastState.RightButton == ButtonState.Released))
            {
                door.LoadNextRoom();
            }
        }
    }
}