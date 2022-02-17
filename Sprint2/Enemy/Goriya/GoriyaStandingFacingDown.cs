﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Sprint2
{
	public class GoriyaStandingFacingDown : IEnemyState
	{
		private Enemies goriya;
		private int currFrame;
		private int totalFrames;
		private int counter;
		private Rectangle frame1;
		private Rectangle frame2;
		private Texture2D sheet;
		private Texture2D sheetMirrored;
		private EnemiesList enemiesList;
		private double totalSecondsPassed;
		private double waitTime;
		private TimeSpan elapsedTime;
		private double secondsPassed;
		Random randomNumberGenerator;
		private int randomNum;
		private int chosenDirectionValue;

		public GoriyaStandingFacingDown(EnemiesList enemiesList)
		{
			randomNumberGenerator = new Random();
			totalSecondsPassed = 0;
			waitTime = 0.25;

			this.enemiesList = enemiesList;
			goriya = enemiesList.goriya;
			counter = 0;
			currFrame = 0;
			totalFrames = 2;
			frame1 = EnemySpriteFactory.GORIYA_SHEET2_FRONT;
			frame2 = EnemySpriteFactory.GORIYA_SHEET2MIRROR_FRONT;
			this.sheet = goriya.spriteFactory.getEnemySheet2();
			this.sheetMirrored = goriya.spriteFactory.getEnemySheet2Mirror();
		}

		public void MoveUp()
		{
			goriya.currState = new GoriyaStandingFacingUp(enemiesList);
		}
		public void MoveDown()
		{
			goriya.pos.Y++;
			if (counter % 5 == 0)
				currFrame++;
			if (currFrame == totalFrames)
				currFrame = 0;
			counter++;
		}
		public void MoveRight()
		{
			goriya.currState = new GoriyaStandingFacingRight(enemiesList);
		}
		public void MoveLeft()
		{
			goriya.currState = new GoriyaStandingFacingLeft(enemiesList);
		}
		public void Attack()
		{

		}

		public void TakeDamage()
		{
			goriya.health--;
			//goriya.currState = new BluebatDamagedFacingDown(goriya);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)goriya.pos.X, (int)goriya.pos.Y, frame1.Width * goriya.spriteSizeMultiplier, frame1.Height * goriya.spriteSizeMultiplier);
			Rectangle destinationRectangleFrame2 = new Rectangle((int)goriya.pos.X, (int)goriya.pos.Y, frame2.Width * goriya.spriteSizeMultiplier, frame2.Height * goriya.spriteSizeMultiplier);
			if (currFrame == 0)
			{
				spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
			}
			else
			{
				spriteBatch.Draw(sheetMirrored, destinationRectangleFrame2, frame2, Color.White);
			}
		}

		//hi

		public void Update(GameTime gameTime)
		{
			elapsedTime = gameTime.ElapsedGameTime;
			secondsPassed = elapsedTime.TotalSeconds;
			totalSecondsPassed = totalSecondsPassed + secondsPassed;

			if (totalSecondsPassed > waitTime)
			{

				randomNum = randomNumberGenerator.Next(0, 100); // random number between 0-99
				chosenDirectionValue = randomNum % 4;

				if (chosenDirectionValue == 0)
					MoveDown();
				else if (chosenDirectionValue == 1)
					MoveUp();
				else if (chosenDirectionValue == 2)
					MoveLeft();
				else if (chosenDirectionValue == 3)
					MoveRight();

				totalSecondsPassed = 0;
			}
			else
			{
				MoveDown();
			}

		}


	}
}
