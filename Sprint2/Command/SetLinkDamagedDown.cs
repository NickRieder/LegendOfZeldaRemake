using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetTakeDamage : ICommand
    {
        private Link link;
        public SetTakeDamage(Link link)
        {
            this.link = link;
        }



        public void Execute()
        {
            link.TakeDamage();

        }
    }
}
