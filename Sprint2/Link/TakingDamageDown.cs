using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Sprint2
{
    class TakingDamageDown : ILinkState
	{
		private Link link;
		private Rectangle frame1;
		private Texture2D sheet;
		private static TimeSpan damagedTime;
		private TimeSpan startDamagedTime;
		bool isDamaged;

		public TakingDamageDown(Link link)
		{
			this.link = link;
			frame1 = LinkSpriteFactory.LINK_DAMAGED_BLACK_AND_RED;
			this.sheet = link.spriteFactory.getLinkSheet();
			damagedTime = TimeSpan.FromMilliseconds(500);
			isDamaged = true;
		}

		
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)link.pos.X, (int)link.pos.Y, frame1.Width * link.sizeMuliplier, frame1.Height * link.sizeMuliplier);
			spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
	
		}
		public void Update(GameTime gameTime)
		{
			if (isDamaged)
            {
				startDamagedTime = gameTime.TotalGameTime;
				isDamaged = false;
			}
			if (startDamagedTime + damagedTime < gameTime.TotalGameTime)
				link.currState = new StandingFacingDown(link);
		}

		// No OPs
		public void TakeDamage() { }
		public void MoveUp() { }
		public void MoveDown() { }
		public void MoveRight() { }
		public void MoveLeft() { }
		public void UseWeapon() { }
		public void UseItem(int itemNum) { }
	}
}

