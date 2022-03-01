using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class GameObjectManager
    {
        private ArrayList spriteList;
        private ArrayList updatableSprites;
        private ArrayList drawableSprites;

        public Link link;
        public Item item;
        public Block block;
        public EnemiesList enemiesList;

        public Enemies bluebat;
        public Enemies bluegel;
        public Enemies darknut;
        public Enemies dragon;
        public Enemies goriya;
        public Enemies snake;
        public Enemies wizzrobe;

        public GameObjectManager()
        {
            spriteList = new ArrayList();
            updatableSprites = new ArrayList();
            drawableSprites = new ArrayList();
            
            link = new Link();
            item = new Item();
            block = new Block();

            bluebat = new Enemies();
            bluegel = new Enemies();
            darknut = new Enemies();
            dragon = new Enemies();
            goriya = new Enemies();
            snake = new Enemies();
            wizzrobe = new Enemies();

            enemiesList = new EnemiesList(this);

            // Adding all these sprite objects should probably be done outside of the GOM.
            // Kevin: I think the class that reads the XML files would be adding the necessary sprite objects into the list. (Unless this IS the class, but idk)
                // PROBLEM: We can't easily access sprite objects from the GOM if we use a list.
                // SOLUTION: Maybe we could use a dictionary, but we can only add unique keys to a dictionary (ie. no duplicate enemies?).
            this.AddToSpriteList(link);
            this.AddToSpriteList(item);
            this.AddToSpriteList(block);

            // Adding all of these enemies into the list causes all enemies to be drawn in the beginning.
                // PROBLEM: Not adding them messes up every enemy files, so just keep it here for now.
            this.AddToSpriteList(bluebat);
            this.AddToSpriteList(bluegel);
            this.AddToSpriteList(darknut);
            this.AddToSpriteList(dragon);
            this.AddToSpriteList(goriya);
            this.AddToSpriteList(snake);
            this.AddToSpriteList(wizzrobe);

            this.AddToSpriteList(enemiesList);

            // Right now, updatableSprites, drawableSprites, and spriteList all hold the same sprite objects.
                // QUESTION: What makes them different?
                // ANSWER:
            updatableSprites = spriteList;
            drawableSprites = spriteList;
        }

        public void SetSpriteContent(SpriteFactory spriteFactory)
        {
            foreach (ISprite sprite in spriteList)
            {
                sprite.SetSpriteContent(spriteFactory);
            }

            bluebat.setEnemyType(new BluebatDown(enemiesList));
            bluegel.setEnemyType(new BluegelDown(enemiesList));
            darknut.setEnemyType(new DarknutStandingFacingDown(enemiesList));
            dragon.setEnemyType(new DragonStandingFacingDown(enemiesList));
            goriya.setEnemyType(new GoriyaStandingFacingDown(enemiesList));
            snake.setEnemyType(new SnakeDown(enemiesList));
            wizzrobe.setEnemyType(new WizzrobeDown(enemiesList));
        }

        public void AddToSpriteList(ISprite spriteObject)
        {
            spriteList.Add(spriteObject);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Could be done in Game1.cs
            // This function could just return an array of IDrawables
            foreach (ISprite sprite in drawableSprites)
            {
                sprite.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gametime)
        {
            // Could be done in Game1.cs
            // This function could just return an array of IUpdatables
            foreach (ISprite sprite in updatableSprites)
            {
                sprite.Update(gametime);
            }
        }

    }
}
