using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Sprint2
{
	public class Link : ILinkState, ISprite
	{
		public ILinkState currState;
		public Vector2 pos { get; set; }
		public bool freeze { get; set; }
		
		public SpriteFactory spriteFactory;
		public SoundFactory soundFactory;
		public Game1 game;
		public Sprite sprite;
		public int health, maxHealth, rupees, keys, bombs;
		public LinkItem item;
		public string direction;
		public List<IItem> itemList;
		public SoundEffect linkHurtSound;
		public SoundEffect linkDeadSound;
		public SoundEffect lowHealthSound;
		public SoundEffect arrowSound;
		public SoundEffect boomerangSound;
		public SoundEffect explosion;

		private const int sizeMuliplier = 3;
		private const int linkStartingHealth = 10;
		private const int linkMaxHealth = 10;
		private const int linkLowHealth = 1;
		private const int linkStartingPosX = 40;
		private const int linkStartingPosY = 40;

		public SoundEffect bombThrow;
		public GameObjectManager gom;
		public bool isUsingItem;
		public bool isMoving;
		public bool canTakeDamage;
		public bool isUsingWeapon;
		public int swordDamage;
		public bool canDealDamage { get; set; }
		public bool canDecreaseKey { get; set; }
		private int keyCooldownTimer = 0;
		private int keyCooldownDuration = 60;

		public Link(Game1 game, GameObjectManager gom)
		{
			this.game = game;
			this.gom = gom;
			health = linkStartingHealth;
			maxHealth = linkMaxHealth;

			rupees = keys = bombs = 0;

			pos = new Vector2(linkStartingPosX, linkStartingPosY);
			itemList = new List<IItem>();
			isMoving = false;
			canTakeDamage = true;
			isUsingWeapon = false;
			canDealDamage = true;
			swordDamage = 2;
			freeze = false;
			canDecreaseKey = true;
		}

		public void SetSoundContent(SoundFactory soundFactory)
        {
			this.soundFactory = soundFactory;
			lowHealthSound = soundFactory.getLowHealth();
			linkHurtSound = soundFactory.getLinkHurt();
			linkDeadSound = soundFactory.getLinkDead();
			arrowSound = soundFactory.getArrowOrBoomerang();
			boomerangSound = soundFactory.getArrowOrBoomerang();
			explosion = soundFactory.getBombBlow();
			bombThrow = soundFactory.getBombDrop();
		}

		
		public void SetSpriteContent(SpriteFactory spriteFactory)
        {
			this.spriteFactory = spriteFactory;
			this.currState = new StandingFacingUp(this);
			sprite = spriteFactory.getLinkStandingFacingDownSprite();
			direction = "up";
			item = new LinkItem(this, spriteFactory);
		}

		public void SetPos(Vector2 pos)
        {
			this.pos = pos;
        }
		public string GetDirection()
		{
			return direction;
		}
		public void SetItem(string newItem)
		{
			item.SetItem(newItem);
		}
		public Rectangle GetSpriteRectangle()
        {
			return sprite.getDestinationRectangle();
        }
		public Rectangle getCurrentFrameRectangle()
        {
			return sprite.getCurrentFrameRectangle();
        }

		public void StandingUp()
        {
			currState.StandingUp();
		}
		public void StandingDown()
        {
			currState.StandingDown();
		}
		public void StandingLeft()
        {
			currState.StandingLeft();
		}
		public void StandingRight()
        {
			currState.StandingRight();
		}
		public void Move(string direction)
        {
			currState.Move(direction);
        }
		public void UseWeapon()
        {
			currState.UseWeapon();
        }
		public void UseItem()
		{
			currState = new UsingItem(this);
			item.Use();
		}
		public void TakeDamage(int collisionSide)
        {
			currState.TakeDamage(collisionSide);
			if (health == 0)
            {
				linkDeadSound.Play();
            }
			else if (health == linkLowHealth)
            {
				lowHealthSound.Play();
            }
            else
            {
				linkHurtSound.Play();
            }
			
            
		}
		public void Draw(SpriteBatch spriteBatch)
        {
			if (!freeze)
			{
				currState.Draw(spriteBatch);
			}
			
			if (keyCooldownTimer >= keyCooldownDuration)
            {
				canDecreaseKey = true;
				keyCooldownTimer = 0;
            }
			if (!canDecreaseKey)
            {
				keyCooldownTimer++;
            }

        }
		public void Update(GameTime gameTime)
		{
			if (!freeze)
            {
				currState.Update(gameTime);
			}
			
		}

        object ISprite.GetConcreteObject()
        {
            return this;
        }
    }
}

