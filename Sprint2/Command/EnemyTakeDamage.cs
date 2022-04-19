using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Command
{
    class EnemyTakeDamage : ICommand
    {
        private Enemies enemy;
        public EnemyTakeDamage(Enemies enemy)
        {
            this.enemy = enemy;
        }



        public void Execute()
        {
            enemy.TakeDamage();
        }
    }
}
