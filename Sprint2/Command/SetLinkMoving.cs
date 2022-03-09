using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetLinkMoving : ICommand
    {
        private Link link;
        public SetLinkMoving(Link link)
        {
            this.link = link;
        }



        public void Execute()
        {
            link.Move();
        }
    }
}