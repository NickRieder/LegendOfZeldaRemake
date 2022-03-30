using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
	public class Link : ILinkState, ISprite
	{
		public ILinkState currState;
		public Vector2 pos { get; set; }
		public SpriteFactory spriteFactory;
		public SoundFactory soundFactory;
		
		public Sprite sprite;
		public int health;
		public IItem item;
		public int sizeMuliplier = 3;
		public string direction;
		public SoundEffect linkHurtSound;
		public SoundEffect linkDeadSound;
		public SoundEffect lowHealthSound;
		
		public Link()
		{
			item = new NullItem();
			health = 3;
			pos = new Vector2(40, 40);
			
		}

		public void SetSoundContent(SoundFactory soundFactory)
        {
			this.soundFactory = soundFactory;
			lowHealthSound = soundFactory.getLowHealth();
			linkHurtSound = soundFactory.getLinkHurt();
			linkDeadSound = soundFactory.getLinkDead();
		}

		
		public void SetSpriteContent(SpriteFactory spriteFactory)
        {
			this.spriteFactory = spriteFactory;
			this.currState = new StandingFacingDown(this);
			sprite = spriteFactory.getLinkStandingFacingDownSprite();
			direction = "down";
		}

		public void SetPos(Vector2 pos)
        {
			this.pos = pos;
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
		public void UseItem(int itemNum)
        {
			currState.UseItem(itemNum);
        }
		public void TakeDamage()
        {
			currState.TakeDamage();
			if (health == 0)
            {
				linkDeadSound.Play();
            }
			else if (health == 1)
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
			item.Draw(spriteBatch, pos);
        }
		public void Update(GameTime gameTime)
		{
			currState.Update(gameTime);
			sprite.Update(gameTime);
			item.Update(gameTime);
		}

		public Link GetConcreteObject()
		{
			return this;
		}

		object ISprite.GetConcreteObject()
		{
			return this;
		}
	}
}

