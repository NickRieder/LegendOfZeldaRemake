using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetCameraMovingDown : ICommand
    {
        private Camera camera;

        public SetCameraMovingDown(Camera camera)
        {
            this.camera = camera;
        }

        public void Execute()
        {
            camera.AnimateRoomTransition("Down");
        }
    }
}
