using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetCameraMovingUp : ICommand
    {
        private Camera camera;
        private Door door;

        public SetCameraMovingUp(Camera camera, Door door)
        {
            this.camera = camera;
            this.door = door;
        }

        public void Execute()
        {
            camera.AnimateRoomTransition("Up", door);
        }
    }
}
