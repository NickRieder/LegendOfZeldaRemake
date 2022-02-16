using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;

namespace Sprint2
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        private LinkSpriteFactory linkSpriteFactory;
        public ItemSpriteFactory itemSpriteFactory;
        public EnemySpriteFactory enemySpriteFactory;
        private Link link;
        private Item item;
        private EnemiesList enemiesList;
        private ArrayList controllerList;
        private KeyboardController keyboardController;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            linkSpriteFactory = new LinkSpriteFactory(this.Content);
            itemSpriteFactory = new ItemSpriteFactory(this.Content);
            enemySpriteFactory = new EnemySpriteFactory(this.Content);

            controllerList = new ArrayList();
            
            keyboardController = new KeyboardController();
            controllerList.Add(keyboardController);

            
            
            base.Initialize();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here

            linkSpriteFactory.LoadSpriteSheet();

            link = new Link(linkSpriteFactory);

            itemSpriteFactory.LoadSpriteSheet();
            item = new Item(itemSpriteFactory);

            enemySpriteFactory.LoadSpriteSheet();
            enemiesList = new EnemiesList(enemySpriteFactory);

            keyboardController.RegisterCommandTap(Keys.I, new SetNextItem(item));
            keyboardController.RegisterCommandTap(Keys.U, new SetPreviousItem(item));

            keyboardController.RegisterCommandTap(Keys.P, new SetNextEnemy(enemiesList));
            keyboardController.RegisterCommandTap(Keys.O, new SetPreviousEnemy(enemiesList));

            keyboardController.RegisterCommandHold(Keys.S, new SetLinkMovingDown(link));
            keyboardController.RegisterCommandHold(Keys.W, new SetLinkMovingUp(link));
            keyboardController.RegisterCommandHold(Keys.A, new SetLinkMovingLeft(link));
            keyboardController.RegisterCommandHold(Keys.D, new SetLinkMovingRight(link));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            foreach (IController controller in controllerList)
            {
                controller.update();
            }

            enemiesList.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();
            link.Draw(spriteBatch);
            item.Draw(spriteBatch);
            enemiesList.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
