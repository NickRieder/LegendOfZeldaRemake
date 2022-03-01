using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Diagnostics;

namespace Sprint2
{
    class GoriyaAttackingUp : IEnemyState
    {

        private Enemies goriya;
        private int currFrame;
        private int totalFrames;
        private int currWeaponFrame;
        private int totalWeaponFrames;
        private int counter;
        private int weaponCounter;
        private bool weaponReturning;
        private Rectangle frame1;
        private Rectangle frame2;
        private Rectangle weaponFrame1;
        private Rectangle weaponFrame2;
        private Rectangle weaponFrame3;
        private Rectangle weaponFrame4;
        private Rectangle weaponFrame5;
        private Rectangle weaponFrame6;
        private Texture2D sheet;
        private Texture2D sheetMirrored;
        private Texture2D weaponSheet;
        private Texture2D weaponSheetUpsideDown;
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

        public GoriyaAttackingUp(EnemiesList enemiesList)
        {
            randomNumberGenerator = new Random();
            weaponFrameArray = new ArrayList();
            totalSecondsPassed = 0;
            waitTime = 0.25;

            this.enemiesList = enemiesList;
            goriya = enemiesList.goriya;
            counter = 0;
            currFrame = 0;
            totalFrames = 2;
            currWeaponFrame = 0;
            totalWeaponFrames = 6;
            frame1 = SpriteFactory.GORIYA_SHEET2_BACK;
            frame2 = SpriteFactory.GORIYA_SHEET2MIRROR_BACK;
            this.sheet = goriya.spriteFactory.getEnemySheet2();
            this.sheetMirrored = goriya.spriteFactory.getEnemySheet2Mirror();

            // CREATE BOOMERANG FRAMES HERE
            weaponFrame1 = SpriteFactory.GORIYA_LINKSHEETUPSIDEDOWN_WEAPON1;
            weaponFrame2 = SpriteFactory.GORIYA_LINKSHEETUPSIDEDOWN_WEAPON2;
            weaponFrame3 = SpriteFactory.GORIYA_LINKSHEETUPSIDEDOWN_WEAPON3;
            weaponFrame4 = SpriteFactory.GORIYA_SHEET2_WEAPON4;
            weaponFrame5 = SpriteFactory.GORIYA_SHEET2_WEAPON5;
            weaponFrame6 = SpriteFactory.GORIYA_SHEET2_WEAPON6;
            this.weaponSheet = goriya.spriteFactory.getEnemySheet2();
            this.weaponSheetUpsideDown = goriya.spriteFactory.getLinkSheetUpsideDown();

            weaponFrameArray.Add(weaponFrame1);
            weaponFrameArray.Add(weaponFrame2);
            weaponFrameArray.Add(weaponFrame3);
            weaponFrameArray.Add(weaponFrame4);
            weaponFrameArray.Add(weaponFrame5);
            weaponFrameArray.Add(weaponFrame6);

            weaponPos = goriya.pos;
            weaponPos.X += frame1.Width / 2;
            weaponReturning = false;
        }

        public void MoveUp()
        {
            goriya.currState = new GoriyaStandingFacingUp(enemiesList);
        }
        public void MoveDown()
        {
            goriya.currState = new GoriyaStandingFacingDown(enemiesList);
        }
        public void MoveRight()
        {
            goriya.currState = new GoriyaStandingFacingRight(enemiesList);
        }
        public void MoveLeft()
        {
            goriya.currState = new GoriyaStandingFacingLeft(enemiesList);
        }
        public void Attack()
        {
            // Goriya standing still and animated
            if (counter % 5 == 0)
                currFrame++;
            if (currFrame == totalFrames)
                currFrame = 0;
            counter++;

            // MAKE BOOMERANG GO AWAY AND BACK TO THE GORIYA
            if (weaponPos.Y < goriya.pos.Y - 150) // 150 is the distance the weapon travels
            {
                weaponReturning = true;
            }
            
            if (weaponReturning)
            {
                if (weaponPos.Y > goriya.pos.Y - 10)
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
                weaponPos.Y += 4;
            }
            else
            {
                weaponPos.Y -= 4;
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
            Rectangle destinationRectangleFrame1 = new Rectangle((int)goriya.pos.X, (int)goriya.pos.Y, frame1.Width * goriya.spriteSizeMultiplier, frame1.Height * goriya.spriteSizeMultiplier);
            Rectangle destinationRectangleFrame2 = new Rectangle((int)goriya.pos.X, (int)goriya.pos.Y, frame2.Width * goriya.spriteSizeMultiplier, frame2.Height * goriya.spriteSizeMultiplier);

            Rectangle weaponFrameToDraw = (Rectangle)weaponFrameArray[currWeaponFrame];
            
            Rectangle destinationRectangleWeaponFrame = new Rectangle((int)weaponPos.X, (int)weaponPos.Y, weaponFrameToDraw.Width * goriya.spriteSizeMultiplier, weaponFrameToDraw.Height * goriya.spriteSizeMultiplier);

            // ANIMATE BOOMERANG HERE
            if (currWeaponFrame < 3)
            {
                spriteBatch.Draw(weaponSheetUpsideDown, destinationRectangleWeaponFrame, weaponFrameToDraw, Color.White);
            }
            else
            {
                spriteBatch.Draw(weaponSheet, destinationRectangleWeaponFrame, weaponFrameToDraw, Color.White);
            }
            

            // ANIMATE GORIYA HERE
            if (currFrame == 0)
            {
                spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
            }
            else
            {
                spriteBatch.Draw(sheetMirrored, destinationRectangleFrame2, frame2, Color.White);
            }

            
        }

        public void Update(GameTime gameTime)
        {
            // CALL Attack() HERE
            Attack();
        }
    }
}
