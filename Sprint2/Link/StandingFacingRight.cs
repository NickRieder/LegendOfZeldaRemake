using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Sprint2
{
    class StandingFacingRight : ILinkState
	{
		private Link link;
		private int currFrame;
		private int totalFrames;
		private Rectangle frame1;
		private Rectangle frame2;
		private Texture2D sheet;
		private ArrayList itemList;
		private int counter;

		public StandingFacingRight(Link link)
		{
			this.link = link;
			currFrame = 0;
			counter = 0;
			totalFrames = 2;
			frame1 = LinkSpriteFactory.LINK_MOVE_RIGHT_1;
			frame2 = LinkSpriteFactory.LINK_MOVE_RIGHT_2;
			this.sheet = link.spriteFactory.getLinkSheet();

			itemList = new ArrayList();
			itemList.Add(new ArrowRight(this.link, this.link.spriteFactory));
			itemList.Add(new BoomerangRight(this.link, this.link.spriteFactory));
			itemList.Add(new ExplosionRight(this.link, this.link.spriteFactory));
		}
		public void MoveUp()
		{
			link.currState = new StandingFacingUp(link);
		}
		public void MoveDown()
		{
			link.currState = new StandingFacingDown(link);
		}
		public void MoveRight()
		{
			link.pos.X += 2;
			if (counter % 5 == 0)
				currFrame++;
			if (currFrame == totalFrames)
				currFrame = 0;
			counter++;
		}
		public void MoveLeft()
		{
			link.currState = new StandingFacingLeft(link);
		}
		public void UseWeapon()
		{
			link.currState = new UsingWeaponRight(link);
		}
		public void UseItem(int itemNum)
		{
			link.currState = new UsingItemRight(link);
			link.item = (IItem)itemList[itemNum - 1];
		}
		public void TakeDamage()
		{
			link.health--;
			link.currState = new TakingDamageDown(link);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)link.pos.X, (int)link.pos.Y, frame1.Width * link.sizeMuliplier, frame1.Height * link.sizeMuliplier);
			Rectangle destinationRectangleFrame2 = new Rectangle((int)link.pos.X, (int)link.pos.Y, frame2.Width * link.sizeMuliplier, frame2.Height * link.sizeMuliplier);
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
			/*
			link.pos.X += 5;
			if (++currFrame == totalFrames)
            {
				currFrame = 0;
            }
			*/
		}
	}
}
