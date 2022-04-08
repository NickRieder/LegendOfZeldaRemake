using System;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.GameStates;

namespace Sprint2.Command
{
    public class SetWinningState : ICommand
    {
        private WinningState winningState;
        private SpriteBatch sb;
        private Game1 game;
        private int cursorpos;
        private SpriteFont font;

        public SetWinningState(WinningState winningState)
        {
            winningState = new WinningState(game, font);
            this.winningState = winningState;
        }

        public void Execute()
        {
            winningState.AnimateWinningState();
        }
    }
}
