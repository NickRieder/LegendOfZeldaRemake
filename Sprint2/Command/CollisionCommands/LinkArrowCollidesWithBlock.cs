using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class LinkArrowCollidesWithBlock : ICollisionCommand
    {
        private Link link;
        private LinkArrow arrow;
        private Block block;
        private int collisionSide;
        private GameObjectManager gom;
        public LinkArrowCollidesWithBlock()
        {

        }
        public void SetCollisionObjects(ISprite arrowObject, ISprite blockObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.arrow = (LinkArrow)arrowObject;
            this.link = arrow.link;
            this.block = (Block)blockObject;
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
