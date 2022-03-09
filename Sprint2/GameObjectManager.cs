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
        public SpriteFactory spriteFactory { get; set; }    // Example of a property
        public ArrayList allObjectList { get; set; }
        public ArrayList movableObjectList { get; set; }
        public ArrayList updatableSpritesList;
        public ArrayList drawableSpritesList;
        
        public Link link;
        public Item item;
        public Block block;
        public EnemiesList enemiesList;

        public GameObjectManager()
        {
            allObjectList = new ArrayList();
            updatableSpritesList = new ArrayList();
            drawableSpritesList = new ArrayList();
            movableObjectList = new ArrayList();

            // Adding all these sprite objects should probably be done outside of the GOM.
            // Kevin: I think the class that reads the XML files would be adding the necessary sprite objects into the list. (Unless this IS the class, but idk)
            // PROBLEM: We can't easily access sprite objects from the GOM if we use a list.
            // SOLUTION: Maybe we could use a dictionary, but we can only add unique keys to a dictionary (ie. no duplicate enemies?).

            link = new Link();
            item = new Item();
            block = new Block();
            enemiesList = new EnemiesList();

            this.AddToallObjectList(link);
            this.AddToallObjectList(item);
            this.AddToallObjectList(block);
            this.AddToallObjectList(enemiesList);

            this.AddToMovableObjectList(link);
            this.AddToMovableObjectList(enemiesList);

            // Right now, updatableSprites, drawableSprites, and allObjectList all hold the same sprite objects.
            // QUESTION: What makes them different?
            // ANSWER:
            updatableSpritesList = allObjectList;
            drawableSpritesList = allObjectList;
        }

        public void SetSpriteContent(SpriteFactory spriteFactory)
        {
            foreach (ISprite sprite in allObjectList)
            {
                sprite.SetSpriteContent(spriteFactory);
            }

        }

        public ArrayList getListOfAllObjects()
        {
            return allObjectList;
        }

        public ArrayList getListOfMovableObjects()
        {
            return movableObjectList;
        }

        public void AddToallObjectList(ISprite spriteObject)
        {
            allObjectList.Add(spriteObject);
        }
        public void AddToMovableObjectList(ISprite spriteObject)
        {
            movableObjectList.Add(spriteObject);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            
            foreach (ISprite sprite in drawableSpritesList)
            {
                sprite.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gametime)
        {
           
            foreach (ISprite sprite in updatableSpritesList)
            {
                sprite.Update(gametime);
            }
        }

    }
}
