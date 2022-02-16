using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint2.Items
{
    public interface IItem
    {
        Texture2D Texture { get; set; }
        void Update();
        Rectangle MakeDestinationRectangle(Vector2 location);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
