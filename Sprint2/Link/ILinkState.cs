using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    public interface ILinkState
    {
        void StandingFacingUp();
        void StandingFacingDown();
        void StandingFacingRight();
        void StandingFacingLeft();
        void Move();
        void UseWeapon();
        void UseItem();
        void TakeDamage();
        void Draw(SpriteBatch spriteBatch);
        void Update();
    }
}


