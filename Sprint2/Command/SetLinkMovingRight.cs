using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetLinkMovingRight : ICommand
    {
        private Link link;
        public SetLinkMovingRight(Link link)
        {
            this.link = link;
        }



        public void Execute()
        {
            link.MoveRight();
        }
    }
}
