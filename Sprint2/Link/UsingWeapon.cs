﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace Sprint2
{
	class UsingWeapon : ILinkState
	{
		private Link link;
		private Sprite sprite;
		private SpriteFactory spriteFactory;
		private static TimeSpan attackTime;
		private TimeSpan startTimeAttack;
		bool isAttacking;

		public UsingWeapon(Link link)
		{
			this.link = link;
			this.sprite = link.sprite;
			spriteFactory = link.spriteFactory;
			switch (link.direction)
			{
				case "down":
					sprite = spriteFactory.getLinkUsingWeaponDown();
					break;
				case "left":
					sprite = spriteFactory.getLinkUsingWeaponLeft();
					break;
				case "right":
					sprite = spriteFactory.getLinkUsingWeaponRight();
					break;
				default: // facing up
					sprite = spriteFactory.getLinkUsingWeaponUp();
					break;
			}
			attackTime = TimeSpan.FromMilliseconds(500);
			isAttacking = true;
		}

		public void TakeDamage()
		{
			link.health--;
			link.currState = new NewDirectionalLinkSprite(link, link.direction);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			sprite.Draw(spriteBatch, link.pos);
		}
		public void Update(GameTime gameTime)
		{
			sprite.Update(gameTime);
			if (isAttacking)
			{
				startTimeAttack = gameTime.TotalGameTime;
				isAttacking = false;
			}
			if (startTimeAttack + attackTime < gameTime.TotalGameTime)
			{
				link.currState = new NewDirectionalLinkSprite(link, link.direction);
			}
		}

		// No OPs
		public void StandingUp() { }
		public void StandingDown() { }
		public void StandingRight() { }
		public void StandingLeft() { }
		public void Move() { }
		public void UseWeapon() { }
		public void UseItem(int itemNum) { }
	}
}