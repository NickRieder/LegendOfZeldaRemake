﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Sprint2
{
	public class DarknutStandingFacingLeft : IEnemyState
	{
		private Enemies darknut;
		private int currFrame;
		private int totalFrames;
		private int counter;
		private Rectangle frame1;
		private Rectangle frame2;
		private Texture2D sheet;
		private EnemiesList enemiesList;
		private double totalSecondsPassed;
		private double waitTime;
		private TimeSpan elapsedTime;
		private double secondsPassed;
		Random randomNumberGenerator;
		private int randomNum;
		private int chosenDirectionValue;

		public DarknutStandingFacingLeft(EnemiesList enemiesList)
		{
			randomNumberGenerator = new Random();
			totalSecondsPassed = 0;
			waitTime = 0.25;

			this.enemiesList = enemiesList;
			darknut = enemiesList.darknut;
			counter = 0;
			currFrame = 0;
			totalFrames = 2;
			frame1 = SpriteFactory.DARKNUT_SHEET2MIRROR_LEFT1;
			frame2 = SpriteFactory.DARKNUT_SHEET2MIRROR_LEFT2;
			this.sheet = darknut.spriteFactory.getEnemySheet2Mirror();
		}

		public void MoveUp()
		{
			darknut.currState = new DarknutStandingFacingUp(enemiesList);
		}
		public void MoveDown()
		{
			darknut.currState = new DarknutStandingFacingDown(enemiesList);
		}
		public void MoveRight()
		{
			darknut.currState = new DarknutStandingFacingRight(enemiesList);
		}
		public void MoveLeft()
		{
			darknut.pos.X--;
			if (counter % 5 == 0)
				currFrame++;
			if (currFrame == totalFrames)
				currFrame = 0;
			counter++;
		}
		public void Attack()
		{

		}

		public void TakeDamage()
		{
			darknut.health--;
			//darknut.currState = new BluegelDamagedFacingDown(darknut);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)darknut.pos.X, (int)darknut.pos.Y, frame1.Width * darknut.spriteSizeMultiplier, frame1.Height * darknut.spriteSizeMultiplier);
			Rectangle destinationRectangleFrame2 = new Rectangle((int)darknut.pos.X, (int)darknut.pos.Y, frame2.Width * darknut.spriteSizeMultiplier, frame2.Height * darknut.spriteSizeMultiplier);
			if (currFrame == 0)
			{
				spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
			}
			else
			{
				spriteBatch.Draw(sheet, destinationRectangleFrame2, frame2, Color.White);
			}
		}

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
				MoveLeft();
			}

		}


	}
}
