using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class LinkItem
    {
        public IItem currItem;
        public SpriteFactory spriteFactory;

        public LinkItem(SpriteFactory linkSpriteFactory)
        {
            spriteFactory = linkSpriteFactory;
        }
    }
}
