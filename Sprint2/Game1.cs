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
        public BlockSpriteFactory blockSpriteFactory;
        public EnemySpriteFactory enemySpriteFactory;
        //public Link link;
        //private Item item;
        //private Block block;
        //private EnemiesList enemiesList;
        private ArrayList controllerList;
        private KeyboardController keyboardController;
        private GameObjectManager gom;

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
            blockSpriteFactory = new BlockSpriteFactory(this.Content);
            enemySpriteFactory = new EnemySpriteFactory(this.Content);

            gom = new GameObjectManager();

            controllerList = new ArrayList();
            
            keyboardController = new KeyboardController();
            controllerList.Add(keyboardController);

            //link = new Link();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            linkSpriteFactory.LoadSpriteSheet();

            //link.SetSpriteContent(linkSpriteFactory);

            itemSpriteFactory.LoadSpriteSheet();
            //item = new Item(itemSpriteFactory);

            blockSpriteFactory.LoadSpriteSheet();
            //block = new Block(blockSpriteFactory);

            enemySpriteFactory.LoadSpriteSheet();
            //enemiesList = new EnemiesList(enemySpriteFactory);

            gom.SetSpriteContent(linkSpriteFactory, enemySpriteFactory, itemSpriteFactory, blockSpriteFactory);

            keyboardController.RegisterCommandTap(Keys.I, new SetNextItem(gom.item));
            keyboardController.RegisterCommandTap(Keys.U, new SetPreviousItem(gom.item));
            
            keyboardController.RegisterCommandTap(Keys.Z, new SetLinkAttacking(gom.link));
            keyboardController.RegisterCommandTap(Keys.N, new SetLinkAttacking(gom.link));

            keyboardController.RegisterCommandTap(Keys.Y, new SetNextBlock(gom.block));
            keyboardController.RegisterCommandTap(Keys.T, new SetPreviousBlock(gom.block));

            keyboardController.RegisterCommandTap(Keys.P, new SetNextEnemy(gom.enemiesList));
            keyboardController.RegisterCommandTap(Keys.O, new SetPreviousEnemy(gom.enemiesList));

            keyboardController.RegisterCommandTap(Keys.D1, new SetLinkUseArrow(gom.link));
            keyboardController.RegisterCommandTap(Keys.D2, new SetLinkUseBoomerang(gom.link));
            keyboardController.RegisterCommandTap(Keys.D3, new SetLinkUseBomb(gom.link));

            keyboardController.RegisterCommandHold(Keys.S, new SetLinkMovingDown(gom.link));
            keyboardController.RegisterCommandHold(Keys.W, new SetLinkMovingUp(gom.link));
            keyboardController.RegisterCommandHold(Keys.A, new SetLinkMovingLeft(gom.link));
            keyboardController.RegisterCommandHold(Keys.D, new SetLinkMovingRight(gom.link));

            keyboardController.RegisterCommandTap(Keys.E, new SetLinkDamagedDown(gom.link));

            keyboardController.RegisterCommandHold(Keys.Down, new SetLinkMovingDown(gom.link));
            keyboardController.RegisterCommandHold(Keys.Up, new SetLinkMovingUp(gom.link));
            keyboardController.RegisterCommandHold(Keys.Left, new SetLinkMovingLeft(gom.link));
            keyboardController.RegisterCommandHold(Keys.Right, new SetLinkMovingRight(gom.link));

            keyboardController.RegisterCommandHold(Keys.Q, new QuitCommand(this));
            keyboardController.RegisterCommandHold(Keys.R, new ResetGame(this));
        }

        protected override void Update(GameTime gameTime)
        {
            // Pretty sure we were told last Sprint that we didn't need this.
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (IController controller in controllerList)
            {
                controller.update();
            }

            //link.Update(gameTime);
            
            //enemiesList.Update(gameTime);

            gom.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();
            //link.Draw(spriteBatch);
            
            //item.Draw(spriteBatch);

            //block.Draw(spriteBatch);

            //enemiesList.Draw(spriteBatch);

            gom.Draw(spriteBatch);

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        internal void Reset()
        {
            // new link, enemy, block, item
            this. Initialize();
        }
    }
}
