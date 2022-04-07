using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;

namespace Sprint2
{
    public class GoriyaBoomerang : DamagingProjectile
    {
        private int counter;
        private double velocity;

		public GoriyaBoomerang(Enemies enemy, string projectileType) : base(enemy, projectileType)
		{
            counter = 0;
            velocity = 7;
            this.gom = enemy.gom;
        }

        public override void Update(GameTime gameTime)
        {
            // // If boomerang collides with a wall (AKA a Block), then it should return to the goriya.

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

            if (((int)gameTime.TotalGameTime.TotalMilliseconds) % 10 == 0)
            {
                base.Update(gameTime);
                velocity -= 0.5;
            }
            if (sprite.getDestinationRectangle().Intersects(enemy.GetSpriteRectangle()))   // 
            {
                base.RemoveProjectile(this);
                enemy.freeze = false;
            }
            counter++;
        }

    }
}
