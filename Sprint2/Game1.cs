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
        private SpriteFactory spriteFactory;
        private ArrayList controllerList;
        private KeyboardController keyboardController;
        private GameObjectManager gom;
        private CollisionDetector collisionDetector;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            spriteFactory = new SpriteFactory(this.Content);

            controllerList = new ArrayList();
            
            keyboardController = new KeyboardController();
            controllerList.Add(keyboardController);

            gom = new GameObjectManager();

            collisionDetector = new CollisionDetector(gom);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            spriteFactory.LoadSpriteSheets();

            gom.spriteFactory = spriteFactory;

            if (gom.spriteFactory != null)
            {
                System.Diagnostics.Debug.WriteLine("DEBUG: " + gom.spriteFactory.getArrowSpriteDown().getDestinationRectangle().X);
                System.Diagnostics.Debug.WriteLine("DEBUG: " + gom.spriteFactory.getArrowSpriteDown().getDestinationRectangle().Y);
            }

            gom.SetSpriteContent(spriteFactory);

            keyboardController.Initialize(gom.link, gom.item, gom.block, gom.enemiesList, this);
        }

        protected override void Update(GameTime gameTime)
        {
            // Pretty sure we were told last Sprint that we didn't need this.
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (IController controller in controllerList)
            {
                controller.Update(gameTime);
            }

            gom.Update(gameTime);
            collisionDetector.Update(gameTime);

            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();

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
