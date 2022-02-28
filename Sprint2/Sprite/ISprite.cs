using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public interface ISprite
    {
        public void SetSpriteContent(LinkSpriteFactory linkSF, EnemySpriteFactory enemySF, ItemSpriteFactory itemSF, BlockSpriteFactory blockSF);
        public void Draw(SpriteBatch spritebatch);

        public void Update(GameTime gameTime);
    }
}
