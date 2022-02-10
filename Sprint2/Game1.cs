using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Sprint2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private LinkSpriteFactory linkSpriteFactory;
        private Link link;
        

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
            link = new Link(linkSpriteFactory);
            base.Initialize();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //linkSpriteFactory.LoadSpriteSheet(this.Content);

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

            link.Update();

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
