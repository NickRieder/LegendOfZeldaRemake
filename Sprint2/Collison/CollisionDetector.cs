using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint2.Collison;
using System.Collections;

namespace Sprint2
{
    public class CollisionDetector : ICollision
    {
        public enum COLLISION_SIDE : int
        {
            NONE = 0,
            TOP = 1,
            RIGHT = 2,
            BOTTOM = 3,
            LEFT = 4
        }

        private GameObjectManager gom;
        private ArrayList allObjectList;
        private ArrayList movableObjectList;
        private CollisionHandler collisionHandler;
        private CollisionHandlerEnemy collisionHandlerEnemy;

        public CollisionDetector(GameObjectManager gom)
        {
            this.gom = gom;
            allObjectList = gom.getListOfAllObjects();
            movableObjectList = gom.getListOfMovableObjects();

            collisionHandler = new CollisionHandler(gom);
            collisionHandlerEnemy = new CollisionHandlerEnemy(gom);
        }

        private int GetCollisionSide(ISprite movableSpite, ISprite otherSprite)
        {
            int collisionSide = 0;

            Rectangle mSprRectangle = movableSpite.GetSpriteRectangle();
            Rectangle oSprRectangle = otherSprite.GetSpriteRectangle();

            Rectangle intersectingArea = Rectangle.Intersect(mSprRectangle, oSprRectangle);

            if (!(intersectingArea.IsEmpty))
            {
                if (intersectingArea.Width >= intersectingArea.Height)      // top-bottom collision
                {
                    if (mSprRectangle.Y < oSprRectangle.Y)
                        return (int)COLLISION_SIDE.TOP;                 // movableSprite top collision
                    else if (mSprRectangle.Y >= oSprRectangle.Y)
                        return (int)COLLISION_SIDE.BOTTOM;              // movableSprite bottom collision
                }
                else if (intersectingArea.Width < intersectingArea.Height)   // left-right collision
                {
                    if (mSprRectangle.X < oSprRectangle.X)
                        return (int)COLLISION_SIDE.LEFT;                // movableSprite left collision
                    else if (mSprRectangle.X >= oSprRectangle.X)
                        return (int)COLLISION_SIDE.RIGHT;               // movableSprite right collision
                }
                else
                {
                    return (int)COLLISION_SIDE.NONE;
                }
            }
            
            return collisionSide;
        }


        public void Update(GameTime gametime)
        {
            foreach (ISprite movableSprite in movableObjectList)
            {
                foreach (ISprite otherSprite in allObjectList)
                {
                    if (!(movableSprite == otherSprite))
                    {
                        int collisionSide = GetCollisionSide(movableSprite, otherSprite);
                        if (collisionSide != (int)COLLISION_SIDE.NONE)
                        {
                            collisionHandler.Collide(movableSprite, otherSprite, collisionSide); // goes through a for each loop twide
                            collisionHandlerEnemy.HandleCollision(otherSprite, movableSprite, (CollisionDetector.COLLISION_SIDE)collisionSide);
                        }
                    }
                }
            }

        }

    }
    
}
