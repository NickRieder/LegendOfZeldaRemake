using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class GameObjectManager
    {
        public SpriteFactory spriteFactory { get; set; }    // Example of a property
        public ConcurrentBag<ISprite> allObjectList { get; set; }
        public ConcurrentBag<ISprite> movableObjectList { get; set; }
        public ConcurrentBag<ISprite> updatableSpritesList;
        public ConcurrentBag<ISprite> drawableSpritesList;
        public ConcurrentBag<ISprite> allObjectListInserts;
        public ConcurrentBag<ISprite> movableObjectListInserts;
        public ConcurrentBag<ISprite> updatableSpritesListInserts;
        public ConcurrentBag<ISprite> drawableSpritesListInserts;
        private ConcurrentBag<ISprite> tempUpdatableList;
        private ConcurrentBag<ISprite> tempDrawableList;
        private ConcurrentBag<ISprite> pauseMenuList;
        public GameTime gameTime;
        public Link link;
        public Item item;
        public Block block;
        //public Door door;
        public EnemiesList enemiesList;

        private Background background;
        public KeyboardController keyboardController;
        public MouseController mouseController;
        private bool isPaused;

        public Menu menu;
        public HUD hud;

        public GameObjectManager()
        {
            // Use ConcurrentBag to allow modifying of a collection while it is being iterated over.
            allObjectList = new ConcurrentBag<ISprite>();
            movableObjectList = new ConcurrentBag<ISprite>();
            drawableSpritesList = new ConcurrentBag<ISprite>();
            updatableSpritesList = new ConcurrentBag<ISprite>();
            
            // Inserts lists are lists that store elements to be added while the actual list corresponding to the name is being iterated through.
            allObjectListInserts = new ConcurrentBag<ISprite>();
            movableObjectListInserts = new ConcurrentBag<ISprite>();
            drawableSpritesListInserts = new ConcurrentBag<ISprite>();
            updatableSpritesListInserts = new ConcurrentBag<ISprite>();
            tempUpdatableList = new ConcurrentBag<ISprite>();
            tempDrawableList = new ConcurrentBag<ISprite>();
            pauseMenuList = new ConcurrentBag<ISprite>();

            keyboardController = new KeyboardController();
            mouseController = new MouseController();

            link = new Link();
            background = new Background();
            gameTime = new GameTime();
            isPaused = false;
            menu = new Menu(this);
            hud = new HUD(this);
            //this.AddToDrawableObjectList(background);

            
        }

        public void SetSpriteContent(SpriteFactory spriteFactory)
        {
            this.spriteFactory = spriteFactory;
            background.SetSpriteContent(spriteFactory);
            menu.SetSpriteContent(spriteFactory);
            hud.SetSpriteContent(spriteFactory);
            foreach (ISprite sprite in drawableSpritesList)
            {
                sprite.SetSpriteContent(spriteFactory);
            }

        }

        public void PauseGame()
        {
            if(isPaused)
            {
                updatableSpritesList = new ConcurrentBag<ISprite>(tempUpdatableList);
                drawableSpritesList = new ConcurrentBag<ISprite>(tempDrawableList);
            }
            else
            {
                tempUpdatableList = new ConcurrentBag<ISprite>(updatableSpritesList);
                updatableSpritesList.Clear();
                tempDrawableList = new ConcurrentBag<ISprite>(drawableSpritesList);
                drawableSpritesList.Clear();
            }
            isPaused = !isPaused;
            
        }

        public void SetBackgroundRoom(string roomName)
        {
            background.SetRoomName(roomName);
        }
        public Background GetBackgroud()
        {
            return background;
        }

        public ConcurrentBag<ISprite> getListOfAllObjects()
        {
            return allObjectList;
        }

        public ConcurrentBag<ISprite> getListOfMovableObjects()
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
            //drawableSpritesList.Add(background);
            //updatableSpritesList.Add(background);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!isPaused) background.Draw(spriteBatch);
            else menu.Draw(spriteBatch);
            hud.Draw(spriteBatch);
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
