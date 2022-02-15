﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2.Enemy.Goriya
{
	public class GoriyaStandingFacingRight : IEnemyState
	{
		private Enemy goriya;
		private int currFrame;
		private int totalFrames;
		private int counter;
		private Rectangle frame1;
		private Rectangle frame2;
		private EnemySpriteFactory spriteFactory;
		private Texture2D sheet;


		public GoriyaStandingFacingRight(Enemy goriya)
		{
			this.goriya = goriya;
			currFrame = 0;
			totalFrames = 2;
			frame1 = EnemySpriteFactory.GORIYA_SHEET2_RIGHT;
			frame2 = EnemySpriteFactory.GORIYA_SHEET2_THROWRIGHT;
			this.sheet = this.spriteFactory.getEnemySheet2();
		}

		public void MoveUp()
		{
			goriya.currState = new GoriyaStandingFacingUp(goriya);

		}
		public void MoveDown()
		{
			goriya.currState = new GoriyaStandingFacingRight(goriya);

		}
		public void MoveRight()
		{
			goriya.pos.X++;
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
		public void MoveLeft()
		{
			goriya.currState = new GoriyaStandingFacingLeft(goriya);
		}

		public void Attack()
		{

		}
		public void TakeDamage()
		{
			goriya.health--;
			
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)goriya.pos.X, (int)goriya.pos.Y, frame1.Width, frame1.Height);
			Rectangle destinationRectangleFrame2 = new Rectangle((int)goriya.pos.X, (int)goriya.pos.Y, frame2.Width, frame2.Height);
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