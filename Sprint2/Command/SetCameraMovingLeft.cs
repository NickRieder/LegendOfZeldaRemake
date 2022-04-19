using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetCameraMovingLeft : ICommand
    {
        private Camera camera;
        private Door door;

        public SetCameraMovingLeft(Camera camera, Door door)
        {
            this.camera = camera;
            this.door = door;
        }

        public void Execute()
        {
            camera.AnimateRoomTransition("Left", door);
        }
    }
}
