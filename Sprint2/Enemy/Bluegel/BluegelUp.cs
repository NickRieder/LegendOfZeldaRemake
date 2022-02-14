using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
	public class BluegelUp : IEnemyState
	{
		private Enemies blueGel;
		private int currFrame;
		private int totalFrames;
		private int counter;
		private Rectangle frame1;
		private Rectangle frame2;
		private EnemySpriteFactory spriteFactory;
		private Texture2D sheet;


		public BluegelUp(Enemies blueGell)
		{
			
			currFrame = 0;
			totalFrames = 2;
			frame1 = EnemySpriteFactory.BLUEGEL_SHEET2_POS1;
			frame2 = EnemySpriteFactory.BLUEGEL_SHEET2_POS1;
			this.sheet = this.spriteFactory.getEnemySheet2();
		}

		public void MoveUp()
		{
			blueGel.pos.Y--;
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
			blueGel.currState = new BluegelDown(blueGel);

		}
		public void MoveRight()
		{
			blueGel.currState = new BluegelRight(blueGel);
		}
		public void MoveLeft()
		{
			blueGel.currState = new BluegelLeft(blueGel);
		}
		public void Attack()
		{

		}

		public void TakeDamage()
		{
			blueGel.health--;
			
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle destinationRectangleFrame1 = new Rectangle((int)blueGel.pos.X, (int)blueGel.pos.Y, frame1.Width, frame1.Height);
			Rectangle destinationRectangleFrame2 = new Rectangle((int)blueGel.pos.X, (int)blueGel.pos.Y, frame2.Width, frame2.Height);
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
