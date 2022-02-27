using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Sprint2
{
	class StandingFacingDown : ILinkState
	{
		private Link link;
		private int currFrame;
		private int totalFrames;
		private Rectangle frame1;
		private Rectangle frame2;
		private Texture2D sheet;
		private int counter;
		private ArrayList itemList;
		private IItem item;

		public StandingFacingDown(Link link)
		{
			this.link = link;
			currFrame = 0;
			counter = 0;
			totalFrames = 2;
			frame1 = SpriteFactory.LINK_MOVE_DOWN_1;
			frame2 = SpriteFactory.LINK_MOVE_DOWN_2;
			this.sheet = link.spriteFactory.getLinkSheet();

			itemList = new ArrayList();
			itemList.Add(new ArrowDown(this.link, this.link.spriteFactory));
			itemList.Add(new BoomerangDown(this.link, this.link.spriteFactory));
			itemList.Add(new ExplosionDown(this.link, this.link.spriteFactory));
		}
		public void MoveUp()
		{
			link.currState = new StandingFacingUp(link);
		}
		public void MoveDown()
		{
			link.pos.Y += 2;
			if (counter % 5 == 0)
				currFrame++;
			if (currFrame == totalFrames)
				currFrame = 0;
			counter++;
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
			link.currState = new UsingWeaponDown(link);
		}
		public void UseItem(int itemNum)
		{
			link.currState = new UsingItemDown(link);
			link.item = (IItem) itemList[itemNum - 1];
		}
		public void TakeDamage()
		{
			link.health--;
			link.currState = new TakingDamageDown(link);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)link.pos.X, (int)link.pos.Y, frame1.Width*link.sizeMuliplier, frame1.Height * link.sizeMuliplier);
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
		}
	}
}
