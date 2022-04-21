using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class LinkCollidesWithItem : ICollisionCommand
    {
        private Link link;
        private Item item;
        private int side;
        private GameObjectManager gom;
        public LinkCollidesWithItem()
        {

        }
        public void SetCollisionObjects(ISprite linkObject, ISprite itemObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.link = (Link)linkObject;
            this.item = (Item)itemObject;
            this.side = (int)collisionSideOfMainObject;
            this.gom = gom;
        }
        public void Invoke()
        {
            System.Diagnostics.Debug.WriteLine("DEBUG: /LinkCollidesWithItem/ Trying to removing item...");
            item.PickupItem();
            gom.RemoveFromEveryCollection(item);
        }
    }
}
