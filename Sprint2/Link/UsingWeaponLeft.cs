using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    class UsingWeaponLeft : ILinkState
	{
		private Link link;
		private int currFrame;
		private int totalFrames;
		private Rectangle frame1;
		private LinkSpriteFactory spriteFactory;
		private Texture2D sheet;

		public UsingWeaponLeft(Link link)
		{
			this.link = link;
			this.spriteFactory = spriteFactory; // needs to be changed. based off class where spriteFactory was passed as param
			currFrame = 0;
			totalFrames = 1;
			frame1 = LinkSpriteFactory.LINK_USESWORD_MIRROR_LEFT;
			this.sheet = this.spriteFactory.getLinkSheetMirrored();
		}

		public void TakeDamage()
		{
			link.health--;
			link.currState = new TakingDamageLeft(link);
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
		public void MoveUp() { }
		public void MoveDown() { }
		public void MoveRight() { }
		public void MoveLeft() { }
		public void UseWeapon() { }
		public void UseItem() { }
	}
}
