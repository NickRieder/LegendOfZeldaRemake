using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;

namespace Sprint2
{
	public class EnemiesList : ISprite
	{
		private ArrayList enemiesArray;
		private int arrIndex;
		public Vector2 startingPos;
		public SpriteFactory spriteFactory;

		public Enemies bluebat;
		public Enemies bluegel;
		public Enemies darknut;
		public Enemies dragon;
		public Enemies goriya;
		public Enemies snake;
		public Enemies wizzrobe;

		Enemies enemyToBeDrawn;

		public EnemiesList(GameObjectManager gom)
		{
			enemiesArray = new ArrayList();


			arrIndex = 0;
			startingPos.X = 600;
			startingPos.Y = 200;

			bluebat = gom.bluebat;
			bluegel = gom.bluegel;
			darknut = gom.darknut;
			dragon = gom.dragon;
			goriya = gom.goriya;
			snake = gom.snake;
			wizzrobe = gom.wizzrobe;

			/*bluebat.setEnemyType(new BluebatDown(this));
			bluegel.setEnemyType(new BluegelDown(this));
			darknut.setEnemyType(new DarknutStandingFacingDown(this));
			dragon.setEnemyType(new DragonStandingFacingDown(this));
			goriya.setEnemyType(new GoriyaStandingFacingDown(this));
			snake.setEnemyType(new SnakeDown(this));
			wizzrobe.setEnemyType(new WizzrobeDown(this));*/

			enemiesArray.Add(bluebat);
			enemiesArray.Add(bluegel);
			enemiesArray.Add(darknut);
            enemiesArray.Add(dragon);
            enemiesArray.Add(goriya);
            enemiesArray.Add(snake);
            enemiesArray.Add(wizzrobe);

        }

		public void SetSpriteContent(SpriteFactory spriteFactory)
		{
			this.spriteFactory = spriteFactory;

			
		}

		public void NextEnemy()
		{
			if (arrIndex == enemiesArray.Count - 1)
			{
				arrIndex = 0;
			}
			else
			{
				arrIndex++;
			}

		}

		public void PreviousEnemy()
		{
			if (arrIndex == 0)
			{
				arrIndex = enemiesArray.Count - 1;
			}
			else
			{
				arrIndex--;
			}
		}

		public void Update(GameTime gameTime)
        {
			enemyToBeDrawn = (Enemies)enemiesArray[arrIndex];
			enemyToBeDrawn.Update(gameTime);

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			enemyToBeDrawn.Draw(spriteBatch);
		}
	}
}
