using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Diagnostics;

namespace Sprint2
{
    class DragonAttacking : IEnemyState
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

        public DragonAttacking(Enemies dragon)
        {
            randomNumberGenerator = new Random();
            weaponFrameArray = new ArrayList();
            totalSecondsPassed = 0;

            this.dragon = dragon;
            this.gom = dragon.gom;

            CreateFireballs();

            weaponFired = false;
        }

        private void CreateFireballs()
        {
            DragonFireball fireballTop = new DragonFireball(dragon, "Fireball");
            DragonFireball fireballMid = new DragonFireball(dragon, "Fireball");
            DragonFireball fireballBot = new DragonFireball(dragon, "Fireball");
            fireballTop.SetTrajectory("Upward");
            fireballMid.SetTrajectory("Straight");
            fireballBot.SetTrajectory("Downward");

            //gom.AddToAllObjectList(fireballTop);
            //gom.AddToAllObjectList(fireballMid);
            //gom.AddToAllObjectList(fireballBot);

            gom.AddToMovableObjectList(fireballTop);
            gom.AddToMovableObjectList(fireballMid);
            gom.AddToMovableObjectList(fireballBot);

            gom.AddToDrawableObjectList(fireballTop);
            gom.AddToDrawableObjectList(fireballMid);
            gom.AddToDrawableObjectList(fireballBot);
            
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
            dragon.currState = new DragonStandingFacingLeft(dragon);
        }
        public void Attack()
        {
            if (!dragon.freeze)
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
            dragon.sprite.Draw(spriteBatch, dragon.pos);
        }

        public void Update(GameTime gameTime)
        {
            Attack();
            //dragon.sprite.Update(gameTime);
        }
    }
}
