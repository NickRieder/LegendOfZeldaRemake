using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetLinkAttacking : ICommand
    {
        private Link link;
        private SoundEffect attackSound;
        public SetLinkAttacking(Link link, SoundFactory soundFactory)
        {
            this.link = link;
            attackSound = soundFactory.getSwordSlash();
        }



        public void Execute()
        {
            link.UseWeapon();
            attackSound.Play();
            
        }
    }
}
