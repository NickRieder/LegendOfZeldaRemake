using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class LinkCollidesWithDoor : ICollisionCommand
    {
        private Link link;
        private Door door;
        private GameObjectManager gom;
        public LinkCollidesWithDoor()
        {

        }
        public void SetCollisionObjects(ISprite linkObject, ISprite doorObject, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject, GameObjectManager gom)
        {
            this.link = (Link)linkObject;
            this.door = (Door)doorObject;
            this.gom = gom;
        }
        public void Invoke()
        {
            /*Link tempLink = (Link)subject;
            Door tempDoor = (Door)target;*/
            string doorType = door.doorType;
            ICommand scrollCommand;

            if (doorType.Contains("Lock") && link.keys > 0)
            {
                door.canContinue = true;
            }

            if (door.canContinue)
            {
                if (doorType.Contains("Top"))
                {
                    System.Diagnostics.Debug.WriteLine("DEBUG2: /CollisionHandlerEnemy/ SCROLL CAMERA");
                    scrollCommand = new SetCameraMovingUp(gom.camera, door);
                    scrollCommand.Execute();
                }
                else if (doorType.Contains("Bot"))
                {
                    System.Diagnostics.Debug.WriteLine("DEBUG2: /CollisionHandlerEnemy/ SCROLL CAMERA");
                    scrollCommand = new SetCameraMovingDown(gom.camera, door);
                    scrollCommand.Execute();
                }
                else if (doorType.Contains("Left"))
                {
                    System.Diagnostics.Debug.WriteLine("DEBUG2: /CollisionHandlerEnemy/ SCROLL CAMERA");
                    scrollCommand = new SetCameraMovingLeft(gom.camera, door);
                    scrollCommand.Execute();
                }
                else if (doorType.Contains("Right"))
                {
                    System.Diagnostics.Debug.WriteLine("DEBUG2: /CollisionHandlerEnemy/ SCROLL CAMERA");
                    scrollCommand = new SetCameraMovingRight(gom.camera, door);
                    scrollCommand.Execute();
                }
            }

            /*if (subjectType == typeof(Link) && targetType == typeof(Door)) // door collision - doesnt work yet - will have to refactor
            {
                
            }*/
        }

        
    }
}
