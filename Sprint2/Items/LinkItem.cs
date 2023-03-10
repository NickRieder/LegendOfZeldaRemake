using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Sprint2
{
    public class LinkItem
    {
        private string itemString;
        private ISprite currItem;
        private SpriteFactory spriteFactory;

        private Link link;
        // private NullSprite nullItem;
        private Boolean isUsingItem;
        private TimeSpan startTimeUsing;
        private GameObjectManager gom;


        public LinkItem(Link link, SpriteFactory spriteFactory)
        {
            this.spriteFactory = spriteFactory;
            this.link = link;
            currItem = new NullSprite();
            // nullItem = new NullSprite();
            isUsingItem = false;
            this.gom = link.gom;

        }

        public void SetItem(string item)
        {
            itemString = item;
        }
        //currItem.GetType().ToString().Equals(nullItem.ToString())
        public void Use()
        {
            if (link.isUsingItem == false)
            {
                /*Debug.WriteLine("currItem = " + currItem.GetType().ToString());
                Debug.WriteLine("null Item = " + nullItem.GetType().ToString());
                Debug.WriteLine("Equals: " + currItem.GetType().Equals(nullItem));
                Debug.WriteLine("Equals: " + currItem.GetType().ToString().Equals(nullItem.ToString()));*/

                switch (itemString)
                {
                    case "boomerang":
                        currItem = new LinkBoomerang(link, "boomerang");
                        gom.AddToMovableObjectList(currItem);
                        gom.AddToDrawableObjectList(currItem);
                        link.boomerangSound.Play();
                        break;
                    case "arrow":
                        currItem = new LinkArrow(link, "arrow");
                        gom.AddToMovableObjectList(currItem);
                        gom.AddToDrawableObjectList(currItem);
                        link.arrowSound.Play();
                        
                        break;
                    case "bomb":
                        if(link.bombs > 0)
                        { 
                            currItem = new LinkExplosion(link, "bomb");
                            gom.AddToMovableObjectList(currItem);
                            gom.AddToDrawableObjectList(currItem);
                            link.bombThrow.Play();
                            link.bombs--;
                        }
                        break;
                }

            }
        }

        public void SetNull()
        {
            currItem = new NullSprite();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //currItem.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            currItem.Update(gameTime);
            if (isUsingItem)
            {
                startTimeUsing = gameTime.TotalGameTime;
                isUsingItem = false;
            }
            if (startTimeUsing + TimeSpan.FromMilliseconds(1000) < gameTime.TotalGameTime)
            {
                SetNull();
            }
        }
    }
}