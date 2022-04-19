using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;

namespace Sprint2
{
    public class DragonFireball : EnemyDamagingProjectile
    {
        private int counter;
        private double velocity;
        private string trajectory;
        private Vector2 slope;
        private TimeSpan startTimeUsing;
        private bool startUsingItem;

        private static int initialVelocity = 1;
        private static int slopeX = 3;
        private static int slopeY = 2;

        public DragonFireball(Enemies enemy, string projectileType) : base(enemy, projectileType)
        {
            counter = 0;
            velocity = initialVelocity;
            this.gom = enemy.gom;
            startUsingItem = true;
        }

        public void SetTrajectory(string path)
        {
            trajectory = path;
            slope = new Vector2(slopeX,slopeY);
        }

        public override void Update(GameTime gameTime)
        {
            // If fireball collides with a wall (AKA a Block), then it should disappear.

            Vector2 newPos = pos;
            if (projectileDirection == "Left")
            {
                switch (trajectory)
                {
                    case "Upward":
                        newPos.X -= slope.X;
                        newPos.Y -= slope.Y;
                        pos = newPos;
                        break;
                    case "Straight":
                        newPos.X -= slope.X;
                        pos = newPos;
                        break;
                    case "Downward":
                        newPos.X -= slope.X;
                        newPos.Y += slope.Y;
                        pos = newPos;
                        break;
                    default:
                        break;
                }
            }

            if (startUsingItem)
            {
                startTimeUsing = gameTime.TotalGameTime;
                startUsingItem = false;

            }
            if (startTimeUsing + TimeSpan.FromMilliseconds(2500) < gameTime.TotalGameTime)
            {
                base.RemoveProjectile(this);
            }

            base.Update(gameTime);
        }

    }
}
