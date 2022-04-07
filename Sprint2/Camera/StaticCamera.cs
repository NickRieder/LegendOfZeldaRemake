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

        public StaticCamera(Camera camera)
        {
            this.camera = camera;
        }

        public void FreezeCamera()
        {
            var position = Matrix.CreateTranslation(0, 0, 0);

            var offset = Matrix.CreateTranslation(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2, 0);

            camera.transform = position;
        }
        public void AnimateRoomTransition()
        {
            camera.currState = new MovingCamera(camera);
        }

        public void Update(GameTime gameTime)
        {
            FreezeCamera();
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}
