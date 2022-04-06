using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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
            doorType = typeof(Door);
               
            //Enemy Types
            Type enemyType = typeof(Enemies);

            //Type[] enemyTypes = { bluebatType };

            foreach (CollisionDetector.COLLISION_SIDE side in Enum.GetValues(typeof(CollisionDetector.COLLISION_SIDE)))
            {
                //System.Diagnostics.Debug.WriteLine($" {side}");
                commandMap.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(Enemies), playerType, side), typeof(SetTakeDamage));
                commandMap.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(playerType, typeof(Enemies), side), typeof(SetTakeDamage));

                commandMap.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(Door), playerType, side), typeof(SetNextRoom));
                commandMap.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(playerType, typeof(Door), side), typeof(SetNextRoom));

            }
        }

        public ICommand parseConstructor(ISprite subject, ISprite target, CollisionDetector.COLLISION_SIDE side, Type commandType)
        {
            Type targetType = target.GetType();
            Type subjectType = subject.GetType();

            // Search for a valid constructor for this commandType.
            List<Type[]> signatures = new List<Type[]> {
                new Type[] { subjectType, targetType, typeof(CollisionDetector.COLLISION_SIDE) },
            };

            ConstructorInfo commandConstructor = null;
            foreach (Type[] signature in signatures)
            {
                commandConstructor = commandType.GetConstructor(signature);
                if (commandConstructor != null) { break; }
            }
            if (commandConstructor == null) { return null; }

            return (ICommand)commandConstructor.Invoke(new object[] { subject, target, side });
        }

        /*
        public void HandleCollision(ISprite subject, ISprite target, CollisionDetector.COLLISION_SIDE side)
        {
            Type subjectType = subject.GetType();
            Type targetType = target.GetType();

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
                    door.LoadNextLevel();
                }
            }
        }
        */

        public void HandleCollision(ISprite subject, ISprite target, CollisionDetector.COLLISION_SIDE side)
        {
            Type subjectType = subject.GetType();
            Type targetType = target.GetType();
            
            Tuple<Type, Type, CollisionDetector.COLLISION_SIDE> key = new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(subjectType, targetType, side);
            if (keySet.Contains(key))
            {
                Type commandType = commandMap[key];
                Console.WriteLine(commandType);
                ICommand commandClass = parseConstructor(subject, target, side, commandType);

                if (commandClass != null) { commandClass.Execute(); }
            }
        }

    }
}
