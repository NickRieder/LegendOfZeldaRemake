using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Sprint2
{
	public class BluebatUp : IEnemyState
	{
		private Enemies bluebat;
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

		public BluebatUp(Enemies bluebat)
		{
			randomNumberGenerator = new Random();
			totalSecondsPassed = 0;
			waitTime = 0.25;

			this.bluebat = bluebat;
			bluebat.sprite = bluebat.spriteFactory.getBluebatSprite();

			/*this.enemiesList = enemiesList;
			bluebat = enemiesList.bluebat;
			counter = 0;
			currFrame = 0;
			totalFrames = 2;
			frame1 = SpriteFactory.BLUEBAT_SHEET2_POS1;
			frame2 = SpriteFactory.BLUEBAT_SHEET2_POS2;
			this.sheet = bluebat.spriteFactory.getEnemySheet2();*/
		}

		public void MoveUp()
		{
			//bluebat.pos.Y--;

			Vector2 currPos = bluebat.pos;
			currPos.Y--;
			bluebat.pos = currPos;

			/*if (counter % 5 == 0)
				currFrame++;
			if (currFrame == totalFrames)
				currFrame = 0;
			counter++;*/
		}
		public void MoveDown()
		{
			bluebat.currState = new BluebatDown(bluebat);
		}
		public void MoveRight()
		{
			bluebat.currState = new BluebatRight(bluebat);
		}
		public void MoveLeft()
		{
			bluebat.currState = new BluebatLeft(bluebat);
		}
		public void Attack()
		{

		}

		public void TakeDamage()
		{
			bluebat.health--;
			//bluebat.currState = new BluebatDamagedFacingDown(bluebat);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			bluebat.sprite.Draw(spriteBatch, bluebat.pos);

			/*Rectangle destinationRectangleFrame1 = new Rectangle((int)bluebat.pos.X, (int)bluebat.pos.Y, frame1.Width * bluebat.spriteSizeMultiplier, frame1.Height * bluebat.spriteSizeMultiplier);
			Rectangle destinationRectangleFrame2 = new Rectangle((int)bluebat.pos.X, (int)bluebat.pos.Y, frame2.Width * bluebat.spriteSizeMultiplier, frame2.Height * bluebat.spriteSizeMultiplier);
			if (currFrame == 0)
			{
				spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
			}
			else
			{
				spriteBatch.Draw(sheet, destinationRectangleFrame2, frame2, Color.White);
			}*/
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
			bluebat.sprite.Update(gameTime);
		}


	}
}
