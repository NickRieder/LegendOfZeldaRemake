using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
		public int spriteSizeMultiplier;

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


		public Enemies(string enemyName, GameObjectManager gom)
		{
			this.enemyName = enemyName;
			this.gom = gom;
			spriteSizeMultiplier = 2;
			bossHealth = 10;
			health = 3;
			pos = new Vector2(600, 200);
			this.freeze = false;
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

        public void TakeDamage()
		{
			currState.TakeDamage();
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
		public void Draw(SpriteBatch spriteBatch)
		{
			currState.Draw(spriteBatch);
		}
		public void Update(GameTime gameTime)
		{
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
