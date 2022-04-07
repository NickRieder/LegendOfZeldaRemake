using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class MovingCamera : ICameraState
    {
        Camera camera;

        public MovingCamera(Camera camera)
        {
            this.camera = camera;
        }

        public void FreezeCamera()
        {
            camera.currState = new StaticCamera(camera);
        }
        public void AnimateRoomTransition()
        {
            var position = Matrix.CreateTranslation(10, 10, 10);

            var offset = Matrix.CreateTranslation(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2, 0);

            camera.transform = position * offset;
        }

        public void Update(GameTime gameTime)
        {
            AnimateRoomTransition();
            
            // After the animation finishes, call FreezeCamera() to stop the camera from scrolling any further;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}
