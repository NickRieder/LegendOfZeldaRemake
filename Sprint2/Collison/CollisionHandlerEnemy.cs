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

        /*

        public ICommand parseConstructor(ICollider subject, ICollider target, CollisionSides side, Type commandType)
        {
            Type targetType = target.GetType();
            Type subjectType = subject.GetType();

            // Search for a valid constructor for this commandType.
            List<Type[]> signatures = new List<Type[]> {
                new Type[] { targetType },
                new Type[] { typeof(Game1) },
                new Type[] { targetType, typeof(CollisionSides) },
                new Type[] { targetType, typeof(Room) },
                new Type[] { subjectType, targetType, typeof(CollisionSides) },
                new Type[] { subjectType, targetType, typeof(Room) },
                new Type[] { typeof(Game1), subjectType, targetType, typeof(CollisionSides) },
            };

            ConstructorInfo commandConstructor = null;
            foreach (Type[] signature in signatures)
            {
                commandConstructor = commandType.GetConstructor(signature);
                if (commandConstructor != null) { break; }
            }
            if (commandConstructor == null) { return null; }

            // Now invoke the constructor.
            switch (commandConstructor.GetParameters().Length)
            {
                case 1:
                    if (commandConstructor.GetParameters()[0].ParameterType == typeof(Game1))
                    {
                        return (ICommand)commandConstructor.Invoke(new object[] { myGame });
                    }
                    else
                    {
                        return (ICommand)commandConstructor.Invoke(new object[] { target });
                    }
                case 2:
                    if (commandConstructor.GetParameters()[1].ParameterType == typeof(Room))
                    {
                        return (ICommand)commandConstructor.Invoke(new object[] { target, myRoom });
                    }
                    else
                    {
                        return (ICommand)commandConstructor.Invoke(new object[] { target, side });
                    }
                case 3:
                    if (commandConstructor.GetParameters()[2].ParameterType == typeof(Room))
                    {
                        return (ICommand)commandConstructor.Invoke(new object[] { subject, target, myRoom });
                    }
                    else
                    {
                        return (ICommand)commandConstructor.Invoke(new object[] { subject, target, side });
                    }
                case 4:
                    return (ICommand)commandConstructor.Invoke(new object[] { myGame, subject, target, side });
                default:
                    return null;
            }
        } */

    }
}
