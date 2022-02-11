﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
	class StandingFacingDown : ILinkState
	{
		private Link link;
		private int currFrame;
		private int totalFrames;
		private Rectangle frame1;
		private Rectangle frame2;
		private LinkSpriteFactory spriteFactory;
		private Texture2D sheet;

		public StandingFacingDown(Link link, LinkSpriteFactory spriteFactory)
		{
			this.link = link;
			this.spriteFactory = spriteFactory;
			currFrame = 0;
			totalFrames = 2;
			frame1 = LinkSpriteFactory.LINK_MOVE_MIRROR_LEFT_1;
			frame2 = LinkSpriteFactory.LINK_MOVE_MIRROR_LEFT_2;
			this.sheet = this.spriteFactory.getLinkSheetMirrored();
		}
		public void MoveUp()
		{
			link.currState = new StandingFacingUp(link);
		}
		public void MoveDown()
		{
			link.pos.Y += 5;
			if (++currFrame == totalFrames)
			{
				currFrame = 0;
			}
		}
		public void MoveRight()
		{
			link.currState = new StandingFacingRight(link);
		}
		public void MoveLeft()
		{
			link.currState = new StandingFacingLeft(link);
		}
		public void UseWeapon()
		{
			link.currState = new UsingWeaponLeft(link);
		}
		public void UseItem()
		{
			link.currState = new UsingItemLeft(link);
		}
		public void TakeDamage()
		{
			link.health--;
			link.currState = new TakingDamageLeft(link);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)link.pos.X, (int)link.pos.Y, frame1.Width, frame1.Height);
			Rectangle destinationRectangleFrame2 = new Rectangle((int)link.pos.X, (int)link.pos.Y, frame2.Width, frame2.Height);
			if (currFrame == 0)
			{
				spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
			}
			else
			{
				spriteBatch.Draw(sheet, destinationRectangleFrame2, frame2, Color.White);
			}
		}
		public void Update()
		{
		}
	}
}
