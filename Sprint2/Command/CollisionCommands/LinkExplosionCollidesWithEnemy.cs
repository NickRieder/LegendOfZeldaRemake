using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class LinkExplosionCollidesWithEnemy : ICollisionCommand
    {
        private Link link;
        private LinkExplosion explosion;
        private Enemies enemy;
        private int collisionSide;
        private GameObjectManager gom;

        public LinkExplosionCollidesWithEnemy()
        {

        }
        public void SetCollisionObjects(ISprite explosionObject, ISprite enemyObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.explosion = (LinkExplosion)explosionObject;
            this.link = explosion.link;
            this.enemy = (Enemies)enemyObject;
            this.collisionSide = (int)collisionSideOfMainObject;
            this.gom = gom;
        }
        public void Invoke()
        {
            if (explosion.canDealDamage && enemy.canTakeDamage)
            {
                
                enemy.TakeDamage(explosion.damage); // bomb damage can be found in the LinkExplosion class
                explosion.canDealDamage = false;
            }
        }
    }
}
