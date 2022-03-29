using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Diagnostics;

namespace Sprint2
{
    class GoriyaAttacking : IEnemyState
    {

        private Enemies goriya;
        private int currFrame;
        private int totalFrames;
        private int currWeaponFrame;
        private int totalWeaponFrames;
        private int counter;
        private int weaponCounter;
        private bool weaponReturning;
        private double totalSecondsPassed;
        private double waitTime;
        private TimeSpan elapsedTime;
        private double secondsPassed;
        Random randomNumberGenerator;
        private int randomNum;
        private int chosenDirectionValue;
        private Vector2 weaponPos;
        private ArrayList weaponFrameArray;
        private GameObjectManager gom;

        public GoriyaAttacking(Enemies goriya)
        {
            randomNumberGenerator = new Random();
            weaponFrameArray = new ArrayList();
            totalSecondsPassed = 0;
            waitTime = 0.25;

            this.goriya = goriya;
            this.gom = goriya.gom;

            /*switch (goriya.direction)
            {
                case "Down":
                    goriya.sprite = goriya.spriteFactory.getGoriyaDownSprite();
                    break;
                case "Left":
                    goriya.sprite = goriya.spriteFactory.getGoriyaLeftSprite();
                    break;
                case "Right":
                    goriya.sprite = goriya.spriteFactory.getGoriyaRightSprite();
                    break;
                case "Up":
                    goriya.sprite = goriya.spriteFactory.getGoriyaUpSprite();
                    break;
                default: // facing down
                    goriya.sprite = goriya.spriteFactory.getGoriyaDownSprite();
                    break;
            }*/

            ISprite projectile = new DamagingProjectile(goriya, "Boomerang");
            gom.AddToAllObjectList(projectile);
            gom.AddToMovableObjectList(projectile);
            gom.AddToDrawableObjectList(projectile);

            /*totalFrames = sprite.GetTotalFrames();
            currFrame = 0;

            counter = 0;
            currFrame = 0;
            totalFrames = 2;
            currWeaponFrame = 0;
            totalWeaponFrames = 6;
            frame1 = SpriteFactory.GORIYA_SHEET2_FRONT;
            frame2 = SpriteFactory.GORIYA_SHEET2MIRROR_FRONT;
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
            weaponFrameArray.Add(weaponFrame6);*/

            weaponReturning = false;
        }

        public void MoveUp()
        {
            System.Diagnostics.Debug.WriteLine("DEBUG: in MoveUp");
            goriya.currState = new GoriyaStandingFacingUp(goriya);
        }
        public void MoveDown()
        {
            System.Diagnostics.Debug.WriteLine("DEBUG: in MoveDown");
            goriya.currState = new GoriyaStandingFacingDown(goriya);
        }
        public void MoveRight()
        {
            System.Diagnostics.Debug.WriteLine("DEBUG: in MoveRight");
            goriya.currState = new GoriyaStandingFacingRight(goriya);
        }
        public void MoveLeft()
        {
            System.Diagnostics.Debug.WriteLine("DEBUG: in MoveLeft");
            goriya.currState = new GoriyaStandingFacingLeft(goriya);
        }
        public void Attack()
        {
            

            Vector2 projectilePos = goriya.projectile.pos;

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

            /*// Goriya standing still and animated
            if (counter % 5 == 0)
                currFrame++;
            if (currFrame == totalFrames)
                currFrame = 0;
            counter++;*/

            // MAKE BOOMERANG GO AWAY AND BACK TO THE GORIYA
            /*if (projectilePos.Y > projectilePos.Y + 150) // 150 is the distance the weapon travels
            {
                weaponReturning = true;
            }

            if (weaponReturning)
            {
                if (projectilePos.Y < goriya.pos.Y + 10)
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
                projectilePos.Y -= 4;
            }
            else
            {
                projectilePos.Y += 4;
            }*/

            /*if (weaponCounter % 5 == 0)
                currWeaponFrame++;
            if (currWeaponFrame == totalWeaponFrames)
                currWeaponFrame = 0;
            weaponCounter++;*/
        }

        public void TakeDamage()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            goriya.sprite.Draw(spriteBatch, goriya.pos);
        }

        public void Update(GameTime gameTime)
        {
            Attack();
        }
    }
}
