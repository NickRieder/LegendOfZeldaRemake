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
        private TimeSpan elapsedTime;
        private double secondsPassed;

        Random randomNumberGenerator;
        private int randomNum;
        private int chosenDirectionValue;

        private Vector2 weaponPos;
        private ArrayList weaponFrameArray;

        private GameObjectManager gom;

        private const int numDirections = 4;
        private const int numPossibleInts = 100;
        private const double waitTime = 0.25;

        public GoriyaAttacking(Enemies goriya)
        {
            randomNumberGenerator = new Random();
            weaponFrameArray = new ArrayList();
            totalSecondsPassed = 0;

            this.goriya = goriya;
            this.gom = goriya.gom;

            CreateBoomerang();

            goriya.freeze = true;
            weaponReturning = false;
        }

        private void CreateBoomerang()
        {
            GoriyaBoomerang boomerang = new GoriyaBoomerang(goriya, "Boomerang");
            //gom.AddToAllObjectList(boomerang);
            gom.AddToMovableObjectList(boomerang);
            gom.AddToDrawableObjectList(boomerang);
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
            if (!goriya.freeze)
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
            }
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
            goriya.sprite.Update(gameTime);
        }
    }
}

