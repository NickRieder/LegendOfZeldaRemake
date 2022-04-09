using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetNextItem : ICommand
    {
        private Menu menu;
        public SetNextItem(Menu menu)
        {
            this.menu = menu;
        }

        public void Execute()
        {
            menu.NextItem();
        }
    }
}
