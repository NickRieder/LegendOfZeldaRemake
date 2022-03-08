using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetLinkMovingLeft : ICommand
    {
        private Link link;
        public SetLinkMovingLeft(Link link)
        {
            this.link = link;
        }



        public void Execute()
        {
            link.StandingLeft();
        }
    }
}
