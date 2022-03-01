using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Diagnostics;

namespace Sprint2
{
    class DragonAttackingLeft : IEnemyState
    {

        private Enemies dragon;
        private int currFrame;
        private int totalFrames;
        private int currWeaponFrame;
        private int totalWeaponFrames;
        private int counter;
        private int weaponCounter;
        private bool weaponFired;
        private Rectangle frame1;
        private Rectangle frame2;
        private Rectangle weaponFrame1;
        private Rectangle weaponFrame2;
        private Rectangle weaponFrame3;
        private Rectangle weaponFrame4;
        private Texture2D sheet;
        private Texture2D weaponSheet;
        private EnemiesList enemiesList;
        private double totalSecondsPassed;
        private double waitTime;
        private TimeSpan elapsedTime;
        private double secondsPassed;
        Random randomNumberGenerator;
        private int randomNum;
        private int chosenDirectionValue;
        private Vector2 weaponPos;
        private ArrayList weaponFrameArray;

        public DragonAttackingLeft(EnemiesList enemiesList)
        {
            randomNumberGenerator = new Random();
            weaponFrameArray = new ArrayList();
            totalSecondsPassed = 0;
            waitTime = 0.25;

            this.enemiesList = enemiesList;
            dragon = enemiesList.dragon;
            counter = 0;
            currFrame = 0;
            totalFrames = 2;
            currWeaponFrame = 0;
            totalWeaponFrames = 4;
            frame1 = SpriteFactory.DRAGON_SHEET1_LEFT1;
            frame2 = SpriteFactory.DRAGON_SHEET1_LEFT2;
            this.sheet = dragon.spriteFactory.getEnemySheet1();

            // CREATE BOOMERANG FRAMES HERE
            weaponFrame1 = SpriteFactory.DRAGON_SHEET1_FIREBALL1;
            weaponFrame2 = SpriteFactory.DRAGON_SHEET1_FIREBALL2;
            weaponFrame3 = SpriteFactory.DRAGON_SHEET1_FIREBALL3;
            weaponFrame4 = SpriteFactory.DRAGON_SHEET1_FIREBALL4;
            this.weaponSheet = dragon.spriteFactory.getEnemySheet1();

            weaponFrameArray.Add(weaponFrame1);
            weaponFrameArray.Add(weaponFrame2);
            weaponFrameArray.Add(weaponFrame3);
            weaponFrameArray.Add(weaponFrame4);

            weaponPos = dragon.pos;
            weaponPos.Y += frame1.Height / 2;
            weaponFired = false;
        }

        public void MoveUp()
        {
            dragon.currState = new DragonStandingFacingUp(enemiesList);
        }
        public void MoveDown()
        {
            dragon.currState = new DragonStandingFacingDown(enemiesList);
        }
        public void MoveRight()
        {
            dragon.currState = new DragonStandingFacingRight(enemiesList);
        }
        public void MoveLeft()
        {
            dragon.currState = new DragonStandingFacingLeft(enemiesList);
        }
        public void Attack()
        {
            // Dragon animated
            
            if (counter % 5 == 0)
            {
                currFrame++;
                dragon.pos.X += 1;
            }
            if (currFrame == totalFrames)
                currFrame = 0;
            counter++;

            // WE MAY NEED TO MAKE ENEMY WEAPONS (BOOMERANG & FIREBALL) INTO THEIR OWN CLASS OBJECTS
            // PROBLEM: DRAGON CANNOT CONTINUE MOVING AFTER IT ATTACKS

            // MAKE 3 FIREBALLS SHOOT OUT AT DIFFERENT ANGLES
            if (weaponPos.X < dragon.pos.X - 450) // 450 is the distance the weapon travels
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
            }
            else
            {
                weaponPos.X -= 4;
            }

            if (weaponCounter % 5 == 0)
                currWeaponFrame++;
            if (currWeaponFrame == totalWeaponFrames)
                currWeaponFrame = 0;
            weaponCounter++;
        }

        public void TakeDamage()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationRectangleFrame1 = new Rectangle((int)dragon.pos.X, (int)dragon.pos.Y, frame1.Width * dragon.spriteSizeMultiplier, frame1.Height * dragon.spriteSizeMultiplier);
            Rectangle destinationRectangleFrame2 = new Rectangle((int)dragon.pos.X, (int)dragon.pos.Y, frame2.Width * dragon.spriteSizeMultiplier, frame2.Height * dragon.spriteSizeMultiplier);

            Rectangle weaponFrameToDraw = (Rectangle)weaponFrameArray[currWeaponFrame];
            
            Rectangle destinationRectangleWeaponFrame = new Rectangle((int)weaponPos.X, (int)weaponPos.Y, weaponFrameToDraw.Width * dragon.spriteSizeMultiplier, weaponFrameToDraw.Height * dragon.spriteSizeMultiplier);

            // ANIMATE FIREBALL HERE (DRAW 3 SPREADING OUT LATER)
            spriteBatch.Draw(weaponSheet, destinationRectangleWeaponFrame, weaponFrameToDraw, Color.White);


            // ANIMATE DRAGON HERE
            if (currFrame == 0)
            {
                spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
            }
            else
            {
                spriteBatch.Draw(sheet, destinationRectangleFrame2, frame2, Color.White);
            }

            
        }

        public void Update(GameTime gameTime)
        {
            // CALL Attack() HERE
            Attack();
        }
    }
}
