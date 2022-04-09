using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetPreviousItem : ICommand
    {
        private Menu menu;
        public SetPreviousItem(Menu menu)
        {
            this.menu = menu;
        }

        public void Execute()
        {
            menu.PreviousItem();
        }
    }
}
