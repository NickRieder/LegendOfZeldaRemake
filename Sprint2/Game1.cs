using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml;
using System.Collections;
using System.IO;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Sprint2.GameStates;

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
        public Camera camera;

        private SoundEffect themeSong;
        private SoundEffectInstance themeSongLoop;
        // For the Camera class
        public static int ScreenHeight;
        public static int ScreenWidth;

        private WinningState winningState;



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
            soundFactory = new SoundFactory(this.Content);

            controllerList = new ArrayList();

            keyboardController = new KeyboardController();
            controllerList.Add(keyboardController);

            gom = new GameObjectManager();
            levelLoader = new LevelLoader(gom, spriteFactory, soundFactory);

            controllerList.Add(gom.mouseController);

            collisionDetector = new CollisionDetector(gom);

            camera = new Camera();



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


            gom.SetSoundContent(soundFactory);


            levelLoader.LoadLevel("TestLevel", "Top");



            keyboardController.Initialize(gom, this, soundFactory, winningState);
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
            GraphicsDevice.Clear(Color.Green);

            spriteBatch.Begin(transformMatrix: camera.transform);

            gom.Draw(spriteBatch);
            hud.Draw(spriteBatch);

            spriteBatch.End();


            base.Draw(gameTime);
        }

        internal void Reset()
        {
            // new link, enemy, block, item
            this.Initialize();
        }
    }
}