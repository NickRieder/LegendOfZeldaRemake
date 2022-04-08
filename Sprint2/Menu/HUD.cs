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
        private int HUDPosX;
        private int HUDPosY;


        public HUD(Game1 game1, SpriteFactory spriteFactory)
        {
            this.game1 = game1;
            this.gom = game1.gom;
            this.camera = game1.camera;
            this.link = gom.link;

            this.spriteFactory = spriteFactory;
            font = this.spriteFactory.getFont();
            HUDSprite = this.spriteFactory.getHUDSprite();
            sheet = this.spriteFactory.getHudSheet();
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

            // numebrs of items link has
            spriteBatch.DrawString(font, "X" + link.rupies.ToString("00"), new Vector2(HUDPos.X + 290, HUDPos.Y), Color.White);
            spriteBatch.DrawString(font, "X" + link.keys.ToString("00"), new Vector2(HUDPos.X + 290, HUDPos.Y + 48), Color.White);
            spriteBatch.DrawString(font, "X" + link.bombs.ToString("00"), new Vector2(HUDPos.X + 290, HUDPos.Y + 74), Color.White);

            //health
            for (int i = 2; i <= link.health; i+=2)
            {
                Rectangle sourceRectangle;
                Rectangle destinationRectangle;
                
                    if(link.health >= i)
                    {
                        //draw full heart
                        sourceRectangle = spriteFactory.getFullHeartRect();

                    }
                    else if(link.health == i - 1)
                    {
                        //draw half heart
                        sourceRectangle = spriteFactory.getHalfHeartRect();
                    }
                    else
                    {
                        //draw empty heart
                        sourceRectangle = spriteFactory.getEmptyHeartRect();
                    }
                    destinationRectangle = new Rectangle((int)(HUDPos.X + 525 + ((3 *sourceRectangle.Width) * (i / 2))), (int)(HUDPos.Y + 50), 3 * sourceRectangle.Width, 3 * sourceRectangle.Height);
                    spriteBatch.Draw(sheet, destinationRectangle, sourceRectangle, Color.White);
                
                
            }
        }

        public void Update(GameTime gameTime)
        {
            HUDSprite.Update(gameTime);
            
        }
    }
}
