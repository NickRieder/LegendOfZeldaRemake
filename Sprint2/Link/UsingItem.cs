using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
	class UsingItem : ILinkState
	{
		private Link link;
		private Sprite sprite;
		private SpriteFactory spriteFactory;
		private int totalFrames;
		private int currFrame;

		private const int frameMultiplier = 5;
		public UsingItem(Link link)
		{
			this.link = link;
			this.sprite = link.sprite;
			spriteFactory = link.spriteFactory;
			switch (link.direction)
			{
				case "down":
					sprite = spriteFactory.getLinkUsingItemDown();
					break;
				case "left":
					sprite = spriteFactory.getLinkUsingItemLeft();
					break;
				case "right":
					sprite = spriteFactory.getLinkUsingItemRight();
					break;
				default: // facing up
					sprite = spriteFactory.getLinkUsingItemUp();
					break;
			}
			link.sprite = sprite;
			totalFrames = sprite.GetTotalFrames();
			currFrame = 0;
		}

		public void TakeDamage(GameTime gameTime)
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
			if (currFrame == totalFrames * frameMultiplier)
            {
				link.currState = new NewDirectionalLinkSprite(link, link.direction);
			}
			currFrame++;
		}

		// No OPs
		public void StandingUp() { }
		public void StandingDown() { }
		public void StandingRight() { }
		public void StandingLeft() { }
		public void Move() { }
		public void UseWeapon() { }
		public void UseItem(string newItem) { }
		public void TakeDamage(int collisionSide) { }
	}
}
