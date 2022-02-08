using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemy
{
    public interface IEnemyState
    {
        // Moving States
        public void MoveLeftState();
        public void MoveRightState();
        public void MoveUpState();
        public void MoveDownState();

        // Attacking States
        public void AttackleftState();
        public void AttackRightState();
        public void AttackUpState();
        public void AttackDownState();

        // Implement enemies taking damage states in the future.
        public void TakeDamageLeftState();
        public void TakeDamageRightState();
        public void TakeDamageUpState();
        public void TakeDamageDownState();
        // Implement enemies death state in the future.
        public void Death();          

        public void Update();
        public void Draw();
    }
}
