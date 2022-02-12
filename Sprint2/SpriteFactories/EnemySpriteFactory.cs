using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Sprint2
{
    class EnemySpriteFactory : ISpriteFactory
    {
        private static Texture2D enemySheet1;
        private static Texture2D enemySheet1Mirror;
        private static Texture2D enemySheet2;
        private static Texture2D enemySheet2Mirror;
        public void LoadSpriteSheet(ContentManager content)
        {
            enemySheet1 = content.Load<Texture2D>("Sheets/EnemySheet");
            enemySheet1Mirror = content.Load<Texture2D>("Sheets/EnemySheet1Mirror");
            enemySheet2 = content.Load<Texture2D>("Sheets/EnemySheet2");
            enemySheet2Mirror = content.Load<Texture2D>("Sheets/EnemySheet2Mirror");
        }

        public Texture2D getEnemySheet1()
        {
            return enemySheet1;
        }

        public Texture2D getEnemySheet1Mirror()
        {
            return enemySheet1Mirror;
        }

        public Texture2D getEnemySheet2()
        {
            return enemySheet2;
        }

        public Texture2D getEnemySheet2Mirror()
        {
            return enemySheet2Mirror;
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
        public static Rectangle GREENGEL_SHEET2POS1 = new Rectangle(1, 28, 8, 16);
        public static Rectangle GREENGEL_SHEET2POS2 = new Rectangle(10, 28, 8, 16);

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
        public static Rectangle GORIYA_SHEET2_WEAPONRIGHT1 = new Rectangle(290, 11, 8, 16);
        public static Rectangle GORIYA_SHEET2_WEAPONRIGHT2 = new Rectangle(299, 11, 8, 16);
        public static Rectangle GORIYA_SHEET2_WEAPONRIGHT3 = new Rectangle(308, 11, 8, 16);

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
