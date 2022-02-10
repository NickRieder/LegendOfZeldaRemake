using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2.Enemy.Dragon
{
	public class DragonMovingDownState : IEnemyState
	{
		private Enemy dragon;
		private int currFrame;
		private int totalFrames;
		private int counter;
		private Rectangle frame1;
		private Rectangle frame2;
		private Rectangle frame3;
		private Rectangle frame4;
		private EnemySpriteFactory spriteFactory;
		private Texture2D sheet;


		public DragonMovingDownState(Enemy dragon)
		{
			this.dragon = dragon;
			currFrame = 0;
			totalFrames = 4;
			frame1 = EnemySpriteFactory.DRAGON_SHEET1_LEFT1;
			frame2 = EnemySpriteFactory.DRAGON_SHEET1_LEFT2;
		    frame3 = EnemySpriteFactory.DRAGON_SHEET1_LEFT3;
			frame4 = EnemySpriteFactory.DRAGON_SHEET1_LEFT4;
			this.sheet = this.spriteFactory.getEnemySheet1();
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
			//dragon.currState = new DragonUsingWeaponDown(dragon);
		}
		public void TakeDamage()
		{
			dragon.health--;
			//dragon.currState = new DragonDamagedFacingDown(dragon);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)dragon.pos.X, (int)dragon.pos.Y, frame1.Width, frame1.Height);
			Rectangle destinationRectangleFrame2 = new Rectangle((int)dragon.pos.X, (int)dragon.pos.Y, frame2.Width, frame2.Height);
			Rectangle destinationRectangleFrame3 = new Rectangle((int)dragon.pos.X, (int)dragon.pos.Y, frame3.Width, frame3.Height);
			Rectangle destinationRectangleFrame4 = new Rectangle((int)dragon.pos.X, (int)dragon.pos.Y, frame4.Width, frame4.Height);

			if (currFrame == 0)
			{
				spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
			}
			else 
			{
				spriteBatch.Draw(sheet, destinationRectangleFrame2, frame2, Color.White);
				spriteBatch.Draw(sheet, destinationRectangleFrame3, frame3, Color.White);
				spriteBatch.Draw(sheet, destinationRectangleFrame4, frame4, Color.White);
			}
			
		}

		public void Update()
		{
			dragon.pos.Y++;
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
