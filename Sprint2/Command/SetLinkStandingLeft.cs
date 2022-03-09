using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetLinkStandingLeft : ICommand
    {
        private Link link;
        public SetLinkStandingLeft(Link link)
        {
            this.link = link;
        }



        public void Execute()
        {
            link.StandingLeft();
        }
    }
}
