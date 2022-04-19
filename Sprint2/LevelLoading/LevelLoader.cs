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
        private string itemName;
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
            gom.SetSpriteContent(spriteFactory);
            gom.SetSoundContent(soundFactory);
            LoadLink(doorType);
            XMLParser parser = new XMLParser(this);
            parser.parseFile(fileName);
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
                case "TopOpen":
                    link.SetPos(SpriteFactory.LINK_BOTTOM_POS);
                    link.currState = new StandingFacingUp(link);
                    break;
                case "BotOpen":
                    link.SetPos(SpriteFactory.LINK_TOP_POS);
                    link.currState = new StandingFacingDown(link);
                    break;
                case "LeftOpen":
                    link.SetPos(SpriteFactory.LINK_RIGHT_POS);
                    link.currState = new StandingFacingLeft(link);
                    break;
                case "RightOpen":
                    link.SetPos(SpriteFactory.LINK_LEFT_POS);
                    link.currState = new StandingFacingRight(link);
                    break;
                case "TopLock":
                    link.SetPos(SpriteFactory.LINK_BOTTOM_POS);
                    link.currState = new StandingFacingUp(link);
                    break;
                case "BotLock":
                    link.SetPos(SpriteFactory.LINK_TOP_POS);
                    link.currState = new StandingFacingDown(link);
                    break;
                case "LeftLock":
                    link.SetPos(SpriteFactory.LINK_RIGHT_POS);
                    link.currState = new StandingFacingLeft(link);
                    break;
                case "RightLock":
                    link.SetPos(SpriteFactory.LINK_LEFT_POS);
                    link.currState = new StandingFacingRight(link);
                    break;
                case "TopWall":

                    break;
                case "BotWall":

                    break;
                case "LeftWall":

                    break;
                case "RightWall":

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

        public void LoadItemObject(String itemName, Vector2 pos)
        {
            Item item = new Item(itemName, pos, gom);
            item.SetSpriteContent(spriteFactory);
            item.SetSoundContent(soundFactory);

            gom.AddToAllObjectList(item);
            gom.AddToDrawableObjectList(item);
            gom.AddToUpdatableObjectList(item);
        }

        public void LoadEnemyObject(String enemyName, Vector2 pos)
        {
            Enemies enemy = new Enemies(enemyName, gom);
            enemy.pos = pos;
            enemy.SetSpriteContent(spriteFactory);
            enemy.SetSoundContent(soundFactory);
            gom.AddToAllObjectList(enemy);
            gom.AddToDrawableObjectList(enemy);
            gom.AddToMovableObjectList(enemy);
        }

        public void LoadDoorObject(String doorType, Vector2 pos, String room, String prevRoom, String nextClickRoom)
        {
            Door door = new Door(doorType, room, this, prevRoom, nextClickRoom);
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