using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace Sprint2
{
    class RoomWriter
    {
        private RoomGenerator roomGenerator;
        private int difficulty = 5;
        private int[] xVar = new int[12] {98, 145, 192, 239, 286, 333, 382, 429, 478, 526, 573, 624};
        private int[] yVar = new int[7] { 98, 145, 192, 239, 286, 336, 383};
        private string projectDirectory;

        public RoomWriter(RoomGenerator roomGenerator)
        {
            string workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            projectDirectory = projectDirectory.Replace((char)92, '/');
            this.roomGenerator = roomGenerator;
        }
    
        public void writeHeader(XmlWriter writer)
        {
           
            writer.WriteStartElement("Level", "root");
            writer.WriteStartElement("background");
            writer.WriteStartElement("sprite");
            writer.WriteString("room1");
            writer.WriteEndElement(); //end sprite
            writer.WriteEndElement(); //end background
            writer.WriteStartElement("Walls");

            //wall 1
            writer.WriteStartElement("wall");
            writer.WriteStartElement("XCoord");
            writer.WriteString("0");
            writer.WriteEndElement(); //end XCoord
            writer.WriteStartElement("YCoord");
            writer.WriteString("22");
            writer.WriteEndElement(); //end YCoord
            writer.WriteStartElement("Width");
            writer.WriteString("300");
            writer.WriteEndElement(); //end Width
            writer.WriteStartElement("Height");
            writer.WriteString("20");
            writer.WriteEndElement(); //end Height
            writer.WriteEndElement(); //end wall

            //wall 2
            writer.WriteStartElement("wall");
            writer.WriteStartElement("XCoord");
            writer.WriteString("0");
            writer.WriteEndElement(); //end XCoord
            writer.WriteStartElement("YCoord");
            writer.WriteString("435");
            writer.WriteEndElement(); //end YCoord
            writer.WriteStartElement("Width");
            writer.WriteString("300");
            writer.WriteEndElement(); //end Width
            writer.WriteStartElement("Height");
            writer.WriteString("5");
            writer.WriteEndElement(); //end Height
            writer.WriteEndElement(); //end wall
            
            //wall 3
            writer.WriteStartElement("wall");
            writer.WriteStartElement("XCoord");
            writer.WriteString("25");
            writer.WriteEndElement(); //end XCoord
            writer.WriteStartElement("YCoord");
            writer.WriteString("0");
            writer.WriteEndElement(); //end YCoord
            writer.WriteStartElement("Width");
            writer.WriteString("20");
            writer.WriteEndElement(); //end Width
            writer.WriteStartElement("Height");
            writer.WriteString("300");
            writer.WriteEndElement(); //end Height
            writer.WriteEndElement(); //end wall
            
            //wall 4
            writer.WriteStartElement("wall");
            writer.WriteStartElement("XCoord");
            writer.WriteString("680");
            writer.WriteEndElement(); //end XCoord
            writer.WriteStartElement("YCoord");
            writer.WriteString("0");
            writer.WriteEndElement(); //end YCoord
            writer.WriteStartElement("Width");
            writer.WriteString("20");
            writer.WriteEndElement(); //end Width
            writer.WriteStartElement("Height");
            writer.WriteString("300");
            writer.WriteEndElement(); //end Height
            writer.WriteEndElement(); //end wall

            writer.WriteEndElement(); //end Wall
        }

        public void generateDoors(XmlWriter writer, string roomName)
        {
            String secDoor = roomGenerator.GenerateSecretDoor();
            writer.WriteStartElement("Doors");
            if (secDoor.Equals("top")) {
                writer.WriteStartElement("door");
                writer.WriteAttributeString("Type", "TopOpen");
                writer.WriteStartElement("room");
                writer.WriteString("EndlessRooms/EndlessSecretRoom");
                writer.WriteEndElement(); //End room
                writer.WriteStartElement("room");
                writer.WriteString("");
                writer.WriteEndElement(); //End room
                writer.WriteStartElement("clickNext");
                writer.WriteString("");
                writer.WriteEndElement();//End clickNext
                writer.WriteEndElement(); //End door
                writer.WriteStartElement("XCoord");
                writer.WriteValue(336);
                writer.WriteEndElement(); //end XCoord
                writer.WriteStartElement("YCoord");
                writer.WriteValue(3);
                writer.WriteEndElement(); //end YCoord
            } else
            {
                writer.WriteStartElement("door");
                writer.WriteAttributeString("Type", "TopWall");
                writer.WriteStartElement("room");
                writer.WriteString("");
                writer.WriteEndElement(); //End room
                writer.WriteStartElement("room");
                writer.WriteString("");
                writer.WriteEndElement(); //End room
                writer.WriteStartElement("clickNext");
                writer.WriteString("");
                writer.WriteEndElement();//End clickNext
                writer.WriteEndElement(); //End door
                writer.WriteStartElement("XCoord");
                writer.WriteValue(336);
                writer.WriteEndElement(); //end XCoord
                writer.WriteStartElement("YCoord");
                writer.WriteValue(3);
                writer.WriteEndElement(); //end YCoord
            }
            switch (roomName)
            {
                case "EndlessRoom1":
                    writer.WriteStartElement("door");
                    writer.WriteAttributeString("Type", "RightOpen");
                    writer.WriteStartElement("room");
                    writer.WriteString("EndlessRooms/EndlessRoom2");
                    writer.WriteEndElement(); //End room
                    writer.WriteStartElement("room");
                    writer.WriteString("");
                    writer.WriteEndElement(); //End room
                    writer.WriteStartElement("clickNext");
                    writer.WriteString("");
                    writer.WriteEndElement();//End clickNext
                    writer.WriteEndElement(); //End door
                    writer.WriteStartElement("XCoord");
                    writer.WriteValue(672);
                    writer.WriteEndElement(); //end XCoord
                    writer.WriteStartElement("YCoord");
                    writer.WriteValue(218);
                    writer.WriteEndElement(); //end YCoord
                    break;
                case "EndlessRoom2":
                    writer.WriteStartElement("door");
                    writer.WriteAttributeString("Type", "RightOpen");
                    writer.WriteStartElement("room");
                    writer.WriteString("EndlessRooms/EndlessRoom3");
                    writer.WriteEndElement(); //End room
                    writer.WriteStartElement("room");
                    writer.WriteString("");
                    writer.WriteEndElement(); //End room
                    writer.WriteStartElement("clickNext");
                    writer.WriteString("");
                    writer.WriteEndElement();//End clickNext
                    writer.WriteEndElement(); //End door
                    writer.WriteStartElement("XCoord");
                    writer.WriteValue(672);
                    writer.WriteEndElement(); //end XCoord
                    writer.WriteStartElement("YCoord");
                    writer.WriteValue(218);
                    writer.WriteEndElement(); //end YCoord
                    break;
                case "EndlessRoom3":
                    writer.WriteStartElement("door");
                    writer.WriteAttributeString("Type", "RightOpen");
                    writer.WriteStartElement("room");
                    writer.WriteString("EndlessRooms/EndlessRoom1");
                    writer.WriteEndElement(); //End room
                    writer.WriteStartElement("room");
                    writer.WriteString("");
                    writer.WriteEndElement(); //End room
                    writer.WriteStartElement("clickNext");
                    writer.WriteString("");
                    writer.WriteEndElement();//End clickNext
                    writer.WriteEndElement(); //End door
                    writer.WriteStartElement("XCoord");
                    writer.WriteValue(672);
                    writer.WriteEndElement(); //end XCoord
                    writer.WriteStartElement("YCoord");
                    writer.WriteValue(218);
                    writer.WriteEndElement(); //end YCoord
                    break;
            }
            //Left wall
            writer.WriteStartElement("door");
            writer.WriteAttributeString("Type", "LeftWall");
            writer.WriteStartElement("room");
            writer.WriteString("");
            writer.WriteEndElement(); //End room
            writer.WriteStartElement("room");
            writer.WriteString("");
            writer.WriteEndElement(); //End room
            writer.WriteStartElement("clickNext");
            writer.WriteString("");
            writer.WriteEndElement();//End clickNext
            writer.WriteEndElement(); //End door
            writer.WriteStartElement("XCoord");
            writer.WriteValue(0);
            writer.WriteEndElement(); //end XCoord
            writer.WriteStartElement("YCoord");
            writer.WriteValue(218);
            writer.WriteEndElement(); //end YCoord
            //write wall bottom 
            writer.WriteStartElement("door");
            writer.WriteAttributeString("Type", "BotWall");
            writer.WriteStartElement("room");
            writer.WriteString("EndlessRooms/EndlessSecretRoom");
            writer.WriteEndElement(); //End room
            writer.WriteStartElement("room");
            writer.WriteString("");
            writer.WriteEndElement(); //End room
            writer.WriteStartElement("clickNext");
            writer.WriteString("");
            writer.WriteEndElement();//End clickNext
            writer.WriteEndElement(); //End door
            writer.WriteStartElement("XCoord");
            writer.WriteValue(336);
            writer.WriteEndElement(); //end XCoord
            writer.WriteStartElement("YCoord");
            writer.WriteValue(435);
            writer.WriteEndElement(); //end YCoord
            writer.WriteEndElement(); //End Doors
        }


        public void generateRandomRoom(string roomName)
        {
            if (File.Exists(projectDirectory + "/Content/Levels/EndlessRooms/" + roomName + ".xml"))
            {
                File.Delete(projectDirectory + "/Content/Levels/EndlessRooms/" + roomName + ".xml");
            }
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            XmlWriter writer = XmlWriter.Create(projectDirectory + "/Content/Levels/EndlessRooms/" + roomName + ".xml", settings);
            writeHeader(writer);
            generateDoors(writer, roomName);
            string[,] roomString = roomGenerator.GenerateRandomRoom(difficulty);
            for(int i = 0; i < roomString.GetLength(1); i++)
            {
                for (int j = 0; i < roomString.GetLength(0); i++)
                {
                    switch(roomString[j,i])
                    {
                        case "Block" :
                            writer.WriteStartElement("Blocks");
                            writer.WriteStartElement("block");
                            writer.WriteAttributeString("Type", "NonFlat");
                            writer.WriteStartElement("XCoord");
                            writer.WriteValue(xVar[i]);
                            writer.WriteEndElement(); //end XCoord
                            writer.WriteStartElement("YCoord");
                            writer.WriteValue(yVar[j]);
                            writer.WriteEndElement(); //end YCoord
                            writer.WriteEndElement(); //end block
                            writer.WriteEndElement(); //end Blocks
                            break;
                        case "Goriya":
                            writer.WriteStartElement("Enemies");
                            writer.WriteStartElement("enemy");
                            writer.WriteAttributeString("Type", "Goriya");
                            writer.WriteStartElement("XCoord");
                            writer.WriteValue(xVar[i]);
                            writer.WriteEndElement(); //end XCoord
                            writer.WriteStartElement("YCoord");
                            writer.WriteValue(yVar[j]);
                            writer.WriteEndElement(); //end YCoord
                            writer.WriteEndElement(); //end enemy
                            writer.WriteEndElement(); //end Enemies
                            break;
                        case "Bluebat":
                            writer.WriteStartElement("Enemies");
                            writer.WriteStartElement("enemy");
                            writer.WriteAttributeString("Type", "Bluebat");
                            writer.WriteStartElement("XCoord");
                            writer.WriteValue(xVar[i]);
                            writer.WriteEndElement(); //end XCoord
                            writer.WriteStartElement("YCoord");
                            writer.WriteValue(yVar[j]);
                            writer.WriteEndElement(); //end YCoord
                            writer.WriteEndElement(); //end enemy
                            writer.WriteEndElement(); //end Enemies
                            break;
                        case "Bluegel":
                            writer.WriteStartElement("Enemies");
                            writer.WriteStartElement("enemy");
                            writer.WriteAttributeString("Type", "Bluegel");
                            writer.WriteStartElement("XCoord");
                            writer.WriteValue(xVar[i]);
                            writer.WriteEndElement(); //end XCoord
                            writer.WriteStartElement("YCoord");
                            writer.WriteValue(yVar[j]);
                            writer.WriteEndElement(); //end YCoord
                            writer.WriteEndElement(); //end enemy
                            writer.WriteEndElement(); //end Enemies
                            break;
                        case "Darknut":
                            writer.WriteStartElement("Enemies");
                            writer.WriteStartElement("enemy");
                            writer.WriteAttributeString("Type", "Darknut");
                            writer.WriteStartElement("XCoord");
                            writer.WriteValue(xVar[i]);
                            writer.WriteEndElement(); //end XCoord
                            writer.WriteStartElement("YCoord");
                            writer.WriteValue(yVar[j]);
                            writer.WriteEndElement(); //end YCoord
                            writer.WriteEndElement(); //end enemy
                            writer.WriteEndElement(); //end Enemies
                            break;
                        case "Snake":
                            writer.WriteStartElement("Enemies");
                            writer.WriteStartElement("enemy");
                            writer.WriteAttributeString("Type", "Snake");
                            writer.WriteStartElement("XCoord");
                            writer.WriteValue(xVar[i]);
                            writer.WriteEndElement(); //end XCoord
                            writer.WriteStartElement("YCoord");
                            writer.WriteValue(yVar[j]);
                            writer.WriteEndElement(); //end YCoord
                            writer.WriteEndElement(); //end enemy
                            writer.WriteEndElement(); //end Enemies
                            break;
                        case "Wizzrobe":
                            writer.WriteStartElement("Enemies");
                            writer.WriteStartElement("enemy");
                            writer.WriteAttributeString("Type", "Wizzrobe");
                            writer.WriteStartElement("XCoord");
                            writer.WriteValue(xVar[i]);
                            writer.WriteEndElement(); //end XCoord
                            writer.WriteStartElement("YCoord");
                            writer.WriteValue(yVar[j]);
                            writer.WriteEndElement(); //end YCoord
                            writer.WriteEndElement(); //end enemy
                            writer.WriteEndElement(); //end Enemies
                            break;
                        case "Dragon":
                            writer.WriteStartElement("Enemies");
                            writer.WriteStartElement("enemy");
                            writer.WriteAttributeString("Type", "Dragon");
                            writer.WriteStartElement("XCoord");
                            writer.WriteValue(xVar[i]);
                            writer.WriteEndElement(); //end XCoord
                            writer.WriteStartElement("YCoord");
                            writer.WriteValue(yVar[j]);
                            writer.WriteEndElement(); //end YCoord
                            writer.WriteEndElement(); //end enemy
                            writer.WriteEndElement(); //end Enemies
                            break;
                        case "Boss":
                            writer.WriteStartElement("Enemies");
                            writer.WriteStartElement("enemy");
                            writer.WriteAttributeString("Type", "Boss");
                            writer.WriteStartElement("XCoord");
                            writer.WriteValue(xVar[i]);
                            writer.WriteEndElement(); //end XCoord
                            writer.WriteStartElement("YCoord");
                            writer.WriteValue(yVar[j]);
                            writer.WriteEndElement(); //end YCoord
                            writer.WriteEndElement(); //end enemy
                            writer.WriteEndElement(); //end Enemies
                            break;
                        default:
                            break;
                    }

                }

            }
            writer.WriteEndElement(); //end Level
            difficulty++;
        }

        public void generateRandomSecrectRoom(string roomName)
        {
            this.roomGenerator = roomGenerator;
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            XmlWriter writer = XmlWriter.Create(projectDirectory + roomName, settings);
            writeHeader(writer);
        }

        public void generateRandomBossRoom(string roomName)
        {
            this.roomGenerator = roomGenerator;
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            XmlWriter writer = XmlWriter.Create(projectDirectory + roomName, settings);
            writeHeader(writer);
        }
    }
}
