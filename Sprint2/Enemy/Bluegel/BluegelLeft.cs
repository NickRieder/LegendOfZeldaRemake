using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Sprint2
{
    public class BluegelLeft : IEnemyState
    {
        private Enemies bluegel;
        private int currFrame;
        private int totalFrames;
        private int counter;
        private Rectangle frame1;
        private Rectangle frame2;
        private Texture2D sheet;
        private EnemiesList enemiesList;
        private double totalSecondsPassed;
        public TimeSpan elapsedTime;
        private double secondsPassed;
        Random randomNumberGenerator;
        private int randomNum;
        private int chosenDirectionValue;

        private const int numDirections = 4;
        private const int numPossibleInts = 100;
        private const double waitTime = 0.25;

        public BluegelLeft(Enemies bluegel)
        {
            randomNumberGenerator = new Random();
            totalSecondsPassed = 0;

            this.bluegel = bluegel;
            bluegel.sprite = bluegel.spriteFactory.getBluegelSprite();

            /*this.enemiesList = enemiesList;
            bluegel = enemiesList.bluegel;
            counter = 0;
            currFrame = 0;
            totalFrames = 2;
            frame1 = SpriteFactory.BLUEGEL_SHEET2_POS1;
            frame2 = SpriteFactory.BLUEGEL_SHEET2_POS2;
            this.sheet = bluegel.spriteFactory.getEnemySheet2();*/
        }

        public void MoveUp()
        {
            bluegel.currState = new BluegelUp(bluegel);
        }
        public void MoveDown()
        {
            bluegel.currState = new BluegelDown(bluegel);
        }
        public void MoveRight()
        {
            bluegel.currState = new BluegelRight(bluegel);
        }
        public void MoveLeft()
        {
            //bluegel.pos.X--;

            Vector2 currPos = bluegel.pos;
            currPos.X--;
            bluegel.pos = currPos;

            /*if (counter % 5 == 0)
                currFrame++;
            if (currFrame == totalFrames)
                currFrame = 0;
            counter++;*/
        }
        public void Attack()
        {

        }

        public void TakeDamage()
        {
            bluegel.health--;
            //bluegel.currState = new BluegelDamagedFacingDown(bluegel);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            bluegel.sprite.Draw(spriteBatch, bluegel.pos);

            /*Rectangle destinationRectangleFrame1 = new Rectangle((int)bluegel.pos.X, (int)bluegel.pos.Y, frame1.Width * bluegel.spriteSizeMultiplier, frame1.Height * bluegel.spriteSizeMultiplier);
            Rectangle destinationRectangleFrame2 = new Rectangle((int)bluegel.pos.X, (int)bluegel.pos.Y, frame2.Width * bluegel.spriteSizeMultiplier, frame2.Height * bluegel.spriteSizeMultiplier);
            if (currFrame == 0)
            {
                spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
            }
            else
            {
                spriteBatch.Draw(sheet, destinationRectangleFrame2, frame2, Color.White);
            }*/
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime = gameTime.ElapsedGameTime;
            secondsPassed = elapsedTime.TotalSeconds;
            totalSecondsPassed = totalSecondsPassed + secondsPassed;

            if (totalSecondsPassed > waitTime)
            {
                randomNum = randomNumberGenerator.Next(0, numPossibleInts); // random number between 0-99
                chosenDirectionValue = randomNum % numDirections;

                if (chosenDirectionValue == 0)
                    MoveDown();
                else if (chosenDirectionValue == 1)
                    MoveUp();
                else if (chosenDirectionValue == 2)
                    MoveLeft();
                else if (chosenDirectionValue == 3)
                    MoveRight();

                totalSecondsPassed = 0;
            }
            else
            {
                MoveLeft();
            }
            bluegel.sprite.Update(gameTime);
        }


    }
}
