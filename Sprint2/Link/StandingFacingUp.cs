using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    class StandingFacingUp : ILinkState
	{
		private Link link;
		private int currFrame;
		private int totalFrames;
		private Rectangle frame1;
		private Rectangle frame2;
		private LinkSpriteFactory spriteFactory;
		private Texture2D sheet;

		public StandingFacingUp(Link link)
		{
			this.link = link;
			this.spriteFactory = spriteFactory; // needs to be changed. based off class where spriteFactory was passed as param
			currFrame = 0;
			totalFrames = 2;
			frame1 = LinkSpriteFactory.LINK_MOVE_UP_1;
			frame2 = LinkSpriteFactory.LINK_MOVE_UP_2;
			this.sheet = this.spriteFactory.getLinkSheet();
		}
		public void MoveUp()
		{
			// No OP
		}
		public void MoveDown()
		{
			//link.currState = new StandingFacingDown(link);
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
			link.currState = new UsingWeaponRight(link);
		}
		public void UseItem()
		{
			link.currState = new UsingItemRight(link);
		}
		public void TakeDamage()
		{
			link.health--;
			link.currState = new TakingDamageRight(link);
		}
		public void Draw(SpriteBatch spriteBatch)
		{

		}
		public void Update()
		{
			link.pos.Y -= 5;
			if (++currFrame == totalFrames)
			{
				currFrame = 0;
			}
		}
	}
}
