using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetLinkStandingDown : ICommand
    {
        private Link link;
        public SetLinkStandingDown(Link link)
        {
            this.link = link;
        }



        public void Execute()
        {
            link.StandingDown();
        }
    }
}
