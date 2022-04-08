using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Threading;

namespace Sprint2.GameStates
{
    public class WinningState : IGameState
    {

        private Game1 game;
        private int cursorpos;
        private SpriteFont font;
        private bool previously_start;
        private bool previously_select;
        private bool isStartPressed;

        public WinningState(Game1 game, SpriteFont font)
        {
            this.game = game;
            this.font = font;
            cursorpos = 0;
            previously_select = previously_select = isStartPressed = false;
        }

        private void MoveCursor()
        {
            cursorpos += 1;
            cursorpos %= 2;
        }

        private void Confirm(bool start_pressed)
        {
            switch (start_pressed)
            {
                case true:
                    Thread.Sleep(500);
                    new ResetGame(game).Execute();
                    break;
                case false:
                    game.Exit();
                    break;
            }
        }

        public void Update()
        {
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            bool select_pressed = Keyboard.GetState().IsKeyDown(Keys.RightShift);
            bool start_pressed = Keyboard.GetState().IsKeyDown(Keys.Enter) || state.IsButtonDown(Buttons.Start);

            if ((start_pressed && !previously_start) || state.IsButtonDown(Buttons.Start))
            {
                Confirm(start_pressed);
                return;
            }

            if ((select_pressed && !previously_select) || state.ThumbSticks.Left.Y < -0.5f || state.ThumbSticks.Left.Y > 0.5f || state.IsButtonDown(Buttons.DPadDown) || state.IsButtonDown(Buttons.DPadUp))
            {
                MoveCursor();
            }

            previously_start = start_pressed;
            previously_select = select_pressed;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.DrawString(font, "Thanks Link, You're", new Vector2(50, 30), Color.Red);
            sb.DrawString(font, "The Hero of Hyrule.", new Vector2(50, 80), Color.Red);
            sb.DrawString(font, "Finally", new Vector2(50, 130), Color.Red);
            sb.DrawString(font, "Peace returns to Hyrule.", new Vector2(50, 180), Color.Red);
            sb.DrawString(font, "This ends the story.", new Vector2(50, 205), Color.Blue);
            sb.DrawString(font, "Another story awaits! Press the Start button.", new Vector2(50, 230), Color.Red);
        }
    }
}
