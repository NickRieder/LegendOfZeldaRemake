using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class LinkExplosion: LinkDamagingProjectile
    {
        private int counter;
        private double speed;
        private TimeSpan startTimeUsing;

        public LinkExplosion(Link link, string projectileType) : base(link, projectileType)
        {

            counter = 0;
            speed = 5;
            this.gom = link.gom;


        }
      
        public override void Update(GameTime gameTime)
        {
            Vector2 newPos = pos;

            // if you want bomb to travel a long distance
            /*switch (projectileDirection)
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
            }*/
            base.Update(gameTime);
            if (link.isUsingItem)
            {
                //System.Diagnostics.Debug.WriteLine("Bomb");
                startTimeUsing = gameTime.TotalGameTime;
                link.isUsingItem = false;
            }
            if(startTimeUsing + TimeSpan.FromMilliseconds(1200) < gameTime.TotalGameTime)
            {
                sprite = spriteFactory.getExplosionSprite();
                
            }
            if (startTimeUsing + TimeSpan.FromMilliseconds(1500) < gameTime.TotalGameTime)
            {
                link.explosion.Play();
                // System.Diagnostics.Debug.WriteLine("");
                base.RemoveProjectile(this);
            }
            //System.Diagnostics.Debug.WriteLine("explosion");
        }
    }
}