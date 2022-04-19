using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public interface ICollisionCommand
    {
        public void SetCollisionObjects(ISprite mainObject, ISprite otherObject, CollisionDetector.COLLISION_SIDE side, GameObjectManager gom);
        public void Invoke();
    }
}
