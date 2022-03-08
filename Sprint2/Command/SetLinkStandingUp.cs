using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetLinkStandingUp : ICommand
    {
        private Link link;
        public SetLinkStandingUp(Link link)
        {
            this.link = link;
        }



        public void Execute()
        {
            link.StandingUp();
        }
    }
}
