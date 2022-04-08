using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Sprint2
{
	class DeadLink : ILinkState, ICommand
	{
		private Link link;
		private Sprite sprite;
		private SpriteFactory spriteFactory;
		private SoundFactory soundFactory;
		private Vector2 currPos;
		private static TimeSpan resetTime;
		private TimeSpan startResetTime;
		bool isDead;
		private Game1 game;

		public DeadLink(Link link)
		{
			this.game = link.game;
			this.link = link;

			spriteFactory = link.spriteFactory;

			sprite = spriteFactory.getDeathScreen();
			resetTime = TimeSpan.FromSeconds(5);
			currPos = link.pos;
			isDead = true;
		}


		public void Draw(SpriteBatch spriteBatch)
		{
			sprite.Draw(spriteBatch, new Vector2(0,0));
		}
		public void Update(GameTime gameTime)
		{

			if (isDead)
			{
				startResetTime = gameTime.TotalGameTime;
				isDead = false;
			}
			else
			{
				if (startResetTime + resetTime < gameTime.TotalGameTime)
				{
					game.Reset();
				}
			}
			sprite.Update(gameTime);
		}

		// No OPs
		public void TakeDamage() { }
		public void StandingUp() { }
		public void StandingDown() { }
		public void StandingRight() { }
		public void StandingLeft() { }
		public void Move() { }
		public void UseWeapon() { }
		public void UseItem(string newItem) { }

		public void Execute()
		{
		}
	}
}

