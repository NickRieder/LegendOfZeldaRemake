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

        public GameObjectManager()
        {
            allObjectList = new ArrayList();
            updatableSpritesList = new ArrayList();
            drawableSpritesList = new ArrayList();
            movableObjectList = new ArrayList();
          
            

            link = new Link();
            background = new Background();
            gameTime = new GameTime();

            this.AddToDrawableObjectList(background);

            
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
        public void AddToUpdatableObjectList(ISprite spriteObject)
        {
            updatableSpritesList.Add(spriteObject);
        }
        public void ClearSpriteList()
        {
            allObjectList.Clear();
            movableObjectList.Clear();
            updatableSpritesList.Clear();
            drawableSpritesList.Clear();
            drawableSpritesList.Add(background);
            updatableSpritesList.Add(background);

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
