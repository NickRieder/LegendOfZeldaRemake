using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Sprint2
{
    public class SpriteFactory : ISpriteFactory
    {
        private static Texture2D tileSheet;
        private ContentManager content;

        private static Texture2D enemySheet;
        private static Texture2D enemySheet2;
        private static Texture2D enemySheet3;
        private static Texture2D enemySheetMirror;
        private static Texture2D enemySheet2Mirror;
        private static Texture2D linkSheetUpsideDown;

        private static Texture2D linkSheetFlipped;
        private static Texture2D linkSheet;
        private static Texture2D itemSheet;

        private static Texture2D linkSheetMirrored;

        public SpriteFactory(ContentManager content)
        {
            this.content = content;
        }

        public void LoadSpriteSheets()
        {
            tileSheet = content.Load<Texture2D>("Sheets/TileSheet");

            enemySheet = content.Load<Texture2D>("Sheets/EnemySheet");
            enemySheet2 = content.Load<Texture2D>("Sheets/EnemySheet2");
            enemySheet3 = content.Load<Texture2D>("Sheets/EnemySheet3");

            enemySheetMirror = content.Load<Texture2D>("Sheets/EnemySheetMirror");
            enemySheet2Mirror = content.Load<Texture2D>("Sheets/EnemySheet2Mirror");

            linkSheetUpsideDown = content.Load<Texture2D>("Sheets/LinkSheetUpsideDown");
            linkSheetFlipped = content.Load<Texture2D>("Sheets/LinkSheetUpsideDown");
            linkSheet = content.Load<Texture2D>("Sheets/LinkSheet");
            linkSheetMirrored = content.Load<Texture2D>("Sheets/LinkSheetMirror");

            itemSheet = content.Load<Texture2D>("Sheets/ItemSheet");

            


        }

        
        public Texture2D getTileSheet()
        {
            return tileSheet;
        }

        public Texture2D getEnemySheet1()
        {
            return enemySheet;
        }

        public Texture2D getEnemySheetMirror()
        {
            return enemySheetMirror;
        }

        public Texture2D getEnemySheet2()
        {
            return enemySheet2;
        }

        public Texture2D getEnemySheet2Mirror()
        {
            return enemySheet2Mirror;
        }

        public Texture2D getEnemySheet3()
        {
            return enemySheet3;
        }

        public Texture2D getLinkSheetUpsideDown()
        {
            return linkSheetUpsideDown;
        }

        public Texture2D getLinkSheetFlipped()
        {
            return linkSheetFlipped;
        }

        public Texture2D getLinkSheet()
        {
            return linkSheet;
        }
        public Texture2D getLinkSheetMirrored()
        {
            return linkSheetMirrored;
        }

        public Texture2D getItemSheet()
        {
            return itemSheet;
        }

        //Tiles
        public static Rectangle TILE_DOOR = new Rectangle(881, 25, 32, 18);
        public static Rectangle TILE_STAIRS = new Rectangle(1035, 28, 16, 16);
        public static Rectangle TILE_FLATBLOCK = new Rectangle(984, 11, 16, 16);
        public static Rectangle TILE_NONFLAT_BLOCK = new Rectangle(1001, 11, 16, 16);
        public static Rectangle TILE_BRICK_BLOCK = new Rectangle(984, 45, 16, 16);

        //Enemies
        public static Rectangle DRAGON_SHEET1_LEFT1 = new Rectangle(1, 11, 24, 32);
        public static Rectangle DRAGON_SHEET1_LEFT2 = new Rectangle(26, 11, 24, 32);
        public static Rectangle DRAGON_SHEET1_LEFT3 = new Rectangle(51, 11, 24, 32);
        public static Rectangle DRAGON_SHEET1_LEFT4 = new Rectangle(76, 11, 24, 32);
        public static Rectangle DRAGON_SHEET1_FIREBALL1 = new Rectangle(101, 11, 8, 16);
        public static Rectangle DRAGON_SHEET1_FIREBALL2 = new Rectangle(110, 11, 8, 16);
        public static Rectangle DRAGON_SHEET1_FIREBALL3 = new Rectangle(119, 11, 8, 16);
        public static Rectangle DRAGON_SHEET1_FIREBALL4 = new Rectangle(128, 11, 8, 16);

        public static Rectangle DRAGON_SHEET1MIRROR_RIGHT1 = new Rectangle(469, 11, 24, 32);
        public static Rectangle DRAGON_SHEET1MIRROR_RIGHT2 = new Rectangle(444, 11, 24, 32);
        public static Rectangle DRAGON_SHEET1MIRROR_RIGHT3 = new Rectangle(419, 11, 24, 32);
        public static Rectangle DRAGON_SHEET1MIRROR_RIGHT4 = new Rectangle(394, 11, 24, 32);

        public static Rectangle BOSS_SHEET1_1 = new Rectangle(40, 154, 32, 32);
        public static Rectangle BOSS_SHEET1_2 = new Rectangle(73, 154, 32, 32);
        public static Rectangle BOSS_SHEET1_3 = new Rectangle(106, 154, 32, 32);
        public static Rectangle BOSS_SHEET1_4 = new Rectangle(139, 154, 32, 32);
        public static Rectangle BOSS_SHEET1_5 = new Rectangle(172, 154, 32, 32);

        public static Rectangle BLUEBAT_SHEET2_POS1 = new Rectangle(183, 11, 16, 16);
        public static Rectangle BLUEBAT_SHEET2_POS2 = new Rectangle(200, 11, 16, 16);
        public static Rectangle BLUEGEL_SHEET2_POS1 = new Rectangle(19, 11, 8, 16);
        public static Rectangle BLUEGEL_SHEET2_POS2 = new Rectangle(28, 11, 8, 16);
        public static Rectangle GREENGEL_SHEET2_POS1 = new Rectangle(1, 28, 8, 16);
        public static Rectangle GREENGEL_SHEET2_POS2 = new Rectangle(10, 28, 8, 16);

        public static Rectangle DARKNUT_SHEET2_FRONT1 = new Rectangle(1, 90, 16, 16);
        public static Rectangle DARKNUT_SHEET2_FRONT2 = new Rectangle(18, 90, 16, 16);
        public static Rectangle DARKNUT_SHEET2_BACK = new Rectangle(35, 90, 16, 16);
        public static Rectangle DARKNUT_SHEET2_RIGHT1 = new Rectangle(52, 90, 16, 16);
        public static Rectangle DARKNUT_SHEET2_RIGHT2 = new Rectangle(69, 90, 16, 16);
        public static Rectangle DARKNUT_SHEET2MIRROR_LEFT1 = new Rectangle(372, 90, 16, 16);
        public static Rectangle DARKNUT_SHEET2MIRROR_LEFT2 = new Rectangle(389, 90, 16, 16);
        public static Rectangle DARKNUT_SHEET2MIRROR_BACK = new Rectangle(405, 90, 16, 16);


        public static Rectangle WIZZROBE_SHEET2_RIGHT1 = new Rectangle(126, 90, 16, 16);
        public static Rectangle WIZZROBE_SHEET2_RIGHT2 = new Rectangle(143, 90, 16, 16);
        public static Rectangle WIZZROBE_SHEET2_BACK1 = new Rectangle(160, 90, 16, 16);
        public static Rectangle WIZZROBE_SHEET2_BACK2 = new Rectangle(177, 90, 16, 16);
        public static Rectangle WIZZROBE_SHEET2MIRROR_LEFT1 = new Rectangle(298, 89, 16, 16);
        public static Rectangle WIZZROBE_SHEET2MIRROR_LEFT2 = new Rectangle(314, 89, 16, 16);

        public static Rectangle GORIYA_SHEET2_FRONT = new Rectangle(222, 11, 16, 16);
        public static Rectangle GORIYA_SHEET2_BACK = new Rectangle(239, 11, 16, 16);
        public static Rectangle GORIYA_SHEET2_RIGHT = new Rectangle(256, 11, 16, 16);
        public static Rectangle GORIYA_SHEET2_THROWRIGHT = new Rectangle(273, 11, 16, 16);

        public static Rectangle GORIYA_LINKSHEETUPSIDEDOWN_WEAPON1 = new Rectangle(298, 109, 8, 16);
        public static Rectangle GORIYA_LINKSHEETUPSIDEDOWN_WEAPON2 = new Rectangle(289, 109, 8, 16);
        public static Rectangle GORIYA_LINKSHEETUPSIDEDOWN_WEAPON3 = new Rectangle(280, 109, 8, 16);
        public static Rectangle GORIYA_SHEET2_WEAPON4 = new Rectangle(290, 11, 8, 16);
        public static Rectangle GORIYA_SHEET2_WEAPON5 = new Rectangle(299, 11, 8, 16);
        public static Rectangle GORIYA_SHEET2_WEAPON6 = new Rectangle(308, 11, 8, 16);

        public static Rectangle GORIYA_SHEET2MIRROR_LEFT = new Rectangle(185, 11, 16, 16);
        public static Rectangle GORIYA_SHEET2MIRROR_BACK = new Rectangle(201, 11, 16, 16);
        public static Rectangle GORIYA_SHEET2MIRROR_FRONT = new Rectangle(219, 11, 16, 16);
        public static Rectangle GORIYA_SHEET2MIRROR_THROWLEFT = new Rectangle(168, 11, 16, 16);
        public static Rectangle GORIYA_SHEET2MIRROR_WEAPONLEFT1 = new Rectangle(159, 11, 8, 16);
        public static Rectangle GORIYA_SHEET2MIRROR_WEAPONLEFT2 = new Rectangle(150, 11, 8, 16);
        public static Rectangle GORIYA_SHEET2MIRROR_WEAPONLEFT3 = new Rectangle(141, 11, 8, 16);

        public static Rectangle SNAKE_SHEET2_RIGHT1 = new Rectangle(126, 59, 16, 16);
        public static Rectangle SNAKE_SHEET2_RIGHT2 = new Rectangle(143, 59, 16, 16);
        public static Rectangle SNAKE_SHEET2MIRROR_LEFT1 = new Rectangle(315, 59, 16, 16);
        public static Rectangle SNAKE_SHEET2MIRROR_LEFT2 = new Rectangle(298, 59, 16, 16);

        //Items
        public static Rectangle ARROWORBOOMERANG_HIT = new Rectangle(89, 189, 7, 7);
        public static Rectangle ARROW_RIGHT = new Rectangle(9, 185, 15, 15);
        public static Rectangle ARROW_UP = new Rectangle(1, 185, 7, 15);
        public static Rectangle ARROW_UPSIDEDOWN_DOWN = new Rectangle(360, 108, 7, 7);
        public static Rectangle ARROW_MIRRORED_LEFT = new Rectangle(345, 185, 15, 15);


        public static Rectangle BOOMERANG_1 = new Rectangle(65, 189, 7, 7);
        public static Rectangle BOOMERANG_2 = new Rectangle(73, 189, 7, 7);
        public static Rectangle BOOMERANG_3 = new Rectangle(81, 189, 7, 7);

        public static Rectangle EXPLOSION_1 = new Rectangle(138, 185, 16, 16);
        public static Rectangle EXPLOSION_2 = new Rectangle(155, 185, 16, 16);
        public static Rectangle EXPLOSION_3 = new Rectangle(172, 185, 16, 16);

        // on ItemSheet
        public static Rectangle HEART_CANISTER = new Rectangle(25, 1, 14, 14);
        public static Rectangle WOODEN_SWORD = new Rectangle(104, 0, 8, 16);
        public static Rectangle MAGIC_SWORD = new Rectangle(104, 16, 8, 16);
        public static Rectangle BOW = new Rectangle(136, 16, 9, 17);
        public static Rectangle BOMB = new Rectangle(136, 0, 9, 14);
        public static Rectangle BOOMERANG = new Rectangle(129, 3, 6, 8);
        public static Rectangle RED_CANDLE = new Rectangle(160, 0, 8, 16);
        public static Rectangle BLUE_CANDLE = new Rectangle(160, 16, 8, 16);
        public static Rectangle ORANGE_RUBY = new Rectangle(71, 0, 9, 16);
        public static Rectangle BLUE_RUBY = new Rectangle(71, 16, 9, 16);

        //Link
        public static Rectangle LINK_MOVE_DOWN_1 = new Rectangle(1, 11, 16, 16);
        public static Rectangle LINK_MOVE_DOWN_2 = new Rectangle(18, 11, 16, 16);
        public static Rectangle LINK_MOVE_RIGHT_1 = new Rectangle(35, 11, 16, 16);
        public static Rectangle LINK_MOVE_RIGHT_2 = new Rectangle(52, 11, 16, 16);
        public static Rectangle LINK_MOVE_UP_1 = new Rectangle(69, 11, 16, 16);
        public static Rectangle LINK_MOVE_UP_2 = new Rectangle(86, 11, 16, 16);
        public static Rectangle LINK_MOVE_MIRROR_LEFT_1 = new Rectangle(320, 11, 16, 16);
        public static Rectangle LINK_MOVE_MIRROR_LEFT_2 = new Rectangle(303, 11, 16, 16);

        public static Rectangle LINK_PICKUP_ITEM_1 = new Rectangle(231, 11, 16, 16);
        public static Rectangle LINK_PICKUP_ITEM_2 = new Rectangle(248, 11, 16, 16);

        public static Rectangle LINK_USEITEM_DOWN = new Rectangle(107, 11, 16, 16);
        public static Rectangle LINK_USEITEM_RIGHT = new Rectangle(124, 11, 16, 16);
        public static Rectangle LINK_USEITEM_UP = new Rectangle(141, 11, 16, 16);
        public static Rectangle LINK_USEITEM_MIRROR_LEFT = new Rectangle(232, 11, 16, 16);

        public static Rectangle LINK_USESWORD_DOWN = new Rectangle(18, 47, 16, 27);
        public static Rectangle LINK_USESWORD_RIGHT = new Rectangle(18, 78, 27, 16);
        public static Rectangle LINK_USESWORD_UP = new Rectangle(18, 97, 16, 28);
        public static Rectangle LINK_USESWORD_MIRROR_LEFT = new Rectangle(326, 78, 27, 16);

        public static Rectangle LINK_DAMAGED_BLACK_AND_RED = new Rectangle(57, 223, 16, 16);
        public static Rectangle LINK_DAMAGED_GREEN_AND_PEACH = new Rectangle(74, 223, 16, 16);
        public static Rectangle LINK_DAMAGED_RED_AND_PEACH = new Rectangle(91, 223, 16, 16);
        public static Rectangle LINK_DAMAGED_PINKBACKGROUND = new Rectangle(109, 223, 16, 16);
        public static Rectangle LINK_DAMAGED_ALLBLUE = new Rectangle(74, 240, 16, 16);
        public static Rectangle LINK_DAMAGED_ALLGREEN = new Rectangle(91, 240, 16, 16);
        public static Rectangle LINK_DAMAGED_ALLORANGE = new Rectangle(108, 240, 16, 16);


        public Sprite getBoomerangSprite()
        {
            return new Sprite(linkSheet, BOOMERANG_1, BOOMERANG_2, BOOMERANG_3);
        }
        public Sprite getArrowSpriteRight()
        {
            return new Sprite(linkSheet, ARROW_RIGHT);
        }
        public Sprite getArrowSpriteUp()
        {
            return new Sprite(linkSheet, ARROW_UP);
        }
        public Sprite getArrowSpriteLeft()
        {
            return new Sprite(linkSheetMirrored, ARROW_MIRRORED_LEFT);
        }
        public Sprite getArrowSpriteDown()
        {
            return new Sprite(linkSheetUpsideDown, ARROW_UPSIDEDOWN_DOWN);
        }
        public Sprite getExplosionSprite()
        {

            return new Sprite(linkSheet, EXPLOSION_1, EXPLOSION_2, EXPLOSION_3);

        }
        public Sprite getLinkStandingFacingDownSprite()
        {
            return new Sprite(linkSheet, LINK_MOVE_DOWN_1);
        }
        public Sprite getLinkStandingFacingRightSprite()
        {
            return new Sprite(linkSheet, LINK_MOVE_RIGHT_1);
        }
        public Sprite getLinkStandingFacingLeftSprite()
        {
            return new Sprite(linkSheetMirrored, LINK_MOVE_MIRROR_LEFT_1);
        }
        public Sprite getLinkStandingFacingUpSprite()
        {
            return new Sprite(linkSheet, LINK_MOVE_UP_1);

        }
        public Sprite getLinkMovingDownSprite()
        {
            return new Sprite(linkSheet, LINK_MOVE_DOWN_1, LINK_MOVE_DOWN_2);
        }
        public Sprite getLinkMovingRightSprite()
        {
            return new Sprite(linkSheet, LINK_MOVE_RIGHT_1, LINK_MOVE_RIGHT_2);
        }
        public Sprite getLinkMovingLeftSprite()
        {
            return new Sprite(linkSheetMirrored, LINK_MOVE_MIRROR_LEFT_1, LINK_MOVE_MIRROR_LEFT_2);
        }
        public Sprite getLinkMovingUpSprite()
        {
            return new Sprite(linkSheet, LINK_MOVE_UP_1, LINK_MOVE_UP_2);

        }

        // Enemies

        public Sprite getBluebatSprite()
        {
            return new Sprite(enemySheet2, BLUEBAT_SHEET2_POS1, BLUEBAT_SHEET2_POS2);
        }

        public Sprite getBluegelSprite()
        {
            return new Sprite(enemySheet2, BLUEGEL_SHEET2_POS1, BLUEGEL_SHEET2_POS2);
        }
    }
}