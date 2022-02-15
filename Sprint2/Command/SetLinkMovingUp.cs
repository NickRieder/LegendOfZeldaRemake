﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetLinkMovingUp : ICommand
    {
        private Link link;
        public SetLinkMovingUp(Link link)
        {
            this.link = link;
        }



        public void Execute()
        {
            link.MoveUp();
        }
    }
}