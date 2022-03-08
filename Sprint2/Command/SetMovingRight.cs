using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetMovingRight : ICommand
    {
        private Link link;
        public SetMovingRight(Link link)
        {
            this.link = link;
        }

        public void Execute()
        {
            link.StandingRight();
        }
    }
}