using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Diagnostics;

namespace Sprint2
{
    class BossAttacking : IEnemyState
    {

        private Enemies boss;

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

        public BossAttacking(Enemies boss)
        {
            randomNumberGenerator = new Random();
            weaponFrameArray = new ArrayList();
            totalSecondsPassed = 0;
            waitTime = 0.25;

            this.boss = boss;
            this.gom = boss.gom;

            CreateMinion();

            boss.freeze = true;
            weaponReturning = false;
        }

        private void CreateMinion()
        {
            BossMinion minion = new BossMinion(boss, "Minion");
            //gom.AddToAllObjectList(boomerang);
            gom.AddToMovableObjectList(minion);
            gom.AddToDrawableObjectList(minion);
        }

        public void MoveUp()
        {
            boss.currState = new BossUp(boss);
        }
        public void MoveDown()
        {
            boss.currState = new BossDown(boss);
        }
        public void MoveRight()
        {
            boss.currState = new BossRight(boss);
        }
        public void MoveLeft()
        {
            boss.currState = new BossLeft(boss);
        }
        public void Attack()
        {
            if (!boss.freeze)
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
            
        }

        public void TakeDamage()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            boss.sprite.Draw(spriteBatch, boss.pos);
        }

        public void Update(GameTime gameTime)
        {
            Attack();
            boss.sprite.Update(gameTime);
        }
    }
}
