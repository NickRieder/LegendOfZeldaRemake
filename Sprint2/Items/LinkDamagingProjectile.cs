using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class LinkDamagingProjectile: ISprite
    {
		public Vector2 pos { get; set; }
		public Link link;
		public Vector2 linkPos { get; set; }
		public Sprite linkSprite;
		public SpriteFactory spriteFactory;
		public GameObjectManager gom;

		public Sprite sprite;
		public string projectileType;
		public string projectileDirection;
		//private string linkDirection;
		Vector2 itemPos;

		public bool canDealDamage;


		public LinkDamagingProjectile(Link link, string projectileType)
		{
			canDealDamage = true;
			//System.Diagnostics.Debug.WriteLine(projectileType);
			this.spriteFactory = link.spriteFactory;
			this.gom = link.gom;

			// Enemy fields setup
			this.link = link;
			this.linkSprite = link.sprite;
			this.linkPos = link.pos;

			// Projectile fields setup
			this.projectileType = projectileType;

			//this.pos = enemy.pos;
			this.projectileDirection = link.direction;

			link.isUsingItem = true;

			switch (projectileType)
			{
				case "boomerang":
					CenterProjectilePosition(spriteFactory.getBoomerangSprite());
					sprite = spriteFactory.getBoomerangSprite();
					
					break;
				case "arrow":
					switch (link.direction)
					{
						case "down":
							CenterProjectilePosition(spriteFactory.getArrowSpriteDown());
							sprite = spriteFactory.getArrowSpriteDown();
							break;
						case "up":
							CenterProjectilePosition(spriteFactory.getArrowSpriteUp());
							sprite = spriteFactory.getArrowSpriteUp();
							break;
						case "right":
							CenterProjectilePosition(spriteFactory.getArrowSpriteRight());
							sprite = spriteFactory.getArrowSpriteRight();
							break;
						case "left":
							CenterProjectilePosition(spriteFactory.getArrowSpriteLeft());
							sprite = spriteFactory.getArrowSpriteLeft();
							break;
						default:
							break;
					}
					break;
				case "bomb":
					CenterProjectilePosition(spriteFactory.getBombSprite());
					sprite = spriteFactory.getBombSprite();

					break;
			
				default:
					sprite = spriteFactory.getNullProjectile();
					break;
			}
		}

		private void CenterProjectilePosition(Sprite projectileSprite)
		{
			Vector2 centeredPos = linkPos;
			Rectangle enemyRectangle = link.getCurrentFrameRectangle();
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
				case "up":
					centeredPos.X = centerPosX;
					centeredPos.Y -= pHeight;
					break;
				case "down":
					centeredPos.X = centerPosX;
					centeredPos.Y += eHeight;
					break;
				case "left":
					centeredPos.X -= pWidth;
					centeredPos.Y = centerPosY;
					break;
				case "right":
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
		public void SetSoundContent(SoundFactory soundFactory)
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

		public LinkDamagingProjectile GetConcreteObject()
		{
			return this;
		}

        object ISprite.GetConcreteObject()
        {
            throw new NotImplementedException();
        }
    }
}

