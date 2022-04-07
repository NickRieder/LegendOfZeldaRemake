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
        public SoundFactory soundFactory { get; set; }
        

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

        public GameObjectManager(Game1 game)
        {
            // Use ConcurrentBag to allow modifying of a collection while it is being iterated over.
            allObjectList = new ConcurrentBag<ISprite>();
            movableObjectList = new ConcurrentBag<ISprite>();
            drawableSpritesList = new ConcurrentBag<ISprite>();
            updatableSpritesList = new ConcurrentBag<ISprite>();
            tempUpdatableList = new ConcurrentBag<ISprite>();

            // Initialize Controllers
            keyboardController = new KeyboardController();
            mouseController = new MouseController();

            link = new Link(game);
            background = new Background();
            gameTime = new GameTime();


            //this.AddToDrawableObjectList(background);

            this.AddToDrawableObjectList(background);
            this.AddToDrawableObjectList(link);



            
        }
        public void SetSoundContent(SoundFactory soundFactory)
        {
            foreach (ISprite sprite in drawableSpritesList)
            {
                sprite.SetSoundContent(soundFactory);
            }
        }

        public void SetSpriteContent(SpriteFactory spriteFactory)
        {
            this.spriteFactory = spriteFactory;
            background.SetSpriteContent(spriteFactory);
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
            }
            else
            {
                tempUpdatableList = new ConcurrentBag<ISprite>(updatableSpritesList);
                updatableSpritesList.Clear();
            }
            isPaused = !isPaused;
            
        }

        public void SetBackgroundRoom(string roomName)
        {
            background.SetRoomName(roomName);
        }

        public ConcurrentBag<ISprite> getListOfAllObjects()
        {
            return allObjectList;
        }

        public ConcurrentBag<ISprite> getListOfMovableObjects()
        {
            return movableObjectList;
        }

        // Add To Collection
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

        // Remove From Collections
        public void RemoveFromEveryCollection(ISprite incoming)
        {
            RemoveFromAllObjectList(incoming);
            RemoveFromMovableObjectList(incoming);
            RemoveFromDrawableObjectList(incoming);
            RemoveFromUpdatableObjectList(incoming);
        }
        public void RemoveFromAllObjectList(ISprite incoming)
        {
            ConcurrentBag<ISprite> bagCopy = new ConcurrentBag<ISprite>();
            ConcurrentBag<ISprite> tempBag = new ConcurrentBag<ISprite>();
            ISprite removed;
            bagCopy = allObjectList;
            while (bagCopy.TryTake(out removed))    // TryTake returns a bool and sets 'removed' to the object that was taken out of the bag.
            {
                if (!(removed.Equals(incoming)))
                {
                    tempBag.Add(removed);
                }
            }
            allObjectList = tempBag;
        }
        public void RemoveFromMovableObjectList(ISprite incoming)
        {
            ConcurrentBag<ISprite> bagCopy = new ConcurrentBag<ISprite>();
            ConcurrentBag<ISprite> tempBag = new ConcurrentBag<ISprite>();
            ISprite removed;
            bagCopy = movableObjectList;
            while (bagCopy.TryTake(out removed))
            {
                if (!(removed.Equals(incoming)))
                {
                    tempBag.Add(removed);
                }
            }
            movableObjectList = tempBag;
        }
        public void RemoveFromDrawableObjectList(ISprite incoming)
        {
            ConcurrentBag<ISprite> bagCopy = new ConcurrentBag<ISprite>();
            ConcurrentBag<ISprite> tempBag = new ConcurrentBag<ISprite>();
            ISprite removed;
            bagCopy = drawableSpritesList;
            while (bagCopy.TryTake(out removed))
            {
                if (!(removed.Equals(incoming)))
                {
                    tempBag.Add(removed);
                }
            }
            drawableSpritesList = tempBag;
        }
        public void RemoveFromUpdatableObjectList(ISprite incoming)
        {
            ConcurrentBag<ISprite> bagCopy = new ConcurrentBag<ISprite>();
            ConcurrentBag<ISprite> tempBag = new ConcurrentBag<ISprite>();
            ISprite removed;
            bagCopy = updatableSpritesList;
            while (bagCopy.TryTake(out removed))
            {
                if (!(removed.Equals(incoming)))
                {
                    tempBag.Add(removed);
                }
            }
            updatableSpritesList = tempBag;
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
            background.Draw(spriteBatch);
            foreach (ISprite sprite in drawableSpritesList)
            {
                sprite.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gametime)
        {
            background.Update(gametime);
            foreach (ISprite sprite in updatableSpritesList)
            {
                sprite.Update(gametime);
            }
        }
    }
}
