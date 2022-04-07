using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public interface ICameraState
    {
        public void FreezeCamera();
        public void AnimateRoomTransition();
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
        
    }
}
