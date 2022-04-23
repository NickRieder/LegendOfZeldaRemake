using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class DragonFireballCollidesWithBlock : ICollisionCommand
    {
        private DragonFireball fireball;
        private LinkArrow arrow;
        private Block block;
        private int collisionSide;
        private GameObjectManager gom;
        public DragonFireballCollidesWithBlock()
        {

        }
        public void SetCollisionObjects(ISprite fireballObject, ISprite blockObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.fireball = (DragonFireball)fireballObject;
            this.block = (Block)blockObject;
            this.collisionSide = (int)collisionSideOfMainObject;
            this.gom = gom;
        }
        public void Invoke()
        {
            fireball.RemoveProjectile(fireball);
        }
    }
}
