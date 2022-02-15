﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2.Enemy.Snake
{
	public class SnakeUp : IEnemyState
	{
		private Enemy snake;
		private int currFrame;
		private int totalFrames;
		private int counter;
		private Rectangle frame1;
		private Rectangle frame2;
		private EnemySpriteFactory spriteFactory;
		private Texture2D sheet;


		public SnakeUp(Enemy snake)
		{
			this.snake = snake;
			currFrame = 0;
			totalFrames = 2;
			frame1 = EnemySpriteFactory.SNAKE_SHEET2_RIGHT1;
			frame2 = EnemySpriteFactory.SNAKE_SHEET2_RIGHT2;
			this.sheet = this.spriteFactory.getEnemySheet2();
		}

		public void MoveUp()
		{
			snake.pos.Y--;
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
		public void MoveDown()
		{
			snake.currState = new SnakeDown(snake);
		}
		public void MoveRight()
		{
			snake.currState = new SnakeRight(snake);
		}
		public void MoveLeft()
		{
			snake.currState = new SnakeLeft(snake);
		}
		public void Attack()
		{

		}

		public void TakeDamage()
		{
			snake.health--;

		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)snake.pos.X, (int)snake.pos.Y, frame1.Width, frame1.Height);
			Rectangle destinationRectangleFrame2 = new Rectangle((int)snake.pos.X, (int)snake.pos.Y, frame2.Width, frame2.Height);
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