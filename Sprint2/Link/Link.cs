using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint2
{
	public class Link : ILinkState, ISprite
	{
		public ILinkState currState;
		public Vector2 pos { get; set; }
		public SpriteFactory spriteFactory;
		public Sprite sprite;
		public int health, maxHealth, rupies, keys, bombs;
		public LinkItem item;
		public int sizeMuliplier = 3;
		public string direction;
		public List<IItem> itemList;
		public Link()
		{
			//item = new NullItem();
			health= 8;
			maxHealth = 10;
			rupies = keys = bombs = 0;
			pos = new Vector2(40, 40);
			
		}

		public void SetSpriteContent(SpriteFactory spriteFactory)
        {
			this.spriteFactory = spriteFactory;
			this.currState = new StandingFacingDown(this);
			sprite = spriteFactory.getLinkStandingFacingDownSprite();
			direction = "down";
			item = new LinkItem(this, spriteFactory);
		}

		public void SetPos(Vector2 pos)
        {
			this.pos = pos;
        }
		public string GetDirection()
		{
			return direction;
		}
		public void SetItem(string newItem)
		{
			item.SetItem(newItem);
		}
		public Rectangle GetSpriteRectangle()
        {
			return sprite.getDestinationRectangle();
        }

		public void StandingUp()
        {
			currState.StandingUp();
		}
		public void StandingDown()
        {
			currState.StandingDown();
		}
		public void StandingLeft()
        {
			currState.StandingLeft();
		}
		public void StandingRight()
        {
			currState.StandingRight();
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
			currState = new UsingItem(this);
			item.Use();
		}
		public void TakeDamage()
        {
			currState.TakeDamage();
		}
		public void Draw(SpriteBatch spriteBatch)
        {
			currState.Draw(spriteBatch);
			item.Draw(spriteBatch);
        }
		public void Update(GameTime gameTime)
		{
			currState.Update(gameTime);
			sprite.Update(gameTime);
			item.Update(gameTime);
		}

		public Link GetConcreteObject()
		{
			return this;
		}

		object ISprite.GetConcreteObject()
		{
			return this;
		}
	}
}

