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
		public SpriteFactory spriteFactory;

		public Sprite sprite;
		public string projectileType;
		public string projectileDirection;

		public DamagingProjectile(Enemies enemy, string projectileType)
		{
			this.spriteFactory = enemy.spriteFactory;
			this.projectileType = projectileType;
			this.pos = enemy.pos;

			this.enemy = enemy;
			this.enemyPos = enemy.pos;
			this.projectileDirection = enemy.direction;

			switch (projectileType)
			{
				case "Boomerang":
					//System.Diagnostics.Debug.WriteLine("DEBUG: Got a Boomerang");
					sprite = spriteFactory.getGoriyaBoomerang();
					break;
				case "Fireball":
					//sprite = spriteFactory.getDragonFireball();
					break;
				case "Null":
					sprite = spriteFactory.getNullProjectile();
					break;
				default:
					sprite = spriteFactory.getFlatBlockSprite();
					break;
			}
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
