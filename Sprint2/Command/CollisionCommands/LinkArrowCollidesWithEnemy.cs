using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class LinkArrowCollidesWithEnemy : ICollisionCommand
    {
        private Link link;
        private LinkArrow arrow;
        private Enemies enemy;
        private int collisionSide;
        private GameObjectManager gom;

        public LinkArrowCollidesWithEnemy()
        {

        }
        public void SetCollisionObjects(ISprite arrowObject, ISprite enemyObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.arrow = (LinkArrow)arrowObject;
            this.link = arrow.link;
            this.enemy = (Enemies)enemyObject;
            this.collisionSide = (int)collisionSideOfMainObject;
            this.gom = gom;
        }
        public void Invoke()
        {           
            if (arrow.canDealDamage)
            {
                arrow.canDealDamage = false;
                enemy.TakeDamage(arrow.damage);
                link.isUsingItem = false;
            }

            // Makes the arrow disappear upon colliding with the an enemy.
            arrow.RemoveProjectile(arrow);
        }
    }
}
