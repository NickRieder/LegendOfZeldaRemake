using System;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public interface IGameState
    {
        void Update();
        void Draw(SpriteBatch sb);
    }
}
