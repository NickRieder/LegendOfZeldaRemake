using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class XMLParser
    {
        private LevelLoader levelLoader;
        public Block block;
        public XMLParser(LevelLoader levelLoader)
        {
            this.levelLoader = levelLoader;
        }
        public void parseFile(String fileName)
        {
            Vector2 pos;
            String objType;
            XmlNode node;
            XmlReader reader = XmlReader.Create(TitleContainer.OpenStream(@"Content/Levels/" + fileName + ".xml"));

         

            
            while(reader.Read())
            {
                if(reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "block":
                            reader.MoveToFirstAttribute();
                            objType = reader.Value;

                            reader.ReadToFollowing("XCoord");
                            pos.X = reader.ReadElementContentAsInt();

                            reader.ReadToFollowing("YCoord");
                            pos.Y = reader.ReadElementContentAsInt();


                            levelLoader.LoadBlockObject(objType, pos);
                            break;
                        case "enemy":
                            reader.MoveToFirstAttribute();
                            objType = reader.Value;

                            reader.ReadToFollowing("XCoord");
                            pos.X = reader.ReadElementContentAsInt();

                            reader.ReadToFollowing("YCoord");
                            pos.Y = reader.ReadElementContentAsInt();

                            levelLoader.LoadEnemyObject(objType, pos);
                            break;
                        case "door":
                            reader.MoveToFirstAttribute();
                            objType = reader.Value;

                            reader.ReadToFollowing("room");
                            string room = reader.ReadElementContentAsString();

                            reader.ReadToFollowing("XCoord");
                            pos.X = reader.ReadElementContentAsInt();

                            reader.ReadToFollowing("YCoord");
                            pos.Y = reader.ReadElementContentAsInt();

                            levelLoader.LoadDoorObject(objType, pos, room);
                            break;
                        default:
                            break;
                    }
                }
                

                

            }

           

            
        }
        
    }
}
