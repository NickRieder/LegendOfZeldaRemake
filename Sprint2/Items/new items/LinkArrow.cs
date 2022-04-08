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
        private TimeSpan startTimeUsing;
        
        public LinkArrow(Link link, string projectileType) : base(link, projectileType)
        {
            counter = 0;
            speed = 7;
            this.gom = link.gom;

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
            base.Update(gameTime);
            if (link.isUsingItem)
            {
               // System.Diagnostics.Debug.WriteLine("isUsingItem");
                startTimeUsing = gameTime.TotalGameTime;
                link.isUsingItem = false;

            }
            if (startTimeUsing + TimeSpan.FromMilliseconds(1500) < gameTime.TotalGameTime)
            {
                link.isUsingItem = false;
                //System.Diagnostics.Debug.WriteLine("no longer using Item");
                base.RemoveProjectile(this);
            }
        }
    }
}