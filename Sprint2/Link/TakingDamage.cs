using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Sprint2
{
	class TakingDamage : ILinkState, ICommand
	{
		private Link link;
		private Sprite sprite;
		private SpriteFactory spriteFactory;
		private SoundFactory soundFactory;
		private Vector2 currPos;
		private static TimeSpan damagedTime;
		private TimeSpan startDamagedTime;
		bool isDamaged;


		public TakingDamage(Link link)
		{
			this.link = link;
			sprite = link.sprite;


			spriteFactory = link.spriteFactory;

			sprite = spriteFactory.getLinkDamaged();
			damagedTime = TimeSpan.FromMilliseconds(500);
			currPos = link.pos;
			isDamaged = true;

		}


		public void Draw(SpriteBatch spriteBatch)
		{
			sprite.Draw(spriteBatch, link.pos);
		}
		public void Update(GameTime gameTime)
		{
			if (isDamaged)
			{

				startDamagedTime = gameTime.TotalGameTime;
				isDamaged = false;
			}
			if (startDamagedTime + damagedTime < gameTime.TotalGameTime)
			{
				link.currState = new NewDirectionalLinkSprite(link, link.direction);
			}
			else
			{
				switch (link.direction)
				{
					case "down":

						currPos.Y -= 3;
						link.pos = currPos;
						break;
					case "left":
						currPos.X += 3;
						link.pos = currPos;
						break;
					case "right":
						currPos.X -= 3;
						link.pos = currPos;
						break;
					default: // facing up
						currPos.Y += 3;

						link.pos = currPos;
						break;
				}
			}
			sprite.Update(gameTime);
			link.sprite.Update(gameTime);
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

			link.TakeDamage();
		}
	}
}