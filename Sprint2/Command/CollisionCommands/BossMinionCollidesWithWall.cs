using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class BossMinionCollidesWithWall : ICollisionCommand
    {
        private BossMinion minion;
        private Wall wall;
        private int collisionSide;
        private GameObjectManager gom;
        public BossMinionCollidesWithWall()
        {

        }
        public void SetCollisionObjects(ISprite minionObject, ISprite wallObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.minion = (BossMinion)minionObject;
            this.wall = (Wall)wallObject;
            this.collisionSide = (int)collisionSideOfMainObject;
            this.gom = gom;
        }
        public void Invoke()
        {
            minion.velocity = -3;
        }
    }
}
