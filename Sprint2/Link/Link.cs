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
		public IItem item;
		public int sizeMuliplier = 3;
		public string direction;
		public List<IItem> itemList;
		public Link()
		{
			item = new NullItem();
			health= 8;
			maxHealth = 10;
			rupies = keys = bombs = 0;
			pos = new Vector2(40, 40);
			itemList = new List<IItem>();
			
		}

		/*public object GetConcreteObject()
        {
			return this; // now its Link that I can get instead of ISprite. watch
        }*/

		public void SetSpriteContent(SpriteFactory spriteFactory)
        {
			this.spriteFactory = spriteFactory;
			this.currState = new StandingFacingDown(this);
			sprite = spriteFactory.getLinkStandingFacingDownSprite();
			direction = "down";

			itemList.Add(new Arrow(this, spriteFactory));
			itemList.Add(new Boomerang(this, spriteFactory));
			itemList.Add(new Explosion(this, spriteFactory));
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
			switch(newItem)
            {
				case "Arrow":
					item = new Arrow(this, spriteFactory);
					break;
				case "Boomerang":
					item = new Boomerang(this, spriteFactory);
					break;
				case "Explosion":
					item = new Explosion(this, spriteFactory);
					break;
				default:
					break;
            }
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
		public void UseItem(string newItem)
        {
			currState.UseItem(newItem);
        }
		public void TakeDamage()
        {
			currState.TakeDamage();
		}
		public void Draw(SpriteBatch spriteBatch)
        {
			currState.Draw(spriteBatch);
			item.Draw(spriteBatch, pos);
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

