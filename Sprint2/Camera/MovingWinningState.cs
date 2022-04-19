using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class MovingWinningState : ICameraState
    {
        private const int START_ANIMATION = 0;
        private const int STOP_VERTICAL_ANIMATION = 800;    // Raw height of room sprite is 176, so 176 * 3 = 528
        private const int STOP_HORIZONTAL_ANIMATION = 700;

        Camera camera;

        private Game1 game;
        private SpriteFont font;
        private SpriteBatch sb;
        private SpriteFactory spriteFactory;

        private int xPos;
        private int yPos;
        string direction;

        bool canContinue;

        public MovingWinningState(Camera camera, string direction, SpriteFactory spriteFactory, SpriteBatch spriteBatch)
        {
            this.camera = camera;
            xPos = START_ANIMATION;
            yPos = START_ANIMATION;
            this.direction = direction;
            canContinue = true;
            this.spriteFactory = spriteFactory;
            this.sb = spriteBatch;
        }

        public void AnimateRoomTransition(string direction, Door door)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }

        public void FreezeCamera(int xPos, int yPos)
        {
            camera.currState = new StaticCamera(camera, xPos, yPos);
        }

        public void Update(GameTime gameTime)
        {
            if (canContinue)
            {
                AnimateWinningState(direction, spriteFactory, sb);
            }
            else
            {
                FreezeCamera(xPos, yPos);
            }
        }

        public void AnimateWinningState(string direction, SpriteFactory spriteFactory, SpriteBatch sb)
        {
            //font = spriteFactory.getFont();

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

            Vector3 pos = new Vector3(xPos, yPos, 0);
            camera.transform = Matrix.CreateTranslation(pos);

            /*
            this.sb.DrawString(font, "Thanks Link, You're", new Vector2(50, 30), Color.Red);
            this.sb.DrawString(font, "The Hero of Hyrule.", new Vector2(50, 80), Color.Red);
            this.sb.DrawString(font, "Finally", new Vector2(50, 130), Color.Red);
            this.sb.DrawString(font, "Peace returns to Hyrule.", new Vector2(50, 180), Color.Red);
            this.sb.DrawString(font, "This ends the story.", new Vector2(50, 205), Color.Blue);
            this.sb.DrawString(font, "Another story awaits! Press the Start or Enter button.", new Vector2(50, 230), Color.Red);
            */
        }
    }
}
