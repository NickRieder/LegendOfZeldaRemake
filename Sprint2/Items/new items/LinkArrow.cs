using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class LinkArrow : LinkDamagingProjectile
    {
        private int counter;
        private double speed;
        public int damage;
        private TimeSpan startTimeUsing;
        private bool startUsingItem;

        public LinkArrow(Link link, string projectileType) : base(link, projectileType)
        {
            counter = 0;
            speed = 7;
            damage = 1;
            this.gom = link.gom;
            startUsingItem = true;
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 newPos = pos;

            switch (projectileDirection)
            {
                case "down":
                    newPos.Y += (int)speed;
                    pos = newPos;
                    break;
                case "up":
                    newPos.Y -= (int)speed;
                    pos = newPos;
                    break;
                case "right":
                    newPos.X += (int)speed;
                    pos = newPos;
                    break;
                case "left":
                    newPos.X -= (int)speed;
                    pos = newPos;
                    break;
                default:
                    break;
            }

            

            if (startUsingItem)
            {
                startTimeUsing = gameTime.TotalGameTime;
                startUsingItem = false;

            }

            

            if (startTimeUsing + TimeSpan.FromMilliseconds(1500) < gameTime.TotalGameTime)
            {
                link.isUsingItem = false;
                base.RemoveProjectile(this);
                
            }

            base.Update(gameTime);

        }
    }
}