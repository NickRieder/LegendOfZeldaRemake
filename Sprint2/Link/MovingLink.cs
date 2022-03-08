using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Sprint2
{
	class MovingLink : ILinkState
	{
		private Link link;
		private Sprite linkSprite;
		private SpriteFactory spriteFactory;
		private ArrayList itemList;
		private IItem item;
		private int counter;

		public MovingLink(Link link)
		{
			this.link = link;
			spriteFactory = link.spriteFactory;
			linkSprite = spriteFactory.getLinkMovingDownSprite();
			counter = 0;
			itemList = new ArrayList();
			itemList.Add(new ArrowDown(this.link, this.link.spriteFactory));
			itemList.Add(new BoomerangDown(this.link, this.link.spriteFactory));
			itemList.Add(new ExplosionDown(this.link, this.link.spriteFactory));
		}
		public void StandingUp()
		{
			link.currState = new StandingFacingUp(link);
			link.direction = "up";
		}
		public void StandingDown()
		{
			link.currState = new StandingFacingDown(link);
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
			switch (link.direction)
			{
				case "down":
					link.pos.Y += 2;
					break;
				case "left":
					link.pos.X += 2;
					break;
				case "right":
					link.pos.X -= 2;
					break;
				default: // facing up
					link.pos.Y -= 2;
					break;
			}
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
			linkSprite.Draw(spriteBatch, link.pos);
		}
		public void Update(GameTime gameTime)
		{
			linkSprite.Update(gameTime);
		}
	}
}
