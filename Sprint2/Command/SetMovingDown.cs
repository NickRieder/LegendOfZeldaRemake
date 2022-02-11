using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetMovingDown : ICommand
    {
        private Link link;
        public SetMovingDown(Link link)
        {
            this.link = link;
        }

        public void Execute()
        {
            link.MoveDown();
        }
    }
}
