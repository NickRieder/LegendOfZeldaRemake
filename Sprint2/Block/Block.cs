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
		public Vector2 pos { get; set; }
		public SpriteFactory spriteFactory;
		private Texture2D blockSheet;

		public Sprite sprite;
		public string blockType;

		public Block(string blockType, Vector2 pos)
		{
			blockArray = new ArrayList();

			arrIndex = 0;
			this.pos = pos;
			//sprite = spriteFactory.getFlatBlockSprite();
		}

		
		public void SetSpriteContent(SpriteFactory spriteFactory)
		{
			this.spriteFactory = spriteFactory;
			blockSheet = this.spriteFactory.getTileSheet();

            switch (blockType)
            {
                case "Flat Block":
                    sprite = spriteFactory.getFlatBlockSprite();
                    break;
                case "Brick Block":
                    sprite = spriteFactory.getBrickBlockSprite();
                    break;
                default:
                    sprite = spriteFactory.getFlatBlockSprite();
                    break;
            }
        }

		public Rectangle GetSpriteRectangle()
		{
			return sprite.getDestinationRectangle();
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

			sprite.Draw(spriteBatch, pos);
		}

		public void Update(GameTime gameTime)
        {
			sprite.Update(gameTime);
        }
	}
}

