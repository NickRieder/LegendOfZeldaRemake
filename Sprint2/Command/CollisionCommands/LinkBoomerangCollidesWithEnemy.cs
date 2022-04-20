using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class LinkBoomerangCollidesWithEnemy : ICollisionCommand
    {
        private Link link;
        private LinkBoomerang boomerang;
        private Enemies enemy;
        private int collisionSide;
        private GameObjectManager gom;

        public LinkBoomerangCollidesWithEnemy()
        {

        }
        public void SetCollisionObjects(ISprite boomerangObject, ISprite enemyObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.boomerang = (LinkBoomerang)boomerangObject;
            this.link = boomerang.link;
            this.enemy = (Enemies)enemyObject;
            this.collisionSide = (int)collisionSideOfMainObject;
            this.gom = gom;
        }
        public void Invoke()
        {
            // Makes the boomerang return to Link upon colliding with the an enemy.
            boomerang.velocity = -2;

            // We should make TakeDamage have a parameter for how much damage LinkBoomerang deals (possibly in the LinkBomerang class?)
            if (boomerang.canDealDamage)
            {
                boomerang.canDealDamage = false;
                enemy.TakeDamage(boomerang.damage);
            }
        }
    }
}
