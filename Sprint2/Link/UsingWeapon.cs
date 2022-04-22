using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace Sprint2
{
	class UsingWeapon : ILinkState
	{
		private Link link;
		private Sprite sprite;
		private SpriteFactory spriteFactory;
		private static TimeSpan attackTime;
		private TimeSpan startTimeAttack;
		bool isAttacking;
		private string direction;

		public UsingWeapon(Link link)
		{
			this.link = link;
			this.direction = link.direction;
			this.sprite = link.sprite;
			spriteFactory = link.spriteFactory;
			switch (direction)
			{
				case "down":
					sprite = spriteFactory.getLinkUsingWeaponDown();
					break;
				case "left":
					sprite = spriteFactory.getLinkUsingWeaponLeft();
					break;
				case "right":
					sprite = spriteFactory.getLinkUsingWeaponRight();
					break;
				default: // facing up
					sprite = spriteFactory.getLinkUsingWeaponUp();
					break;
			}
			link.sprite = sprite;
			attackTime = TimeSpan.FromMilliseconds(500);
			isAttacking = true;
			link.isUsingWeapon = true;
		}

		public void TakeDamage(int collisionSide)
		{
			link.health--;
			link.currState = new NewDirectionalLinkSprite(link, link.direction);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			link.sprite.Draw(spriteBatch, link.pos);
		}
		public void Update(GameTime gameTime)
		{
			link.sprite.Update(gameTime);
			if (isAttacking)
			{
				startTimeAttack = gameTime.TotalGameTime;
				isAttacking = false;
			}
			if (startTimeAttack + attackTime < gameTime.TotalGameTime)
			{
				link.isUsingWeapon = false;
				link.canDealDamage = true;
				link.currState = new NewDirectionalLinkSprite(link, link.direction);
			}
		}

		// No OPs
		public void StandingUp() { }
		public void StandingDown() { }
		public void StandingRight() { }
		public void StandingLeft() { }
		public void Move(string direction) { }
		public void UseWeapon() { }
		public void UseItem(string newItem) { }
	}
}
