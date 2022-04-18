using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint2.Collison;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Linq;

namespace Sprint2
{
    public class CollisionHandler
    {
        private GameObjectManager gom;
        private ConcurrentBag<ISprite> allObjectList;
        private ConcurrentBag<ISprite> movableObjectList;
        private Link link;
        private Enemies enemy;
        private CollisionHandlerEnemy collisionHandlerEnemy;

        public CollisionHandler(GameObjectManager gom)
        {
            this.gom = gom;
            this.link = gom.link;
            allObjectList = gom.allObjectList;
            movableObjectList = gom.movableObjectList;
            collisionHandlerEnemy = new CollisionHandlerEnemy(gom);
        }

        public void Collide(ISprite mainSpriteObject, ISprite otherSpriteObject, int collisionSideEnum)  // Check the collisionSideEnum parameter against the CollisionDetection.COLLISION_SIDE enums
        {
            //ConcurrentBag<ISprite> tempConcurrentBag = gom.movableObjectList;
            var tempList = gom.movableObjectList.ToList();
            if (gom.movableObjectList.Contains(mainSpriteObject))
            {
                CheckCollisionWithBlock(mainSpriteObject, otherSpriteObject, collisionSideEnum);
                CheckCollisionWithDoor(mainSpriteObject, otherSpriteObject, collisionSideEnum);
            }
        }

        public void CheckCollisionWithBlock(ISprite mainSpriteObject, ISprite otherSpriteObject, int collisionSideEnum)
        {
            if (collisionSideEnum == (int)CollisionDetector.COLLISION_SIDE.LEFT)
            {
                PreventLeftCollision(mainSpriteObject, otherSpriteObject);
            }
            else if (collisionSideEnum == (int)CollisionDetector.COLLISION_SIDE.RIGHT)
            {
                PreventRightCollision(mainSpriteObject, otherSpriteObject);
            }
            else if (collisionSideEnum == (int)CollisionDetector.COLLISION_SIDE.TOP)
            {
                PreventTopCollision(mainSpriteObject, otherSpriteObject);
            }
            else if (collisionSideEnum == (int)CollisionDetector.COLLISION_SIDE.BOTTOM)
            {
                PreventBottomCollision(mainSpriteObject, otherSpriteObject);
            }
        }

        public void CheckCollisionWithDoor(ISprite mainSpriteObject, ISprite otherSpriteObject, int collisionSideEnum)
        {
            // type rn is ISprite but...
            // something link this. theres errors but as long as we can get the concrete type and not the interface type...
            //Link otherSprConcreteObj = otherSpriteObject.GetConcreteObject();

            // now i can call Link specific functions whereas before since it was an ISprite, I couldn't
            //otherSprConcreteObj.GetSpriteRectangle(); // something like this

            // this basicaly might help solve your problem of having to cast the (Door) type on an ISprite variable.

            //exactly so you should technically be able to call doorConcerteObject.LoadNextRoom();

            //thats my thoughts

            // try your best with this info lol idk if itll work cool have a good night man. bruh ik lOl
            //ok peace. i wont haha

            /*Type otherSprObjType = otherSpriteObject.GetType();
            if (otherSprObjType.Equals(typeof(Door)))
            {
                otherSprObjType.b
                //new SetNextRoom((Door)otherSpriteObject);
                Door door = (Door)otherSpriteObject;
                door.LoadNextRoom();
                System.Diagnostics.Debug.WriteLine("Checking Door");
            }*/
        }

        public void PreventLeftCollision(ISprite mainSpriteObject, ISprite otherSpriteObject)
        {
            Vector2 mainSprObjPos = mainSpriteObject.pos;
            Vector2 otherSprObjPos = otherSpriteObject.pos;
            Rectangle mainSpriteRectangle = mainSpriteObject.GetSpriteRectangle();
            Rectangle otherSpriteRectangle = otherSpriteObject.GetSpriteRectangle();

            mainSprObjPos.X = otherSprObjPos.X - mainSpriteRectangle.Width;
            mainSpriteObject.pos = mainSprObjPos;

            /*otherSprObjPos.X = mainSprObjPos.X + mainSpriteRectangle.Width;
            otherSpriteObject.pos = otherSprObjPos;*/
        }
        public void PreventRightCollision(ISprite mainSpriteObject, ISprite otherSpriteObject)
        {
            Vector2 mainSprObjPos = mainSpriteObject.pos;
            Vector2 otherSprObjPos = otherSpriteObject.pos;
            Rectangle mainSpriteRectangle = mainSpriteObject.GetSpriteRectangle();
            Rectangle otherSpriteRectangle = otherSpriteObject.GetSpriteRectangle();

            mainSprObjPos.X = otherSprObjPos.X + otherSpriteRectangle.Width;
            mainSpriteObject.pos = mainSprObjPos;
        }
        public void PreventTopCollision(ISprite mainSpriteObject, ISprite otherSpriteObject)
        {
            Vector2 mainSprObjPos = mainSpriteObject.pos;
            Vector2 otherSprObjPos = otherSpriteObject.pos;
            Rectangle mainSpriteRectangle = mainSpriteObject.GetSpriteRectangle();
            Rectangle otherSpriteRectangle = otherSpriteObject.GetSpriteRectangle();
            
            mainSprObjPos.Y = otherSprObjPos.Y - mainSpriteRectangle.Height;
            mainSpriteObject.pos = mainSprObjPos;
        }
        public void PreventBottomCollision(ISprite mainSpriteObject, ISprite otherSpriteObject)
        {
            Vector2 mainSprObjPos = mainSpriteObject.pos;
            Vector2 otherSprObjPos = otherSpriteObject.pos;
            Rectangle mainSpriteRectangle = mainSpriteObject.GetSpriteRectangle();
            Rectangle otherSpriteRectangle = otherSpriteObject.GetSpriteRectangle();

            mainSprObjPos.Y = otherSprObjPos.Y + otherSpriteRectangle.Height;
            mainSpriteObject.pos = mainSprObjPos;
        }
    }   

}
