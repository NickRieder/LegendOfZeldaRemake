using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Sprint2
{
    class StandingFacingUp : ILinkState
	{
		private Link link;
		private Sprite sprite;
		private SpriteFactory spriteFactory;
		private SoundFactory soundFactory;
		private ArrayList itemList;

		public StandingFacingUp(Link link)
		{
			this.link = link;
			this.sprite = link.sprite;
			link.direction = "up";
			spriteFactory = link.spriteFactory;
			soundFactory = link.soundFactory;
			sprite = spriteFactory.getLinkStandingFacingUpSprite();
			
			itemList = new ArrayList();
			itemList.Add(new ArrowUp(this.link, this.link.spriteFactory));
			itemList.Add(new BoomerangUp(this.link, this.link.spriteFactory));
			itemList.Add(new ExplosionUp(this.link, this.link.spriteFactory));
		}
		public void StandingUp() { }
		public void StandingDown()
		{
			link.currState = new StandingFacingDown(link);
		}
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
		}
	}
}
