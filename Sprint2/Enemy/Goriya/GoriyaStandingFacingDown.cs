﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Sprint2
{
    public class GoriyaStandingFacingDown : IEnemyState
    {
        private Enemies goriya;
        private double totalSecondsPassed;
        private TimeSpan elapsedTime;
        private double secondsPassed;
        Random randomNumberGenerator;
        private int randomNum;
        private int chosenDirectionValue;

        private const int numActions = 5;
        private const int numPossibleInts = 100;
        private const double waitTime = 0.25;

        public GoriyaStandingFacingDown(Enemies goriya)
        {
            System.Diagnostics.Debug.WriteLine("DEBUG: In FacingDownState");

            randomNumberGenerator = new Random();
            totalSecondsPassed = 0;

            this.goriya = goriya;
            goriya.sprite = goriya.spriteFactory.getGoriyaDownSprite();
            goriya.direction = "Down";
        }

        public void MoveUp()
        {
            goriya.currState = new GoriyaStandingFacingUp(goriya);
        }
        public void MoveDown()
        {
            Vector2 currPos = goriya.pos;
            currPos.Y++;
            goriya.pos = currPos;


            /*if (counter % 5 == 0)
                currFrame++;
            if (currFrame == totalFrames)
                currFrame = 0;
            counter++;*/
        }
        public void MoveRight()
        {
            goriya.currState = new GoriyaStandingFacingRight(goriya);
        }
        public void MoveLeft()
        {
            goriya.currState = new GoriyaStandingFacingLeft(goriya);
        }
        public void Attack()
        {
            goriya.currState = new GoriyaAttacking(goriya);
        }

        public void TakeDamage()
        {
            goriya.health--;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            goriya.sprite.Draw(spriteBatch, goriya.pos);
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
                    MoveUp();
                else if (chosenDirectionValue == 1)
                    MoveDown();
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
                MoveDown();
            }
            goriya.sprite.Update(gameTime);
        }


    }
}
