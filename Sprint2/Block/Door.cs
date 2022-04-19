using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class Door : ISprite
    {
        public Vector2 pos { get; set; }
        public SpriteFactory spriteFactory;
        private string nextLevel; // why is the string type have "S" capitalized?
        private string prevRoom;
        private string nextClickRoom;

        private LevelLoader levelLoader;

        public Sprite sprite;
        public string doorType;
        public bool canContinue;

        private const int initialDoorPosX = 100;
        private const int initialDoorPosY = 500;
        public Door(string doorType, String nextLevel, LevelLoader levelLoader, String prevRoom, String nextClickRoom) 
        {
            pos = new Vector2(initialDoorPosX, initialDoorPosY);
            this.nextLevel = nextLevel;
            this.levelLoader = levelLoader;
            this.prevRoom = prevRoom;
            this.nextClickRoom = nextClickRoom;
            this.doorType = doorType;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch, pos);
        }

        public void SetSpriteContent(SpriteFactory spriteFactory)
        {
            this.spriteFactory = spriteFactory;

            switch (doorType)
            {
                case "TopOpen":
                    sprite = spriteFactory.getTopDoorOpenSprite();
                    canContinue = true;
                    break;
                case "BotOpen":
                    sprite = spriteFactory.getBottomDoorOpenSprite();
                    canContinue = true;
                    break;
                case "LeftOpen":
                    sprite = spriteFactory.getLeftDoorOpenSprite();
                    canContinue = true;
                    break;
                case "RightOpen":
                    sprite = spriteFactory.getRightDoorOpenSprite();
                    canContinue = true;
                    break;
                case "TopWall":
                    sprite = spriteFactory.getTopDoorClosedSprite();
                    canContinue = false;
                    break;
                case "BotWall":
                    sprite = spriteFactory.getBottomDoorClosedSprite();
                    canContinue = false;
                    break;
                case "LeftWall":
                    sprite = spriteFactory.getLeftDoorClosedSprite();
                    canContinue = false;
                    break;
                case "RightWall":
                    sprite = spriteFactory.getRightDoorClosedSprite();
                    canContinue = false;
                    break;
                case "TopLock":
                    sprite = spriteFactory.getTopDoorLockedSprite();
                    canContinue = false;
                    break;
                case "BotLock":
                    sprite = spriteFactory.getBottomDoorLockedSprite();
                    canContinue = false;
                    break;
                case "LeftLock":
                    sprite = spriteFactory.getLeftDoorLockedSprite();
                    canContinue = false;
                    break;
                case "RightLock":
                    sprite = spriteFactory.getRightDoorLockedSprite();
                    canContinue = false;
                    break;
                default:
                    sprite = spriteFactory.getTopDoorClosedSprite();
                    break;

            }
        }
        public void SetSoundContent(SoundFactory soundFactory)
        {

        }

        public static explicit operator Door(Type v)
        {
            throw new NotImplementedException();
        }

        public Rectangle GetSpriteRectangle()
        {
            return sprite.getDestinationRectangle();
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void LoadNextLevel()
        {
            if (canContinue)
            {
                levelLoader.LoadLevel(nextLevel, doorType);
            }
            
        }

        public void LoadNextRoom()
        {
            levelLoader.LoadLevel(nextClickRoom, "Right");
        }

        public void LoadPreviousRoom()
        {
            levelLoader.LoadLevel(prevRoom, "Left");
        }

        public Door GetConcreteObject()
        {
            return this;
        }

        object ISprite.GetConcreteObject()
        {
            return this;
        }

       
    }
}
