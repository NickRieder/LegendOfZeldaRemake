﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{

	class NewDirectionalLinkSprite : ILinkState
	{
		private Link link;
		private string direction;
		public NewDirectionalLinkSprite(Link link, String direction)
		{
			this.link = link;
			this.direction = direction;
		}
		public void StandingUp() { }
		public void StandingDown() { }
		public void StandingRight() { }
		public void StandingLeft() { }
		public void Move() { }
		public void UseWeapon() { }
		public void UseItem(int itemNum) { }
		public void TakeDamage() { }
		public void Draw(SpriteBatch spriteBatch) { }
		public void Update(GameTime gameTime) 
		{
			switch (direction)
			{
				case "down":
					link.currState = new StandingFacingDown(link);
					break;
				case "left":
					link.currState = new StandingFacingLeft(link);
					break;
				case "right":
					link.currState = new StandingFacingRight(link);
					break;
				default: // facing up
					link.currState = new StandingFacingUp(link);
					break;
			}
		}

	}
}

