using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml;
using System.Collections;
using System.IO;

namespace Sprint2
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public Rectangle windowRectangle;
        private SpriteFactory spriteFactory;
        private ArrayList controllerList;
        private KeyboardController keyboardController;
        private MouseController mouseController;
        private GameObjectManager gom;
        private LevelLoader levelLoader;
        private CollisionDetector collisionDetector;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            windowRectangle = this.Window.ClientBounds;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            spriteFactory = new SpriteFactory(this.Content);

            controllerList = new ArrayList();
            
            keyboardController = new KeyboardController();
            controllerList.Add(keyboardController);

            gom = new GameObjectManager();
            levelLoader = new LevelLoader(gom, spriteFactory);

            Door door = new Door("Top", "TestLevel2", levelLoader, "TestLevel");
            mouseController = new MouseController(door);
            controllerList.Add(mouseController);

            collisionDetector = new CollisionDetector(gom);
            //levelLoader = new LevelLoader(gom, spriteFactory);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            spriteFactory.LoadSpriteSheets();

            gom.spriteFactory = spriteFactory;

            gom.SetSpriteContent(spriteFactory);

            levelLoader.LoadLevel("TestLevel", "Top");

            

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
