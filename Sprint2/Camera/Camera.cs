using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class Camera
    {
        private const int STARTING_X_POS = 0;
        private const int STARTING_Y_POS = 0;
        public int xPos { get; set; }
        public int yPos { get; set; }

        private GameTime gameTime;
        public ICameraState currState;
        public Matrix transform;
        public Viewport view;
        public Vector2 center;

        

        public Camera()    // , Viewport newView
        {
            //view = newView;

            xPos = STARTING_X_POS;
            yPos = STARTING_Y_POS;

            currState = new StaticCamera(this, xPos, yPos);
        }

        public void FreezeCamera(int xPos, int yPos)
        {
            currState.FreezeCamera(xPos, yPos);
        }

        public void AnimateRoomTransition(string direction) // pass in the side of the door later
        {
            currState.AnimateRoomTransition(direction);
        }

        public void Update(GameTime gameTime)
        {
            currState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currState.Draw(spriteBatch);
        }
    }
}
