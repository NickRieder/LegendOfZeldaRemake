using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class LevelLoader
    {
        private GameObjectManager gom;
        private SpriteFactory spriteFactory;
        public LevelLoader(GameObjectManager gom, SpriteFactory spriteFactory)
        {
            this.gom = gom;
            this.spriteFactory = spriteFactory;
        }

        public void LoadLevel(String fileName)
        {
            gom.ClearSpriteList();
            XMLParser parser = new XMLParser(this);
            parser.parseFile(fileName);
        }

        public void LoadBlockObject(String blockType, Vector2 pos)
        {
            Sprite blockSprite;
            Block block;
            switch(blockType)
            {
                case "Flat Block":
                    blockSprite = spriteFactory.getFlatBlockSprite();
                    break;
                case "Brick Block":
                    blockSprite = spriteFactory.getBrickBlockSprite();
                    break;
                default:
                    blockSprite = spriteFactory.getFlatBlockSprite();
                    break;
            }
            
            block = new Block(blockSprite, pos);
            
            gom.AddToSpriteList(block);
        }

        public void LoadEnemyObject(String enemyType, Vector2 pos)
        {
            Sprite enemySprite;
            Enemies enemy = new Enemies();
            switch (enemyType)
            {
                case "Goriya":
                    //enemy.setEnemyType(new GoriyaStandingFacingLeft());
                    break;
                case "Bluebat":
                    //enemy.setEnemyType(new BluebatLeft());
                    break;
                case "Darknut":
                    //enemy.setEnemyType(new DarknutFacingDown());
                    break;
                case "Dragon":
                    //enemy.setEnemyType(new DragonStandingFacingLeft());
                    break;
                case "Snake":
                    //enemy.setEnemyType(new SnakeLeft());
                    break;
                case "Wizzrobe":
                    //enemy.setEnemyType(new WizzrobeLeft());
                    break;
                default:
                    break;
            }


        }

        public void LoadDoorObject(String doorType, Vector2 pos, String room)
        {
            Sprite sprite;
            Door door;
            switch(doorType)
            {
                case "Top Door":
                    sprite = spriteFactory.getTopDoorSprite();
                    break;
                default:
                    sprite = spriteFactory.getTopDoorSprite();
                    break;
                   
            }

            door = new Door(sprite, pos, room, this);
            gom.AddToSpriteList(door);
        }
    }
}
