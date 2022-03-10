using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class LevelLoader
    {
        private GameObjectManager gom;
        private SpriteFactory spriteFactory;
        private Game1 game;
        public LevelLoader(GameObjectManager gom, SpriteFactory spriteFactory)
        {
            this.gom = gom;
            this.spriteFactory = spriteFactory;
        }

        public void LoadLevel(String fileName)
        {
            //gom.ClearSpriteList();
            XMLParser parser = new XMLParser(this);
            parser.parseFile(fileName);
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
            gom.SetSpriteContent(spriteFactory);
        }
    }
}
