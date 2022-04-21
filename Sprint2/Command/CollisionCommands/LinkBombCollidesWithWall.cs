using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class LinkBombCollidesWithWall : ICollisionCommand
    {
        private Link link;
        private LinkExplosion bomb;
        private Wall wall;
        private int collisionSide;
        private GameObjectManager gom;
        public LinkBombCollidesWithWall()
        {

        }
        public void SetCollisionObjects(ISprite bombObject, ISprite wallObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.bomb = (LinkExplosion)bombObject;
            this.link = bomb.link;
            this.wall = (Wall)wallObject;
            this.collisionSide = (int)collisionSideOfMainObject;
            this.gom = gom;

        }
        public void Invoke()
        {
            System.Diagnostics.Debug.WriteLine("debug message");
            Vector2 newPos = bomb.pos;
            int bombWidth = bomb.sprite.getCurrentFrameRectangle().Width;
            int bombHeight = bomb.sprite.getCurrentFrameRectangle().Height;


            if (collisionSide == (int)CollisionDetector.COLLISION_SIDE.TOP)
            {
                newPos.Y += bombHeight;
            }
            else if (collisionSide == (int)CollisionDetector.COLLISION_SIDE.BOTTOM)
            {
                newPos.Y -= bombHeight;
            }
            else if (collisionSide == (int)CollisionDetector.COLLISION_SIDE.LEFT)
            {
                newPos.X += bombWidth;
            }
            else if (collisionSide == (int)CollisionDetector.COLLISION_SIDE.RIGHT)
            {
                newPos.X -= bombWidth;
            }

            bomb.pos = newPos;
        }
    }
}
