using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class LinkCollidesWithGoriyaBoomerang : ICollisionCommand
    {
        private Link link;
        private GoriyaBoomerang boomerang;
        private int collisionSide;
        private GameObjectManager gom;
        public LinkCollidesWithGoriyaBoomerang()
        {

        }
        public void SetCollisionObjects(ISprite linkObject, ISprite boomerangObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.link = (Link)linkObject;
            this.boomerang = (GoriyaBoomerang)boomerangObject;
            this.collisionSide = (int)collisionSideOfMainObject;
            this.gom = gom;
        }
        public void Invoke()
        {
            link.TakeDamage(collisionSide);
            boomerang.velocity = -3;
        }
    }
}
