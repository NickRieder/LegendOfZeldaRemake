using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;


namespace Sprint2
{
    class SetLinkUseBomb : ICommand
    {
        private Link link;
        private SoundEffect bombSound;
        public SetLinkUseBomb(Link link, SoundFactory soundFactory)
        {
            this.link = link;
            bombSound = soundFactory.getBombBlow();
        }



        public void Execute()
        {
            link.UseItem(3);
            bombSound.Play();

        }
    }
}