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
		public Vector2 itemPos;
		public ItemSpriteFactory spriteFactory;
		private Texture2D itemSheet;

		public Item()
		{
			itemArray = new ArrayList();

			arrIndex = 0;
			itemPos.X = 200;
			itemPos.Y = 200;

			itemArray.Add(ItemSpriteFactory.BOOMERANG);
			itemArray.Add(ItemSpriteFactory.BOMB);
			itemArray.Add(ItemSpriteFactory.BOW);
			itemArray.Add(ItemSpriteFactory.RED_CANDLE);
			itemArray.Add(ItemSpriteFactory.BLUE_CANDLE);
			itemArray.Add(ItemSpriteFactory.WOODEN_SWORD);
			itemArray.Add(ItemSpriteFactory.MAGIC_SWORD);
			itemArray.Add(ItemSpriteFactory.HEART_CANISTER);
			itemArray.Add(ItemSpriteFactory.ORANGE_RUBY);
			itemArray.Add(ItemSpriteFactory.BLUE_RUBY);

		}

		public void SetSpriteContent(LinkSpriteFactory linkSF, EnemySpriteFactory enemySF, ItemSpriteFactory itemSF, BlockSpriteFactory blockSF)
        {
			this.spriteFactory = itemSF;
			this.itemSheet = spriteFactory.getItemSheet();
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

			Rectangle destinationRectangle = new Rectangle((int)itemPos.X, (int)itemPos.Y, sourceRectangle.Width * 5, sourceRectangle.Height * 5);
			spriteBatch.Draw(itemSheet, destinationRectangle, sourceRectangle, Color.White);
		}

		public void Update(GameTime gameTime)
        {
			// No Op
        }
	}
}
