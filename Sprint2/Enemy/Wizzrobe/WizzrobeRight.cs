using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Sprint2
{
    public class WizzrobeRight : IEnemyState
    {
        private Enemies wizzrobe;
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

        public WizzrobeRight(Enemies wizzrobe)
        {
            randomNumberGenerator = new Random();
            totalSecondsPassed = 0;
            waitTime = 0.25;

            this.wizzrobe = wizzrobe;
            wizzrobe.sprite = wizzrobe.spriteFactory.getWizzrobeRightSprite();
            /*this.enemiesList = enemiesList;
            wizzrobe = enemiesList.wizzrobe;
            counter = 0;
            currFrame = 0;
            totalFrames = 2;
            frame1 = SpriteFactory.WIZZROBE_SHEET2_RIGHT1;
            frame2 = SpriteFactory.WIZZROBE_SHEET2_RIGHT2;
            this.sheet = wizzrobe.spriteFactory.getEnemySheet2();*/
        }

        public void MoveUp()
        {
            wizzrobe.currState = new WizzrobeUp(wizzrobe);
        }
        public void MoveDown()
        {
            wizzrobe.currState = new WizzrobeDown(wizzrobe);
        }
        public void MoveRight()
        {
            Vector2 currPos = wizzrobe.pos;
            currPos.X++;
            wizzrobe.pos = currPos;
            /*  if (counter % 5 == 0)
                  currFrame++;
              if (currFrame == totalFrames)
                  currFrame = 0;
              counter++;*/
        }
        public void MoveLeft()
        {
            wizzrobe.currState = new WizzrobeLeft(wizzrobe);
        }
        /*public void Attack()
        {

        }*/

        public void TakeDamage()
        {
            wizzrobe.health--;
            //wizzrobe.currState = new BluebatDamagedFacingDown(wizzrobe);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            wizzrobe.sprite.Draw(spriteBatch, wizzrobe.pos);
            /* Rectangle destinationRectangleFrame1 = new Rectangle((int)wizzrobe.pos.X, (int)wizzrobe.pos.Y, frame1.Width * wizzrobe.spriteSizeMultiplier, frame1.Height * wizzrobe.spriteSizeMultiplier);
             Rectangle destinationRectangleFrame2 = new Rectangle((int)wizzrobe.pos.X, (int)wizzrobe.pos.Y, frame2.Width * wizzrobe.spriteSizeMultiplier, frame2.Height * wizzrobe.spriteSizeMultiplier);
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
                chosenDirectionValue = randomNum % 4;

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
                MoveRight();
            }
            wizzrobe.sprite.Update(gameTime);
        }


    }
}
