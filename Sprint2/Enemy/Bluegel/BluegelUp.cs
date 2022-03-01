using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Sprint2
{
	public class BluegelUp : IEnemyState
	{
		private Enemies bluegel;
		private int currFrame;
		private int totalFrames;
		private int counter;
		private Rectangle frame1;
		private Rectangle frame2;
		private Texture2D sheet;
		private EnemiesList enemiesList;
		private double totalSecondsPassed;
		private double waitTime;
		public TimeSpan elapsedTime;
		private double secondsPassed;
		Random randomNumberGenerator;
		private int randomNum;
		private int chosenDirectionValue;

		public BluegelUp(EnemiesList enemiesList)
		{
			randomNumberGenerator = new Random();
			totalSecondsPassed = 0;
			waitTime = 0.25;

			this.enemiesList = enemiesList;
			bluegel = enemiesList.bluegel;
			counter = 0;
			currFrame = 0;
			totalFrames = 2;
			frame1 = SpriteFactory.BLUEGEL_SHEET2_POS1;
			frame2 = SpriteFactory.BLUEGEL_SHEET2_POS2;
			this.sheet = bluegel.spriteFactory.getEnemySheet2();
		}

		public void MoveUp()
		{
			bluegel.pos.Y--;
			if (counter % 5 == 0)
				currFrame++;
			if (currFrame == totalFrames)
				currFrame = 0;
			counter++;
		}
		public void MoveDown()
		{
			bluegel.currState = new BluegelDown(enemiesList);
		}
		public void MoveRight()
		{
			bluegel.currState = new BluegelRight(enemiesList);
		}
		public void MoveLeft()
		{
			bluegel.currState = new BluegelLeft(enemiesList);
		}
		public void Attack()
		{

		}

		public void TakeDamage()
		{
			bluegel.health--;
			//bluegel.currState = new BluegelDamagedFacingDown(bluegel);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)bluegel.pos.X, (int)bluegel.pos.Y, frame1.Width * bluegel.spriteSizeMultiplier, frame1.Height * bluegel.spriteSizeMultiplier);
			Rectangle destinationRectangleFrame2 = new Rectangle((int)bluegel.pos.X, (int)bluegel.pos.Y, frame2.Width * bluegel.spriteSizeMultiplier, frame2.Height * bluegel.spriteSizeMultiplier);
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
				MoveUp();
			}

		}


	}
}
