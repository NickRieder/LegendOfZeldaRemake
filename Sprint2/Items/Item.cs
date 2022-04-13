using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;
using Microsoft.Xna.Framework.Audio;

namespace Sprint2
{
	public class Item : ISprite
	{
		public Vector2 pos { get; set; }
		public SpriteFactory spriteFactory;
		public SoundFactory soundFactory;
		private GameObjectManager gom;
		private Texture2D itemSheet;
		public int spriteSizeMultiplier;
		private Sprite sprite;
		public string itemName;
		private static int itemPosX = 200;
		private static int itemPosY = 200;
		private static int sourceRectangleMultiplier = 5;
		private Link link;
		private Menu menu;
		private SoundEffect rupeePickup;
		private SoundEffect swordPickup;
		private SoundEffect keyPickup;
		private SoundEffect bombPickup;
		private SoundEffect bowPickup;
		private SoundEffect heartPickup;
		private SoundEffect boomerangPickup;


		public Item(string itemName, Vector2 pos, GameObjectManager gom)
		{
			
			this.gom = gom;
			this.itemName = itemName;
			spriteSizeMultiplier = 2;
			this.pos = pos;
			this.link = gom.link;
			this.menu = gom.menu;

		}

		public Rectangle GetSpriteRectangle()
		{
			return new Rectangle(0, 0, 0, 0); // Change this to Item Sprite
		}
		public void SetSpriteContent(SpriteFactory spriteFactory)
		{
			this.spriteFactory = spriteFactory;
			this.itemSheet = this.spriteFactory.getItemSheet();

			switch (itemName)
			{
				case "sword":
					sprite = spriteFactory.getSwordSprite();
					break;
				case "boomerang":
					sprite = spriteFactory.getBoomerangPickUpSprite();
					break;
				case "bomb":
					sprite = spriteFactory.getBombSprite();
					break;
				case "key":
					sprite = spriteFactory.getKeySprite();
					break;
				case "bow":
                    sprite = spriteFactory.getBowSprite();
					break;
				case "heart":
					sprite = spriteFactory.getHeartSprite();
					break;
				case "rupee":
					sprite = spriteFactory.getRupeeSprite();
					break;
                default:
					break;
			}
		}
		public void SetSoundContent(SoundFactory soundFactory)
		{
			this.soundFactory = soundFactory;
			rupeePickup = soundFactory.getRupeeSound();
			swordPickup = soundFactory.newDiscoveredItemSound();
			heartPickup = soundFactory.getHeartSound();
			keyPickup = soundFactory.getSecretSolved();
			bombPickup = soundFactory.getItemSound();
			bowPickup = soundFactory.getItemSound();
			boomerangPickup = soundFactory.getItemSound();


		}
		public void PickupItem()
        {
			menu.AddToItemList(itemName);
			switch (itemName)
			{
				case "sword":
					swordPickup.Play();
					break;

				case "boomerang":
					boomerangPickup.Play();
					break;

				case "bomb":
					link.bombs++;
					bombPickup.Play();
					break;

				case "key":
					link.keys++;
					keyPickup.Play();
					break;

				case "bow":	
					bowPickup.Play();
					break;

				case "heart":
					link.health++;
					heartPickup.Play();
					break;

				case "rupee":
					link.rupees++;
					rupeePickup.Play();
					break;

				default:
					break;
			}
		}
		

		public void Draw(SpriteBatch spriteBatch)
		{
			if (!menu.itemList.Contains(itemName)){
				sprite.Draw(spriteBatch, pos);
			}
			
		}

		public void Update(GameTime gameTime)
		{
			sprite.Update(gameTime);
		}

		public Item GetConcreteObject()
		{
			return this;
		}

		object ISprite.GetConcreteObject()
		{
			return this;
		}
	}
}
