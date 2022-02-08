using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemy
{
    public class Enemy
    {
        public IEnemyState enemyState;

        public Enemy()
        {
            enemyState = new DownMovingEnemyState(this);
        }

        // Enemy Move
        public void MoveLeft()
        {
            enemyState.MoveLeftState();
        }
        public void MoveRight()
        {
            enemyState.MoveRightState();
        }
        public void MoveUp()
        {
            enemyState.MoveUpState();
        }
        public void MoveDown()
        {
            enemyState.MoveDownState();
        }

        // Enemy Attack
        public void AttackLeft()
        {
            enemyState.AttackleftState();
        }
        public void AttackRight()
        {
            enemyState.AttackRightState();
        }
        public void AttackUp()
        {
            enemyState.AttackUpState();
        }
        public void AttackDown()
        {
            enemyState.AttackDownState();
        }

        // Enemy Take Damage
        public void TakeDamageLeft()
        {

        }
        public void TakeDamageRight()
        {

        }
        public void TakeDamageUp()
        {

        }
        public void TakeDamageDown()
        {

        }

    }
}
