using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
	public class EnemyMovingLeftState : IEnemyState
	{
		private Enemy enemy;
		private int currFrame;
		private int totalFrames;
		private int counter;
		private Rectangle frame1;
		private Rectangle frame2;
		private EnemySpriteFactory spriteFactory;
		private Texture2D sheet;


		public EnemyMovingLeftState(Enemy enemy)
		{
			this.enemy = enemy;
			currFrame = 0;
			totalFrames = 2;
			frame1 = EnemySpriteFactory.DARKNUT_SHEET2MIRROR_LEFT1;
			frame2 = EnemySpriteFactory.DARKNUT_SHEET2MIRROR_LEFT2;
			this.sheet = this.spriteFactory.getEnemySheet2();
		}

		public void StandingFacingUp()
		{

		}
		public void StandingFacingDown()
		{

		}
		public void StandingFacingRight()
		{

		}
		public void StandingFacingLeft()
		{

		}
		public void Move()
		{

		}
		public void UseWeapon()
		{
			//enemy.currState = new EnemyUsingWeaponLeft(enemy);
		}
	
		public void TakeDamage()
		{
			enemy.health--;
			//enemy.currState = new EnemyDamagedFacingLeft(enemy);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)enemy.pos.X, (int)enemy.pos.Y, frame1.Width, frame1.Height);
			Rectangle destinationRectangleFrame2 = new Rectangle((int)enemy.pos.X, (int)enemy.pos.Y, frame2.Width, frame2.Height);
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
			enemy.pos.Y++;
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


	}
}
