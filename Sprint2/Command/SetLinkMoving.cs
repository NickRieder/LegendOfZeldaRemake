using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetLinkMoving : ICommand
    {
        private Link link;
        private string direction;
        public SetLinkMoving(Link link, string direction)
        {
            this.link = link;
            this.direction = direction;
        }



        public void Execute()
        {
            link.Move(direction);
        }
    }
}