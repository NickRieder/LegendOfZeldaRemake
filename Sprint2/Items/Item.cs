﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;

namespace Sprint2
{
	public class Item : ISprite
	{
		public Vector2 pos { get; set; }
		public SpriteFactory spriteFactory;
		private Texture2D itemSheet;
		public int spriteSizeMultiplier;
		private Sprite sprite;
		public string itemName;

		public Item(string itemName, Vector2 pos)
		{
			this.itemName = itemName;
			spriteSizeMultiplier = 2;
			this.pos = pos;

		}

		public Rectangle GetSpriteRectangle()
		{
			return new Rectangle(0, 0, 0, 0); // Change this to Item Sprite
		}
		public void SetSpriteContent(SpriteFactory spriteFactory)
		{
			this.spriteFactory = spriteFactory;

			switch (itemName)
			{
				case "sword":
					sprite = spriteFactory.getSwordSprite();
					break;
				case "boomerang":
					sprite = spriteFactory.getBoomerangPickUpSprite();
					break;
				case "bomb":
					sprite = spriteFactory.getBombSprite();
					break;
				case "key":
					sprite = spriteFactory.getKeySprite();
					break;
				default:
					break;
			}
		}

		public void Draw(SpriteBatch spriteBatch)
        {
			sprite.Draw(spriteBatch, pos);
		}

		public void Update(GameTime gameTime)
        {
			sprite.Update(gameTime);
        }

		public Item GetConcreteObject()
		{
			return this;
		}

		object ISprite.GetConcreteObject()
		{
			return this;
		}
	}
}
