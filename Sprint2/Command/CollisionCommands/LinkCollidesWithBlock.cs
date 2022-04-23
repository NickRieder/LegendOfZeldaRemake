using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;




namespace Sprint2
{
    class LinkCollidesWithBlock : ICollisionCommand
    {
        private Link link;
        private Block block;
        private GameObjectManager gom;
        private int side;
        public LinkCollidesWithBlock()
        {

        }
        public void SetCollisionObjects(ISprite linkObject, ISprite blockObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.link = (Link)linkObject;
            this.block = (Block)blockObject;
            this.side = (int)collisionSideOfMainObject;
            this.gom = gom;
        }

        public void CheckCollisionWithBlock(ISprite mainSpriteObject, ISprite otherSpriteObject, int collisionSideEnum)
        {
            //System.Diagnostics.Debug.WriteLine("DEBUG1: /LinkCollidesWithBlock/ INSIDE checkCollisionWithBlock");
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

        public void PreventRightCollision(ISprite mainSpriteObject, ISprite otherSpriteObject)
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
        public void PreventLeftCollision(ISprite mainSpriteObject, ISprite otherSpriteObject)
        {
            Vector2 mainSprObjPos = mainSpriteObject.pos;
            Vector2 otherSprObjPos = otherSpriteObject.pos;
            Rectangle mainSpriteRectangle = mainSpriteObject.GetSpriteRectangle();
            Rectangle otherSpriteRectangle = otherSpriteObject.GetSpriteRectangle();

            mainSprObjPos.X = otherSprObjPos.X + otherSpriteRectangle.Width;
            mainSpriteObject.pos = mainSprObjPos;
        }
        public void PreventBottomCollision(ISprite mainSpriteObject, ISprite otherSpriteObject)
        {
            Vector2 mainSprObjPos = mainSpriteObject.pos;
            Vector2 otherSprObjPos = otherSpriteObject.pos;
            Rectangle mainSpriteRectangle = mainSpriteObject.GetSpriteRectangle();
            Rectangle otherSpriteRectangle = otherSpriteObject.GetSpriteRectangle();
            
            mainSprObjPos.Y = otherSprObjPos.Y - mainSpriteRectangle.Height;
            mainSpriteObject.pos = mainSprObjPos;
        }
        public void PreventTopCollision(ISprite mainSpriteObject, ISprite otherSpriteObject)
        {
            Vector2 mainSprObjPos = mainSpriteObject.pos;
            Vector2 otherSprObjPos = otherSpriteObject.pos;
            Rectangle mainSpriteRectangle = mainSpriteObject.GetSpriteRectangle();
            Rectangle otherSpriteRectangle = otherSpriteObject.GetSpriteRectangle();

            mainSprObjPos.Y = otherSprObjPos.Y + otherSpriteRectangle.Height;
            mainSpriteObject.pos = mainSprObjPos;
        }

        public void Invoke()
        {
            CheckCollisionWithBlock(link, block, side);

            if (!link.canTakeDamage)
            {
                link.canTakeDamage = true;
            }

        }
    }
}
