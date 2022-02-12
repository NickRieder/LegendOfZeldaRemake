using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2.Enemy.Darknut
{
	public class DarknutStandingFacingUp : IEnemyState
	{
		private Enemy darknut;
		private int currFrame;
		private int totalFrames;
		private int counter;
		private Rectangle frame1;
		private Rectangle frame2;
		private EnemySpriteFactory spriteFactory;
		private Texture2D sheet;
		private Texture2D sheetMirror;


		public DarknutStandingFacingUp(Enemy darknut)
		{
			this.darknut = darknut;
			currFrame = 0;
			totalFrames = 2;
			frame1 = EnemySpriteFactory.DARKNUT_SHEET2_BACK;
			frame2 = EnemySpriteFactory.DARKNUT_SHEET2MIRROR_BACK;
			this.sheet = this.spriteFactory.getEnemySheet2();
			this.sheetMirror = this.spriteFactory.getEnemySheet2Mirror();
		}

		public void MoveUp()
		{
			darknut.pos.Y--;
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
			darknut.currState = new DarknutStandingFacingDown(darknut);

		}
		public void MoveRight()
		{
			darknut.currState = new DarknutStandingFacingRight(darknut);
		}
		public void MoveLeft()
		{
			darknut.currState = new DarknutStandingFacingLeft(darknut);
		}

		public void Attack()
		{

		}
		public void TakeDamage()
		{
			darknut.health--;
			//darknut.currState = new DarknutDamagedFacingDown(darknut);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)darknut.pos.X, (int)darknut.pos.Y, frame1.Width, frame1.Height);
			Rectangle destinationRectangleFrame2 = new Rectangle((int)darknut.pos.X, (int)darknut.pos.Y, frame2.Width, frame2.Height);
			if (currFrame == 0)
			{
				spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
			}
			else
			{
				spriteBatch.Draw(sheetMirror, destinationRectangleFrame2, frame2, Color.White);
			}
		}

		public void Update()
		{
		}


	}
}
