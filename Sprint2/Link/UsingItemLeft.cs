using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    class UsingItemLeft : ILinkState
	{
		private Link link;
		private int currFrame;
		private int totalFrames;
		private Rectangle frame1;
		private Texture2D sheet;

		public UsingItemLeft(Link link)
		{
			this.link = link;
			currFrame = 0;
			totalFrames = 1;
			frame1 = SpriteFactory.LINK_USEITEM_MIRROR_LEFT;
			this.sheet = link.spriteFactory.getLinkSheetMirrored();
		}

		public void TakeDamage()
		{
			link.health--;
			link.currState = new TakingDamageDown(link);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)link.pos.X, (int)link.pos.Y, frame1.Width * link.sizeMuliplier, frame1.Height * link.sizeMuliplier);
			spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
		}
		public void Update(GameTime gameTime)
		{
			if (++currFrame == totalFrames)
			{
				link.currState = new StandingFacingLeft(link);
			}
		}

		// No OPs
		public void MoveUp() { }
		public void MoveDown() { }
		public void MoveRight() { }
		public void MoveLeft() { }
		public void UseWeapon() { }
		public void UseItem(int itemNum) { }
	}
}
