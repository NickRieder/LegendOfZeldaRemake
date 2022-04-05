using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Sprint2
{
    public class GoriyaStandingFacingLeft : IEnemyState
    {
        private Enemies goriya;
        private int currFrame;
        private int totalFrames;
        private int counter;
        private Rectangle frame1;
        private Rectangle frame2;
        private Texture2D sheet;
        private EnemiesList enemiesList;
        private double totalSecondsPassed;
        private double waitTime;
        private TimeSpan elapsedTime;
        private double secondsPassed;
        Random randomNumberGenerator;
        private int randomNum;
        private int chosenDirectionValue;

        public GoriyaStandingFacingLeft(Enemies goriya)
        {
            randomNumberGenerator = new Random();
            totalSecondsPassed = 0;
            waitTime = 0.25;

            this.goriya = goriya;
            goriya.sprite = goriya.spriteFactory.getGoriyaLeftSprite();
            goriya.direction = "Left";
        }

        public void MoveUp()
        {
            goriya.currState = new GoriyaStandingFacingUp(goriya);
        }
        public void MoveDown()
        {
            goriya.currState = new GoriyaStandingFacingDown(goriya);
        }
        public void MoveRight()
        {
            goriya.currState = new GoriyaStandingFacingRight(goriya);
        }
        public void MoveLeft()
        {
            Vector2 currPos = goriya.pos;
            currPos.X--;
            goriya.pos = currPos;


            /*if (counter % 5 == 0)
                currFrame++;
            if (currFrame == totalFrames)
                currFrame = 0;
            counter++;*/
        }
        public void Attack()
        {
            goriya.currState = new GoriyaAttacking(goriya);
        }

        public void TakeDamage()
        {
            goriya.health--;
            //goriya.currState = new BluebatDamagedFacingDown(goriya);
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            goriya.sprite.Draw(spriteBatch, goriya.pos);
            /*Rectangle destinationRectangleFrame1 = new Rectangle((int)goriya.pos.X, (int)goriya.pos.Y, frame1.Width * goriya.spriteSizeMultiplier, frame1.Height * goriya.spriteSizeMultiplier);
            Rectangle destinationRectangleFrame2 = new Rectangle((int)goriya.pos.X, (int)goriya.pos.Y, frame2.Width * goriya.spriteSizeMultiplier, frame2.Height * goriya.spriteSizeMultiplier);
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
                MoveLeft();
            }
            goriya.sprite.Update(gameTime);
        }


    }
}
