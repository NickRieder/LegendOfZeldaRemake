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
            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result

            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            projectDirectory = projectDirectory.Replace((char)92, '/');

            XmlReader reader = XmlReader.Create(projectDirectory + "/Content/Levels/" + fileName + ".xml");



            while (reader.Read())
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

                            reader.ReadToFollowing("room");
                            string prevRoom = reader.ReadElementContentAsString();

                            reader.ReadToFollowing("clickNext");
                            string nextClickRoom = reader.ReadElementContentAsString();

                            reader.ReadToFollowing("XCoord");
                            pos.X = reader.ReadElementContentAsInt();

                            reader.ReadToFollowing("YCoord");
                            pos.Y = reader.ReadElementContentAsInt();

                            levelLoader.LoadDoorObject(objType, pos, room, prevRoom, nextClickRoom);
                            break;
                        case "background":
                            reader.ReadToFollowing("sprite");
                            string roomName = reader.ReadElementContentAsString();

                            levelLoader.LoadBackground(roomName);
                            break;
                        case "wall":
                            reader.ReadToFollowing("XCoord");
                            pos.X = reader.ReadElementContentAsInt();

                            reader.ReadToFollowing("YCoord");
                            pos.Y = reader.ReadElementContentAsInt();

                            reader.ReadToFollowing("Width");
                            int width = reader.ReadElementContentAsInt();

                            reader.ReadToFollowing("Height");
                            int height = reader.ReadElementContentAsInt();

                            Rectangle rect = new Rectangle(0, 0, width, height);
                            levelLoader.LoadWall(rect, pos);
                            break;
                        default:
                            break;
                    }
                }
            }
        } 
    }
}
