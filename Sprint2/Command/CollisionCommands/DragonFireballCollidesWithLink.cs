using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class DragonFireballCollidesWithLink : ICollisionCommand
    {
        private Link link;
        private EnemyDamagingProjectile fireball;
        private int collisionSide;
        private GameObjectManager gom;
        public DragonFireballCollidesWithLink()
        {

        }
        public void SetCollisionObjects(ISprite fireballObject, ISprite linkObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.fireball = (DragonFireball)fireballObject;
            this.link = (Link)linkObject;
            this.collisionSide = (int)collisionSideOfMainObject;
            this.gom = gom;
        }
        public void Invoke()
        {
            link.TakeDamage(collisionSide);
            fireball.RemoveProjectile(fireball);

            /*if (subjectType == typeof(DragonFireball) && targetType == typeof(Link))
            {
                System.Diagnostics.Debug.WriteLine("DEBUG1: /CollisionHandlerEnemy/ subjectType = " + subjectType);
                Link tempLink = (Link)target;
                EnemyDamagingProjectile tempProjectile = (DragonFireball)subject;
                tempLink.TakeDamage();
                tempProjectile.RemoveProjectile(tempProjectile);

            }*/
        }
    }
}
