using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
	public class DragonStandingFacingRight : IEnemyState
	{
		private Enemies dragon;
		private int currFrame;
		private int totalFrames;
		private int counter;
		private Rectangle frame1;
		private Rectangle frame2;
		private Rectangle frame3;
		private Rectangle frame4;
		private EnemySpriteFactory spriteFactory;
		private Texture2D sheet;


		public DragonStandingFacingRight(Enemies dragon)
		{
			this.dragon = dragon;
			currFrame = 0;
			totalFrames = 3;
			frame1 = EnemySpriteFactory.DRAGON_SHEET1MIRROR_RIGHT1;
			frame2 = EnemySpriteFactory.DRAGON_SHEET1MIRROR_RIGHT2;
			frame3 = EnemySpriteFactory.DRAGON_SHEET1MIRROR_RIGHT3;
			frame4 = EnemySpriteFactory.DRAGON_SHEET1MIRROR_RIGHT4;
			this.sheet = this.spriteFactory.getEnemySheetMirror();
		}

		public void MoveUp()
		{
			dragon.currState = new DragonStandingFacingUp(dragon);

		}
		public void MoveDown()
		{
			dragon.currState = new DragonStandingFacingDown(dragon);
		}
		public void MoveRight()
		{
			dragon.pos.X++;
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
			dragon.currState = new DragonStandingFacingLeft(dragon);
		}

		public void Attack()
		{

		}
		public void TakeDamage()
		{
			dragon.health--;
			
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)dragon.pos.X, (int)dragon.pos.Y, frame1.Width*3, frame1.Height*3);
			Rectangle destinationRectangleFrame2 = new Rectangle((int)dragon.pos.X, (int)dragon.pos.Y, frame2.Width*3, frame2.Height*3);
			Rectangle destinationRectangleFrame3 = new Rectangle((int)dragon.pos.X, (int)dragon.pos.Y, frame3.Width*3, frame3.Height*3);
			Rectangle destinationRectangleFrame4 = new Rectangle((int)dragon.pos.X, (int)dragon.pos.Y, frame4.Width*3, frame4.Height*3);

			if (currFrame == 0)
			{
				spriteBatch.Draw(sheet, destinationRectangleFrame1, frame1, Color.White);
			}
			else if (currFrame == 1)
			{
				spriteBatch.Draw(sheet, destinationRectangleFrame2, frame2, Color.White);
			}
			else if (currFrame == 2)
			{
				spriteBatch.Draw(sheet, destinationRectangleFrame3, frame3, Color.White);
			}
			else if (currFrame == 3)
			{
				spriteBatch.Draw(sheet, destinationRectangleFrame4, frame4, Color.White);
			}

		}

		public void Update()
		{
		}
	}
}
