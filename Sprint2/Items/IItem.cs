using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint2
{
    public interface IItem
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
