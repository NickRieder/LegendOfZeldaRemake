using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Sprint2
{
    public class BossRight : IEnemyState
    {
        private Enemies boss;
        private double totalSecondsPassed;
        private TimeSpan elapsedTime;
        private double secondsPassed;
        Random randomNumberGenerator;
        private int randomNum;
        private int chosenDirectionValue;

        private const int numActions = 5;
        private const int numPossibleInts = 100;
        private const double waitTime = 0.25;

        public BossRight(Enemies boss)
        {
            randomNumberGenerator = new Random();
            totalSecondsPassed = 0;

            this.boss = boss;
            boss.sprite = boss.spriteFactory.getBossSprite();
            boss.direction = "Right";
        }

        public void MoveUp()
        {
            boss.currState = new BossUp(boss);
        }
        public void MoveDown()
        {
            boss.currState = new BossDown(boss);
        }
        public void MoveRight()
        {
            Vector2 currPos = boss.pos;
            currPos.X++;
            boss.pos = currPos;

            /*if (counter % 5 == 0)
                currFrame++;
            if (currFrame == totalFrames)
                currFrame = 0;
            counter++;*/
        }
        public void MoveLeft()
        {
            boss.currState = new BossLeft(boss);
        }

        public void Attack()
        {
            boss.currState = new BossAttacking(boss);
        }

        public void TakeDamage()
        {
            boss.bossHealth--;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            boss.sprite.Draw(spriteBatch, boss.pos);
        }

        public void Update(GameTime gameTime)
        {
            
            elapsedTime = gameTime.ElapsedGameTime;
            secondsPassed = elapsedTime.TotalSeconds;
            totalSecondsPassed = totalSecondsPassed + secondsPassed;

            if (totalSecondsPassed > waitTime)
            {

                randomNum = randomNumberGenerator.Next(0, numPossibleInts); // random number between 0-99
                chosenDirectionValue = randomNum % numActions;

                if (chosenDirectionValue == 0)
                    MoveDown();
                else if (chosenDirectionValue == 1)
                    MoveUp();
                else if (chosenDirectionValue == 2)
                    MoveLeft();
                else if (chosenDirectionValue == 3)
                    MoveRight();
                else if (chosenDirectionValue == 4)
                    Attack();

                totalSecondsPassed = 0;
            }
            else
            {
                MoveRight();
            }
            boss.sprite.Update(gameTime);
        }


    }
}
