using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Sprint2
{
    public class DragonStandingFacingUp : IEnemyState
    {
        private Enemies dragon;
        private int currFrame;
        private int totalFrames;
        private int counter;
        private Rectangle frame3;
        private Rectangle frame4;
        private Texture2D sheet;
        private EnemiesList enemiesList;
        private double totalSecondsPassed;
        private double waitTime;
        private TimeSpan elapsedTime;
        private double secondsPassed;
        Random randomNumberGenerator;
        private int randomNum;
        private int chosenDirectionValue;

        public DragonStandingFacingUp(Enemies dragon)
        {
            randomNumberGenerator = new Random();
            totalSecondsPassed = 0;
            waitTime = 0.25;

            this.dragon = dragon;
            dragon.sprite = dragon.spriteFactory.getDragonLeftSprite();
            dragon.direction = "Left";
        }

        public void MoveUp()
        {
            Vector2 currPos = dragon.pos;
            currPos.Y--;
            dragon.pos = currPos;

            /*    if (counter % 5 == 0)
                    currFrame++;
                if (currFrame == totalFrames)
                    currFrame = 0;
                counter++;*/
        }
        public void MoveDown()
        {
            dragon.currState = new DragonStandingFacingDown(dragon);
        }
        public void MoveRight()
        {
            dragon.currState = new DragonStandingFacingRight(dragon);
        }
        public void MoveLeft()
        {
            dragon.currState = new DragonStandingFacingLeft(dragon);
        }
        public void Attack()
        {
            dragon.currState = new DragonAttacking(dragon);
        }

        public void TakeDamage()
        {
            dragon.health--;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            dragon.sprite.Draw(spriteBatch, dragon.pos);
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime = gameTime.ElapsedGameTime;
            secondsPassed = elapsedTime.TotalSeconds;
            totalSecondsPassed = totalSecondsPassed + secondsPassed;

            if (totalSecondsPassed > waitTime)
            {

                randomNum = randomNumberGenerator.Next(0, 100); // random number between 0-99
                chosenDirectionValue = randomNum % 5;

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
                MoveUp();
            }
            dragon.sprite.Update(gameTime);
        }


    }
}
