using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
	public class Link : ILinkState
	{
		public ILinkState currState;

		public Vector2 pos;

		
		public int health;
		public Link(LinkSpriteFactory linkSpriteFactory)
		{
			currState = new LinkMovingDownState(this, linkSpriteFactory);
			health = 3;
			pos.X = 40;
			pos.Y = 40;
		}
		public void StandingFacingUp()
        {
			currState.StandingFacingUp();
        }
		public void StandingFacingDown()
        {
			currState.StandingFacingDown();
		}
		public void StandingFacingLeft()
        {
			currState.StandingFacingLeft();
		}
		public void StandingFacingRight()
        {
			currState.StandingFacingRight();
		}
		public void Move()
        {
			currState.Move();
        }
		public void UseWeapon()
        {
			currState.UseWeapon();
        }
		public void UseItem()
        {
			currState.UseItem();
        }
		public void TakeDamage()
        {
			currState.TakeDamage();
		}
		public void Draw(SpriteBatch spriteBatch)
        {
			currState.Draw(spriteBatch);
        }
		public void Update()
		{
			currState.Update();
		}
	}
}

