using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
	public class LinkMovingDownState : ILinkState
	{
		private Link link;
		private int currFrame;
		private int totalFrames;
		private Rectangle frame1;
		private Rectangle frame2;
		private LinkSpriteFactory spriteFactory;
		private Texture2D sheet;
		

		public LinkMovingDownState(Link link, LinkSpriteFactory spriteFactory)
		{
			this.link = link;
			this.spriteFactory = spriteFactory;
			currFrame = 0;
			totalFrames = 2;
			frame1 = LinkSpriteFactory.LINK_MOVE_DOWN_1;
			frame2 = LinkSpriteFactory.LINK_MOVE_DOWN_2;
			this.sheet = this.spriteFactory.getLinkSheet();
	}

		public void StandingFacingUp()
        {

        }
		public void StandingFacingDown()
        {

        }
		public void StandingFacingRight()
        {

        }
		public void StandingFacingLeft()
        {

        }
		public void Move()
        {

        }
		public void UseWeapon()
		{
			//link.currState = new LinkUsingWeaponDown(link);
		}
		public void UseItem()
		{
			//link.currState = new LinkUsingItemDown(link);
		}
		public void TakeDamage()
		{
			link.health--;
			//link.currState = new LinkDamagedFacingDown(link);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)link.pos.X, (int)link.pos.Y, frame1.Width, frame1.Height);
			Rectangle destinationRectangleFrame2 = new Rectangle((int)link.pos.X, (int)link.pos.Y, frame2.Width, frame2.Height);
			if (currFrame == 0)
            {
				spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
			} else
            {
				spriteBatch.Draw(sheet, destinationRectangleFrame2, frame2, Color.White);
			}
				
			
		}
		public void Update()
		{
			link.pos.Y++;
			currFrame++;
			if (currFrame == totalFrames)
            {
				currFrame = 0;
            }
		}
	}

}
