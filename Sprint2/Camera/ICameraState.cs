using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public interface ICameraState
    {
        public void FreezeCamera(int xPos, int yPos);
        public void AnimateRoomTransition(string direction, Door door);
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
        public void AnimateWinningState(string direction, SpriteFactory spriteFactory, SpriteBatch spriteBatch);
    }
}
