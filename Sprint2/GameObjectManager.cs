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
        public GameTime gameTime;
        public Link link;
        public Item item;
        public Block block;
        //public Door door;
        public EnemiesList enemiesList;
        private Background background;
        public KeyboardController keyboardController;

        public GameObjectManager()
        {
            allObjectList = new ArrayList();
            updatableSpritesList = new ArrayList();
            drawableSpritesList = new ArrayList();
            movableObjectList = new ArrayList();
            keyboardController = new KeyboardController();
            // Adding all these sprite objects should probably be done outside of the GOM.
            // Kevin: I think the class that reads the XML files would be adding the necessary sprite objects into the list. (Unless this IS the class, but idk)
            // PROBLEM: We can't easily access sprite objects from the GOM if we use a list.
            // SOLUTION: Maybe we could use a dictionary, but we can only add unique keys to a dictionary (ie. no duplicate enemies?).

            background = new Background();
            link = new Link();
            item = new Item();
            //block = new Block("Brick Block");
            gameTime = new GameTime();
            //door = new Door("Top Door", "room", new LevelLoader(this, spriteFactory));
            enemiesList = new EnemiesList();

            this.AddToDrawableObjectList(background);

            //this.AddToAllObjectList(enemiesList);

            //this.AddToMovableObjectList(enemiesList);

            // Right now, updatableSprites, drawableSprites, and allObjectList all hold the same sprite objects.
            // QUESTION: What makes them different?
            // ANSWER:
            
        }

        public void SetSpriteContent(SpriteFactory spriteFactory)
        {
            foreach (ISprite sprite in drawableSpritesList)
            {
                sprite.SetSpriteContent(spriteFactory);
            }

        }

        public void SetBackgroundRoom(string roomName)
        {
            background.SetRoomName(roomName);
        }

        public ArrayList getListOfAllObjects()
        {
            return allObjectList;
        }

        public ArrayList getListOfMovableObjects()
        {
            return movableObjectList;
        }

        public void AddToAllObjectList(ISprite spriteObject)
        {
            allObjectList.Add(spriteObject);
            drawableSpritesList.Add(spriteObject);
            updatableSpritesList.Add(spriteObject);
        }
        public void AddToMovableObjectList(ISprite spriteObject)
        {
            movableObjectList.Add(spriteObject);
            
        }
        public void AddToDrawableObjectList(ISprite spriteObject)
        {
            drawableSpritesList.Add(spriteObject);
            updatableSpritesList.Add(spriteObject);
        }
        public void ClearSpriteList()
        {
            allObjectList.Clear();
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
