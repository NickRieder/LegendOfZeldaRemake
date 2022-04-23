using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class LinkCollidesWithDragonFireball : ICollisionCommand
    {
        private Link link;
        private DragonFireball fireball;
        private int collisionSide;
        private GameObjectManager gom;
        public LinkCollidesWithDragonFireball()
        {

        }
        public void SetCollisionObjects(ISprite linkObject, ISprite fireballObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.link = (Link)linkObject;
            this.fireball = (DragonFireball)fireballObject;
            this.collisionSide = (int)collisionSideOfMainObject;
            this.gom = gom;
        }
        public void Invoke()
        {
            link.TakeDamage(collisionSide);
            fireball.RemoveProjectile(fireball);
        }
    }
}
