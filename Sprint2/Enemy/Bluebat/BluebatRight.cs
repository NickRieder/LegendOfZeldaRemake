using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2.Enemy.Bluebat
{
	public class BluebatRight : IEnemyState
	{
		private Enemy bluebat;
		private int currFrame;
		private int totalFrames;
		private int counter;
		private Rectangle frame1;
		private Rectangle frame2;
		private EnemySpriteFactory spriteFactory;
		private Texture2D sheet;


		public BluebatRight(Enemy bluebat)
		{
			this.bluebat = bluebat;
			currFrame = 0;
			totalFrames = 2;
			frame1 = EnemySpriteFactory.BLUEBAT_SHEET2_POS1;
			frame2 = EnemySpriteFactory.BLUEBAT_SHEET2_POS2;
			this.sheet = this.spriteFactory.getEnemySheet2();
		}

		public void MoveUp()
		{
			bluebat.currState = new BluebatUp(bluebat);

		}
		public void MoveDown()
		{

			bluebat.currState = new BluebatDown(bluebat);
		}
		public void MoveRight()
		{
			bluebat.pos.X++;
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
			bluebat.currState = new BluebatLeft(bluebat);
		}
		public void Attack()
		{
			//bluebat.currState = new BluebatUsingWeaponDown(bluebat);
		}

		public void TakeDamage()
		{
			bluebat.health--;
			//bluebat.currState = new BluebatDamagedFacingDown(bluebat);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)bluebat.pos.X, (int)bluebat.pos.Y, frame1.Width, frame1.Height);
			Rectangle destinationRectangleFrame2 = new Rectangle((int)bluebat.pos.X, (int)bluebat.pos.Y, frame2.Width, frame2.Height);
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
