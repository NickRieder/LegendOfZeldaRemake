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
        public enum GAME_WINDOW : int
        {
            WIDTH = 765,
            HEIGHT = 630,
            ROOM_WIDTH = 765,
            ROOM_HEIGHT = 528,
            HUD_WIDTH = 765
        }

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
        private RoomGenerator roomGenerator;
        private RoomWriter roomWriter;

        private HUD hud;
        public Camera camera;

        public SoundEffect themeSong;
        public SoundEffectInstance themeSongLoop;

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

            gom = new GameObjectManager(this);
            
            roomGenerator = new RoomGenerator();
            roomWriter = new RoomWriter(roomGenerator);
            levelLoader = new LevelLoader(gom, spriteFactory, soundFactory, roomWriter);


            controllerList.Add(gom.mouseController);
            controllerList.Add(keyboardController);


            collisionDetector = new CollisionDetector(gom);



            base.Initialize();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            soundFactory.LoadSounds();

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

            levelLoader.LoadLevel("EndlessRooms/EndlessRoomDefault", "Left");
            //roomGenerator.GenerateRandomRoom(25);
            //roomWriter.generateRandomRoom("EndlessRoom1");

            keyboardController.Initialize(gom, this, soundFactory, spriteFactory, spriteBatch);


        }

        protected override void Update(GameTime gameTime)
        {

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
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(transformMatrix: gom.camera.transform);

            gom.Draw(spriteBatch);
            //hud.Draw(spriteBatch);

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void Reset()
        {
            // new link, enemy, block, item
            this.Initialize();
        }
    }
}