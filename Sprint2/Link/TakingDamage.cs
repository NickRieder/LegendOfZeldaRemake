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
		private static TimeSpan damagedTimeSpan;
		private TimeSpan startDamagedTime;
		private static TimeSpan resetTime;
		private TimeSpan startResetTime;
		private Game1 game;

		private int damagedTimer;

		public static int damagedDuration = 30;
		private const int linkKnockedSpeed = 7;
		

		private int collisionSide;
		private static int topSide = (int)CollisionDetector.COLLISION_SIDE.TOP;
		private static int bottomSide = (int)CollisionDetector.COLLISION_SIDE.BOTTOM;
		private static int leftSide = (int)CollisionDetector.COLLISION_SIDE.LEFT;
		private static int rightSide = (int)CollisionDetector.COLLISION_SIDE.RIGHT;

		public TakingDamage(Link link, int collisionSide)
		{
			this.game = link.game;
			this.link = link;
			sprite = link.sprite;
			damagedTimer = 0;

			spriteFactory = link.spriteFactory;
			
			link.sprite = spriteFactory.getLinkDamaged(); // why does link.sprite not work the same?
			damagedTimeSpan = TimeSpan.FromMilliseconds(500);
			currPos = link.pos;

			link.canTakeDamage = false;
			this.collisionSide = collisionSide;
		}


		public void Draw(SpriteBatch spriteBatch)
		{
			link.sprite.Draw(spriteBatch, link.pos);
		}
		public void Update(GameTime gameTime)
		{

			if (link.health == 0)
            {
				link.currState = new DeadLink(link);
			}
			if (damagedTimer >= damagedDuration)    // link.canTakeDamage || 
			{
				link.canTakeDamage = true;
				//damagedTimer = 0;
				link.currState = new NewDirectionalLinkSprite(link, link.direction);
			}
            else if (!link.canTakeDamage)
            {
                if (collisionSide == topSide)
                {
                    currPos.Y += linkKnockedSpeed;
                    link.pos = currPos;
                }
                else if (collisionSide == bottomSide)
                {
                    currPos.Y -= linkKnockedSpeed;
                    link.pos = currPos;
                }
                else if (collisionSide == leftSide)
                {
                    currPos.X += linkKnockedSpeed;
                    link.pos = currPos;
                }
                else if (collisionSide == rightSide)
                {
                    currPos.X -= linkKnockedSpeed;
                    link.pos = currPos;
                }
            }
            if (!link.canTakeDamage)
            {
                damagedTimer++;
            }
			damagedTimer++;


			link.sprite.Update(gameTime);
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
			link.TakeDamage(collisionSide);
		}
	}
}