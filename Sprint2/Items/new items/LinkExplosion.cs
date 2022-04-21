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
        private bool hasNotExploded;
        public int damage;

        public LinkExplosion(Link link, string projectileType) : base(link, projectileType)
        {

            counter = 0;
            speed = 5;
            hasNotExploded = true;
            this.gom = link.gom;
            canDealDamage = false;
            damage = 5;
        }

        private void Explode()
        {
            Vector2 explosionPos = pos;

            int halfBombWidth = sprite.getCurrentFrameRectangle().Width / 2;
            int halfBombHeight = sprite.getCurrentFrameRectangle().Height / 2;

            sprite = spriteFactory.getExplosionSprite();
            sprite.scaleMultiplier = 10;      
            
            explosionPos.X -= (sprite.getCurrentFrameRectangle().Width / 2) - halfBombWidth;
            explosionPos.Y -= (sprite.getCurrentFrameRectangle().Height / 2) - halfBombHeight;
            pos = explosionPos;


            canDealDamage = true;

            hasNotExploded = false;
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
                startTimeUsing = gameTime.TotalGameTime;
                link.isUsingItem = false;
            }
            if(startTimeUsing + TimeSpan.FromMilliseconds(1500) < gameTime.TotalGameTime)
            {
                if (hasNotExploded)
                {
                    Explode();
                }
            }
            if (startTimeUsing + TimeSpan.FromMilliseconds(1800) < gameTime.TotalGameTime)
            {
                link.explosion.Play();
                base.RemoveProjectile(this);
            }
        }
    }
}