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
		public SpriteFactory spriteFactory;
		private Texture2D blockSheet;
		private Sprite blockSprite;

        public Block(Sprite blockType, Vector2 pos)
		{
			blockArray = new ArrayList();

			arrIndex = 0;
			blockPos = pos;
			blockSprite = blockType;
		}

		public void SetSpriteContent(SpriteFactory spriteFactory)
		{
			this.spriteFactory = spriteFactory;
			blockSheet = this.spriteFactory.getTileSheet();
		}

		/*
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
		*/

		public void Draw(SpriteBatch spriteBatch)
		{

			blockSprite.Draw(spriteBatch, blockPos);
		}

		public void Update(GameTime gameTime)
        {
			blockSprite.Update(gameTime);
        }
	}
}

