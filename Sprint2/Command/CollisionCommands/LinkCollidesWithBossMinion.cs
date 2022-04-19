using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class LinkCollidesWithBossMinion : ICollisionCommand
    {
        private Link link;
        private BossMinion minion;
        private int collisionSide;
        private GameObjectManager gom;
        public LinkCollidesWithBossMinion()
        {

        }
        public void SetCollisionObjects(ISprite linkObject, ISprite minionObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.link = (Link)linkObject;
            this.minion = (BossMinion)minionObject;
            this.collisionSide = (int)collisionSideOfMainObject;
            this.gom = gom;
        }
        public void Invoke()
        {
            link.TakeDamage(collisionSide);
            minion.velocity = -3;
            //fireball.RemoveProjectile(fireball);
        }
    }
}
