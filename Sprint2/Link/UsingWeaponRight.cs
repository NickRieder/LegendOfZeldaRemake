using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    class UsingWeaponRight : ILinkState
	{
		private Link link;
		private int currFrame;
		private int totalFrames;
		private Rectangle frame1;
		private Texture2D sheet;

		public UsingWeaponRight(Link link)
		{
			this.link = link;
			currFrame = 0;
			totalFrames = 1;
			frame1 = LinkSpriteFactory.LINK_USESWORD_RIGHT;
			this.sheet = link.spriteFactory.getLinkSheet();
		}

		public void TakeDamage()
		{
			link.health--;
			link.currState = new TakingDamageRight(link);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)link.pos.X, (int)link.pos.Y, frame1.Width, frame1.Height);
			spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
		}
		public void Update()
		{
			if (++currFrame == totalFrames)
			{
				link.currState = new StandingFacingRight(link);
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
