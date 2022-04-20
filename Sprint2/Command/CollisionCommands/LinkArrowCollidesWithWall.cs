using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class LinkArrowCollidesWithWall : ICollisionCommand
    {
        private Link link;
        private LinkArrow arrow;
        private Wall wall;
        private int collisionSide;
        private GameObjectManager gom;
        public LinkArrowCollidesWithWall()
        {

        }
        public void SetCollisionObjects(ISprite arrowObject, ISprite wallObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.arrow = (LinkArrow)arrowObject;
            this.link = arrow.link;
            this.wall = (Wall)wallObject;
            this.collisionSide = (int)collisionSideOfMainObject;
            this.gom = gom;
        }
        public void Invoke()
        {
            link.isUsingItem = false;
            arrow.RemoveProjectile(arrow);
        }
    }
}
