﻿using System;
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

        public WinningState(Game1 game, SpriteFont font)
        {
            this.game = game;
            this.font = font;
            cursorpos = 0;
            previously_select = previously_select = false;
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
                    new ResetGame(game).Execute();
                    break;
                case 1:
                    game.Exit();
                    break;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.DrawString(font, "Thanks Link, You're", new Vector2(20, 30), Color.Red);
            sb.DrawString(font, "The Hero of Hyrule.", new Vector2(50, 80), Color.Red);
            sb.DrawString(font, "Finally", new Vector2(50, 130), Color.Red);
            sb.DrawString(font, "Peace returns to Hyrule.", new Vector2(50, 180), Color.Red);
            sb.DrawString(font, "This ends the story.", new Vector2(20, 80 + 50 * cursorpos), Color.Blue);
            sb.DrawString(font, "Another story awaits! Press the Start button.", new Vector2(50, 230), Color.Red);
        }

        public void Update()
        {
            bool select_pressed = Keyboard.GetState().IsKeyDown(Keys.RightShift);
            bool start_pressed = Keyboard.GetState().IsKeyDown(Keys.Enter);
            GamePadState state = GamePad.GetState(PlayerIndex.One);

            if ((start_pressed && !previously_start) || state.IsButtonDown(Buttons.Start))
            {
                Confirm();
                return;
            }

            if ((select_pressed && !previously_select) || state.ThumbSticks.Left.Y < -0.5f || state.ThumbSticks.Left.Y > 0.5f || state.IsButtonDown(Buttons.DPadDown) || state.IsButtonDown(Buttons.DPadUp))
            {
                MoveCursor();
            }

            previously_start = start_pressed;
            previously_select = select_pressed;
        }
    }
}
