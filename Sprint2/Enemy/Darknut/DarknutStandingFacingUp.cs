using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Sprint2
{
    public class DarknutStandingFacingUp : IEnemyState
    {
        private Enemies darknut;
        private int currFrame;
        private int totalFrames;
        private int counter;
        private Rectangle frame1;
        private Rectangle frame2;
        private Texture2D sheet;
        private Texture2D sheetMirrored;
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

        public DarknutStandingFacingUp(Enemies darknut)
        {
            randomNumberGenerator = new Random();
            totalSecondsPassed = 0;

            this.darknut = darknut;
            darknut.sprite = darknut.spriteFactory.getDarknutUpSprite();
            /*this.enemiesList = enemiesList;
            darknut = enemiesList.darknut;
            counter = 0;
            currFrame = 0;
            totalFrames = 2;
            frame1 = SpriteFactory.DARKNUT_SHEET2_BACK;
            frame2 = SpriteFactory.DARKNUT_SHEET2MIRROR_BACK;
            this.sheet = darknut.spriteFactory.getEnemySheet2();
            this.sheetMirrored = darknut.spriteFactory.getEnemySheet2Mirror();*/
        }

        public void MoveUp()
        {
            Vector2 currPos = darknut.pos;
            currPos.Y--;
            darknut.pos = currPos;
            /* if (counter % 5 == 0)
                 currFrame++;
             if (currFrame == totalFrames)
                 currFrame = 0;
             counter++;*/
        }
        public void MoveDown()
        {
            darknut.currState = new DarknutStandingFacingDown(darknut);
        }
        public void MoveRight()
        {
            darknut.currState = new DarknutStandingFacingRight(darknut);
        }
        public void MoveLeft()
        {
            darknut.currState = new DarknutStandingFacingLeft(darknut);
        }
        public void Attack()
        {

        }

        public void TakeDamage()
        {
            darknut.health--;
            //darknut.currState = new BluegelDamagedFacingDown(darknut);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            darknut.sprite.Draw(spriteBatch, darknut.pos);
        
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
                MoveUp();
            }
            darknut.sprite.Update(gameTime);

        }


    }
}
