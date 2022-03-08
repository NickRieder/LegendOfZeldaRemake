using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetNextRoom : ICommand
    {
        private Door door;
        public SetNextRoom(Door door)
        {
            this.door = door;
        }

        public void Execute()
        {
            door.LoadNextLevel();
        }
    }
}
