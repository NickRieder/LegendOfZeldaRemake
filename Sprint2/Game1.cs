using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml;
using System.Collections;
using System.IO;
<<<<<<< HEAD
using Sprint2.Controller;
=======
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
>>>>>>> origin/Sprint4

namespace Sprint2
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public Rectangle windowRectangle;
        private SpriteFactory spriteFactory;
        private SoundFactory soundFactory;
        private ArrayList controllerList;
        private KeyboardController keyboardController;
        private GameObjectManager gom;
        private LevelLoader levelLoader;
        private CollisionDetector collisionDetector;

        private HUD hud;
<<<<<<< HEAD
        private GamePadController GamePadController;
=======
        public Camera camera;

        private SoundEffect themeSong;
        private SoundEffectInstance themeSongLoop;
        // For the Camera class
        public static int ScreenHeight;
        public static int ScreenWidth;

>>>>>>> origin/Sprint4


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            windowRectangle = this.Window.ClientBounds;
        }

        protected override void Initialize()
        {
            /// Sizes of sprites (before x3 scale multiplier is applied).
            /// These could be changed into constants later.
            /// Sprite : (width, height)
            /// Room : (256, 176)
            /// HUD : (256, 56)
            

            graphics.PreferredBackBufferWidth = 766;
            graphics.PreferredBackBufferHeight = 696;
            graphics.ApplyChanges();

            // For the Camera class
            ScreenHeight = graphics.PreferredBackBufferHeight;
            ScreenWidth = graphics.PreferredBackBufferWidth;

            System.Diagnostics.Debug.WriteLine(
                "DEBUG: Window Size"
                + "\n ScreenWidth = " + ScreenWidth
                + "\n ScreenHeight = " + ScreenHeight);

            // TODO: Add your initialization logic here

            spriteFactory = new SpriteFactory(this.Content);
<<<<<<< HEAD
            gom = new GameObjectManager();
=======
            soundFactory = new SoundFactory(this.Content);
>>>>>>> origin/Sprint4

            // controllers
            controllerList = new ArrayList();
            keyboardController = new KeyboardController();
            GamePadController = new GamePadController();
            controllerList.Add(keyboardController);
            controllerList.Add(gom.mouseController);
            controllerList.Add(GamePadController);

<<<<<<< HEAD
            levelLoader = new LevelLoader(gom, spriteFactory);
=======
            gom = new GameObjectManager();
            levelLoader = new LevelLoader(gom, spriteFactory,soundFactory);
>>>>>>> origin/Sprint4

            collisionDetector = new CollisionDetector(gom);

<<<<<<< HEAD
=======
            camera = new Camera();
            


>>>>>>> origin/Sprint4
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            spriteFactory.LoadSpriteSheets();
            soundFactory.LoadSounds();        
            themeSong = soundFactory.getThemeSong();
            themeSongLoop = themeSong.CreateInstance();
            themeSongLoop.IsLooped = true;
            themeSongLoop.Play();
           
            gom.spriteFactory = spriteFactory;
            gom.soundFactory = soundFactory;

            gom.SetSpriteContent(spriteFactory);

            hud = new HUD(gom, spriteFactory);

<<<<<<< HEAD
            levelLoader.LoadLevel("TestLevel", "Top");

            keyboardController.Initialize(gom.link, gom.item, gom.block, this);
=======

            gom.SetSoundContent(soundFactory);


            levelLoader.LoadLevel("TestLevel", "Top");

            

            keyboardController.Initialize(gom, this, soundFactory);
>>>>>>> origin/Sprint4
        }

        protected override void Update(GameTime gameTime)
        {

            foreach (IController controller in controllerList)
            {
                controller.Update(gameTime);
            }

            gom.Update(gameTime);
            collisionDetector.Update(gameTime);
            hud.Update(gameTime);

            camera.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(transformMatrix: camera.transform);

            gom.Draw(spriteBatch);
            hud.Draw(spriteBatch);

            spriteBatch.End();
         

            base.Draw(gameTime);
        }

        internal void Reset()
        {
            // new link, enemy, block, item
            this. Initialize();
        }
    }
}
