using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Sprint2
{
    public class CollisonDetector
    {
        private GameObjectManager gom;
        private ArrayList allObjectList;
        private ArrayList movableObjectList;

        public CollisonDetector(GameObjectManager gom)
        {
            this.gom = gom;
            allObjectList = gom.allObjectList;
            movableObjectList = gom.movableList;
        }
        public void Update(GameTime gametime)
        {
            foreach(ISprite movableSprite in movableObjectList)
            {
                foreach(ISprite otherSprite in allObjectList)
                {
                    if (!(movableSprite == otherSprite))
                    {
                        
                    }

                                     
                }
            }
        }
    }
}
