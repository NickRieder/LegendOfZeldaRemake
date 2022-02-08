using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemy
{
    public class DownMovingEnemyState : IEnemyState
    {
        private Enemy enemy;

        public DownMovingEnemyState(Enemy enemy)
        {
            this.enemy = enemy;
            // construct enemy's sprite here too
        }

        // Moving States
        public void MoveLeftState()
        {

        }
        public void MoveRightState()
        {

        }
        public void MoveUpState()
        {

        }
        public void MoveDownState()
        {

        }

        // Attacking States
        public void AttackleftState()
        {

        }
        public void AttackRightState()
        {

        }
        public void AttackUpState()
        {

        }
        public void AttackDownState()
        {

        }

        // Implement enemy Taking Damage States in the future.
        public void TakeDamageLeftState()
        {

        }
        public void TakeDamageRightState()
        {

        }
        public void TakeDamageUpState()
        {

        }
        public void TakeDamageDownState()
        {

        }
        // Implement enemy Death State in the future.
        public void Death()
        {

        }

        public void Update()
        {
            // call something like enemy.MoveDown() or enemy.Move(0,-y);
        }
        public void Draw()
        {

        }

    }
}
