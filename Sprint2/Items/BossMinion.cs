using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;

namespace Sprint2
{
    public class BossMinion : EnemyDamagingProjectile
    {
        private int counter;
        private double velocity;

        private static int initialVelocity = 7;
        private static double velocityUpdate = 0.5;
        private static int velocityUpdateMod = 10;

        public BossMinion(Enemies enemy, string projectileType) : base(enemy, projectileType)
		{
            counter = 0;
            velocity = initialVelocity;
            this.gom = enemy.gom;
        }

        public override void Update(GameTime gameTime)
        {
            // // If projectile collides with a wall (AKA a Block), then it should return to the boss.

            Vector2 newPos = pos;
            switch (projectileDirection)
            {
                case "Down":
                    newPos.Y += (int)velocity;
                    pos = newPos; 
                    break;
                case "Up":
                    newPos.Y -= (int)velocity;
                    pos = newPos;
                    break;
                case "Right":
                    newPos.X += (int)velocity;
                    pos = newPos;
                    break;
                case "Left":
                    newPos.X -= (int)velocity;
                    pos = newPos;
                    break;
                default:
                    break;
            }

            if (((int)gameTime.TotalGameTime.TotalMilliseconds) % velocityUpdateMod == 0)
            {
                base.Update(gameTime);
                velocity -= velocityUpdate;
            }
            if (sprite.getDestinationRectangle().Intersects(enemy.GetSpriteRectangle()))  
            {
                base.RemoveProjectile(this);
                enemy.freeze = false;
            }
            counter++;
        }

    }
}
