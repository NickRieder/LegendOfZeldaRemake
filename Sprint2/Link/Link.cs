using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
	public class Link : ILinkState
	{
		public ILinkState currState;
		public Vector2 pos;
		public LinkSpriteFactory spriteFactory;
		public int health;
		public IItem item;
		public int sizeMuliplier = 3;
		public Link(LinkSpriteFactory linkSpriteFactory)
		{
			spriteFactory = linkSpriteFactory;
			currState = new StandingFacingDown(this);
			item = new NullItem();
			health = 3;
			pos.X = 40;
			pos.Y = 40;
		}
		public void MoveUp()
        {
			currState.MoveUp();
        }
		public void MoveDown()
        {
			currState.MoveDown();
		}
		public void MoveLeft()
        {
			currState.MoveLeft();
		}
		public void MoveRight()
        {
			currState.MoveRight();
		}
		public void UseWeapon()
        {
			currState.UseWeapon();
        }
		public void UseItem(int itemNum)
        {
			currState.UseItem(itemNum);
        }
		public void TakeDamage()
        {
			currState.TakeDamage();
		}
		public void Draw(SpriteBatch spriteBatch)
        {
			currState.Draw(spriteBatch);
			item.Draw(spriteBatch, new Vector2(pos.X, pos.Y));
        }
		public void Update(GameTime gametime)
		{
			currState.Update(gametime);
			item.Update();
		}
	}
}

