using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace Sprint2
{
    class SetLinkUseBoomerang : ICommand
    {
        private Link link;
        private SoundEffect boomerangSound;
        public SetLinkUseBoomerang(Link link)
        {
            this.link = link;
        }



        public void Execute()
        {
            link.item.SetItem("Boomerang");

        }
    }
}