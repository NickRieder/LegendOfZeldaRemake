using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
	public class Enemies : ISprite
	{
		public IEnemyState currState;
		public Vector2 pos;
		public SpriteFactory spriteFactory { get; set; }
		public Sprite sprite;
		public int health;
		public int spriteSizeMultiplier;
		public string enemyName;

		public Enemies(string enemyName)
		{
			this.enemyName = enemyName;
			spriteSizeMultiplier = 2;
			health = 3;
			pos.X = 600;
			pos.Y = 200;
		}

		public void SetSpriteContent(SpriteFactory spriteFactory)
        {
			this.spriteFactory = spriteFactory;
			switch (enemyName)
			{
				case "Bluebat":
					currState = new BluebatDown(this);
					break;
				case "Bluegel":
					currState = new BluegelDown(this);
					break;
				case "Darknut":
					currState = new DarknutStandingFacingDown(this);
					break;
				case "Dragon":
					currState = new DragonStandingFacingDown(this);
					break;
				case "Goriya":
					currState = new GoriyaStandingFacingDown(this);
					break;
				case "Snake":
					currState = new SnakeDown(this);
					break;
				case "Wizzrobe":
					currState = new WizzrobeDown(this);
					break;
				default: // facing up
					currState = null;
					break;
			}
		}

		public Rectangle GetSpriteRectangle()
		{
			return new Rectangle(0, 0, 0, 0); // Change this to Enemy Sprite
		}

		/*public void setEnemyType(IEnemyState enemyType)
        {
			currState = enemyType;
		}*/

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

		/*public void Attack()
		{
			currState.Attack();
		}*/
		public void TakeDamage()
		{
			currState.TakeDamage();
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			currState.Draw(spriteBatch);
		}
		public void Update(GameTime gameTime)
		{
			currState.Update(gameTime);
		}
	}
}
