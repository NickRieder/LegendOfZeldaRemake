using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;


namespace Sprint2
{
    class SetLinkUseBomb : ICommand
    {
        private Link link;
        
        public SetLinkUseBomb(Link link)
        {
            this.link = link;
           
        }



        public void Execute()
        {
            link.item.SetItem("Explosion");

        }
    }
}