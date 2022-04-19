using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class LinkCollidesWithEnemy : ICollisionCommand
    {
        private Link link;
        private Enemies enemy;
        private int side;
        private GameObjectManager gom;
        public LinkCollidesWithEnemy()
        {

        }
        public void SetCollisionObjects(ISprite linkObject, ISprite enemyObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.link = (Link)linkObject;
            this.enemy = (Enemies)enemyObject;
            this.side = (int)collisionSideOfMainObject;
            this.gom = gom;
        }
        public void Invoke()
        {
            if (link.canTakeDamage && enemy.canDamage)
            {
                link.TakeDamage(side);
                //enemy.DealDamage();
            }
        }
    }
}
