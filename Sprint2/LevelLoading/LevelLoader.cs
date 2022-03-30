using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class LevelLoader
    {
        private GameObjectManager gom;
        private SpriteFactory spriteFactory;
        private SoundFactory soundFactory;
        private string doorType;
        private Link link;
        private MouseController mouse;
        public LevelLoader(GameObjectManager gom, SpriteFactory spriteFactory, SoundFactory soundFactory)
        {
            this.gom = gom;
            this.link = gom.link;
            this.spriteFactory = spriteFactory;
            this.soundFactory = soundFactory;
            doorType = "Right";
        }

        public void LoadLevel(String fileName, string doorType)
        {
            gom.ClearSpriteList();
            LoadLink(doorType);
            XMLParser parser = new XMLParser(this);
            parser.parseFile(fileName);
            gom.SetSpriteContent(spriteFactory);
        }

        public void LoadLink(string doorType)
        {
            link.SetSpriteContent(spriteFactory);
            switch (doorType)
            {
                case "Top":
                    link.SetPos(SpriteFactory.LINK_BOTTOM_POS);
                    link.currState = new StandingFacingUp(link);
                    break;
                case "Bottom":
                    link.SetPos(SpriteFactory.LINK_TOP_POS);
                    link.currState = new StandingFacingDown(link);
                    break;
                case "Left":
                    link.SetPos(SpriteFactory.LINK_RIGHT_POS);
                    link.currState = new StandingFacingLeft(link);
                    break;
                case "Right":
                    link.SetPos(SpriteFactory.LINK_LEFT_POS);
                    link.currState = new StandingFacingRight(link);
                    break;
                default:
                    link.SetPos(SpriteFactory.LINK_RIGHT_POS);
                    link.currState = new StandingFacingLeft(link);
                    break;

            }
            gom.AddToAllObjectList(link);
            gom.AddToDrawableObjectList(link);
            gom.AddToMovableObjectList(link);
        }

        public void LoadBlockObject(String blockType, Vector2 pos)
        {
            Block block = new Block(blockType, pos);
            block.SetSpriteContent(spriteFactory);

            gom.AddToAllObjectList(block);
            gom.AddToDrawableObjectList(block);
        }

        public void LoadEnemyObject(String enemyName, Vector2 pos)
        {
            Enemies enemy = new Enemies(enemyName);
            enemy.pos = pos;
            enemy.SetSpriteContent(spriteFactory);
            enemy.SetSoundContent(soundFactory);
            gom.AddToAllObjectList(enemy);
            gom.AddToDrawableObjectList(enemy);
            gom.AddToMovableObjectList(enemy);
        }

        public void LoadDoorObject(String doorType, Vector2 pos, String room, String prevRoom)
        {
            Door door = new Door(doorType, room, this, prevRoom);
            door.pos = pos;
            door.SetSpriteContent(spriteFactory);
            gom.mouseController.SetDoor(door);
            gom.AddToAllObjectList(door);
            gom.AddToDrawableObjectList(door);
        }

        public void LoadBackground(string roomName)
        {
            gom.SetBackgroundRoom(roomName);
        }

        public void LoadWall(Rectangle rect, Vector2 pos)
        {
            Sprite sprite = spriteFactory.getWallSprite(rect);
            Wall wall = new Wall(sprite, pos);
            gom.AddToAllObjectList(wall);
            gom.AddToDrawableObjectList(wall);
        }
    }
}
