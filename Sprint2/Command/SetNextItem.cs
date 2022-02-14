using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetNextItem : ICommand
    {
        private Item item;
        public SetNextItem(Item item)
        {
            this.item = item;
        }

        public void Execute()
        {
            item.NextItem();
        }
    }
}
