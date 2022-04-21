using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;

namespace Sprint2
{
	public class Enemies : ISprite
	{
		public IEnemyState currState;
		public Vector2 pos { get; set; }
		public SpriteFactory spriteFactory { get; set; }
		public SoundFactory soundFactory;
		public int health;
		public int bossHealth;

		public string direction;
		public GameObjectManager gom;
		public Sprite sprite;
		public string enemyName;
		public ArrayList projectileList;
		public bool freeze { get; set; }
		

		public SoundEffect enemyHurtSound;
		public SoundEffect enemyDeadSound;
		public SoundEffect bossHurtSound;
		public SoundEffect bossDeadSound;

		public const int spriteSizeMultiplier = 2;

		private const int startingHealth = 3;
		private const int startingBossHealth = 10;

		private const int startingPosX = 600;
		private const int startingPosY = 200;

		//temp
		public bool canDamage;
		public bool canTakeDamage;
		private static int damageCooldownTimer = 0;
		private static int damageCooldown = 60;

		private static int invulnerableTimer = 0;
		private static int invulnerableDuration = 10;

		public Enemies(string enemyName, GameObjectManager gom)
		{
			this.enemyName = enemyName;
			this.gom = gom;
			bossHealth = startingBossHealth;
			health = startingHealth;
			pos = new Vector2(startingPosX, startingPosY);
			this.freeze = false;
			canDamage = true;
			canTakeDamage = true;
		}

		public void SetSpriteContent(SpriteFactory spriteFactory)
        {
			this.spriteFactory = spriteFactory;
			direction = "Down";

			switch (enemyName)
			{
				case "Bluebat":
					currState = new BluebatDown(this);
					break;
				case "Bluegel":
					currState = new BluegelDown(this);
					break;
				case "Darknut":
					currState = new DarknutStandingFacingDown(this);
					break;
				case "Dragon":
					currState = new DragonStandingFacingDown(this);
					break;
				case "Goriya":
					currState = new GoriyaStandingFacingDown(this);
					break;
				case "Snake":
					currState = new SnakeDown(this);
					break;
				case "Wizzrobe":
					currState = new WizzrobeDown(this);
                    break;
                case "Boss":
					currState = new BossDown(this);
					break;
                default: // facing up
					currState = null;
					break;
			}
		}
		public void SetSoundContent(SoundFactory soundFactory)
		{
			this.soundFactory = soundFactory;
			enemyDeadSound = soundFactory.getEnemyDead();
			enemyHurtSound = soundFactory.getEnemyHit();
			bossDeadSound = soundFactory.getBossScream3();
			bossHurtSound = soundFactory.getBossScream1();

		}

		public Rectangle GetSpriteRectangle()
		{
			return sprite.getDestinationRectangle();
		}

		public void setPos(Vector2 pos)
        {
			this.pos = pos;
        }

		public void MoveUp()
		{
			currState.MoveDown();
		}
		public void MoveDown()
		{
			currState.MoveDown();
		}
		public void MoveLeft()
		{
			currState.MoveLeft();
		}
		public void MoveRight()
		{
			currState.MoveRight();
		}

        public void Attack()
        {
            currState.Attack();
        }

        public void TakeDamage(int damage)
		{
			//canTakeDamage = false;
			System.Diagnostics.Debug.WriteLine("/Enemies/ enemy can take damage = " + canTakeDamage);
			for (int i = 0; i < damage; i++)
            {
				currState.TakeDamage();
			}
			System.Diagnostics.Debug.WriteLine("DEBUG: /Enemies/ health = " +this.health);
			if (enemyName == "Boss")
            {
				if (bossHealth == 0)
				{
					bossDeadSound.Play();
				}
				else
				{
					bossHurtSound.Play();
				}
			}
            else
            {
				if (health == 0)
				{
					enemyDeadSound.Play();
				}
				else
				{
					enemyHurtSound.Play();
				}
			}
		
		}
		public void DealDamage()
        {
			//canDamage = false;
			System.Diagnostics.Debug.WriteLine("DEBUG1: /Enemies/ canDamage =  " + canDamage);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			if (health != 0 || bossHealth !=0)
            {
				currState.Draw(spriteBatch);
			}
		}
		public void Update(GameTime gameTime)
		{

			currState.Update(gameTime);
			if (bossHealth <= 0)
            {
				gom.RemoveFromEveryCollection(this);
            }
			else if (health <= 0)
			{
				gom.RemoveFromEveryCollection(this);
			}

            if (!canTakeDamage)
            {
				canTakeDamage = true;
			}

            currState.Update(gameTime);

		}

		public Enemies GetConcreteObject()
		{
			return this;
		}

		object ISprite.GetConcreteObject()
		{
			return this;
		}
	}
}
