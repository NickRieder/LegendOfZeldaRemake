using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetPreviousItem : ICommand
    {
        private Item item;
        public SetPreviousItem(Item item)
        {
            this.item = item;
        }

        public void Execute()
        {
            item.PreviousItem();
        }
    }
}
