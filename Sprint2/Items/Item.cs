using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;

namespace Sprint2
{
	public class Item : ISprite
	{
		private ArrayList itemArray;
		private int arrIndex;
		public Vector2 pos { get; set; }
		public SpriteFactory spriteFactory;
		private Texture2D itemSheet;
		private Sprite sprite;

		public Item()
		{
			itemArray = new ArrayList();

			arrIndex = 0;
			pos = new Vector2(200, 200);

			itemArray.Add(SpriteFactory.BOOMERANG);
			itemArray.Add(SpriteFactory.BOMB);
			itemArray.Add(SpriteFactory.BOW);
			itemArray.Add(SpriteFactory.RED_CANDLE);
			itemArray.Add(SpriteFactory.BLUE_CANDLE);
			itemArray.Add(SpriteFactory.WOODEN_SWORD);
			itemArray.Add(SpriteFactory.MAGIC_SWORD);
			itemArray.Add(SpriteFactory.HEART_CANISTER);
			itemArray.Add(SpriteFactory.ORANGE_RUBY);
			itemArray.Add(SpriteFactory.BLUE_RUBY);

		}

		public Rectangle GetSpriteRectangle()
		{
			return new Rectangle(0, 0, 0, 0); // Change this to Item Sprite
		}
		public void SetSpriteContent(SpriteFactory spriteFactory)
        {
			this.spriteFactory = spriteFactory;
			this.itemSheet = this.spriteFactory.getItemSheet();
		}

		public  void NextItem()
        {
			if(arrIndex == itemArray.Count - 1)
            {
				arrIndex = 0;
            }
			else
            {
				arrIndex++;
			}
			
        }

		public void PreviousItem()
        {
			if (arrIndex == 0)
			{
				arrIndex = itemArray.Count - 1;
			}
			else
			{
				arrIndex--;
			}
		}

		public void Draw(SpriteBatch spriteBatch)
        {

			Rectangle sourceRectangle = (Rectangle)itemArray[arrIndex];

			Rectangle destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, sourceRectangle.Width * 5, sourceRectangle.Height * 5);
			spriteBatch.Draw(itemSheet, destinationRectangle, sourceRectangle, Color.White);
		}

		public void Update(GameTime gameTime)
        {
			// No Op
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
