using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Sprint2
{
    public class EnemySpriteFactory : ISpriteFactory
    {
        private static Texture2D enemySheet;
        private static Texture2D enemySheet2;
        private static Texture2D enemySheet3;
        private static Texture2D enemySheetMirror;
        private static Texture2D enemySheet2Mirror;
        private static Texture2D linkSheetUpsideDown;
        private ContentManager content;

        public EnemySpriteFactory(ContentManager content)
        {
            this.content = content;
        }

        public void LoadSpriteSheet()
        {
            enemySheet = content.Load<Texture2D>("Sheets/EnemySheet");
            enemySheet2 = content.Load<Texture2D>("Sheets/EnemySheet2");
            enemySheet3 = content.Load<Texture2D>("Sheets/EnemySheet3");

            enemySheetMirror = content.Load<Texture2D>("Sheets/EnemySheetMirror");
            enemySheet2Mirror = content.Load<Texture2D>("Sheets/EnemySheet2Mirror");

            linkSheetUpsideDown = content.Load<Texture2D>("Sheets/LinkSheetUpsideDown");
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

        public static Rectangle DRAGON_SHEET1_LEFT1 = new Rectangle(1, 11, 24, 32);
        public static Rectangle DRAGON_SHEET1_LEFT2 = new Rectangle(26, 11, 24, 32);
        public static Rectangle DRAGON_SHEET1_LEFT3 = new Rectangle(51, 11, 24, 32);
        public static Rectangle DRAGON_SHEET1_LEFT4 = new Rectangle(76, 11, 24, 32);
        public static Rectangle DRAGONFIREBALL_SHEET1 = new Rectangle(119, 11, 8, 16);

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

    }
}
