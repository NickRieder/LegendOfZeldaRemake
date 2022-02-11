using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    class TakingDamageLeft : ILinkState
	{
		private Link link;
		private int currFrame;
		private int totalFrames;
		private Rectangle frame1;
		private Rectangle frame2;
		private LinkSpriteFactory spriteFactory;
		private Texture2D sheet;

		public TakingDamageLeft(Link link)
		{
			this.link = link;
			this.spriteFactory = spriteFactory; // needs to be changed. based off class where spriteFactory was passed as param
			currFrame = 0;
			totalFrames = 2;
			//frame1 =						NEED DAMAGED LINK SPRITES
			this.sheet = this.spriteFactory.getLinkSheetMirrored();
		}


		public void Draw(SpriteBatch spriteBatch)
		{

		}
		public void Update()
		{
			if (++currFrame == totalFrames)
			{
				link.currState = new StandingFacingLeft(link);
			}
		}

		// No OPs
		public void TakeDamage() { }
		public void MoveUp() { }
		public void MoveDown() { }
		public void MoveRight() { }
		public void MoveLeft() { }
		public void UseWeapon() { }
		public void UseItem() { }
	}
}
