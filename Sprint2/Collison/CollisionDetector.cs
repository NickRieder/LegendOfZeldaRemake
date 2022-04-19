using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint2.Collison;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Collections.Concurrent;

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
        private ConcurrentBag<ISprite> allObjectList;
        private ConcurrentBag<ISprite> movableObjectList;
        private CollisionHandler collisionHandler;
        private CollisionHandlerEnemy collisionHandlerEnemy;

        public CollisionDetector(GameObjectManager gom)
        {
            this.gom = gom;
            /*allObjectList = gom.allObjectList;
            movableObjectList = gom.movableObjectList;*/

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
                        return (int)COLLISION_SIDE.BOTTOM;                 // movableSprite bottom collision
                    else if (mSprRectangle.Y >= oSprRectangle.Y)
                        return (int)COLLISION_SIDE.TOP;              // movableSprite top collision
                }
                else if (intersectingArea.Width < intersectingArea.Height)   // left-right collision
                {
                    if (mSprRectangle.X < oSprRectangle.X)
                        return (int)COLLISION_SIDE.RIGHT;                // movableSprite right collision
                    else if (mSprRectangle.X >= oSprRectangle.X)
                        return (int)COLLISION_SIDE.LEFT;               // movableSprite left collision
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
            /*foreach (ISprite movableSprite in gom.movableObjectList)
            {
                if (movableSprite.GetType() == typeof(Enemies))
                {
                    Enemies tempEnemy = (Enemies)movableSprite;
                    if (movableSprite.GetSpriteRectangle().Intersects(gom.link.GetSpriteRectangle()))
                    {
                        *//*System.Diagnostics.Debug.WriteLine("DEBUG1: /CollisionDetector/ canDamage = " + tempEnemy.canDamage);
                        System.Diagnostics.Debug.WriteLine("DEBUG1: /CollisionDetector/ canTakeDamage = " + gom.link.canTakeDamage);*//*
                        if (gom.link.canTakeDamage && tempEnemy.canDamage)
                        {
                            //tempEnemy.canDamage = false;
                            collisionHandlerEnemy.HandleCollision(gom.link, movableSprite, CollisionDetector.COLLISION_SIDE.BOTTOM);
                        }

                    }
                }

            }*/

            //System.Diagnostics.Debug.WriteLine("DEBUG1: /CollisionDetector/ counter = " + counter);

            foreach (ISprite movableSprite in gom.movableObjectList)
            {
                foreach (ISprite otherSprite in gom.allObjectList)
                {

                    if (movableSprite.GetType() == typeof(Link) && otherSprite.GetType() == typeof(Enemies))
                    {
                        Link tempLink = (Link)movableSprite;

                        int collisionSideOfMainSprite = GetCollisionSide(movableSprite, otherSprite);
                        int collisionSideOfOtherSprite = GetCollisionSide(otherSprite, movableSprite);

                        if (collisionSideOfMainSprite != (int)COLLISION_SIDE.NONE && tempLink.canTakeDamage)
                        {
                            collisionHandlerEnemy.HandleCollision(movableSprite, otherSprite, (CollisionDetector.COLLISION_SIDE)collisionSideOfMainSprite);
                        }

                    }

                    if (!(movableSprite == otherSprite))
                    {
                        int collisionSideOfMainSprite = GetCollisionSide(movableSprite, otherSprite);
                        int collisionSideOfOtherSprite = GetCollisionSide(otherSprite, movableSprite);

                        if (collisionSideOfMainSprite != (int)COLLISION_SIDE.NONE)
                        {
                            collisionHandlerEnemy.HandleCollision(movableSprite, otherSprite, (CollisionDetector.COLLISION_SIDE)collisionSideOfMainSprite);
                        }
                    }
                }
            }

        }
    }
}