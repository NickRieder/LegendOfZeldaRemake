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
        public  ArrayList allObjectList;
        public ArrayList updatableSprites;
        public ArrayList drawableSprites;
        public ArrayList movableList;

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
            allObjectList = new ArrayList();
            updatableSprites = new ArrayList();
            drawableSprites = new ArrayList();
            movableList = new ArrayList();
            
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
            this.AddToallObjectList(link);
            this.AddToallObjectList(item);
            this.AddToallObjectList(block);
            this.AddToMovableList(link);

            this.AddToMovableList(bluebat);
            this.AddToMovableList(bluegel);
            this.AddToMovableList(darknut);
            this.AddToMovableList(dragon);
            this.AddToMovableList(goriya);
            this.AddToMovableList(snake);
            this.AddToMovableList(wizzrobe);



            // Adding all of these enemies into the list causes all enemies to be drawn in the beginning.
            // PROBLEM: Not adding them messes up every enemy files, so just keep it here for now.
            this.AddToallObjectList(bluebat);
            this.AddToallObjectList(bluegel);
            this.AddToallObjectList(darknut);
            this.AddToallObjectList(dragon);
            this.AddToallObjectList(goriya);
            this.AddToallObjectList(snake);
            this.AddToallObjectList(wizzrobe);

            this.AddToallObjectList(enemiesList);

            // Right now, updatableSprites, drawableSprites, and allObjectList all hold the same sprite objects.
                // QUESTION: What makes them different?
                // ANSWER:
            updatableSprites = allObjectList;
            drawableSprites = allObjectList;
        }

        public void SetSpriteContent(SpriteFactory spriteFactory)
        {
            foreach (ISprite sprite in allObjectList)
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

        public void AddToallObjectList(ISprite spriteObject)
        {
            allObjectList.Add(spriteObject);
        }
        public void AddToMovableList(ISprite spriteObject)
        {
            movableList.Add(spriteObject);
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
