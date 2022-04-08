using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml;
using System.Collections;
using System.IO;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Sprint2
{
    public class Game1 : Game
    {
        public enum GAME_WINDOW : int
        {
            WIDTH = 765,
            HEIGHT = 630,
            ROOM_WIDTH = 765,
            ROOM_HEIGHT = 528,
            HUD_WIDTH = 765
        }

        /*public const int GAME_WINDOW_WIDTH = 765;
        public const int GAME_WINDOW_HEIGHT = 633;*/

        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public Rectangle windowRectangle;
        private SpriteFactory spriteFactory;
        private SoundFactory soundFactory;
        private ArrayList controllerList;
        private KeyboardController keyboardController;
        public GameObjectManager gom;
        private LevelLoader levelLoader;
        private CollisionDetector collisionDetector;

        private HUD hud;
        public Camera camera;

        private SoundEffect themeSong;
        private SoundEffectInstance themeSongLoop;
        // For the Camera class
        public static int ScreenHeight;
        public static int ScreenWidth;



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
            
            // Game window size
            graphics.PreferredBackBufferWidth = (int)GAME_WINDOW.WIDTH;
            graphics.PreferredBackBufferHeight = (int)GAME_WINDOW.HEIGHT;
            graphics.ApplyChanges();

            // For the Camera class
            ScreenHeight = graphics.PreferredBackBufferHeight;
            ScreenWidth = graphics.PreferredBackBufferWidth;

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
            gom.SetSoundContent(soundFactory);


            levelLoader.LoadLevel("Level 0/L0R1", "Top");
            camera = new Camera(gom);
            hud = new HUD(this, spriteFactory);
            

            keyboardController.Initialize(gom, this, soundFactory);
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
            camera.Draw(spriteBatch);
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
