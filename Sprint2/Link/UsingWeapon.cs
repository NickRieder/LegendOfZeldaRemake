﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace Sprint2
{
	class UsingWeapon : ILinkState
	{
		private Link link;
		private Rectangle frame1;
		private Texture2D sheet;
		private static TimeSpan attackTime;
		private TimeSpan startTimeAttack;
		bool isAttacking;

		public UsingWeapon(Link link)
		{
			this.link = link;
			// Need switch to get proper sprite
			frame1 = SpriteFactory.LINK_USESWORD_DOWN;
			this.sheet = link.spriteFactory.getLinkSheet();

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
			Rectangle destinationRectangleFrame1 = new Rectangle((int)link.pos.X, (int)link.pos.Y, frame1.Width * link.sizeMuliplier, frame1.Height * link.sizeMuliplier);
			spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
		}
		public void Update(GameTime gameTime)
		{
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
