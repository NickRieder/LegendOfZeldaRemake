using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class Camera
    {
        public enum CAMERA_SETTING : int
        {
            STARTING_X_POS = 0,
            STARTING_Y_POS = 0,
            START_ANIMATION = 0,
            STOP_VERTICAL_ANIMATION = (int)Game1.GAME_WINDOW.ROOM_HEIGHT,
            STOP_HORIZONTAL_ANIMATION = (int)Game1.GAME_WINDOW.ROOM_WIDTH
        }

        public int xPos { get; set; }
        public int yPos { get; set; }

        private GameTime gameTime;
        public ICameraState currState;
        public Matrix transform;
        public Viewport view;
        public Vector2 center;
        private Sprite topRoomSprite;
        private Sprite bottomRoomSprite;
        private Sprite leftRoomSprite;
        private Sprite rightRoomSprite;
        private Vector2 topRoomSpritePos = new Vector2(0, -(int)Game1.GAME_WINDOW.ROOM_HEIGHT);
        private Vector2 bottomRoomSpritePos = new Vector2(0, (int)Game1.GAME_WINDOW.ROOM_HEIGHT);
        private Vector2 leftRoomSpritePos = new Vector2(-(int)Game1.GAME_WINDOW.ROOM_WIDTH, 0);
        private Vector2 rightRoomSpritePos = new Vector2((int)Game1.GAME_WINDOW.ROOM_WIDTH, 0);

        public GameObjectManager gom;
        private SpriteFactory spriteFactory;

        public Camera(GameObjectManager gom)    // , Viewport newView
        {
            this.gom = gom;
            //this.spriteFactory = gom.spriteFactory;

            //view = newView;

            // Initialize starting camera position
            xPos = (int)CAMERA_SETTING.STARTING_X_POS;
            yPos = (int)CAMERA_SETTING.STARTING_Y_POS;

            // Empty room sprites that border the main center room. Used for camera to scroll over to it.
            /*topRoomSprite = spriteFactory.getEmptyRoomSprite();
            bottomRoomSprite = spriteFactory.getEmptyRoomSprite();
            leftRoomSprite = spriteFactory.getEmptyRoomSprite();
            rightRoomSprite = spriteFactory.getEmptyRoomSprite();*/

            currState = new StaticCamera(this, xPos, yPos);
        }

        public void SetSpriteContent(SpriteFactory spriteFactory)
        {
            this.spriteFactory = spriteFactory;

            // Empty room sprites that border the main center room. Used for camera to scroll over to it.
            topRoomSprite = spriteFactory.getEmptyRoomSprite();
            bottomRoomSprite = spriteFactory.getEmptyRoomSprite();
            leftRoomSprite = spriteFactory.getEmptyRoomSprite();
            rightRoomSprite = spriteFactory.getEmptyRoomSprite();
        }

        public void FreezeCamera(int xPos, int yPos)
        {
            currState.FreezeCamera(xPos, yPos);
        }

        public void AnimateRoomTransition(string direction) // pass in the side of the door later
        {
            currState.AnimateRoomTransition(direction);
        }

        public void Update(GameTime gameTime)
        {
            
            currState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            topRoomSprite.Draw(spriteBatch, topRoomSpritePos);
            bottomRoomSprite.Draw(spriteBatch, bottomRoomSpritePos);
            leftRoomSprite.Draw(spriteBatch, leftRoomSpritePos);
            rightRoomSprite.Draw(spriteBatch, rightRoomSpritePos);

            //currState.Draw(spriteBatch);
        }

        public void AnimateWinningState(string direction, SpriteFactory spriteFactory, SpriteBatch spriteBatch)
        {
            currState.AnimateWinningState(direction, spriteFactory, spriteBatch);
        }
    }
}
