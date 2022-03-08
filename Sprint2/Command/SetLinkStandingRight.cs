using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetLinkStandingRight : ICommand
    {
        private Link link;
        public SetLinkStandingRight(Link link)
        {
            this.link = link;
        }



        public void Execute()
        {
            link.StandingRight();
        }
    }
}
