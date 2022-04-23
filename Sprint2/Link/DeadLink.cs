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
		private GameObjectManager gom;

		public DeadLink(Link link)
		{
			this.game = link.game;
			this.link = link;
			this.gom = link.gom;

			game.themeSongLoop.Stop();

			spriteFactory = link.spriteFactory;
			
			sprite = spriteFactory.getDeathScreen();
			resetTime = TimeSpan.FromSeconds(5);
			currPos = link.pos;
			gom.isDead = true;
			isDead = true;
			gom.ClearSpriteList();
		}


		public void Draw(SpriteBatch spriteBatch)
		{
			//sprite.Draw(spriteBatch, new Vector2(0,0));
			spriteBatch.Draw(spriteFactory.getDeathSheet(), new Rectangle(0, 0, (int) Game1.GAME_WINDOW.WIDTH, (int) Game1.GAME_WINDOW.HEIGHT), new Rectangle(0, 0, 255, 300), Color.White);
			
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
		public void TakeDamage(int collisionSide) { }
		public void StandingUp() { }
		public void StandingDown() { }
		public void StandingRight() { }
		public void StandingLeft() { }
		public void Move(string direction) { }
		public void UseWeapon() { }
		public void UseItem(string newItem) { }

		public void Execute()
		{
		}
	}
}

