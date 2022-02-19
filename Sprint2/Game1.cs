﻿using Microsoft.Xna.Framework;
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
        public Link link;
        private Item item;
        private Block block;
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
            blockSpriteFactory = new BlockSpriteFactory(this.Content);
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

            blockSpriteFactory.LoadSpriteSheet();
            block = new Block(blockSpriteFactory);
            enemySpriteFactory.LoadSpriteSheet();
            enemiesList = new EnemiesList(enemySpriteFactory);

            keyboardController.RegisterCommandTap(Keys.I, new SetNextItem(item));
            keyboardController.RegisterCommandTap(Keys.U, new SetPreviousItem(item));
            
            keyboardController.RegisterCommandTap(Keys.Z, new SetLinkAttacking(link));
            keyboardController.RegisterCommandTap(Keys.N, new SetLinkAttacking(link));

            keyboardController.RegisterCommandTap(Keys.Y, new SetNextBlock(block));
            keyboardController.RegisterCommandTap(Keys.T, new SetPreviousBlock(block));

            keyboardController.RegisterCommandTap(Keys.P, new SetNextEnemy(enemiesList));
            keyboardController.RegisterCommandTap(Keys.O, new SetPreviousEnemy(enemiesList));

            keyboardController.RegisterCommandTap(Keys.D1, new SetLinkUseArrow(link));
            keyboardController.RegisterCommandTap(Keys.D2, new SetLinkUseBoomerang(link));
            keyboardController.RegisterCommandTap(Keys.D3, new SetLinkUseBomb(link));

            keyboardController.RegisterCommandHold(Keys.S, new SetLinkMovingDown(link));
            keyboardController.RegisterCommandHold(Keys.W, new SetLinkMovingUp(link));
            keyboardController.RegisterCommandHold(Keys.A, new SetLinkMovingLeft(link));
            keyboardController.RegisterCommandHold(Keys.D, new SetLinkMovingRight(link));

            keyboardController.RegisterCommandTap(Keys.E, new SetLinkDamagedDown(link));

            keyboardController.RegisterCommandHold(Keys.Down, new SetLinkMovingDown(link));
            keyboardController.RegisterCommandHold(Keys.Up, new SetLinkMovingUp(link));
            keyboardController.RegisterCommandHold(Keys.Left, new SetLinkMovingLeft(link));
            keyboardController.RegisterCommandHold(Keys.Right, new SetLinkMovingRight(link));

            keyboardController.RegisterCommandHold(Keys.Q, new QuitCommand(this));
            keyboardController.RegisterCommandHold(Keys.R, new ResetGame(this));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (IController controller in controllerList)
            {
                controller.update();
            }
            
            link.Update(gameTime);
            enemiesList.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();
            link.Draw(spriteBatch);
            item.Draw(spriteBatch);

            block.Draw(spriteBatch);

            enemiesList.Draw(spriteBatch);

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
