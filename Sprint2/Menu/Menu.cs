using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class Menu
    {

        private GameObjectManager gom;
        private SpriteFactory spriteFactory;
        private Link link;
        public List<string> itemList;
        private int index;
        private Sprite menuSprite;
        private Sprite selectorSprite;
        private Sprite itemSprite;
        public Menu(GameObjectManager gom)
        {
            this.gom = gom;
            this.link = gom.link;
            itemList = new List<string>();

        }

        public void SetSpriteContent(SpriteFactory spriteFactory)
        {
            this.spriteFactory = spriteFactory;
            menuSprite = spriteFactory.getMenuSprite();
            selectorSprite = spriteFactory.getSelectorSprite();
            itemSprite = spriteFactory.getWallSprite(new Rectangle(0, 0, 0, 0));

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            menuSprite.Draw(spriteBatch, new Vector2(0, 0));
            selectorSprite.Draw(spriteBatch, new Vector2(390 + (index * 50), 140));
            itemSprite.Draw(spriteBatch, new Vector2(205, 150));

            Vector2 pos = new Vector2(400, 150);
            foreach (string item in itemList)
            {
                
                Sprite sprite;
                
                switch(item)
                {
                    case "boomerang":
                        sprite = spriteFactory.getBoomerangSprite();
                        break;
                    case "arrow":
                        sprite = spriteFactory.getBowSprite();
                        break;
                    case "bow":
                        sprite = spriteFactory.getBowSprite();
                        break;
                    case "bomb":
                        sprite = spriteFactory.getBombSprite();
                        break;
                    default:
                        sprite = spriteFactory.getFlatBlockSprite();
                        break;
                }
                
                sprite.Draw(spriteBatch, pos);
                pos.X += selectorSprite.getDestinationRectangle().Width;
            }

        }


        public void AddToItemList(string item)
        {
            if(!itemList.Contains(item)) itemList.Add(item);
        }

        public void SetItem()
        {
            if (index < itemList.Count)
            {
                string item = itemList[index];
                link.SetItem(item);

                switch (item)
                {
                    case "boomerang":
                        itemSprite = spriteFactory.getBoomerangSprite();
                        break;
                    case "arrow":
                        itemSprite = spriteFactory.getBowSprite();
                        break;
                    case "bomb":
                        itemSprite = spriteFactory.getBombSprite();
                        break;
                    default:
                        itemSprite = spriteFactory.getFlatBlockSprite();
                        break;
                }
                gom.hud.SetItemSprite(itemSprite);
            }

        }

        public void NextItem()
        {
            if(index != itemList.Count - 1) index++;
        }
        public void PreviousItem()
        {
            if (index != 0) index--;
        }

    }
}
