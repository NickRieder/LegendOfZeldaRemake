using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetLinkUseItem : ICommand
    {
        private Link link;
        public SetLinkUseItem(Link link)
        {
            this.link = link;
        }



        public void Execute()
        {
            link.UseItem();

        }
    }
}