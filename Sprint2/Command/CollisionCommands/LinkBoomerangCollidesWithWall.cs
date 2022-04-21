using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class LinkBoomerangCollidesWithWall : ICollisionCommand
    {
        private Link link;
        private LinkBoomerang boomerang;
        private Wall wall;
        private int collisionSide;
        private GameObjectManager gom;

        public LinkBoomerangCollidesWithWall()
        {
            
        }
        public void SetCollisionObjects(ISprite boomerangObject, ISprite wallObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.boomerang = (LinkBoomerang)boomerangObject;
            this.link = boomerang.link;
            this.wall = (Wall)wallObject;
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
