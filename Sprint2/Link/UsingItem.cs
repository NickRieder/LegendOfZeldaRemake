using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
	class UsingItem : ILinkState
	{
		private Link link;
		private int currFrame;
		private int totalFrames;
		private Rectangle frame1;
		private Texture2D sheet;

		public UsingItem(Link link)
		{
			this.link = link;
			currFrame = 0;
			totalFrames = 1;
			// Need switch to get proper sprite
			frame1 = SpriteFactory.LINK_USEITEM_DOWN;
			this.sheet = link.spriteFactory.getLinkSheet();
		}

		public void TakeDamage(GameTime gameTime)
		{
			link.health--;
			link.currState = new NewDirectionalLinkSprite(link, link.direction);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)link.pos.X, (int)link.pos.Y, frame1.Width * link.sizeMuliplier, frame1.Height * link.sizeMuliplier);
			spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
		}
		public void Update(GameTime gametime)
		{
			if (++currFrame == totalFrames)
			{
				link.currState = new NewDirectionalLinkSprite(link, link.direction);
			}
		}

		// No OPs
		public void MoveUp() { }
		public void MoveDown() { }
		public void MoveRight() { }
		public void MoveLeft() { }
		public void UseWeapon() { }
		public void UseItem(int itemNum) { }
		public void TakeDamage() { }
	}
}
