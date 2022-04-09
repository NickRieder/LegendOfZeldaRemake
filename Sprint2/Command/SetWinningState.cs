using System;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.GameStates;

namespace Sprint2.Command
{
    public class SetWinningState : ICommand
    {
        private Camera camera;
        private SpriteFont font;
        private SpriteFactory spriteFactory;
        private SpriteBatch spriteBatch;

        public SetWinningState(Camera camera, SpriteFactory spriteFactory, SpriteBatch spriteBatch)
        {
            this.camera = camera;
            this.spriteFactory = spriteFactory;
            this.spriteBatch = spriteBatch;
        }

        public void Execute()
        {
            camera.AnimateWinningState("Up", spriteFactory, spriteBatch);
        }
    }
}
