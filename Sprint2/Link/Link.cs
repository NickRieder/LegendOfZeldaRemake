using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
	public class Link 
	{
		public ILinkState currState;
		public Vector2 pos;
		public SpriteFactory spriteFactory;
		public int health;
		public IItem item;
		public int sizeMuliplier = 3;
		public Vector2 direction;
		public Link()
		{	
			item = new NullItem();
			health = 3;
			pos.X = 40;
			pos.Y = 40;
		}

		public void SetSpriteContent(SpriteFactory spriteFactory)
        {
			this.spriteFactory = spriteFactory;
			this.currState = new StandingFacingDown(this);
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
		public void Update(GameTime gameTime)
		{
			currState.Update(gameTime);
			item.Update(gameTime);
		}
	}
}

