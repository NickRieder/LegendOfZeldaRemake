using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;

namespace Sprint2
{
	public class Block : ISprite
	{
		private ArrayList blockArray;
		private int arrIndex;
		public Vector2 blockPos;
		public BlockSpriteFactory spriteFactory;
		private Texture2D blockSheet;

        public Block()
		{
			blockArray = new ArrayList();

			arrIndex = 0;
			blockPos.X = 100;
			blockPos.Y = 100;

			blockArray.Add(BlockSpriteFactory.TILE_DOOR);
			blockArray.Add(BlockSpriteFactory.TILE_STAIRS);
			blockArray.Add(BlockSpriteFactory.TILE_FLATBLOCK);
			blockArray.Add(BlockSpriteFactory.TILE_NONFLAT_BLOCK);
			blockArray.Add(BlockSpriteFactory.TILE_BRICK_BLOCK);

		}

		public void SetSpriteContent(LinkSpriteFactory linkSF, EnemySpriteFactory enemySF, ItemSpriteFactory itemSF, BlockSpriteFactory blockSF)
		{
			this.spriteFactory = blockSF;
			blockSheet = spriteFactory.getTileSheet();
		}

		public void NextBlock()
		{
			if (arrIndex == blockArray.Count - 1)
			{
				arrIndex = 0;
			}
			else
			{
				arrIndex++;
			}

		}

		public void PreviousBlock()
		{
			if (arrIndex == 0)
			{
				arrIndex = blockArray.Count - 1;
			}
			else
			{
				arrIndex--;
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{

			Rectangle sourceRectangle = (Rectangle)blockArray[arrIndex];

			Rectangle destinationRectangle = new Rectangle((int)blockPos.X, (int)blockPos.Y, sourceRectangle.Width * 5, sourceRectangle.Height * 5);
			spriteBatch.Draw(blockSheet, destinationRectangle, sourceRectangle, Color.White);
		}

		public void Update(GameTime gameTime)
        {
			// No Op
        }
	}
}

