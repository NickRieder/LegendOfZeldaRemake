﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Sprint2
{
	class TakingDamage : ILinkState, ICommand
	{
		private Link link;
		private Sprite sprite;
		private SpriteFactory spriteFactory;
		private SoundFactory soundFactory;		
		private Vector2 currPos;
		private static TimeSpan damagedTime;
		private TimeSpan startDamagedTime;
		private static TimeSpan resetTime;
		private TimeSpan startResetTime;
		bool isDamaged;
		private Game1 game;

		public TakingDamage(Link link)
		{
			this.game = link.game;
			this.link = link;
			sprite = link.sprite;
			
			
			spriteFactory = link.spriteFactory;
			
			sprite = spriteFactory.getLinkDamaged();
			damagedTime = TimeSpan.FromMilliseconds(500);
			resetTime = TimeSpan.FromSeconds(5);
			currPos = link.pos;
			isDamaged = true;
			
		}


		public void Draw(SpriteBatch spriteBatch)
		{
			sprite.Draw(spriteBatch, link.pos);
		}
		public void Update(GameTime gameTime)
		{
			if (isDamaged)
			{

				startDamagedTime = gameTime.TotalGameTime;
			}
			if (startDamagedTime + damagedTime < gameTime.TotalGameTime)
            {
				if (link.health > 0)
                {
					isDamaged = false;
					link.currState = new NewDirectionalLinkSprite(link, link.direction);
				}
				else
                {
					startResetTime = gameTime.TotalGameTime;
					// draw game over screen
					if (startResetTime + resetTime < gameTime.TotalGameTime)
                    {
						game.Reset();
					}
                }
			}	
            else
            {
				switch (link.direction)
				{
					case "down":

						currPos.Y -= 3;
						link.pos = currPos;
						break;
					case "left":
						currPos.X += 3;
						link.pos = currPos;
						break;
					case "right":
						currPos.X -= 3;
						link.pos = currPos;
						break;
					default: // facing up
						currPos.Y += 3;

						link.pos = currPos;
						break;
				}
            }
			sprite.Update(gameTime);
			link.sprite.Update(gameTime);
		}

		// No OPs
		public void TakeDamage() { }
		public void StandingUp() { }
		public void StandingDown() { }
		public void StandingRight() { }
		public void StandingLeft() { }
		public void Move() { }
		public void UseWeapon() { }
		public void UseItem(string newItem) { }

        public void Execute()
        {

			link.TakeDamage();
		}
    }
}

