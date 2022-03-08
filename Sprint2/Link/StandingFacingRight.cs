using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Sprint2
{
    class StandingFacingRight : ILinkState
	{
		private Link link;
		private SpriteFactory spriteFactory;
		private ArrayList itemList;

		public StandingFacingRight(Link link)
		{
			this.link = link;
			spriteFactory = link.spriteFactory;
			link.sprite = spriteFactory.getLinkStandingFacingRightSprite();
			link.direction = "right";
			itemList = new ArrayList();
			itemList.Add(new ArrowRight(this.link, this.link.spriteFactory));
			itemList.Add(new BoomerangRight(this.link, this.link.spriteFactory));
			itemList.Add(new ExplosionRight(this.link, this.link.spriteFactory));
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
		public void StandingRight() { }
		public void StandingLeft()
		{
			link.direction = "left";
			link.currState = new StandingFacingLeft(link);
		}
		public void Move()
        {
			link.currState = new MovingLink(link);
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
