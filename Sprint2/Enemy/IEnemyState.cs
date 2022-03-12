using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public interface IEnemyState
    {
        void MoveUp();
        void MoveDown();
        void MoveRight();
        void MoveLeft();
        //void Attack();
        void TakeDamage();
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
