using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Sprint2
{
	class TakingDamage : ILinkState
	{
		private Link link;
		private Rectangle frame1;
		private Texture2D sheet;
		private static TimeSpan damagedTime;
		private TimeSpan startDamagedTime;
		bool isDamaged;

		public TakingDamage(Link link)
		{
			this.link = link;
			frame1 = SpriteFactory.LINK_DAMAGED_BLACK_AND_RED;
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
				link.currState = new NewDirectionalLinkSprite(link, link.direction);
		}

		// No OPs
		public void TakeDamage() { }
		public void StandingUp() { }
		public void StandingDown() { }
		public void StandingRight() { }
		public void StandingLeft() { }
		public void Move() { }
		public void UseWeapon() { }
		public void UseItem(int itemNum) { }
	}
}

