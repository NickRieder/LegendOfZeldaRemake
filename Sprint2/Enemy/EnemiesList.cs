using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;

namespace Sprint2
{
	public class EnemiesList
	{
		private ArrayList enemiesArray;
		private int arrIndex;
		public Vector2 startingPos;
		public EnemySpriteFactory spriteFactory;

		public Enemies bluebat;
		public Enemies bluegel;
		public Enemies darknut;
		public Enemies dragon;
		public Enemies goriya;
		public Enemies snake;
		public Enemies wizzrobe;

		Enemies enemyToBeDrawn;

		public EnemiesList(EnemySpriteFactory enemySpriteFactory)
		{
			enemiesArray = new ArrayList();
			spriteFactory = enemySpriteFactory;

			arrIndex = 0;
			startingPos.X = 600;
			startingPos.Y = 200;

			bluebat = new Enemies(spriteFactory);
			bluegel = new Enemies(spriteFactory);
            darknut = new Enemies(spriteFactory);
            dragon = new Enemies(spriteFactory);
            goriya = new Enemies(spriteFactory);
            snake = new Enemies(spriteFactory);
            wizzrobe = new Enemies(spriteFactory);

            bluebat.setEnemyType(new BluebatDown(this));
			bluegel.setEnemyType(new BluegelDown(this));
            darknut.setEnemyType(new DarknutStandingFacingDown(this));
            dragon.setEnemyType(new DragonStandingFacingDown(this));
            goriya.setEnemyType(new GoriyaStandingFacingDown(this));
            snake.setEnemyType(new SnakeDown(this));
            wizzrobe.setEnemyType(new WizzrobeDown(this));

            enemiesArray.Add(bluebat);
			enemiesArray.Add(bluegel);
			enemiesArray.Add(darknut);
            enemiesArray.Add(dragon);
            enemiesArray.Add(goriya);
            enemiesArray.Add(snake);
            enemiesArray.Add(wizzrobe);

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
