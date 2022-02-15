using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    class TakingDamageUp : ILinkState
    {
		private Link link;
		private int currFrame;
		private int totalFrames;
		private Rectangle frame1;
		private Rectangle frame2;
		private LinkSpriteFactory spriteFactory;
		private Texture2D sheet;

		public TakingDamageUp(Link link)
        {
			this.link = link;
			this.spriteFactory = spriteFactory; // needs to be changed. based off class where spriteFactory was passed as param
			currFrame = 0;
			totalFrames = 2;
			//frame1 =						NEED DAMAGED LINK SPRITES
			this.sheet = this.spriteFactory.getLinkSheet();
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
		public void Update(GameTime gameTime)
		{
			if (++currFrame == totalFrames)
			{
				link.currState = new StandingFacingUp(link);
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
