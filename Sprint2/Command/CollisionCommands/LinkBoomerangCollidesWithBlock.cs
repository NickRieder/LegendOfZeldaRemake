using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class LinkBoomerangCollidesWithBlock : ICollisionCommand
    {
        private Link link;
        private LinkBoomerang boomerang;
        private Block block;
        private int collisionSide;
        private GameObjectManager gom;

        public LinkBoomerangCollidesWithBlock()
        {

        }
        public void SetCollisionObjects(ISprite boomerangObject, ISprite blockObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.boomerang = (LinkBoomerang)boomerangObject;
            this.link = boomerang.link;
            this.block = (Block)blockObject;
            this.collisionSide = (int)collisionSideOfMainObject;
            this.gom = gom;
        }
        public void Invoke()
        {
            // Makes the boomerang return to Link upon colliding with the walls.
            boomerang.velocity = -3;
        }
    }
}
