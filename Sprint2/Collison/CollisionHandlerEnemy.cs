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
        private Dictionary<Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>, Type> collisionDictionary;
        private HashSet<Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>> keySet;
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
            this.link = gom.link;
            collisionDictionary = new Dictionary<Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>, Type>();
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

            foreach (CollisionDetector.COLLISION_SIDE side in Enum.GetValues(typeof(CollisionDetector.COLLISION_SIDE)))
            {
                //System.Diagnostics.Debug.WriteLine($" {side}");
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(linkType, enemyType, side), typeof(SetTakeDamage));
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(DragonFireball), typeof(Link), side), typeof(SetTakeDamage));
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(linkType, typeof(Door), side), typeof(SetNextRoom));
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(linkType, typeof(Item), side), typeof(SetLinkUseItem));
            }
        }

        public void HandleCollision(ISprite subject, ISprite target, COLLISION_SIDE side)
        {
            Type subjectType = subject.GetType();
            Type targetType = target.GetType();
            System.Diagnostics.Debug.WriteLine("DEBUG1: /CollisionHandlerEnemy/ subjectType = " + subjectType);
            System.Diagnostics.Debug.WriteLine("DEBUG2: /CollisionHandlerEnemy/ targetType = " + targetType);

            Tuple<Type, Type, CollisionDetector.COLLISION_SIDE> key = new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(subjectType, targetType, side);

            if (keySet.Contains(key))
            {
                //System.Diagnostics.Debug.WriteLine("DEBUG: /CollisionHandlerEnemy/ touching projectile ");
                //collisionDictionary.

                //System.Diagnostics.Debug.WriteLine($" {key}");

                if (subjectType == typeof(DragonFireball) && targetType == typeof(Link))
                {
                    System.Diagnostics.Debug.WriteLine("DEBUG3: /CollisionHandlerEnemy/ PROJECTILE COLLISION ");
                    //subject.GetLinkObject().TakeDamage();
                    Link tempLink = (Link)target;
                    tempLink.TakeDamage();
                    //link.TakeDamage();
                }

                if (subjectType == typeof(Link) && targetType == typeof(Enemies))
                {
                    //subject.GetLinkObject().TakeDamage();
                    Link tempLink = (Link)subject;
                    tempLink.TakeDamage();
                    //link.TakeDamage();
                }

                if (subjectType == typeof(Link) && targetType == typeof(Door)) // door collision - doesnt work yet - will have to refactor
                {
                    System.Diagnostics.Debug.WriteLine("DEBUG4: /CollisionHandlerEnemy/ DOOR COLLISION ");

                    Door tempDoor = (Door)target;
                    tempDoor.LoadNextRoom();
                }
            }
        }
    }
}