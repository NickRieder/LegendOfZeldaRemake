using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Sprint2
{
    
    public class SoundFactory : ISounds
    {
        private ContentManager content;

        private static SoundEffect themeSong;
        private static SoundEffect arrowOrBoomerang;
        private static SoundEffect bombBlow;
        private static SoundEffect bombDrop;
        private static SoundEffect bossHit;
        private static SoundEffect bossScream1;
        private static SoundEffect bossScream2;
        private static SoundEffect bossScream3;
        private static SoundEffect doorUnlock;
        private static SoundEffect enemyDead;
        private static SoundEffect enemyHit;
        private static SoundEffect getHeart;
        private static SoundEffect getItem;
        private static SoundEffect newDiscoveredItem;
        private static SoundEffect getRupee;
        private static SoundEffect keyAppear;
        private static SoundEffect linkDead;
        private static SoundEffect linkHurt;
        private static SoundEffect lowHealth;
        private static SoundEffect refillHeartsOrCountRupees;
        private static SoundEffect secretSolved;
        private static SoundEffect shieldBlock;
        private static SoundEffect stairs;
        private static SoundEffect swordSlash;
        private static SoundEffect text;

        public SoundFactory(ContentManager content)
        {
            this.content = content;
        }
        public void LoadSounds()
        {
            themeSong = content.Load<SoundEffect>("Sounds/LOZ_ThemeSong");
            arrowOrBoomerang = content.Load<SoundEffect>("Sounds/LOZ_Arrow_Boomerang");
            bombBlow = content.Load<SoundEffect>("Sounds/LOZ_Bomb_Blow");
            bombDrop = content.Load<SoundEffect>("Sounds/LOZ_Bomb_Drop");
            bossHit = content.Load<SoundEffect>("Sounds/LOZ_Boss_Hit");
            bossScream1 = content.Load<SoundEffect>("Sounds/LOZ_Boss_Scream1");
            bossScream2 = content.Load<SoundEffect>("Sounds/LOZ_Boss_Scream2");
            bossScream3 = content.Load<SoundEffect>("Sounds/LOZ_Boss_Scream3");
            doorUnlock = content.Load<SoundEffect>("Sounds/LOZ_Door_Unlock");
            enemyDead = content.Load<SoundEffect>("Sounds/LOZ_Enemy_Die");
            enemyHit = content.Load<SoundEffect>("Sounds/LOZ_Enemy_Hit");
            getHeart = content.Load<SoundEffect>("Sounds/LOZ_Get_Heart");
            getItem = content.Load<SoundEffect>("Sounds/LOZ_Get_Item");
            newDiscoveredItem = content.Load<SoundEffect>("Sounds/LOZ_Fanfare");
            getRupee = content.Load<SoundEffect>("Sounds/LOZ_Get_Rupee");
            keyAppear = content.Load<SoundEffect>("Sounds/LOZ_Key_Appear");
            linkDead = content.Load<SoundEffect>("Sounds/LOZ_Link_Die");
            linkHurt = content.Load<SoundEffect>("Sounds/LOZ_Link_Hurt");
            lowHealth = content.Load<SoundEffect>("Sounds/LOZ_LowHealth");
            refillHeartsOrCountRupees = content.Load<SoundEffect>("Sounds/LOZ_Refill_Loop");
            secretSolved = content.Load<SoundEffect>("Sounds/LOZ_Secret");
            shieldBlock = content.Load<SoundEffect>("Sounds/LOZ_Shield");
            stairs = content.Load<SoundEffect>("Sounds/LOZ_Stairs");
            swordSlash = content.Load<SoundEffect>("Sounds/LOZ_Sword_Slash");
            text = content.Load<SoundEffect>("Sounds/LOZ_Text");
        }

        public SoundEffect getThemeSong()
        {
            return themeSong;
        }
        public SoundEffect getArrowOrBoomerang()
        {
            return arrowOrBoomerang;
        }
        public SoundEffect getBombBlow()
        {
            return bombBlow;
        }
        public SoundEffect getBombDrop()
        {
            return bombDrop;
        }
        public SoundEffect getBossHit()
        {
            return bossHit;
        }
        public SoundEffect getBossScream1()
        {
            return bossScream1;
        }
        public SoundEffect getBossScream2()
        {
            return bossScream2;
        }
        public SoundEffect getBossScream3()
        {
            return bossScream3;
        }
        public SoundEffect getDoorUnlock()
        {
            return doorUnlock;
        }
        public SoundEffect getEnemyDead()
        {
            return enemyDead;
        }
        public SoundEffect getEnemyHit()
        {
            return enemyHit;
        }
        public SoundEffect getHeartSound()
        {
            return getHeart;
        }
        public SoundEffect getItemSound()
        {
            return getItem;
        }
        public SoundEffect newDiscoveredItemSound()
        {
            return newDiscoveredItem;
        }
        public SoundEffect getRupeeSound()
        {
            return getRupee;
        }
        public SoundEffect getKeyAppear()
        {
            return keyAppear;
        }
        public SoundEffect getLinkDead()
        {
            return linkDead;
        }
        public SoundEffect getLinkHurt()
        {
            return linkHurt;
        }
        public SoundEffect getLowHealth()
        {
            return lowHealth;
        }
        public SoundEffect getRefillHeartsOrCountRupees()
        {
            return refillHeartsOrCountRupees;
        }
        public SoundEffect getSecretSolved()
        {
            return secretSolved;
        }
        public SoundEffect getShieldBlock()
        {
            return shieldBlock;
        }
        public SoundEffect getStairs()
        {
            return stairs;
        }
        public SoundEffect getSwordSlash()
        {
            return swordSlash;
        }
        public SoundEffect getText()
        {
            return text;
        }
    }
}
