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
        void Move(string direction);
        void UseWeapon();
        void TakeDamage(int collisionSide);
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}


