using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetLinkUseArrow : ICommand
    {
        private Link link;
        public SetLinkUseArrow(Link link)
        {
            this.link = link;
        }



        public void Execute()
        {
            link.UseItem(1);

        }
    }
}