using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Sprint2
{
    public class DragonStandingFacingLeft : IEnemyState
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

        public DragonStandingFacingLeft(Enemies dragon)
        {
            randomNumberGenerator = new Random();
            totalSecondsPassed = 0;
            waitTime = 0.25;

            this.dragon = dragon;
            dragon.sprite = dragon.spriteFactory.getDragonLeftSprite();
            /*
            this.enemiesList = enemiesList;
            dragon = enemiesList.dragon;
            counter = 0;
            currFrame = 0;
            totalFrames = 2;
            frame3 = SpriteFactory.DRAGON_SHEET1_LEFT3;
            frame4 = SpriteFactory.DRAGON_SHEET1_LEFT4;
            this.sheet = dragon.spriteFactory.getEnemySheet1();*/
        }

        public void MoveUp()
        {
            dragon.currState = new DragonStandingFacingUp(dragon);
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
            dragon.pos.X--;
            /*if (counter % 5 == 0)
                currFrame++;
            if (currFrame == totalFrames)
                currFrame = 0;
            counter++;*/
        }
       /* public void Attack()
        {
            dragon.currState = new DragonAttackingLeft(enemiesList);
        }*/

        public void TakeDamage()
        {
            dragon.health--;
            //dragon.currState = new BluebatDamagedFacingDown(dragon);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            dragon.sprite.Draw(spriteBatch, dragon.pos);
            /* Rectangle destinationRectangleFrame1 = new Rectangle((int)dragon.pos.X, (int)dragon.pos.Y, frame3.Width * dragon.spriteSizeMultiplier, frame3.Height * dragon.spriteSizeMultiplier);
             Rectangle destinationRectangleFrame2 = new Rectangle((int)dragon.pos.X, (int)dragon.pos.Y, frame4.Width * dragon.spriteSizeMultiplier, frame4.Height * dragon.spriteSizeMultiplier);
             if (currFrame == 0)
             {
                 spriteBatch.Draw(sheet, destinationRectangleFrame1, frame3, Color.White);
             }
             else
             {
                 spriteBatch.Draw(sheet, destinationRectangleFrame2, frame4, Color.White);
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
                   // Attack();

                totalSecondsPassed = 0;
            }
            else
            {
                MoveLeft();
            }
            dragon.sprite.Update(gameTime);
        }


    }
}
