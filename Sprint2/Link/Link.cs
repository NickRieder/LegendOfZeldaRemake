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
		public SpriteFactory spriteFactory;
		public SoundFactory soundFactory;
		public Game1 game;
		public Sprite sprite;
		public int health, maxHealth, rupies, keys, bombs;
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
		private const int linkStartingHealth = 8;
		private const int linkMaxHealth = 10;
		private const int linkLowHealth = 1;
		private const int linkStartingPosX = 40;
		private const int linkStartingPosY = 40;

		public SoundEffect bombThrow;
		public GameObjectManager gom;
		public bool isUsingItem;
		public bool canTakeDamage;

		public Link(Game1 game, GameObjectManager gom)
		{
			//item = new NullItem();
			this.game = game;
			this.gom = gom;
			health = linkStartingHealth;
			maxHealth = linkMaxHealth;
			rupies = keys = bombs = 1;	// Link should start with 0. Currently 1 for debugging purposes.
			pos = new Vector2(linkStartingPosX, linkStartingPosY);
			itemList = new List<IItem>();
			canTakeDamage = true;
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
			this.currState = new StandingFacingDown(this);
			sprite = spriteFactory.getLinkStandingFacingDownSprite();
			direction = "down";
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
		public void Move()
        {
			currState.Move();
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
			currState.Draw(spriteBatch);
			//item.Draw(spriteBatch);
        }
		public void Update(GameTime gameTime)
		{
			currState.Update(gameTime);
			//sprite.Update(gameTime);
			//item.Update(gameTime);
		}

        /*public Link GetLinkObject()
        {
            return this;
        }*/

        /*public T GetObject<T>() where T : ISprite
        {
			T result = this;
            return this;
        }*/


        object ISprite.GetConcreteObject()
        {
            return this;
        }
    }
}

