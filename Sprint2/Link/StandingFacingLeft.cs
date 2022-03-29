using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Sprint2
{
    class StandingFacingLeft : ILinkState
	{
		private Link link;
		private Sprite sprite;
		private SpriteFactory spriteFactory;
		private ArrayList itemList;
		private int counter;

		public StandingFacingLeft(Link link)
		{
			this.link = link;
			this.sprite = link.sprite;
			link.direction = "left";
			spriteFactory = link.spriteFactory;
			sprite = spriteFactory.getLinkStandingFacingLeftSprite();
			
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
			link.currState = new StandingFacingRight(link);
			link.direction = "right";
		}
		public void StandingLeft() { }
		public void Move()
        {
			link.currState = new MovingLink(link);
		}
		public void UseWeapon()
		{
			link.currState = new UsingWeapon(link);
		}
		public void UseItem(string newItem)
		{
			link.currState = new UsingItem(link);
			link.SetItem(newItem);
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
