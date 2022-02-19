using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class LinkItem
    {
        public IItem currItem;
        public LinkSpriteFactory spriteFactory;

        public LinkItem(LinkSpriteFactory linkSpriteFactory)
        {
            spriteFactory = linkSpriteFactory;
        }
    }
}
