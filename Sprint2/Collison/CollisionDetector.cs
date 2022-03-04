using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        public CollisionDetector(GameObjectManager gom)
        {
            this.gom = gom;
            allObjectList = gom.getListOfAllObjects();
            movableObjectList = gom.getListOfMovableObjects();

            collisionHandler = new CollisionHandler(gom);
        }

        private int GetCollision(Sprite movableSpite, Sprite otherSprite)
        {
            int collisionSide = 0;
            Rectangle mSprRectangle = movableSpite.getDestinationRectangle();
            Rectangle oSprRectangle = otherSprite.getDestinationRectangle();
            Rectangle intersectingArea = Rectangle.Intersect(mSprRectangle, oSprRectangle);

            if (intersectingArea.Width >= intersectingArea.Height)      // top-bottom collision
            {
                if (mSprRectangle.Y < oSprRectangle.Y)
                    return (int)COLLISION_SIDE.TOP;                 // movableSprite top collision
                else if(mSprRectangle.Y >= oSprRectangle.Y)
                    return (int)COLLISION_SIDE.BOTTOM;              // movableSprite bottom collision
            }
            else if(intersectingArea.Width < intersectingArea.Height)   // left-right collision
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
            return collisionSide;
        }


        public void Update(GameTime gametime)
        {
            foreach(Sprite movableSprite in movableObjectList)
            {
                foreach(Sprite otherSprite in allObjectList)
                {
                    if (!(movableSprite == otherSprite))
                    {
                        int collisionSide = GetCollision(movableSprite, otherSprite);
                        if (collisionSide != (int)COLLISION_SIDE.NONE)
                        {
                            // This was how the pseudocode had it
                            /*movableSprite.Collide(collisionSide);
                            otherSprite.Collide(collisionSide);*/

                            // We are implementing the Collide() function in the CollisionHandler instead.
                            collisionHandler.Collide(movableSprite, collisionSide);
                            collisionHandler.Collide(otherSprite, collisionSide);
                        }
                        
                    }

                                     
                }
            }

        }
    }
}
