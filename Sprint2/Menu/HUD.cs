using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class HUD
    {
        private GameObjectManager gom;
        private SpriteFactory spriteFactory;
        private SpriteFont font;
        private Sprite HUDSprite;
        private Link link;
        private Sprite HeartSprite;
        private Texture2D sheet;
        private Vector2 HUDPos;



        public HUD(GameObjectManager gom, SpriteFactory spriteFactory)
        {
            this.gom = gom;
            this.link = gom.link;
            this.spriteFactory = spriteFactory;
            font = this.spriteFactory.getFont();
            HUDSprite = spriteFactory.getHUDSprite();
            sheet = spriteFactory.getHudSheet();
            HUDPos = new Vector2(300, 550); // 300, 550
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            //draw HUD background
            HUDSprite.Draw(spriteBatch, HUDPos);

            // numebrs of items link has
            spriteBatch.DrawString(font, "X" + link.rupies.ToString("00"), new Vector2(HUDPos.X + 38, HUDPos.Y), Color.White);
            spriteBatch.DrawString(font, "X" + link.keys.ToString("00"), new Vector2(HUDPos.X + 38, HUDPos.Y + 48), Color.White);
            spriteBatch.DrawString(font, "X" + link.bombs.ToString("00"), new Vector2(HUDPos.X + 38, HUDPos.Y + 74), Color.White);

            //health
            for (int i = 2; i <= link.maxHealth; i+=2)
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
                    destinationRectangle = new Rectangle(550 + ((3 *sourceRectangle.Width) * (i / 2)), 600, 3 * sourceRectangle.Width, 3 * sourceRectangle.Height);
                    spriteBatch.Draw(sheet, destinationRectangle, sourceRectangle, Color.White);
                
                
            }
        }

        public void Update(GameTime gameTime)
        {
            HUDSprite.Update(gameTime);
            
        }
    }
}
