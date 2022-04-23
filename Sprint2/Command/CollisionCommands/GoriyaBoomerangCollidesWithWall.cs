using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class GoriyaBoomerangCollidesWithWall : ICollisionCommand
    {
        private GoriyaBoomerang boomerang;
        private Wall wall;
        private int collisionSide;
        private GameObjectManager gom;
        public GoriyaBoomerangCollidesWithWall()
        {

        }
        public void SetCollisionObjects(ISprite boomerangObject, ISprite wallObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.boomerang = (GoriyaBoomerang)boomerangObject;
            this.wall = (Wall)wallObject;
            this.collisionSide = (int)collisionSideOfMainObject;
            this.gom = gom;
        }
        public void Invoke()
        {
            boomerang.velocity = -3;
        }
    }
}
