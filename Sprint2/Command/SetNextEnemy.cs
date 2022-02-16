using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetNextEnemy : ICommand
    {
        private EnemiesList enemiesList;
        public SetNextEnemy(EnemiesList enemiesList)
        {
            this.enemiesList = enemiesList;
        }

        public void Execute()
        {
            enemiesList.NextEnemy();
        }
    }
}
