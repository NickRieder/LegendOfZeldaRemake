using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetLinkDamagedDown : ICommand
    {
        private Link link;
        public SetLinkDamagedDown(Link link)
        {
            this.link = link;
        }



        public void Execute()
        {
            link.TakeDamage();

        }
    }
}
