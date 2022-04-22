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
		private string direction;
		private bool isMoving;
		private const int movementSpeed = 4;

		public MovingLink(Link link, string direction)
		{
			this.link = link;
			this.direction = direction;
			spriteFactory = link.spriteFactory;
			soundFactory = link.soundFactory;
			switch (direction)
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
			link.currState = new StandingFacingUp(link);
		}
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
		public void Move(string direction)
        {
			Vector2 currPos = link.pos;

			switch (direction)
			{
				case "down":
					currPos.Y += movementSpeed;
					link.pos = currPos;
					break;
				case "left":
					currPos.X -= movementSpeed;
					link.pos = currPos;
					break;
				case "right":
					currPos.X += movementSpeed;
					link.pos = currPos;
					break;
				default: // facing up
					currPos.Y -= movementSpeed;
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
		public void TakeDamage(int collisionSide)
		{
			link.health--;
			link.currState = new TakingDamage(link, collisionSide);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			link.sprite.Draw(spriteBatch, link.pos);
		}
		public void Update(GameTime gameTime)
		{
			//sprite.Update(gameTime);
			link.sprite.Update(gameTime);
		}
	}
}
