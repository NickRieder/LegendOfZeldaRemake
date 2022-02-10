using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public interface IEnemyState
    {
        void StandingFacingUp();
        void StandingFacingDown();
        void StandingFacingRight();
        void StandingFacingLeft();
        void Move();
        void UseWeapon();
        void TakeDamage();
        void Draw(SpriteBatch spriteBatch);
        void Update();
    }
}
