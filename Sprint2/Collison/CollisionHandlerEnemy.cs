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
        private Dictionary<Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>, Type> commandMap;
        private HashSet<Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>> keySet;
        public Game1 myGame;
        private Link link;
        // ArrayList[] enumValues = { 0, 1, 2, 3, 4 };
        Type playerType;
        Type doorType;
        private Door door;



        public CollisionHandlerEnemy(GameObjectManager gom)
        {
            this.link = gom.link;
            commandMap = new Dictionary<Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>, Type>();
            BuildDictionary();
            keySet = new HashSet<Tuple<Type, Type, CollisionDetector.COLLISION_SIDE> >(commandMap.Keys);
        }
        
        private void BuildDictionary()
        {
            playerType = typeof(Link);
            Type enemyType = typeof(Enemies); // type is Sprint2.Enemies

            foreach (CollisionDetector.COLLISION_SIDE side in Enum.GetValues(typeof(CollisionDetector.COLLISION_SIDE)))
            {
                //System.Diagnostics.Debug.WriteLine($" {side}");
                commandMap.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(playerType, typeof(Enemies), side), typeof(SetTakeDamage));
                commandMap.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(playerType, typeof(Door), side), typeof(SetNextRoom));
            }
        }

        public void HandleCollision(ISprite subject, ISprite target, COLLISION_SIDE side)
        {
            Type subjectType = subject.GetType();
            Type targetType = target.GetType();
            Type doorType = typeof(Door); // type is Sprint2.Door

            Tuple<Type, Type, CollisionDetector.COLLISION_SIDE> key = new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(subjectType, targetType, side);

            if (keySet.Contains(key))
            {
                //System.Diagnostics.Debug.WriteLine($" {key}");

                if (subjectType == playerType)
                {
                    link.TakeDamage();
                }

                if (subjectType == doorType)
                {
                    //(Door)door.LoadNextLevel;
                }
                // try to figure out concrete type of the door so that we can do subjectType==doorType
            }
        }
    }
}