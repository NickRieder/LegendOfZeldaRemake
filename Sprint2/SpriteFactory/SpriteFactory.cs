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
        private static Texture2D tileSheet2;
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
        private static Texture2D transparentSheet;
        private static Texture2D hudSheet;

        private static Texture2D basementSheet;
        private static Texture2D level1Sheet1;
        private static Texture2D level1Sheet2;
        private static Texture2D level2Sheet;
        private static Texture2D level3Sheet;
        private static Texture2D level4Sheet;

        private static Texture2D deathScreen;

        private static SpriteFont font;
        public SpriteFactory(ContentManager content)
        {
            this.content = content;
        }

        public void LoadSpriteSheets()
        {
            tileSheet = content.Load<Texture2D>("Sheets/TileSheet");
            tileSheet2 = content.Load<Texture2D>("Sheets/TileSheet2");

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

            transparentSheet = content.Load<Texture2D>("Sheets/TransparentSheet");

            hudSheet = content.Load<Texture2D>("Sheets/HudSprites");

            font = content.Load<SpriteFont>("File");

            /*
            basementSheet = content.Load<Texture2D>("Sheets/Level 0 SpriteSheet");
            level1Sheet1 = content.Load<Texture2D>("Sheets/Level 1 P1 SpriteSheet");
            level1Sheet2 = content.Load<Texture2D>("Sheets/Level 1 P2 SpriteSheet");
            level2Sheet = content.Load<Texture2D>("Sheets/Level 2 SpriteSheet");
            level3Sheet = content.Load<Texture2D>("Sheets/Level 3 SpriteSheet");
            level4Sheet = content.Load<Texture2D>("Sheets/Level 4 SpriteSheet");
            */

            deathScreen = content.Load<Texture2D>("Sheets/YouDiedScreen");
        }


        public Texture2D getTileSheet()
        {
            return tileSheet;
        }

        public Texture2D getDeathSheet()
        {
            return deathScreen;
        }

        public Texture2D getItemSheet()
        {
            return itemSheet;
        }

        public Texture2D getHudSheet()
        {
            return hudSheet;
        }


        public SpriteFont getFont()
        {
            return font;
        }


        public static Rectangle DEFAULT = new Rectangle(270, 270, 30, 30);
        //Tiles
        //doors
        public static Rectangle TILE_DOOR_TOP_OPEN = new Rectangle(848, 11, 32, 32);
        public static Rectangle TILE_DOOR_RIGHT_OPEN = new Rectangle(848, 77, 32, 32);
        public static Rectangle TILE_DOOR_BOTTOM_OPEN = new Rectangle(848, 110, 32, 32);
        public static Rectangle TILE_DOOR_LEFT_OPEN = new Rectangle(848, 44, 32, 32);
        public static Rectangle TILE_DOOR_TOP_WALL = new Rectangle(815, 11, 32, 32);
        public static Rectangle TILE_DOOR_RIGHT_WALL = new Rectangle(815, 77, 32, 32);
        public static Rectangle TILE_DOOR_BOTTOM_WALL = new Rectangle(815, 110, 32, 32);
        public static Rectangle TILE_DOOR_LEFT_WALL = new Rectangle(815, 44, 32, 32);
        public static Rectangle TILE_DOOR_TOP_LOCKED = new Rectangle(881, 11, 32, 32);
        public static Rectangle TILE_DOOR_RIGHT_LOCKED = new Rectangle(881, 77, 32, 32);
        public static Rectangle TILE_DOOR_BOTTOM_LOCKED = new Rectangle(881, 110, 32, 32);
        public static Rectangle TILE_DOOR_LEFT_LOCKED = new Rectangle(881, 44, 32, 32);

        //Blocks
        public static Rectangle TILE_STAIRS = new Rectangle(1035, 28, 16, 16);
        public static Rectangle TILE_FLATBLOCK = new Rectangle(984, 11, 16, 16);
        public static Rectangle TILE_NONFLAT_BLOCK = new Rectangle(1001, 11, 16, 16);
        public static Rectangle TILE_BRICK_BLOCK = new Rectangle(984, 45, 16, 16);
        public static Rectangle TILE_FLOOR_BASIC = new Rectangle(1, 92, 191, 111);
        public static Rectangle TILE_FLOOR_DESIGN1 = new Rectangle(976, 192, 191, 111);
        public static Rectangle FULL_ROOM = new Rectangle(521, 11, 255, 177);
        public static Rectangle BRIDGE_ROOM = new Rectangle(586, 307, 255, 177);
        public static Rectangle ITEM_ROOM = new Rectangle(975, 536, 255, 177);
        public static Rectangle ITEM_FLIPPED_ROOM = new Rectangle(951, 1013, 255, 177);
        public static Rectangle EMPTY_ROOM = new Rectangle(521, 11, 256, 176);

        public static Rectangle TOP_DOOR_OPEN = new Rectangle(848, 10, 32, 32);
        public static Rectangle BOT_DOOR_OPEN = new Rectangle(848, 110, 32, 32);
        public static Rectangle RIGHT_DOOR_OPEN = new Rectangle(848, 77, 32, 32);
        public static Rectangle LEFT_DOOR_OPEN = new Rectangle(848, 44, 32, 32);

        //Enemies
        private static Rectangle DRAGON_SHEET1_LEFT1 = new Rectangle(1, 11, 24, 32);
        private static Rectangle DRAGON_SHEET1_LEFT2 = new Rectangle(26, 11, 24, 32);
        private static Rectangle DRAGON_SHEET1_LEFT3 = new Rectangle(51, 11, 24, 32);
        private static Rectangle DRAGON_SHEET1_LEFT4 = new Rectangle(76, 11, 24, 32);
        private static Rectangle DRAGON_SHEET1_FIREBALL1 = new Rectangle(101, 11, 8, 16);
        private static Rectangle DRAGON_SHEET1_FIREBALL2 = new Rectangle(110, 11, 8, 16);
        private static Rectangle DRAGON_SHEET1_FIREBALL3 = new Rectangle(119, 11, 8, 16);
        private static Rectangle DRAGON_SHEET1_FIREBALL4 = new Rectangle(128, 11, 8, 16);

        private static Rectangle DRAGON_SHEET1MIRROR_RIGHT1 = new Rectangle(469, 11, 24, 32);
        private static Rectangle DRAGON_SHEET1MIRROR_RIGHT2 = new Rectangle(444, 11, 24, 32);
        private static Rectangle DRAGON_SHEET1MIRROR_RIGHT3 = new Rectangle(419, 11, 24, 32);
        private static Rectangle DRAGON_SHEET1MIRROR_RIGHT4 = new Rectangle(394, 11, 24, 32);

        private static Rectangle BOSS_SHEET1_1 = new Rectangle(40, 154, 32, 32);
        private static Rectangle BOSS_SHEET1_2 = new Rectangle(73, 154, 32, 32);
        private static Rectangle BOSS_SHEET1_3 = new Rectangle(106, 154, 32, 32);
        private static Rectangle BOSS_SHEET1_4 = new Rectangle(139, 154, 32, 32);
        private static Rectangle BOSS_SHEET1_5 = new Rectangle(172, 154, 32, 32);
        private static Rectangle HURT_BOSS = new Rectangle(206, 154, 32, 32);
        private static Rectangle BOSS_MINION_1 = new Rectangle(18, 158, 8, 8);
        private static Rectangle BOSS_MINION_2 = new Rectangle(27, 158, 8, 8);


        private static Rectangle BLUEBAT_SHEET2_POS1 = new Rectangle(183, 11, 16, 16);
        private static Rectangle BLUEBAT_SHEET2_POS2 = new Rectangle(200, 11, 16, 16);
        private static Rectangle BLUEGEL_SHEET2_POS1 = new Rectangle(19, 11, 8, 16);
        private static Rectangle BLUEGEL_SHEET2_POS2 = new Rectangle(28, 11, 8, 16);
        private static Rectangle GREENGEL_SHEET2_POS1 = new Rectangle(1, 28, 8, 16);
        private static Rectangle GREENGEL_SHEET2_POS2 = new Rectangle(10, 28, 8, 16);

        private static Rectangle DARKNUT_SHEET2_FRONT1 = new Rectangle(1, 90, 16, 16);
        private static Rectangle DARKNUT_SHEET2_FRONT2 = new Rectangle(18, 90, 16, 16);
        private static Rectangle DARKNUT_SHEET2_BACK = new Rectangle(35, 90, 16, 16);
        private static Rectangle DARKNUT_SHEET2_BACK2 = new Rectangle(90, 106, 16, 16);
        private static Rectangle DARKNUT_SHEET2_RIGHT1 = new Rectangle(52, 90, 16, 16);
        private static Rectangle DARKNUT_SHEET2_RIGHT2 = new Rectangle(69, 90, 16, 16);
        private static Rectangle DARKNUT_SHEET2MIRROR_LEFT1 = new Rectangle(372, 90, 16, 16);
        private static Rectangle DARKNUT_SHEET2MIRROR_LEFT2 = new Rectangle(389, 90, 16, 16);


        private static Rectangle WIZZROBE_SHEET2_RIGHT1 = new Rectangle(126, 90, 16, 16);
        private static Rectangle WIZZROBE_SHEET2_RIGHT2 = new Rectangle(143, 90, 16, 16);
        private static Rectangle WIZZROBE_SHEET2_BACK1 = new Rectangle(160, 90, 16, 16);
        private static Rectangle WIZZROBE_SHEET2_BACK2 = new Rectangle(177, 90, 16, 16);
        private static Rectangle WIZZROBE_SHEET2MIRROR_LEFT1 = new Rectangle(298, 89, 16, 16);
        private static Rectangle WIZZROBE_SHEET2MIRROR_LEFT2 = new Rectangle(314, 89, 16, 16);

        private static Rectangle GORIYA_SHEET2_FRONT = new Rectangle(222, 11, 16, 16);
        private static Rectangle GORIYA_SHEET2_FRONT2 = new Rectangle(290, 27, 16, 16);
        private static Rectangle GORIYA_SHEET2_BACK = new Rectangle(239, 11, 16, 16);
        private static Rectangle GORIYA_SHEET2_BACK2 = new Rectangle(308, 27, 16, 16);
        private static Rectangle GORIYA_SHEET2_RIGHT = new Rectangle(256, 11, 16, 16);
        private static Rectangle GORIYA_SHEET2_THROWRIGHT = new Rectangle(273, 11, 16, 16);

        private static Rectangle GORIYA_LINKSHEETUPSIDEDOWN_WEAPON1 = new Rectangle(298, 109, 8, 16);
        private static Rectangle GORIYA_LINKSHEETUPSIDEDOWN_WEAPON2 = new Rectangle(289, 109, 8, 16);
        private static Rectangle GORIYA_LINKSHEETUPSIDEDOWN_WEAPON3 = new Rectangle(280, 109, 8, 16);
        private static Rectangle GORIYA_SHEET2_WEAPON4 = new Rectangle(290, 11, 8, 16);
        private static Rectangle GORIYA_SHEET2_WEAPON5 = new Rectangle(299, 11, 8, 16);
        private static Rectangle GORIYA_SHEET2_WEAPON6 = new Rectangle(308, 11, 8, 16);

        private static Rectangle GORIYA_SHEET2MIRROR_LEFT = new Rectangle(185, 11, 16, 16);
        private static Rectangle GORIYA_SHEET2MIRROR_THROWLEFT = new Rectangle(168, 11, 16, 16);
        private static Rectangle GORIYA_SHEET2MIRROR_WEAPONLEFT1 = new Rectangle(159, 11, 8, 16);
        private static Rectangle GORIYA_SHEET2MIRROR_WEAPONLEFT2 = new Rectangle(150, 11, 8, 16);
        private static Rectangle GORIYA_SHEET2MIRROR_WEAPONLEFT3 = new Rectangle(141, 11, 8, 16);

        private static Rectangle SNAKE_SHEET2_RIGHT1 = new Rectangle(126, 59, 16, 16);
        private static Rectangle SNAKE_SHEET2_RIGHT2 = new Rectangle(143, 59, 16, 16);
        private static Rectangle SNAKE_SHEET2MIRROR_LEFT1 = new Rectangle(315, 59, 16, 16);
        private static Rectangle SNAKE_SHEET2MIRROR_LEFT2 = new Rectangle(298, 59, 16, 16);

        //Items
        private static Rectangle ARROWORBOOMERANG_HIT = new Rectangle(89, 189, 7, 7);
        private static Rectangle ARROW_RIGHT = new Rectangle(9, 185, 15, 15);
        private static Rectangle ARROW_UP = new Rectangle(1, 185, 7, 15);
        private static Rectangle ARROW_UPSIDEDOWN_DOWN = new Rectangle(360, 108, 7, 15);
        private static Rectangle ARROW_MIRRORED_LEFT = new Rectangle(345, 185, 15, 15);

        private static Rectangle TRIFORCE_P1 = new Rectangle(81, 139, 47, 24);
        private static Rectangle TRIFORCE_P2 = new Rectangle(128, 139, 49, 24);
        private static Rectangle TRIFORCE_P3 = new Rectangle(97, 115, 64, 23);

        private static Rectangle BOOMERANG_1 = new Rectangle(63, 189, 8, 8);
        private static Rectangle BOOMERANG_2 = new Rectangle(73, 189, 8, 8);
        private static Rectangle BOOMERANG_3 = new Rectangle(82, 189, 8, 8);
        private static Rectangle BOOMERANG_4 = new Rectangle(128, 202, 8, 8);
        private static Rectangle BOOMERANG_5 = new Rectangle(137, 202, 8, 8);
        private static Rectangle BOOMERANG_6 = new Rectangle(146, 202, 8, 8);
        private static Rectangle BOOMERANG_7 = new Rectangle(155, 202, 8, 8);
        private static Rectangle BOOMERANG_8 = new Rectangle(164, 202, 8, 8);

        private static Rectangle BOMB_SPRITE = new Rectangle(135, 0, 9, 14);
        private static Rectangle EXPLOSION_1 = new Rectangle(138, 185, 16, 16);
        private static Rectangle EXPLOSION_2 = new Rectangle(155, 185, 16, 16);
        private static Rectangle EXPLOSION_3 = new Rectangle(172, 185, 16, 16);

        // on ItemSheet
        public static Rectangle HEART_CANISTER = new Rectangle(25, 1, 14, 14);
        public static Rectangle WOODEN_SWORD = new Rectangle(104, 0, 8, 16);
        public static Rectangle MAGIC_SWORD = new Rectangle(104, 16, 8, 16);
        public static Rectangle BOW = new Rectangle(136, 15, 8, 16);
        public static Rectangle BOMB = new Rectangle(136, 0, 9, 14);
        public static Rectangle BOOMERANG = new Rectangle(129, 3, 6, 8);
        public static Rectangle RED_CANDLE = new Rectangle(160, 0, 8, 16);
        public static Rectangle BLUE_CANDLE = new Rectangle(160, 16, 8, 16);
        public static Rectangle ORANGE_RUPEE = new Rectangle(71, 0, 9, 16);
        public static Rectangle BLUE_RUPEE = new Rectangle(71, 16, 9, 16);
        public static Rectangle KEY = new Rectangle(240, 0, 8, 16);

        //Link
        private static Rectangle LINK_MOVE_DOWN_1 = new Rectangle(1, 11, 16, 16);
        private static Rectangle LINK_MOVE_DOWN_2 = new Rectangle(18, 11, 16, 16);
        private static Rectangle LINK_MOVE_RIGHT_1 = new Rectangle(35, 11, 16, 16);
        private static Rectangle LINK_MOVE_RIGHT_2 = new Rectangle(52, 11, 16, 16);
        private static Rectangle LINK_MOVE_UP_1 = new Rectangle(69, 11, 16, 16);
        private static Rectangle LINK_MOVE_UP_2 = new Rectangle(86, 11, 16, 16);
        private static Rectangle LINK_MOVE_MIRROR_LEFT_1 = new Rectangle(320, 11, 16, 16);
        private static Rectangle LINK_MOVE_MIRROR_LEFT_2 = new Rectangle(303, 11, 16, 16);

        private static Rectangle LINK_PICKUP_ITEM_1 = new Rectangle(231, 11, 16, 16);
        private static Rectangle LINK_PICKUP_ITEM_2 = new Rectangle(248, 11, 16, 16);

        private static Rectangle LINK_USEITEM_DOWN = new Rectangle(107, 11, 16, 16);
        private static Rectangle LINK_USEITEM_RIGHT = new Rectangle(124, 11, 16, 16);
        private static Rectangle LINK_USEITEM_UP = new Rectangle(141, 11, 16, 16);
        private static Rectangle LINK_USEITEM_MIRROR_LEFT = new Rectangle(232, 11, 16, 16);

        private static Rectangle LINK_USESWORD_DOWN = new Rectangle(18, 47, 16, 27);
        private static Rectangle LINK_USESWORD_RIGHT = new Rectangle(18, 78, 27, 16);
        private static Rectangle LINK_USESWORD_UP = new Rectangle(18, 97, 16, 28);
        private static Rectangle LINK_USESWORD_MIRROR_LEFT = new Rectangle(326, 78, 27, 16);

        private static Rectangle LINK_DAMAGED_BLACK_AND_RED = new Rectangle(57, 223, 16, 16);
        private static Rectangle LINK_DAMAGED_GREEN_AND_PEACH = new Rectangle(74, 223, 16, 16);
        private static Rectangle LINK_DAMAGED_RED_AND_PEACH = new Rectangle(91, 223, 16, 16);
        private static Rectangle LINK_DAMAGED_PINKBACKGROUND = new Rectangle(109, 223, 16, 16);
        private static Rectangle LINK_DAMAGED_ALLBLUE = new Rectangle(74, 240, 16, 16);
        private static Rectangle LINK_DAMAGED_ALLGREEN = new Rectangle(91, 240, 16, 16);
        private static Rectangle LINK_DAMAGED_ALLORANGE = new Rectangle(108, 240, 16, 16);

        // link starting positions
        public static Vector2 LINK_LEFT_POS = new Vector2(96, 240);
        public static Vector2 LINK_RIGHT_POS = new Vector2(624, 240);
        public static Vector2 LINK_TOP_POS = new Vector2(360, 110);
        public static Vector2 LINK_BOTTOM_POS = new Vector2(360, 370);

        // HUD
        public static Rectangle HUD_SPRITE = new Rectangle(258, 26, 255, 34);
        public static Rectangle EMPTY_HEART = new Rectangle(626, 116, 8, 8);
        public static Rectangle HALF_HEART = new Rectangle(635, 116, 8, 8);
        public static Rectangle FULL_HEART = new Rectangle(644, 116, 8, 8);
        private static Rectangle MENU = new Rectangle(0, 10, 256, 176);
        private static Rectangle SELECTOR = new Rectangle(518, 136, 17, 17);

        // Levels
        public static Rectangle B_R1 = new Rectangle(32, 27, 164, 164);
        public static Rectangle B_R2 = new Rectangle(217, 27, 164, 164);
        public static Rectangle B_R3 = new Rectangle(402, 27, 164, 164);
        public static Rectangle B_R4 = new Rectangle(587, 27, 164, 164);
        public static Rectangle B_R5 = new Rectangle(772, 27, 164, 164);
        public static Rectangle B_R6 = new Rectangle(32, 212, 164, 164);

        public static Rectangle L1_R1 = new Rectangle(39, 31, 130, 145);
        public static Rectangle L1_R2 = new Rectangle(186, 31, 130, 145);
        public static Rectangle L1_R3 = new Rectangle(333, 31, 130, 145);
        public static Rectangle L1_R4 = new Rectangle(481, 31, 130, 145);
        public static Rectangle L1_R5 = new Rectangle(628, 31, 130, 145);
        public static Rectangle L1_R6 = new Rectangle(39, 193, 130, 145);
        public static Rectangle L1_R7 = new Rectangle(185, 193, 130, 145);
        public static Rectangle L1_R8 = new Rectangle(333, 193, 130, 145);
        public static Rectangle L1_R9 = new Rectangle(481, 193, 130, 145);
        public static Rectangle L1_R10 = new Rectangle(626, 193, 130, 145);
        public static Rectangle L1_R11 = new Rectangle(39, 354, 130, 145);
        public static Rectangle L1_R12 = new Rectangle(185, 354, 130, 145);
        public static Rectangle L1_R13 = new Rectangle(332, 212, 130, 145);

        public static Rectangle L2_R1 = new Rectangle(33, 36, 108, 133);
        public static Rectangle L2_R2 = new Rectangle(155, 36, 108, 133);
        public static Rectangle L2_R3 = new Rectangle(277, 36, 108, 133);
        public static Rectangle L2_R4 = new Rectangle(399, 36, 108, 133);
        public static Rectangle L2_R5 = new Rectangle(521, 36, 108, 133);
        public static Rectangle L2_R6 = new Rectangle(33, 183, 108, 133);
        public static Rectangle L2_R7 = new Rectangle(155, 182, 108, 133);
        public static Rectangle L2_R8 = new Rectangle(278, 182, 108, 133);
        public static Rectangle L2_R9 = new Rectangle(400, 182, 108, 133);

        public static Rectangle L3_R1 = new Rectangle(25, 26, 131, 109);
        public static Rectangle L3_R2 = new Rectangle(170, 26, 131, 109);
        public static Rectangle L3_R3 = new Rectangle(315, 26, 131, 109);
        public static Rectangle L3_R4 = new Rectangle(460, 26, 131, 109);
        public static Rectangle L3_R5 = new Rectangle(25, 149, 131, 109);
        public static Rectangle L3_R6 = new Rectangle(170, 149, 131, 109);
        public static Rectangle L3_R7 = new Rectangle(315, 149, 131, 109);
        public static Rectangle L3_R8 = new Rectangle(460, 149, 131, 109);
        public static Rectangle L3_R9 = new Rectangle(25, 272, 131, 109);

        public static Rectangle L4_R1 = new Rectangle(41, 27, 131, 131);

        //Minimap Position
        public static Rectangle BP_R1 = new Rectangle(217, 212, 164, 164);
        public static Rectangle BP_R2 = new Rectangle(402, 212, 164, 164);
        public static Rectangle BP_R3 = new Rectangle(587, 212, 164, 164);
        public static Rectangle BP_R4 = new Rectangle(772, 212, 164, 164);
        public static Rectangle BP_R5 = new Rectangle(217, 397, 164, 164);
        public static Rectangle BP_R6 = new Rectangle(402, 397, 164, 164);

        public static Rectangle L1P_R1 = new Rectangle(480, 354, 130, 145);
        public static Rectangle L1P_R2 = new Rectangle(626, 354, 130, 145);
        public static Rectangle L1P_R3 = new Rectangle(32, 14, 129, 146);
        public static Rectangle L1P_R4 = new Rectangle(178, 14, 129, 146);
        public static Rectangle L1P_R5 = new Rectangle(324, 14, 129, 146);
        public static Rectangle L1P_R6 = new Rectangle(470, 14, 129, 146);
        public static Rectangle L1P_R7 = new Rectangle(617, 14, 129, 146);
        public static Rectangle L1P_R8 = new Rectangle(32, 175, 129, 146);
        public static Rectangle L1P_R9 = new Rectangle(178, 175, 129, 146);
        public static Rectangle L1P_R10 = new Rectangle(324, 175, 129, 146);
        public static Rectangle L1P_R11 = new Rectangle(470, 175, 129, 146);
        public static Rectangle L1P_R12 = new Rectangle(617, 175, 129, 146);
        //public static Rectangle L1P_R13 = new Rectangle(332, 212, 130, 145); //Missing

        public static Rectangle L2P_R1 = new Rectangle(523, 182, 108, 133);
        public static Rectangle L2P_R2 = new Rectangle(33, 329, 108, 133);
        public static Rectangle L2P_R3 = new Rectangle(156, 329, 108, 133);
        public static Rectangle L2P_R4 = new Rectangle(278, 329, 108, 133);
        public static Rectangle L2P_R5 = new Rectangle(401, 329, 108, 133);
        public static Rectangle L2P_R6 = new Rectangle(523, 183, 108, 133);
        public static Rectangle L2P_R7 = new Rectangle(34, 475, 108, 133);
        public static Rectangle L2P_R8 = new Rectangle(156, 475, 108, 133);
        public static Rectangle L2P_R9 = new Rectangle(478, 475, 108, 133);

        public static Rectangle L3P_R1 = new Rectangle(171, 272, 131, 109);
        public static Rectangle L3P_R2 = new Rectangle(316, 272, 131, 109);
        public static Rectangle L3P_R3 = new Rectangle(461, 272, 131, 109);
        public static Rectangle L3P_R4 = new Rectangle(26, 395, 131, 109);
        public static Rectangle L3P_R5 = new Rectangle(171, 395, 131, 109);
        public static Rectangle L3P_R6 = new Rectangle(316, 395, 131, 109);
        public static Rectangle L3P_R7 = new Rectangle(461, 395, 131, 109);
        public static Rectangle L3P_R8 = new Rectangle(171, 518, 131, 109);
        public static Rectangle L3P_R9 = new Rectangle(316, 518, 131, 109);

        public static Rectangle L4P_R1 = new Rectangle(186, 27, 131, 131);

        // Death Screen
        public static Rectangle DEATH_SCREEN = new Rectangle(0, 0, 255, 300);

        // Projectiles
        public Sprite getBoomerangSprite()
        {
            return new Sprite(linkSheet, BOOMERANG_1, BOOMERANG_2, BOOMERANG_3, BOOMERANG_4, BOOMERANG_5, BOOMERANG_6, BOOMERANG_7, BOOMERANG_8);
        }
        public Sprite getArrowSpriteRight()
        {
            return new Sprite(linkSheet, ARROW_RIGHT);
        }
        public Sprite getTriforceSprite1()
        {
            return new Sprite(hudSheet, TRIFORCE_P1);
        }
        public Sprite getTriforceSprite2()
        {
            return new Sprite(hudSheet, TRIFORCE_P2);
        }
        public Sprite getTriforceSprite3()
        {
            return new Sprite(hudSheet, TRIFORCE_P3);
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
      

        /*        public Sprite getBombSprite()
                {
                    return new Sprite(itemSheet, BOMB_SPRITE);
                }*/

        public Sprite getExplosionSprite()
        {

            return new Sprite(linkSheet, EXPLOSION_1, EXPLOSION_2, EXPLOSION_3);

        }
        public Sprite getBossMinion()
        {
            return new Sprite(enemySheet, BOSS_MINION_1, BOSS_MINION_2);
        }

        public Sprite getNullProjectile()
        {
            return new Sprite(enemySheet2);
        }
        public Sprite getFireballSprite()
        {
            return new Sprite(enemySheet, DRAGON_SHEET1_FIREBALL1, DRAGON_SHEET1_FIREBALL2, DRAGON_SHEET1_FIREBALL2, DRAGON_SHEET1_FIREBALL2);
        }

        // Link

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
        public Sprite getLinkUsingWeaponUp()
        {
            return new Sprite(linkSheet, LINK_USESWORD_UP);
        }
        public Sprite getLinkUsingWeaponDown()
        {
            return new Sprite(linkSheet, LINK_USESWORD_DOWN);
        }
        public Sprite getLinkUsingWeaponRight()
        {
            return new Sprite(linkSheet, LINK_USESWORD_RIGHT);
        }
        public Sprite getLinkUsingWeaponLeft()
        {
            return new Sprite(linkSheetMirrored, LINK_USESWORD_MIRROR_LEFT);
        }
        public Sprite getLinkUsingItemUp()
        {
            return new Sprite(linkSheet, LINK_USEITEM_UP);
        }
        public Sprite getLinkUsingItemDown()
        {
            return new Sprite(linkSheet, LINK_USEITEM_DOWN);
        }
        public Sprite getLinkUsingItemRight()
        {
            return new Sprite(linkSheet, LINK_USEITEM_RIGHT);
        }
        public Sprite getLinkUsingItemLeft()
        {
            return new Sprite(linkSheetMirrored, LINK_USEITEM_MIRROR_LEFT);
        }
        public Sprite getLinkDamaged()
        {
            return new Sprite(linkSheet, LINK_DAMAGED_BLACK_AND_RED);
        }

        // Tiles
        public Sprite getFlatBlockSprite()
        {
            return new Sprite(tileSheet, TILE_FLATBLOCK);
        }
        public Sprite getBrickBlockSprite()
        {
            return new Sprite(tileSheet, TILE_BRICK_BLOCK);
        }
        public Sprite getNonFlatBlockSprite()
        {
            return new Sprite(tileSheet, TILE_NONFLAT_BLOCK);
        }

        public Sprite getTopDoorOpenSprite()
        {
            return new Sprite(tileSheet, TILE_DOOR_TOP_OPEN);
        }
        public Sprite getRightDoorOpenSprite()
        {
            return new Sprite(tileSheet, TILE_DOOR_RIGHT_OPEN);
        }
        public Sprite getLeftDoorOpenSprite()
        {
            return new Sprite(tileSheet, TILE_DOOR_LEFT_OPEN);
        }
        public Sprite getBottomDoorOpenSprite()
        {
            return new Sprite(tileSheet, TILE_DOOR_BOTTOM_OPEN);
        }

        public Sprite getTopDoorClosedSprite()
        {
            return new Sprite(tileSheet, TILE_DOOR_TOP_WALL);
        }
        public Sprite getRightDoorClosedSprite()
        {
            return new Sprite(tileSheet, TILE_DOOR_RIGHT_WALL);
        }
        public Sprite getLeftDoorClosedSprite()
        {
            return new Sprite(tileSheet, TILE_DOOR_LEFT_WALL);
        }
        public Sprite getBottomDoorClosedSprite()
        {
            return new Sprite(tileSheet, TILE_DOOR_BOTTOM_WALL);
        }

        public Sprite getTopDoorLockedSprite()
        {
            return new Sprite(tileSheet, TILE_DOOR_TOP_LOCKED);
        }
        public Sprite getRightDoorLockedSprite()
        {
            return new Sprite(tileSheet, TILE_DOOR_RIGHT_LOCKED);
        }
        public Sprite getLeftDoorLockedSprite()
        {
            return new Sprite(tileSheet, TILE_DOOR_LEFT_LOCKED);
        }
        public Sprite getBottomDoorLockedSprite()
        {
            return new Sprite(tileSheet, TILE_DOOR_BOTTOM_LOCKED);
        }

        //Items
        public Sprite getSwordSprite()
        {
            return new Sprite(itemSheet, MAGIC_SWORD);
        }

        public Sprite getBoomerangPickUpSprite()
        {
            return new Sprite(itemSheet, BOOMERANG);
        }
        public Sprite getKeySprite()
        {
            return new Sprite(itemSheet, KEY);
        }
        public Sprite getRupeeSprite()
        {
            return new Sprite(itemSheet, ORANGE_RUPEE);
        }
        public Sprite getHeartSprite()
        {
            return new Sprite(itemSheet, HEART_CANISTER);
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

        public Sprite getDarknutUpSprite()
        {
            return new Sprite(enemySheet2, DARKNUT_SHEET2_BACK, DARKNUT_SHEET2_BACK2);
        }
        public Sprite getDarknutDownSprite()
        {
            return new Sprite(enemySheet2, DARKNUT_SHEET2_FRONT1, DARKNUT_SHEET2_FRONT2);
        }
        public Sprite getDarknutLeftSprite()
        {
            return new Sprite(enemySheet2Mirror, DARKNUT_SHEET2MIRROR_LEFT1, DARKNUT_SHEET2MIRROR_LEFT2);
        }
        public Sprite getDarknutRightSprite()
        {
            return new Sprite(enemySheet2, DARKNUT_SHEET2_RIGHT1, DARKNUT_SHEET2_RIGHT2);
        }
        public Sprite getDragonRightSprite()
        {
            return new Sprite(enemySheetMirror, DRAGON_SHEET1MIRROR_RIGHT3, DRAGON_SHEET1MIRROR_RIGHT4);
        }
        public Sprite getDragonLeftSprite()
        {
            return new Sprite(enemySheet, DRAGON_SHEET1_LEFT3, DRAGON_SHEET1_LEFT4);
        }
        public Sprite getGoriyaLeftSprite()
        {
            return new Sprite(enemySheet2Mirror, GORIYA_SHEET2MIRROR_LEFT, GORIYA_SHEET2MIRROR_THROWLEFT);
        }
        public Sprite getGoriyaRightSprite()
        {
            return new Sprite(enemySheet2, GORIYA_SHEET2_RIGHT, GORIYA_SHEET2_THROWRIGHT);
        }
        public Sprite getGoriyaUpSprite()
        {
            return new Sprite(enemySheet2, GORIYA_SHEET2_BACK, GORIYA_SHEET2_BACK2);
        }
        public Sprite getGoriyaDownSprite()
        {
            return new Sprite(enemySheet2, GORIYA_SHEET2_FRONT, GORIYA_SHEET2_FRONT2);
        }
        public Sprite getSnakeRightSprite()
        {
            return new Sprite(enemySheet2, SNAKE_SHEET2_RIGHT1, SNAKE_SHEET2_RIGHT2);
        }
        public Sprite getSnakeLeftSprite()
        {
            return new Sprite(enemySheet2Mirror, SNAKE_SHEET2MIRROR_LEFT1, SNAKE_SHEET2MIRROR_LEFT2);
        }
        public Sprite getWizzrobeRightSprite()
        {
            return new Sprite(enemySheet2, WIZZROBE_SHEET2_RIGHT1, WIZZROBE_SHEET2_RIGHT2);
        }
        public Sprite getWizzrobeLeftSprite()
        {
            return new Sprite(enemySheet2Mirror, WIZZROBE_SHEET2MIRROR_LEFT1, WIZZROBE_SHEET2MIRROR_LEFT2);
        }
        public Sprite getWizzrobeBackSprite()
        {
            return new Sprite(enemySheet2, WIZZROBE_SHEET2_BACK1, WIZZROBE_SHEET2_BACK2);
        }

        public Sprite getBossSprite()
        {
            return new Sprite(enemySheet, BOSS_SHEET1_1, BOSS_SHEET1_2, BOSS_SHEET1_3, BOSS_SHEET1_4, BOSS_SHEET1_5);
        }

        public Sprite getHurtBossSprite()
        {
            return new Sprite(enemySheet, HURT_BOSS);
        }


        // Heart

        public Rectangle getEmptyHeartRect()
        {
            return EMPTY_HEART;
        }

        public Rectangle getHalfHeartRect()
        {
            return HALF_HEART;
        }

        public Rectangle getFullHeartRect()
        {
            return FULL_HEART;
        }


        // Rooms
        public Sprite getEmptyRoomSprite()
        {
            return new Sprite(tileSheet2, EMPTY_ROOM);
        }
        public Sprite getRoom1Sprite()
        {
            return new Sprite(tileSheet, FULL_ROOM);
        }

        public Sprite getItemRoomSprite()
        {
            return new Sprite(tileSheet, ITEM_ROOM);
        }

        public Sprite getItemRoomFlippedSprite()
        {
            return new Sprite(tileSheet, ITEM_FLIPPED_ROOM);
        }

        public Sprite getBridgeRoomSprite()
        {
            return new Sprite(tileSheet, BRIDGE_ROOM);
        }
        public Sprite getDefaultSprite()
        {
            return new Sprite(linkSheet, DEFAULT);
        }


        public Sprite getWallSprite(Rectangle rect)
        {
            return new Sprite(transparentSheet, rect);
        }

        public Sprite getHUDSprite()
        {
            return new Sprite(hudSheet, HUD_SPRITE);
        }

        //menu
        public Sprite getMenuSprite()
        {
            return new Sprite(hudSheet, MENU);
        }
        public Sprite getSelectorSprite()
        {
            return new Sprite(hudSheet, SELECTOR);
        }
        public Sprite getBowSprite()
        {
            return new Sprite(itemSheet, BOW);
        }
        public Sprite getBombSprite()
        {
            return new Sprite(itemSheet, BOMB);
        }

        // death
        public Sprite getDeathScreen()
        {
            return new Sprite(deathScreen, DEATH_SCREEN);
        }
    }
}