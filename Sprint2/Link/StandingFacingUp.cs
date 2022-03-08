using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Sprint2
{
    class StandingFacingUp : ILinkState
	{
		private Link link;
		private int currFrame;
		private int totalFrames;
		private Rectangle frame1;
		private Rectangle frame2;
		private Texture2D sheet;
		private ArrayList itemList;
		private int counter;

		public StandingFacingUp(Link link)
		{
			this.link = link;
			currFrame = 0;
			counter = 0;
			totalFrames = 2;
			frame1 = SpriteFactory.LINK_MOVE_UP_1;
			frame2 = SpriteFactory.LINK_MOVE_UP_2;
			this.sheet = link.spriteFactory.getLinkSheet();

			itemList = new ArrayList();
			itemList.Add(new ArrowUp(this.link, this.link.spriteFactory));
			itemList.Add(new BoomerangUp(this.link, this.link.spriteFactory));
			itemList.Add(new ExplosionUp(this.link, this.link.spriteFactory));
		}
		public void StandingUp()
		{
			link.pos.Y -= 2;
			if (counter % 5 == 0)
				currFrame++;
			if (currFrame == totalFrames)
				currFrame = 0;
			counter++;
		}
		public void StandingDown()
		{
			link.currState = new StandingFacingDown(link);
			link.direction = "down";
		}
		public void StandingRight()
		{
			link.currState = new StandingFacingRight(link);
			link.direction = "right";
		}
		public void StandingLeft()
		{
			link.currState = new StandingFacingLeft(link);
			link.direction = "left";
		}
		public void Move()
        {

        }
		public void UseWeapon()
		{
			link.currState = new UsingWeapon(link);
		}
		public void UseItem(int itemNum)
		{
			link.currState = new UsingItem(link);
			link.item = (IItem)itemList[itemNum - 1];
		}
		public void TakeDamage()
		{
			link.health--;
			link.currState = new TakingDamage(link);
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
			link.pos.Y -= 5;
			if (++currFrame == totalFrames)
			{
				currFrame = 0;
			}
			*/
		}
	}
}
