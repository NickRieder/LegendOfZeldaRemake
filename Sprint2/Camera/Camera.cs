using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class Camera
    {
        
        private GameTime gameTime;
        public ICameraState currState;
        public Matrix transform;
        public Viewport view;
        public Vector2 center;


        public Camera()    // , Viewport newView
        {
            //view = newView;

            currState = new StaticCamera(this, 0, 0);
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
