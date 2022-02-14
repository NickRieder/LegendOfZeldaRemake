﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
	public class WizzrobeLeft : IEnemyState
	{
		private Enemies wizzrobe;
		private int currFrame;
		private int totalFrames;
		private int counter;
		private Rectangle frame1;
		private Rectangle frame2;
		private EnemySpriteFactory spriteFactory;
		private Texture2D sheet;


		public WizzrobeLeft(Enemies wizzrobe)
		{
			this.wizzrobe = wizzrobe;
			currFrame = 0;
			totalFrames = 2;
			frame1 = EnemySpriteFactory.WIZZROBE_SHEET2MIRROR_LEFT1;
			frame2 = EnemySpriteFactory.WIZZROBE_SHEET2MIRROR_LEFT2;
			this.sheet = this.spriteFactory.getEnemySheet2Mirror();
		}

		public void MoveUp()
		{
			wizzrobe.currState = new WizzrobeUp(wizzrobe);

		}
		public void MoveDown()  
		{
			wizzrobe.currState = new WizzrobeDown(wizzrobe);
		}
		public void MoveRight()
		{
			wizzrobe.currState = new WizzrobeRight(wizzrobe);
		}
		public void MoveLeft()
		{
			wizzrobe.pos.X--;
			if (counter % 5 == 0)
				currFrame++;
			if (currFrame == totalFrames)
				currFrame = 0;
			counter++;

			if (currFrame == totalFrames)
			{
				currFrame = 0;
			}

		}
		public void Attack()
		{

		}

		public void TakeDamage()
		{
			wizzrobe.health--;

		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)wizzrobe.pos.X, (int)wizzrobe.pos.Y, frame1.Width, frame1.Height);
			Rectangle destinationRectangleFrame2 = new Rectangle((int)wizzrobe.pos.X, (int)wizzrobe.pos.Y, frame2.Width, frame2.Height);
			if (currFrame == 0)
			{
				spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
			}
			else
			{
				spriteBatch.Draw(sheet, destinationRectangleFrame2, frame2, Color.White);
			}
		}

		public void Update()
		{

		}


	}
}
