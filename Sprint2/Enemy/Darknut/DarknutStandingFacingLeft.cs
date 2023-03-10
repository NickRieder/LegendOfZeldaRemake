using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Sprint2
{
    public class DarknutStandingFacingLeft : IEnemyState
    {
        private Enemies darknut;
        private int currFrame;
        private int totalFrames;
        private int counter;
        private Rectangle frame1;
        private Rectangle frame2;
        private Texture2D sheet;
        private EnemiesList enemiesList;
        private double totalSecondsPassed;
        private TimeSpan elapsedTime;
        private double secondsPassed;
        Random randomNumberGenerator;
        private int randomNum;
        private int chosenDirectionValue;

        private const int numDirections = 4;
        private const int numPossibleInts = 100;
        private const double waitTime = 0.25;

        public DarknutStandingFacingLeft(Enemies darknut)
        {
            randomNumberGenerator = new Random();
            totalSecondsPassed = 0;

            this.darknut = darknut;
            darknut.sprite = darknut.spriteFactory.getDarknutLeftSprite();
            /*this.enemiesList = enemiesList;
            darknut = enemiesList.darknut;
            counter = 0;
            currFrame = 0;
            totalFrames = 2;
            frame1 = SpriteFactory.DARKNUT_SHEET2MIRROR_LEFT1;
            frame2 = SpriteFactory.DARKNUT_SHEET2MIRROR_LEFT2;
            this.sheet = darknut.spriteFactory.getEnemySheet2Mirror();*/
        }

        public void MoveUp()
        {
            darknut.currState = new DarknutStandingFacingUp(darknut);
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
            Vector2 currPos = darknut.pos;
            currPos.X--;
            darknut.pos = currPos;
           
        }
        public void Attack()
        {

        }

        public void TakeDamage()
        {
            darknut.health--;
           
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
                MoveLeft();
            }
            darknut.sprite.Update(gameTime);

        }


    }
}
