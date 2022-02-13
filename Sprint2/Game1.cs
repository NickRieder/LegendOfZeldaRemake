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
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private LinkSpriteFactory linkSpriteFactory;
        private Link link;
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
            keyboardController.RegisterCommand(Keys.S, new SetLinkMovingDown(link));

            // PROBLEM:
            // Putting this line of code into the Initialize() function throws an error
            // because link = new Link(linkSpriteFactory) doesn't know what linkSpriteFactory is yet until the game runs the LoadContent() function.
            // SOLUTION:
            // We create a LinkSpriteFactory constructor that loads the sprite sheet upon the initialization of a LinkSpriteFactory object.
            // link = new Link(linkSpriteFactory);
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
