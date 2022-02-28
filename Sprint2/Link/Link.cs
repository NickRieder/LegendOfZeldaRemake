using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
	public class Link : ISprite
	{
		public ILinkState currState;
		public Vector2 pos;
		public LinkSpriteFactory spriteFactory;
		public int health;
		public IItem item;
		public int sizeMuliplier = 3;
		public Link()
		{
			
			
			item = new NullItem();
			health = 3;
			pos.X = 40;
			pos.Y = 40;
		}

		public void SetSpriteContent(LinkSpriteFactory linkSF, EnemySpriteFactory enemySF, ItemSpriteFactory itemSF, BlockSpriteFactory blockSF)
        {
			this.spriteFactory = linkSF;
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
		public void Update(GameTime gametime)
		{
			currState.Update(gametime);
			item.Update();
		}
	}
}

