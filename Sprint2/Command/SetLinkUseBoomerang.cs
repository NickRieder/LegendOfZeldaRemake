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
        public SetLinkUseBoomerang(Link link, SoundFactory soundFactory)
        {
            this.link = link;
            boomerangSound = soundFactory.getArrowOrBoomerang();
        }



        public void Execute()
        {
            link.item.SetItem("Boomerang");

        }
    }
}