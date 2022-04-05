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
		public GameObjectManager gom;

		public Sprite sprite;
		public string projectileType;
		public string projectileDirection;

		public DamagingProjectile(Enemies enemy, string projectileType)
		{
			this.spriteFactory = enemy.spriteFactory;
			this.gom = enemy.gom;

			// Enemy fields setup
			this.enemy = enemy;
			this.enemySprite = enemy.sprite;
			this.enemyPos = enemy.pos;

			// Projectile fields setup
			this.projectileType = projectileType;
			//this.pos = enemy.pos;
			this.projectileDirection = enemy.direction;
			

			switch (projectileType)
			{
				case "Boomerang":
					CenterProjectilePosition(spriteFactory.getBoomerangSprite());
					sprite = spriteFactory.getBoomerangSprite();
					break;
				case "Fireball":
					CenterProjectilePosition(spriteFactory.getFireballSprite());
					sprite = spriteFactory.getFireballSprite();
					break;
				default:
					sprite = spriteFactory.getNullProjectile();
					break;
			}

			
			
		}

		private void CenterProjectilePosition(Sprite projectileSprite)
        {
			Vector2 centeredPos = enemyPos;
			Rectangle enemyRectangle = enemy.GetSpriteRectangle(); // enemySprite.getDestinationRectangle()
			Rectangle projectileRectangle = projectileSprite.getCurrentFrameRectangle();
			int divisorVal = 2;
			int eWidth = enemyRectangle.Width;
			int halfEW = enemyRectangle.Width / divisorVal;
			int pWidth = projectileRectangle.Width;
			int halfPW = projectileRectangle.Width / divisorVal;
			int eHeight = enemyRectangle.Height;
			int halfEH = enemyRectangle.Height / divisorVal;
			int pHeight = projectileRectangle.Height;
			int halfPH = projectileRectangle.Height / divisorVal;
			//System.Diagnostics.Debug.WriteLine("DEBUG: Values" +"\n centeredPos.X = " + centeredPos.X + "\n centeredPos.Y = " +centeredPos.Y +"\n enemy w = " +eWidth +"\n 1/2 enemy w = " +halfEW +"\n proj w = " +pWidth +"\n 1/2 proj w = " +halfPW + "\n enemy h = " + eHeight + "\n 1/2 enemy h = " + halfEH + "\n proj h = " + pHeight + "\n 1/2 proj h = " + halfPH);
			float centerPosX = centeredPos.X + (float)(halfEW - halfPW);
			float centerPosY = centeredPos.Y + (float)(halfEH - halfPH);
			//System.Diagnostics.Debug.WriteLine("DEBUG: Result" +"\n centerPosX = " +centerPosX +"\n centerPosY = " +centerPosY);
			switch (projectileDirection)
            {
                case "Up":
					centeredPos.X = centerPosX;
					centeredPos.Y -= pHeight;
					break;
                case "Down":
					centeredPos.X = centerPosX;
					centeredPos.Y += eHeight;
					break;
                case "Left":
					centeredPos.X -= pWidth;
					centeredPos.Y = centerPosY;
					break;
                case "Right":
					centeredPos.X += eWidth;
					centeredPos.Y = centerPosY;
					break;
                default:
                    break;
            }
			//System.Diagnostics.Debug.WriteLine("DEBUG: Return" + "\n centeredPos.X = " + centeredPos.X + "\n centeredPos.Y = " + centeredPos.Y);
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

		public void RemoveProjectile(ISprite projectile)
        {
			gom.RemoveFromEveryCollection(projectile);
        }

		public virtual void Update(GameTime gameTime) // the virtual keyword allows subclasses to override methods
		{
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
