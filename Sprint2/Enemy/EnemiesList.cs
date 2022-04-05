
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
        public Vector2 pos { get; set; }
        public SpriteFactory spriteFactory;
        public GameObjectManager gom;

        public Enemies bluebat;
        public Enemies bluegel;
        public Enemies darknut;
        public Enemies dragon;
        public Enemies goriya;
        public Enemies snake;
        public Enemies wizzrobe;

        Enemies enemyToBeDrawn;

        public EnemiesList()
        {

            enemiesArray = new ArrayList();

            arrIndex = 0;
            pos = new Vector2(600, 200);

            /*bluebat = new Enemies("Bluebat");
            bluegel = new Enemies("Bluegel");
            darknut = new Enemies("Darknut");
            dragon = new Enemies("Dragon");
            goriya = new Enemies("Goriya");
            snake = new Enemies("Snake");
            wizzrobe = new Enemies("Wizzrobe");*/

            enemiesArray.Add(bluebat);
            enemiesArray.Add(bluegel);
            enemiesArray.Add(darknut);
            enemiesArray.Add(dragon);
            enemiesArray.Add(goriya);
            enemiesArray.Add(snake);
            enemiesArray.Add(wizzrobe);

        }

        public Rectangle GetSpriteRectangle()
        {
            enemyToBeDrawn = (Enemies)enemiesArray[arrIndex];
            return enemyToBeDrawn.sprite.getDestinationRectangle();

            //return new Rectangle(0, 0, 0, 0); // Change this to Enemies Sprites
        }
        public void SetSpriteContent(SpriteFactory spriteFactory)
        {
            this.spriteFactory = spriteFactory;

            foreach (Enemies enemy in enemiesArray)
            {
                enemy.spriteFactory = spriteFactory;
                enemy.SetSpriteContent(spriteFactory);
            }

            /*bluebat.setEnemyType(new BluebatDown(this));
            bluegel.setEnemyType(new BluegelDown(this));
            darknut.setEnemyType(new DarknutStandingFacingDown(this));
            dragon.setEnemyType(new DragonStandingFacingDown(this));
            goriya.setEnemyType(new GoriyaStandingFacingDown(this));
            snake.setEnemyType(new SnakeDown(this));
            wizzrobe.setEnemyType(new WizzrobeDown(this));*/

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

        public EnemiesList GetConcreteObject()
        {
            return this;
        }

        object ISprite.GetConcreteObject()
        {
            return this;
        }
    }
}
