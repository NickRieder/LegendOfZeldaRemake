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

            ISprite projectile = new DamagingProjectile(goriya, "Boomerang");
            gom.AddToAllObjectList(projectile);
            gom.AddToMovableObjectList(projectile);
            gom.AddToDrawableObjectList(projectile);

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
