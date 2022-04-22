using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class HUD
    {
        private Game1 game1;
        private GameObjectManager gom;
        private Camera camera;
        private SpriteFactory spriteFactory;
        private SpriteFont font;
        private Sprite HUDSprite;
        private Link link;
        private Sprite HeartSprite;
        private Texture2D sheet;
        private Vector2 HUDPos;
        private Sprite itemSprite;
        private Sprite swordSprite;
        private int HUDPosX;
        private int HUDPosY;

        private const int HUDPosOffsetX = 525;
        private const int HUDPosOffsetY = 50;

        private const int itemStringOffsetX = 290;
        private const int keysStringOffsetY = 48;
        private const int bombsStringOffsetY = 74;

        private const int sourceRectangleMultiplier = 3;

        private const int fullHeart = 2;
        private const int halfHeart = 1;

        public HUD(GameObjectManager gom)
        {
            this.gom = gom;
            
            this.link = gom.link;
            
        }

        public void SetCamera(Camera camera)
        {
            this.camera = camera;
        }

        public void SetSpriteContent(SpriteFactory spriteFactory)
        {
            this.spriteFactory = spriteFactory;
            font = this.spriteFactory.getFont();
            HUDSprite = this.spriteFactory.getHUDSprite();
            sheet = this.spriteFactory.getHudSheet();
            if(itemSprite == null) itemSprite = spriteFactory.getWallSprite(new Rectangle(0, 0, 0, 0));
            swordSprite = spriteFactory.getSwordSprite();
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            //draw HUD background
            //HUDPos = new Vector2(0, gom.GetBackgroud().GetSpriteRectangle().Height);

            // HUD position is based on the camera position
            HUDPosX = camera.xPos; 
            HUDPosY = (int)Game1.GAME_WINDOW.ROOM_HEIGHT + camera.yPos;
            HUDPos = new Vector2(HUDPosX, HUDPosY);

            HUDSprite.Draw(spriteBatch, HUDPos);
            itemSprite.Draw(spriteBatch, new Vector2(HUDPos.X + 385, HUDPos.Y + 40));
            swordSprite.Draw(spriteBatch, new Vector2(HUDPos.X + 458, HUDPos.Y + 35));

            // numebrs of items link has
            spriteBatch.DrawString(font, "X" + link.rupees.ToString("00"), new Vector2(HUDPos.X + itemStringOffsetX, HUDPos.Y), Color.White);
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

        public void SetItemSprite(Sprite sprite)
        {
            itemSprite = sprite;
        }

        public void SetSoundContent(SoundFactory soundFactory)
        {

        }
        public object GetConcreteObject()
        {
            return this;
        }
    }
}
