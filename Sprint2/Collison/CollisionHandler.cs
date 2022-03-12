using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint2.Collison;
using System;
using System.Collections;

namespace Sprint2
{
    public class CollisionHandler
    {
        private GameObjectManager gom;
        private ArrayList allObjectList;
        private ArrayList movableObjectList;
        private Link link;
        private Enemies enemy;
        private CollisionHandlerEnemy collisionHandlerEnemy;

        public CollisionHandler(GameObjectManager gom)
        {
            this.gom = gom;
            this.link = gom.link;
            enemy = new Enemies("bluebat");
            allObjectList = gom.getListOfAllObjects();
            movableObjectList = gom.getListOfMovableObjects();
            collisionHandlerEnemy = new CollisionHandlerEnemy(gom);
        }

        public void Collide(ISprite mainSpriteObject, ISprite otherSpriteObject, int collisionSideEnum)  // Check the collisionSideEnum parameter against the CollisionDetection.COLLISION_SIDE enums
        {
            if (gom.movableObjectList.Contains(mainSpriteObject))
            {
                if (collisionSideEnum == (int)CollisionDetector.COLLISION_SIDE.LEFT)
                {
                    preventLeftCollision(mainSpriteObject, otherSpriteObject);
                }
                else if (collisionSideEnum == (int)CollisionDetector.COLLISION_SIDE.RIGHT)
                {
                    preventRightCollision(mainSpriteObject, otherSpriteObject);
                }
                else if (collisionSideEnum == (int)CollisionDetector.COLLISION_SIDE.TOP)
                {
                    preventTopCollision(mainSpriteObject, otherSpriteObject);
                }
                else if (collisionSideEnum == (int)CollisionDetector.COLLISION_SIDE.BOTTOM)
                {
                    preventBottomCollision(mainSpriteObject, otherSpriteObject);
                }
            }
        }

        public void preventLeftCollision(ISprite mainSpriteObject, ISprite otherSpriteObject)
        {
            Vector2 mainSprObjPos = mainSpriteObject.pos;
            Vector2 otherSprObjPos = otherSpriteObject.pos;
            Rectangle mainSpriteRectangle = mainSpriteObject.GetSpriteRectangle();
            Rectangle otherSpriteRectangle = otherSpriteObject.GetSpriteRectangle();

            mainSprObjPos.X = otherSprObjPos.X - mainSpriteRectangle.Width;
            mainSpriteObject.pos = mainSprObjPos;
        }
        public void preventRightCollision(ISprite mainSpriteObject, ISprite otherSpriteObject)
        {
            Vector2 mainSprObjPos = mainSpriteObject.pos;
            Vector2 otherSprObjPos = otherSpriteObject.pos;
            Rectangle mainSpriteRectangle = mainSpriteObject.GetSpriteRectangle();
            Rectangle otherSpriteRectangle = otherSpriteObject.GetSpriteRectangle();

            mainSprObjPos.X = otherSprObjPos.X + otherSpriteRectangle.Width;
            mainSpriteObject.pos = mainSprObjPos;
        }
        public void preventTopCollision(ISprite mainSpriteObject, ISprite otherSpriteObject)
        {
            Vector2 mainSprObjPos = mainSpriteObject.pos;
            Vector2 otherSprObjPos = otherSpriteObject.pos;
            Rectangle mainSpriteRectangle = mainSpriteObject.GetSpriteRectangle();
            Rectangle otherSpriteRectangle = otherSpriteObject.GetSpriteRectangle();
            
            mainSprObjPos.Y = otherSprObjPos.Y - mainSpriteRectangle.Height;
            mainSpriteObject.pos = mainSprObjPos;
        }
        public void preventBottomCollision(ISprite mainSpriteObject, ISprite otherSpriteObject)
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
