using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetCameraMovingRight : ICommand
    {
        private Camera camera;

        public SetCameraMovingRight(Camera camera)
        {
            this.camera = camera;
        }

        public void Execute()
        {
            camera.AnimateRoomTransition("Right");
        }
    }
}
