using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    public interface ILinkState
    {
        void StandingUp();
        void StandingDown();
        void StandingRight();
        void StandingLeft();
        void Move();
        void UseWeapon();
        void UseItem(string newItem);
        void TakeDamage();
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}


