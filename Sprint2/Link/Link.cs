﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
	public class Link : ILinkState, ISprite
	{
		public ILinkState currState;
		public Vector2 pos { get; set; }
		public SpriteFactory spriteFactory;
		public Sprite sprite;
		public int health;
		public IItem item;
		public int sizeMuliplier = 3;
		public string direction;
		public Link()
		{
			item = new NullItem();
			health = 3;
			pos = new Vector2(40, 40);
		}

		public void SetSpriteContent(SpriteFactory spriteFactory)
        {
			this.spriteFactory = spriteFactory;
			this.currState = new StandingFacingDown(this);
			sprite = spriteFactory.getLinkStandingFacingDownSprite();
			direction = "down";
		}

		public Rectangle GetSpriteRectangle()
        {
			return sprite.getDestinationRectangle();
        }

		public void StandingUp()
        {
			direction = "up";
			currState.StandingUp();
		}
		public void StandingDown()
        {
			direction = "down";
			currState.StandingDown();
		}
		public void StandingLeft()
        {
			direction = "left";
			currState.StandingLeft();
		}
		public void StandingRight()
        {
			direction = "right";
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
			sprite.Update(gameTime);
			item.Update(gameTime);
		}
	}
}

