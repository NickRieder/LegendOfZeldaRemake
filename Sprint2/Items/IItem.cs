using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint2.Items
{
    public interface IItem
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
