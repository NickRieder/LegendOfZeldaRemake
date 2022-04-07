using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace Sprint2
{
    class SetLinkUseArrow : ICommand
    {
        private Link link;
        private SoundEffect arrowSound;
        public SetLinkUseArrow(Link link, SoundFactory soundFactory)
        {
            this.link = link;
            arrowSound = soundFactory.getArrowOrBoomerang();
        }



        public void Execute()
        {
            link.item.SetItem("Arrow");
        }
    }
}