using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Sprint2
{
    public class SnakeLeft : IEnemyState
    {
        private Enemies snake;
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

        public SnakeLeft(Enemies snake)
        {
            randomNumberGenerator = new Random();
            totalSecondsPassed = 0;

            this.snake = snake;
            snake.sprite = snake.spriteFactory.getSnakeLeftSprite();
            /* this.enemiesList = enemiesList;
             snake = enemiesList.snake;
             counter = 0;
             currFrame = 0;
             totalFrames = 2;
             frame1 = SpriteFactory.SNAKE_SHEET2MIRROR_LEFT1;
             frame2 = SpriteFactory.SNAKE_SHEET2MIRROR_LEFT2;
             this.sheet = snake.spriteFactory.getEnemySheet2Mirror();*/
        }

        public void MoveUp()
        {
            snake.currState = new SnakeUp(snake);
        }
        public void MoveDown()
        {
            snake.currState = new SnakeDown(snake);
        }
        public void MoveRight()
        {
            snake.currState = new SnakeRight(snake);
        }
        public void MoveLeft()
        {
            Vector2 currPos = snake.pos;
            currPos.X--;
            snake.pos = currPos;
            /* if (counter % 5 == 0)
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
            snake.health--;
            //snake.currState = new BluebatDamagedFacingDown(snake);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            snake.sprite.Draw(spriteBatch, snake.pos);
            /* Rectangle destinationRectangleFrame1 = new Rectangle((int)snake.pos.X, (int)snake.pos.Y, frame1.Width * snake.spriteSizeMultiplier, frame1.Height * snake.spriteSizeMultiplier);
             Rectangle destinationRectangleFrame2 = new Rectangle((int)snake.pos.X, (int)snake.pos.Y, frame2.Width * snake.spriteSizeMultiplier, frame2.Height * snake.spriteSizeMultiplier);
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
            snake.sprite.Update(gameTime);
        }


    }
}
