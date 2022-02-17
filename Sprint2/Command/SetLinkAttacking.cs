using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetLinkAttacking : ICommand
    {
        private Link link;
        public SetLinkAttacking(Link link)
        {
            this.link = link;
        }



        public void Execute()
        {
            link.UseWeapon();
            
        }
    }
}
