using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class HUD : ISprite
    {
        public Vector2 pos { get; set; }
        private GameObjectManager gom;
        private SpriteFactory spriteFactory;
        private SpriteFont font;
        private Sprite HUDSprite;
        private Link link;
        private Sprite HeartSprite;
        private Texture2D sheet;
        private Vector2 HUDPos;

        private const int HUDPosX = 300;
        private const int HUDPosY = 550;

        private const int HUDPosOffsetX = 250;
        private const int HUDPosOffsetY = 50;

        private const int itemStringOffsetX = 38;
        private const int keysStringOffsetY = 48;
        private const int bombsStringOffsetY = 74;

        private const int sourceRectangleMultiplier = 3;

        private const int fullHeart = 2;
        private const int halfHeart = 1;

        public HUD(GameObjectManager gom, SpriteFactory spriteFactory)
        {
            this.gom = gom;
            this.link = gom.link;
            this.spriteFactory = spriteFactory;
            font = this.spriteFactory.getFont();
            HUDSprite = this.spriteFactory.getHUDSprite();
            sheet = this.spriteFactory.getHudSheet();
            HUDPos = new Vector2(HUDPosX, HUDPosY);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            //draw HUD background
            HUDSprite.Draw(spriteBatch, HUDPos);

            // numebrs of items link has
            spriteBatch.DrawString(font, "X" + link.rupies.ToString("00"), new Vector2(HUDPos.X + itemStringOffsetX, HUDPos.Y), Color.White);
            spriteBatch.DrawString(font, "X" + link.keys.ToString("00"), new Vector2(HUDPos.X + itemStringOffsetX, HUDPos.Y + keysStringOffsetY), Color.White);
            spriteBatch.DrawString(font, "X" + link.bombs.ToString("00"), new Vector2(HUDPos.X + itemStringOffsetX, HUDPos.Y + bombsStringOffsetY), Color.White);

            //health
            for (int i = fullHeart; i <= link.maxHealth; i+=fullHeart)
            {
                Rectangle sourceRectangle;
                Rectangle destinationRectangle;
                
                    if(link.health >= i)
                    {
                        //draw full heart
                        sourceRectangle = spriteFactory.getFullHeartRect();

                    }
                    else if(link.health == i - halfHeart)
                    {
                        //draw half heart
                        sourceRectangle = spriteFactory.getHalfHeartRect();
                    }
                    else
                    {
                        //draw empty heart
                        sourceRectangle = spriteFactory.getEmptyHeartRect();
                    }
                    destinationRectangle = new Rectangle((int)(HUDPos.X + HUDPosOffsetX + ((sourceRectangleMultiplier * sourceRectangle.Width) * (i / 2))), (int)(HUDPos.Y + HUDPosOffsetY), sourceRectangleMultiplier * sourceRectangle.Width, sourceRectangleMultiplier * sourceRectangle.Height);
                    spriteBatch.Draw(sheet, destinationRectangle, sourceRectangle, Color.White);
                
                
            }
        }

        public void Update(GameTime gameTime)
        {
            HUDSprite.Update(gameTime);
            
        }

        public void SetSpriteContent(SpriteFactory spriteFactory)
        {

        }
        public void SetSoundContent(SoundFactory soundFactory)
        {

        }
        public Rectangle GetSpriteRectangle()
        {
            return new Rectangle(0,0,0,0);
        }
        public object GetConcreteObject()
        {
            return this;
        }
    }
}
