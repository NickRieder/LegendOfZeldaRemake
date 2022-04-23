using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class DragonFireballCollidesWithWall : ICollisionCommand
    {
        private DragonFireball fireball;
        private Wall wall;
        private int collisionSide;
        private GameObjectManager gom;
        public DragonFireballCollidesWithWall()
        {

        }
        public void SetCollisionObjects(ISprite fireballObject, ISprite wallObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.fireball = (DragonFireball)fireballObject;
            this.wall = (Wall)wallObject;
            this.collisionSide = (int)collisionSideOfMainObject;
            this.gom = gom;
        }
        public void Invoke()
        {
            fireball.RemoveProjectile(fireball);
        }
    }
}
