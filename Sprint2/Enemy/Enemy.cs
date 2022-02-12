using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2.Enemy
{
	public class Enemy : IEnemyState
	{
		public IEnemyState currState;

		public Vector2 pos;


		public int health;
		public Enemy()
		{
			/*TODO: currState has a different name for each enemy. We want the current state to 
			 * either be a front sprite or a right sprite if the sheet does not have front sprite.
			 * 
			 * POSSIBLE SOLUTION: Make an IEnemyState currState variable for all every single file.
			 * 
			 * MY RECOMMENDED SOLUTION: Make an enemy class for each folder but not sure how that 
			 * would be coded since each up, right, down, left classes each have implemetations for 
			 * each move method
			 */
			//currState = new BluebatDown(this);  <-- BluebatDown needs to be able to change depedning on folder
			health = 3;
			pos.X = 40;
			pos.Y = 40;
		}
		public void MoveUp()
		{
			currState.MoveDown();
		}
		public void MoveDown()
		{
			currState.MoveDown();
		}
		public void MoveLeft()
		{
			currState.MoveLeft();
		}
		public void MoveRight()
		{
			currState.MoveRight();
		}
	
		public void Attack()
		{
			currState.Attack();
		}
		public void TakeDamage()
		{
			currState.TakeDamage();
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			currState.Draw(spriteBatch);
		}
		public void Update()
		{
			currState.Update();
		}
	}
}
