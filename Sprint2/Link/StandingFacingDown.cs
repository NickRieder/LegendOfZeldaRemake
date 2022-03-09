using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Sprint2
{
	class StandingFacingDown : ILinkState
	{
		private Link link;
		private Sprite sprite;
		private SpriteFactory spriteFactory;
		private ArrayList itemList;
		private IItem item;
		

		public StandingFacingDown(Link link)
		{
			this.link = link;
			this.sprite = link.sprite;
			link.direction = "down";
			spriteFactory = link.spriteFactory;
			sprite = spriteFactory.getLinkStandingFacingDownSprite();
			
			itemList = new ArrayList();
			itemList.Add(new ArrowDown(this.link, this.link.spriteFactory));
			itemList.Add(new BoomerangDown(this.link, this.link.spriteFactory));
			itemList.Add(new ExplosionDown(this.link, this.link.spriteFactory));
		}
		public void StandingUp()
		{
			link.currState = new StandingFacingUp(link);
		}
		public void StandingDown() { }
		public void StandingRight()
		{
			link.currState = new StandingFacingRight(link);
		}
		public void StandingLeft()
		{
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
			link.item = (IItem) itemList[itemNum - 1];
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
		}
	}
}
