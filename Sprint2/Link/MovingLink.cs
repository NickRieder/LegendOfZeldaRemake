using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Sprint2
{
	class MovingLink : ILinkState
	{
		private Link link;
		private Sprite sprite;
		private SpriteFactory spriteFactory;
		private ArrayList itemList;
		private IItem item;

		public MovingLink(Link link)
		{
			this.link = link;
			this.sprite = link.sprite;
			spriteFactory = link.spriteFactory;
			switch (link.direction)
			{
				case "down":
					sprite = spriteFactory.getLinkMovingDownSprite();
					break;
				case "left":
					sprite = spriteFactory.getLinkMovingLeftSprite();
					break;
				case "right":
					sprite = spriteFactory.getLinkMovingRightSprite();
					break;
				default: // facing up
					sprite = spriteFactory.getLinkMovingUpSprite();
					break;
			}
			link.sprite = sprite;
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
			Vector2 currPos = link.pos;
			
			switch (link.direction)
			{
				case "down":
					currPos.Y += 2;
					link.pos = currPos;
					break;
				case "left":
					currPos.X -= 2;
					link.pos = currPos;
					break;
				case "right":
					currPos.X += 2;
					link.pos = currPos;
					break;
				default: // facing up
					currPos.Y -= 2;
					link.pos = currPos;
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
			sprite.Draw(spriteBatch, link.pos);
		}
		public void Update(GameTime gameTime)
		{
			sprite.Update(gameTime);
			link.sprite.Update(gameTime);
		}
	}
}
