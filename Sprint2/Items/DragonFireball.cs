using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;

namespace Sprint2
{
    public class DragonFireball : DamagingProjectile
    {
        private int counter;
        private double velocity;
        private string trajectory;
        private Vector2 slope;

        public DragonFireball(Enemies enemy, string projectileType) : base(enemy, projectileType)
        {
            counter = 0;
            velocity = 1;
            this.gom = enemy.gom;
        }

        public void SetTrajectory(string path)
        {
            trajectory = path;
            slope = new Vector2(3,2);
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
            else
            {

            }
            
            base.Update(gameTime);
        }

    }
}
