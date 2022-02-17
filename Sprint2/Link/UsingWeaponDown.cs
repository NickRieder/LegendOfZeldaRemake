using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace Sprint2
{
    class UsingWeaponDown : ILinkState
	{
		private Link link;
		private int currFrame;
		private int totalFrames;
		private Rectangle frame1;
		private Texture2D sheet;

		private static TimeSpan attackTime;
		private TimeSpan startTimeAttack;
		bool isAttacking;

		public UsingWeaponDown(Link link)
		{
			this.link = link;
			currFrame = 0;
			totalFrames = 1;
			frame1 = LinkSpriteFactory.LINK_USESWORD_DOWN;
			this.sheet = link.spriteFactory.getLinkSheet();

			attackTime = TimeSpan.FromMilliseconds(500);
			isAttacking = true;
		}
		
		public void TakeDamage()
		{
			link.health--;
			link.currState = new TakingDamageDown(link);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)link.pos.X, (int)link.pos.Y, frame1.Width, frame1.Height);
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
				link.currState = new StandingFacingDown(link);
			}
		}

		// No OPs
		public void MoveUp() { }
		public void MoveDown() { }
		public void MoveRight() { }
		public void MoveLeft() { }
		public void UseWeapon() { }
		public void UseItem() { }
	}
}
