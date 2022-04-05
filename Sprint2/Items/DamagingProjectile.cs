using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;

namespace Sprint2
{
    public class DamagingProjectile : ISprite
    {
		public Vector2 pos { get; set; }
		public Enemies enemy;
		public Vector2 enemyPos { get; set; }
		public Sprite enemySprite;
		public SpriteFactory spriteFactory;

		public Sprite sprite;
		public string projectileType;
		public string projectileDirection;

		public DamagingProjectile(Enemies enemy, string projectileType)
		{
			this.spriteFactory = enemy.spriteFactory;
			
			// Enemy fields setup
			this.enemy = enemy;
			this.enemySprite = enemy.sprite;
			this.enemyPos = enemy.pos;

			// Projectile fields setup
			this.projectileType = projectileType;
			this.pos = enemy.pos;
			this.projectileDirection = enemy.direction;

			switch (projectileType)
			{
				case "Boomerang":
					sprite = spriteFactory.getBoomerangSprite();
					break;
				case "Fireball":
					//sprite = spriteFactory.getFireballSprite();
					break;
				default:
					//sprite = spriteFactory.getNullProjectile();
					break;
			}

			CenterProjectilePosition();
			
		}

		private void CenterProjectilePosition()
        {
			Vector2 centeredPos = enemy.pos;
			Rectangle enemyRectangle = enemySprite.getDestinationRectangle();
			Rectangle projectileRectangle = sprite.getDestinationRectangle();

			switch (projectileDirection)
            {
                case "Up":
					centeredPos.X += enemyRectangle.Width / 2;
					centeredPos.Y += projectileRectangle.Height;
					break;
                case "Down":
					centeredPos.X += enemyRectangle.Width / 2;
					centeredPos.Y += enemyRectangle.Height;
					break;
                case "Left":
					centeredPos.X += projectileRectangle.Width;
					centeredPos.Y += enemyRectangle.Height / 2;
					break;
                case "Right":
					centeredPos.X += enemyRectangle.Width;
					centeredPos.Y += enemyRectangle.Height / 2;
					break;
                default:
                    break;
            }
			this.pos = centeredPos;
		}

		public void SetSpriteContent(SpriteFactory spriteFactory)
		{

		}

		public Rectangle GetSpriteRectangle()
		{
			return sprite.getDestinationRectangle();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			sprite.Draw(spriteBatch, pos);
		}

		public void Update(GameTime gameTime)
		{
            Vector2 newPos = pos;
            switch (projectileDirection)
            {
                case "Down":
                    newPos.Y++;
                    pos = newPos;
                    break;
                case "Left":
                    newPos.X--;
                    pos = newPos;
                    break;
                case "Right":
                    newPos.X++;
                    pos = newPos;
                    break;
                case "Up":
                    newPos.Y--;
                    pos = newPos;
                    break;
                default:
                    newPos.Y++;
                    pos = newPos;
                    break;
            }
            sprite.Update(gameTime);
		}

		public DamagingProjectile GetConcreteObject()
		{
			return this;
		}

		object ISprite.GetConcreteObject()
        {
			return this;
        }
    }
}
