using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;
using static Sprint2.CollisionDetector;

namespace Sprint2.Collison
{
    public class CollisionResolver
    {
        private Dictionary<Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>, ICollisionCommand> collisionDictionary;
        private HashSet<Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>> keySet;
        private GameObjectManager gom;
        public Game1 myGame;

        public CollisionResolver(GameObjectManager gom)
        {
            this.gom = gom;
            collisionDictionary = new Dictionary<Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>, ICollisionCommand>();
            BuildDictionary();
            keySet = new HashSet<Tuple<Type, Type, CollisionDetector.COLLISION_SIDE> >(collisionDictionary.Keys);
        }
        
        private void BuildDictionary()
        {
            foreach (CollisionDetector.COLLISION_SIDE side in Enum.GetValues(typeof(CollisionDetector.COLLISION_SIDE)))
            {
                // Link colliding with Door objects
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(Link), typeof(Door), side), new LinkCollidesWithDoor());

                // Link colliding with Enemy objects
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(Link), typeof(Enemies), side), new LinkCollidesWithEnemy());

                // Link colliding with enemy projectiles
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(Link), typeof(DragonFireball), side), new LinkCollidesWithDragonFireball());
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(Link), typeof(GoriyaBoomerang), side), new LinkCollidesWithGoriyaBoomerang());
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(Link), typeof(BossMinion), side), new LinkCollidesWithBossMinion());

                // Colliding into Block objects
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(Link), typeof(Block), side), new LinkCollidesWithBlock());
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(Enemies), typeof(Block), side), new EnemyCollidesWithBlock());

                // Colliding into the Wall boundaries
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(Link), typeof(Wall), side), new LinkCollidesWithWall());
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(Enemies), typeof(Wall), side), new EnemyCollidesWithWall());
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(DragonFireball), typeof(Wall), side), new DragonFireballCollidesWithWall());
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(GoriyaBoomerang), typeof(Wall), side), new GoriyaBoomerangCollidesWithWall());
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(BossMinion), typeof(Wall), side), new BossMinionCollidesWithWall());

                /*collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(DragonFireball), typeof(Block), side), new DragonFireballCollidesWithBlock());

                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(DragonFireball), typeof(Door), side), new DragonFireballCollidesWithDoor());

                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(linkType, enemyType, side), typeof(SetTakeDamage));
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(enemyType, linkType, side), typeof(SetTakeDamage));
                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(typeof(DragonFireball), typeof(Link), side), typeof(SetTakeDamage));

                collisionDictionary.Add(new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(linkType, typeof(Item), side), typeof(SetLinkUseItem));*/
            }
        }

        public void HandleCollision(ISprite subject, ISprite target, CollisionDetector.COLLISION_SIDE collisionSideOfMainObject)
        {
            Type subjectType = subject.GetType();
            Type targetType = target.GetType();

            Tuple<Type, Type, CollisionDetector.COLLISION_SIDE> key = new Tuple<Type, Type, CollisionDetector.COLLISION_SIDE>(subjectType, targetType, collisionSideOfMainObject);

            if (keySet.Contains(key))
            {
                collisionDictionary[key].SetCollisionObjects(subject, target, collisionSideOfMainObject, gom);
                collisionDictionary[key].Invoke();
            }
        }
    }
}