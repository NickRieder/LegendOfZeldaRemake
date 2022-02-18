using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    public interface ILinkState
    {
        void MoveUp();
        void MoveDown();
        void MoveRight();
        void MoveLeft();
        void UseWeapon();
        void UseItem();
        void TakeDamage();
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}


