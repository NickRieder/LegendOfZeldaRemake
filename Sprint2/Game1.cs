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

        private SoundEffect themeSong;
        private SoundEffectInstance themeSongLoop;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            windowRectangle = this.Window.ClientBounds;
        }

        protected override void Initialize()
        {

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 700;
            graphics.ApplyChanges();

            // TODO: Add your initialization logic here

            spriteFactory = new SpriteFactory(this.Content);
            soundFactory = new SoundFactory(this.Content);

            controllerList = new ArrayList();
            
            keyboardController = new KeyboardController();
            controllerList.Add(keyboardController);

            gom = new GameObjectManager();
            levelLoader = new LevelLoader(gom, spriteFactory,soundFactory);

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

            hud = new HUD(gom, spriteFactory);


            gom.SetSoundContent(soundFactory);


            levelLoader.LoadLevel("TestLevel", "Top");

          
            keyboardController.Initialize(gom.link, gom.item, gom.block, this, soundFactory);
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

            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

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
