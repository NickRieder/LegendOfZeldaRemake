using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetCameraMovingUp : ICommand
    {
        private Camera camera;

        public SetCameraMovingUp(Camera camera)
        {
            this.camera = camera;
        }

        public void Execute()
        {
            camera.AnimateRoomTransition("Up");
        }
    }
}
