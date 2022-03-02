using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Sprint2
{
    public class CollisonDetector
    {
        enum COLLISION_SIDE : int
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

        public CollisonDetector(GameObjectManager gom)
        {
            this.gom = gom;
            allObjectList = gom.getListOfAllObjects();
            movableObjectList = gom.getListOfMovableObjects();
        }

        private int GetCollision(ISprite movableSpite, ISprite otherSprite)
        {
            // THIS MIGHT BE HOW YOU IMPLEMENT GetCollision
            /*//
              mSprRectangle = movableSprite.Rectangle;
              oSprRectangle = otherSprite.Rectangle;
              int intersectingArea = Rectangle.Intersect(mSprRectangle, oSprRectangle);
              if (intersectingArea.Width >= intersectingArea.Height)      // top-bottom collision
                  {
                      if (mSprRectangle.pos.Y < oSprRectangle.pos.Y)
                          return (int)COLLISION_SIDE.TOP;                 // movableSprite top collision
                      elseif (mSprRectangle.pos.Y >= oSprRectangle.pos.Y)
                          return (int)COLLISION_SIDE.BOTTOM;              // movableSprite bottom collision
                  }
              elseif (intersectingArea.Width < intersectingArea.Height)   // left-right collision
                  {
                      if (mSprRectangle.pos.X < oSprRectangle.pos.X)
                          return (int)COLLSION_SIDE.LEFT;                 // movableSprite left collision
                      elseif (mSprRectangle.pos.X >= oSprRectangle.pos.X)
                          return (int)COLLISION_SIDE.RIGHT                // movableSprite right collision
                  }
              else
                  {
                      return (int)COLLISION_SIDE.NONE;
                  }
            //*/

            return 0; // return this for now, so code doesnt break
        }

        public void Update(GameTime gametime)
        {
            foreach(ISprite movableSprite in movableObjectList)
            {
                foreach(ISprite otherSprite in allObjectList)
                {
                    if (!(movableSprite == otherSprite))
                    {
                        int collisionSide = GetCollision(movableSprite, otherSprite);
                        if (collisionSide != (int)COLLISION_SIDE.NONE)
                        {
                            // Kevin: is the Collide function a part of collision response? If so, it should probably be in the ColisionHandler.cs file.
                            // movableSprite.Collide(collision);
                            // otherSprite.Collide(collision);
                        }
                        
                    }

                                     
                }
            }
        }
    }
}
