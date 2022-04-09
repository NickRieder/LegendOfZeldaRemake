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
        private const int START_ANIMATION = 0;
        private const int STOP_VERTICAL_ANIMATION = 800;    // Raw height of room sprite is 176, so 176 * 3 = 528
        private const int STOP_HORIZONTAL_ANIMATION = 700;

        Camera camera;

        private Game1 game;
        private SpriteFont font;
        private SpriteBatch sb;

        private int xPos;
        private int yPos;
        string direction;

        bool canContinue;

        public WinningState(Game1 game, SpriteFont font)
        {
            this.camera = game.camera;
            this.game = game;
            this.font = font;
            xPos = START_ANIMATION;
            yPos = START_ANIMATION;
            this.direction = direction;
            canContinue = true;
        }

        public void AnimateWinningState(String direction)
        {
            System.Diagnostics.Debug.WriteLine("debug message 1");

            switch (direction)
            {
                case "Up":
                    yPos += 5;
                    if (yPos >= STOP_VERTICAL_ANIMATION)
                    {
                        canContinue = false;
                    }
                    break;
                default:
                    break;
            }

            System.Diagnostics.Debug.WriteLine(yPos);

            //var position = Matrix.CreateTranslation(xPos, yPos, 0);
            Vector3 pos = new Vector3(xPos, yPos, 0);
            camera.transform = Matrix.CreateTranslation(pos);

            //System.Diagnostics.Debug.WriteLine(camera.transform);
        }

        public void Update()
        {
            if (canContinue)
            {
                while (yPos < STOP_VERTICAL_ANIMATION)
                    AnimateWinningState("Up");
            }
        }

        public void Draw(SpriteBatch sb)
        {
            /*
            sb.DrawString(font, "Thanks Link, You're", new Vector2(50, 30), Color.Red);
            sb.DrawString(font, "The Hero of Hyrule.", new Vector2(50, 80), Color.Red);
            sb.DrawString(font, "Finally", new Vector2(50, 130), Color.Red);
            sb.DrawString(font, "Peace returns to Hyrule.", new Vector2(50, 180), Color.Red);
            sb.DrawString(font, "This ends the story.", new Vector2(50, 205), Color.Blue);
            sb.DrawString(font, "Another story awaits! Press the Start or Enter button.", new Vector2(50, 230), Color.Red);
            */
        }
    }
}
