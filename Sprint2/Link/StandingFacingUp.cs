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
		private bool isMoving;

		public StandingFacingUp(Link link)
		{
			this.link = link;
			this.sprite = link.sprite;
			this.isMoving = link.isMoving;
			link.direction = "up";
			spriteFactory = link.spriteFactory;
			soundFactory = link.soundFactory;
			sprite = spriteFactory.getLinkStandingFacingUpSprite();
			
		}
		public void StandingUp() { }
		public void StandingDown()
		{
			//if (!isMoving) 
				link.currState = new StandingFacingDown(link);
		}
		public void StandingRight()
		{
			//if (!isMoving) 
				link.currState = new StandingFacingRight(link);
		}
		public void StandingLeft()
		{
			//if (!isMoving) 
				link.currState = new StandingFacingLeft(link);
		}
		public void Move()
        {
			//if (!isMoving)
			//{
			//	isMoving = true;
				link.isMoving = isMoving;
				link.currState = new MovingLink(link);
			//}
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
