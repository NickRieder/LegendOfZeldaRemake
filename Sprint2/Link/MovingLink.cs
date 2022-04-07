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
		private SoundFactory soundFactory;
		private ArrayList itemList;
		private IItem item;
		private bool isMoving;

		public MovingLink(Link link)
		{
			this.link = link;
			this.sprite = link.sprite;
			spriteFactory = link.spriteFactory;
			soundFactory = link.soundFactory;
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
		}
		public void StandingUp()
		{
			if (link.direction != "up")
			{
				link.direction = "up";
				link.currState = new StandingFacingUp(link);
			}
		}
		public void StandingDown()
		{
			if (link.direction != "down")
			{
				link.direction = "down";
				link.currState = new StandingFacingDown(link);
			}
		}
		public void StandingRight()
		{
			if (link.direction != "right")
			{
				link.direction = "right";
				link.currState = new StandingFacingRight(link);
			}
		}
		public void StandingLeft()
		{
			if (link.direction != "left")
            {
				link.direction = "left";
				link.currState = new StandingFacingLeft(link);
			}
			
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
			link.sprite.Update(gameTime);
		}
	}
}
