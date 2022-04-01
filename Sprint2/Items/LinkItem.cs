using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Sprint2
{
    public class LinkItem
    {
        private string itemString;
        private IItem currItem;
        private SpriteFactory spriteFactory;
        private Link link;
        private NullItem nullItem;
        private Boolean isUsingItem;
        private TimeSpan startTimeUsing;

        public LinkItem(Link link, SpriteFactory spriteFactory)
        {
            this.spriteFactory = spriteFactory;
            this.link = link;
            currItem = new NullItem();
            nullItem = new NullItem();
            isUsingItem = false;
        }

        public void SetItem(string item)
        {
            itemString = item;
        }

        public void Use()
        {
            if(currItem.GetType().ToString().Equals(nullItem.ToString()))
            {
            /*Debug.WriteLine("currItem = " + currItem.GetType().ToString());
            Debug.WriteLine("null Item = " + nullItem.GetType().ToString());
            Debug.WriteLine("Equals: " + currItem.GetType().Equals(nullItem));
            Debug.WriteLine("Equals: " + currItem.GetType().ToString().Equals(nullItem.ToString()));*/

            switch (itemString)
                {
                    case "Boomerang":
                        currItem = new Boomerang(link, spriteFactory);
                        break;
                    case "Arrow":
                        currItem = new Arrow(link, spriteFactory);
                        break;
                    case "Explosion":
                        currItem = new Explosion(link, spriteFactory);
                        break;
                }
                isUsingItem = true;
            }
            
        }

        public void SetNull()
        {
            currItem = new NullItem();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currItem.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            currItem.Update(gameTime);
            if (isUsingItem)
            {
                startTimeUsing = gameTime.TotalGameTime;
                isUsingItem = false;
            }
            if (startTimeUsing + TimeSpan.FromMilliseconds(3000) < gameTime.TotalGameTime)
            {
                SetNull();
            }
        }
    }
}
