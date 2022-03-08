using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Sprint2
{
    public class CollisionHandler
    {
        private GameObjectManager gom;
        private ArrayList allObjectList;
        private ArrayList movableObjectList;

        public CollisionHandler(GameObjectManager gom)
        {
            this.gom = gom;
            allObjectList = gom.getListOfAllObjects();
            movableObjectList = gom.getListOfMovableObjects();
        }

        public void Collide(ISprite spriteObject, int collisionSideEnum)  // Check the collisionSideEnum parameter against the CollisionDetection.COLLISION_SIDE enums
        {
            if (gom.movableObjectList.Contains(spriteObject))
            {
                if (collisionSideEnum == (int)CollisionDetector.COLLISION_SIDE.LEFT)
                {
                    preventLeftCollision(spriteObject);
                }
                else if (collisionSideEnum == (int)CollisionDetector.COLLISION_SIDE.RIGHT)
                {

                }
                else if (collisionSideEnum == (int)CollisionDetector.COLLISION_SIDE.TOP)
                {

                }
                else if (collisionSideEnum == (int)CollisionDetector.COLLISION_SIDE.BOTTOM)
                {

                }
            }

        }

        public void preventLeftCollision(ISprite spriteObject)
        {
            Rectangle spriteRectangle = spriteObject.GetDestinationRectangle();
            spriteRectangle.X = 50;
        }

    }
}
