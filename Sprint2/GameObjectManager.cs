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
        private ConcurrentBag<ISprite> tempUpdatableList;
        public SoundFactory soundFactory { get; set; }


        private ConcurrentBag<ISprite> tempDrawableList;
        private ConcurrentBag<ISprite> pauseMenuList;
        public GameTime gameTime;
        public Link link;
        public Item item;
        public Block block;
        //public Door door;
        public EnemiesList enemiesList;
        public HUD Hud;
        private Background background;
        public KeyboardController keyboardController;
        public MouseController mouseController;
        private bool isPaused;

        public Game1 game1;
        public Menu menu;
        public HUD hud;
        public Camera camera;

        public GameObjectManager(Game1 game)
        {

            // Use ConcurrentBag to allow modifying of a collection while it is being iterated over.
            allObjectList = new ConcurrentBag<ISprite>();
            movableObjectList = new ConcurrentBag<ISprite>();
            drawableSpritesList = new ConcurrentBag<ISprite>();
            updatableSpritesList = new ConcurrentBag<ISprite>();

            // Inserts lists are lists that store elements to be added while the actual list corresponding to the name is being iterated through.
            tempUpdatableList = new ConcurrentBag<ISprite>();
            tempDrawableList = new ConcurrentBag<ISprite>();
            pauseMenuList = new ConcurrentBag<ISprite>();

            // Initialize Controllers
            keyboardController = new KeyboardController();
            mouseController = new MouseController();

            link = new Link(game, this);
            background = new Background();
            gameTime = new GameTime();
            isPaused = false;
            menu = new Menu(this);
            this.camera = new Camera(this);
            hud = new HUD(this);
            hud.SetCamera(camera);
            //this.AddToDrawableObjectList(background);

            this.AddToDrawableObjectList(background);
            this.AddToDrawableObjectList(link);

        }

        public void SetGame(Game1 game1)
        {
            this.game1 = game1;
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

            camera.SetSpriteContent(spriteFactory);
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
            if (isPaused)
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
            camera.Draw(spriteBatch);
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
            camera.Update(gameTime);
            foreach (ISprite sprite in updatableSpritesList)
            {
                sprite.Update(gametime);
            }
        }
    }
}
   