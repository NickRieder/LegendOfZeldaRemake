using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Sprint2
{
	class MovingLink : ILinkState
	{
		private Link link;
		private SpriteFactory spriteFactory;
		private ArrayList itemList;
		private IItem item;

		public MovingLink(Link link)
		{
			this.link = link;
			spriteFactory = link.spriteFactory;
			switch (link.direction)
			{
				case "down":
					link.sprite = spriteFactory.getLinkMovingDownSprite();
					break;
				case "left":
					link.sprite = spriteFactory.getLinkMovingLeftSprite();
					break;
				case "right":
					link.sprite = spriteFactory.getLinkMovingRightSprite();
					break;
				default: // facing up
					link.sprite = spriteFactory.getLinkMovingUpSprite();
					break;
			}
			itemList = new ArrayList();
			itemList.Add(new ArrowDown(this.link, this.link.spriteFactory));
			itemList.Add(new BoomerangDown(this.link, this.link.spriteFactory));
			itemList.Add(new ExplosionDown(this.link, this.link.spriteFactory));
		}
		public void StandingUp()
		{
			link.direction = "up";
			link.currState = new StandingFacingUp(link);
		}
		public void StandingDown()
		{
			link.direction = "down";
			link.currState = new StandingFacingDown(link);
		}
		public void StandingRight()
		{
			link.direction = "right";
			link.currState = new StandingFacingRight(link);
		}
		public void StandingLeft()
		{
			link.direction = "left";
			link.currState = new StandingFacingLeft(link);
		}
		public void Move()
        {
			switch (link.direction)
			{
				case "down":
					link.pos.Y += 2;
					break;
				case "left":
					link.pos.X -= 2;
					break;
				case "right":
					link.pos.X += 2;
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
			link.sprite.Draw(spriteBatch, link.pos);
		}
		public void Update(GameTime gameTime)
		{
			link.sprite.Update(gameTime);
		}
	}
}
