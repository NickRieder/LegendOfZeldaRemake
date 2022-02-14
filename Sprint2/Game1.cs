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
        public LinkSpriteFactory linkSpriteFactory;
        public EnemySpriteFactory enemySpriteFactory;
        public Link link;
        public Enemies bluebatEnemy;
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

            enemySpriteFactory.LoadSpriteSheet();
            bluebatEnemy = new Enemies(enemySpriteFactory);
            bluebatEnemy.setEnemyType(new BluebatDown(this));

            keyboardController.RegisterCommand(Keys.S, new SetLinkMovingDown(link));
            keyboardController.RegisterCommand(Keys.W, new SetLinkMovingUp(link));
            keyboardController.RegisterCommand(Keys.A, new SetLinkMovingLeft(link));
            keyboardController.RegisterCommand(Keys.D, new SetLinkMovingRight(link));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            foreach (IController controller in controllerList)
            {
                controller.update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();
            link.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
