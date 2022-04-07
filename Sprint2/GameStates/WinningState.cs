using System;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2.GameStates
{
    public class WinningState : IGameState
    {

        private Game1 game;
        private int cursorpos;
        private SpriteFont font;

        public WinningState(Game1 game, SpriteFont font)
        {
            this.game = game;
            this.font = font;
            cursorpos = 0;
        }

        private void MoveCursor()
        {
            cursorpos += 1;
            cursorpos %= 2;
        }

        private void Confirm()
        {
            switch (cursorpos)
            {
                case 0:
                    Thread.Sleep(500);
                    (new ResetGame(game)).Execute();
                    break;
                case 1:
                    game.Exit();
                    break;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
        }
    }
}
