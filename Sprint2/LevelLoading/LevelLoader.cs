using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class LevelLoader
    {
        private GameObjectManager gom;
        private SpriteFactory spriteFactory;
        private string doorType;
        private Link link;
        public LevelLoader(GameObjectManager gom, SpriteFactory spriteFactory)
        {
            this.gom = gom;
            this.link = gom.link;
            this.spriteFactory = spriteFactory;
            doorType = "Right";
        }

        public void LoadLevel(String fileName, string doorType)
        {
            //gom.ClearSpriteList();
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
            gom.AddToMovableObjectList(link);
        }

        public void LoadBlockObject(String blockType, Vector2 pos)
        {
            Block block = new Block(blockType, pos);
            block.SetSpriteContent(spriteFactory);

            gom.AddToAllObjectList(block);
        }

        public void LoadEnemyObject(String enemyName, Vector2 pos)
        {
            Enemies enemy = new Enemies(enemyName);
            enemy.pos = pos;
            enemy.SetSpriteContent(spriteFactory);

            gom.AddToAllObjectList(enemy);
            gom.AddToMovableObjectList(enemy);
        }

        public void LoadDoorObject(String doorType, Vector2 pos, String room)
        {
            Door door = new Door(doorType, room, this);
            door.pos = pos;
            door.SetSpriteContent(spriteFactory);

            gom.AddToAllObjectList(door);
        }

        public void LoadBackground(string roomName)
        {
            gom.SetBackgroundRoom(roomName);
        }
    }
}
