using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetCameraMovingLeft : ICommand
    {
        private Camera camera;

        public SetCameraMovingLeft(Camera camera)
        {
            this.camera = camera;
        }

        public void Execute()
        {
            camera.AnimateRoomTransition("Left");
        }
    }
}
