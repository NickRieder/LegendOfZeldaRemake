using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;
using static Sprint2.CollisionDetector;

namespace Sprint2.Collison
{
    public class CollisionHandlerEnemy
    {
        private Dictionary<Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>, ICollisionCommand> collisionDictionary;
        private HashSet<Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>> keySet;
        private GameObjectManager gom;
        public Game1 myGame;
        private Link link;
        // ArrayList[] enumValues = { 0, 1, 2, 3, 4 };
        Type linkType;
        Type doorType;
        Type itemType;
        Type enemyType;
        Type enemyProjectileType;
        private Door door;



        public CollisionHandlerEnemy(GameObjectManager gom)
        {
            this.gom = gom;
            this.link = gom.link;
            collisionDictionary = new Dictionary<Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>, ICollisionCommand>();
            BuildDictionary();
            keySet = new HashSet<Tuple<Type, Type, CollisionDetector.COLLISION_SIDE> >(collisionDictionary.Keys);
        }
        
        private void BuildDictionary()
        {
            linkType = typeof(Link);
            doorType = typeof(Door); // type is Sprint2.Door
            itemType = typeof(Item);
            enemyType = typeof(Enemies); // type is Sprint2.Enemies

            enemyProjectileType = typeof(EnemyDamagingProjectile);
            //dragonFireballType = typeof(DragonFireball);

            foreach (CollisionDetector.COLLISION_SIDE side in Enum.GetValues(typeof(CollisionDetector.COLLISION_SIDE)))
            {
                //System.Diagnostics.Debug.WriteLine($" {side}");
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(Link), typeof(Door), side), new LinkCollidesWithDoor());
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(Link), typeof(Enemies), side), new LinkCollidesWithEnemy());
                //collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(DragonFireball), typeof(Link), side), new DragonFireballCollidesWithLink());

                /*collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(linkType, enemyType, side), typeof(SetTakeDamage));
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(enemyType, linkType, side), typeof(SetTakeDamage));
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(DragonFireball), typeof(Link), side), typeof(SetTakeDamage));

                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(linkType, typeof(Item), side), typeof(SetLinkUseItem));*/
            }
        }

        public void HandleCollision(ISprite subject, ISprite target, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject)
        {
            Type subjectType = subject.GetType();
            Type targetType = target.GetType();
            /*System.Diagnostics.Debug.WriteLine("DEBUG1: /CollisionHandlerEnemy/ subjectType = " + subjectType);
            System.Diagnostics.Debug.WriteLine("DEBUG2: /CollisionHandlerEnemy/ targetType = " + targetType);*/

            Tuple<Type, Type, CollisionDetector.COLLISION_SIDE> key = new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(subjectType, targetType, collisionSideOfMainObject);

            if (keySet.Contains(key))
            {
                collisionDictionary[key].SetCollisionObjects(subject, target, collisionSideOfMainObject, gom);
                collisionDictionary[key].Invoke();

                System.Diagnostics.Debug.WriteLine("DEBUG1: /CollisionHandlerEnemy/ subjectType = " + subjectType);

                if (subjectType == typeof(DragonFireball) && targetType == typeof(Link))
                {
                    System.Diagnostics.Debug.WriteLine("DEBUG1: /CollisionHandlerEnemy/ subjectType = " + subjectType);
                    Link tempLink = (Link)target;
                    EnemyDamagingProjectile tempProjectile = (DragonFireball)subject;
                    tempLink.TakeDamage();
                    tempProjectile.RemoveProjectile(tempProjectile);

                }

            }
        }
    }
}