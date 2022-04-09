using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetLinkItem : ICommand
    {
        private Menu menu;
        public SetLinkItem(Menu menu)
        {
            this.menu = menu;
        }

        public void Execute()
        {
            menu.SetItem();
        }
    }
}
