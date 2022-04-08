using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class LinkBoomerang : LinkDamagingProjectile
    {
        private int counter;
        private double velocity;

        public LinkBoomerang(Link link, string projectileType) : base(link, projectileType)
        {
            counter = 0;
            velocity = 7;
            this.gom = link.gom;
        }

        public override void Update(GameTime gameTime)
        {
            // // If boomerang collides with a wall (AKA a Block), then it should return to the goriya.

            Vector2 newPos = pos;
            switch (projectileDirection)
            {
                case "down":
                    newPos.Y += (int)velocity;
                    pos = newPos;
                    break;
                case "up":
                    newPos.Y -= (int)velocity;
                    pos = newPos;
                    break;
                case "right":
                    newPos.X += (int)velocity;
                    pos = newPos;
                    break;
                case "left":
                    newPos.X -= (int)velocity;
                    pos = newPos;
                    break;
                default:
                    break;

                   
            }
            base.Update(gameTime);

            if (((int)gameTime.TotalGameTime.TotalMilliseconds) % 10== 0)
            {

                velocity -= 0.5;
                if (sprite.getDestinationRectangle().Intersects(link.GetSpriteRectangle()))
                {
                    base.RemoveProjectile(this);
                    link.isUsingItem = false;
                    //link.freeze = false;
                }
            }
            
            counter++;
        }
    }
}
