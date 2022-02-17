using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetPreviousEnemy : ICommand
    {
        private EnemiesList enemiesList;
        public SetPreviousEnemy(EnemiesList enemiesList)
        {
            this.enemiesList = enemiesList;
        }

        public void Execute()
        {
            enemiesList.PreviousEnemy();
        }
    }
}
