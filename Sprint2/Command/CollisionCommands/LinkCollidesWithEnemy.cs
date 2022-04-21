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

            if (link.isUsingWeapon && link.canDealDamage)
            {
                link.canDealDamage = false;

                if (link.direction == "up" && side == (int)CollisionDetector.COLLISION_SIDE.TOP)
                {
                    enemy.TakeDamage(link.swordDamage);
                }
                else if (link.direction == "down" && side == (int)CollisionDetector.COLLISION_SIDE.BOTTOM)
                {
                    enemy.TakeDamage(link.swordDamage);
                }
                else if (link.direction == "left" && side == (int)CollisionDetector.COLLISION_SIDE.LEFT)
                {
                    enemy.TakeDamage(link.swordDamage);
                }
                else if (link.direction == "right" && side == (int)CollisionDetector.COLLISION_SIDE.RIGHT)
                {
                    enemy.TakeDamage(link.swordDamage);
                }
                else
                {
                    link.TakeDamage(side);
                }

            }
            else if (!link.isUsingWeapon && link.canTakeDamage)
            {
                link.TakeDamage(side);
            }

        }
    }
}
