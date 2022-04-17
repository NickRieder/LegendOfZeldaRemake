using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class RoomGenerator
    {
        // Furniture
        private static string[,] FURNITURE1 = new string[4, 4] { { "full", "full", "full", "full", }, { "full", "Block", "Block", "full" }, { "full", "Block", "Block", "full" }, { "full", "full", "full", "full", } };
        private static string[,] FURNITURE2 = new string[3, 3] { { "full", "full", "full" }, { "full", "Block", "full" }, { "full", "full", "full" } };
        private static string[,] FURNITURE3 = new string[5, 3] { { "full", "full", "full" }, { "full", "Block", "full" }, { "full", "Block", "full" }, { "full", "Block", "full" }, { "full", "full", "full" } };
        private static string[,] FURNITURE4 = new string[4, 4] { { "full", "full", "full", "empty" }, { "full", "Block", "full", "full" }, { "full", "Block", "Block", "full" }, { "full", "full", "full", "full" } };
        private static string[,] FURNITURE5 = new string[5, 4] { { "full", "full", "full", "full" }, { "full", "Block", "Block", "full" }, { "full", "full", "Block", "full" }, { "full", "Block", "Block", "full" }, { "full", "full", "full", "full" } };
        private static string[,] FURNITURE6 = new string[6, 5] { { "empty", "empty", "full", "full", "full" }, { "empty", "empty", "full", "Block", "full" }, { "empty", "empty", "full", "Block", "full" }, { "full", "full", "full", "Block", "full" }, { "full", "Block", "Block", "Block", "full" }, { "full", "full", "full", "full", "full" } };
        private static string[,] FURNITURE7 = new string[4, 5] { { "full", "full", "full", "full", "empty" }, { "full", "Block", "Block", "full", "full" }, { "full", "full", "Block", "Block", "full" }, { "empty", "full", "full", "full", "full" } };
        private static string[,] FURNITURE8 = new string[3, 7] { { "full", "full", "full", "full", "full", "full", "full" }, { "full", "Block", "Block", "Block", "Block", "Block", "full" }, { "full", "full", "full", "full", "full", "full", "full" } };
        private static string[,] FURNITURE9 = new string[5, 5] { { "empty", "full", "full", "full", "empty" }, { "full", "full", "Block", "full", "full" }, { "full", "Block", "Block", "Block", "full" }, { "full", "full", "Block", "full", "full" }, { "empty", "full", "full", "full", "empty" } };
        private static string[,] FURNITURE10 = new string[5, 5] { { "full", "full", "full", "empty", "empty" }, { "full", "Block", "full", "full", "empty" }, { "full", "full", "Block", "full", "full" }, { "empty", "full", "full", "Block", "full" }, { "empty", "empty", "full", "full", "full" } };
        private static string[,] FURNITURE11 = new string[5, 5] { { "empty", "empty", "full", "full", "full" }, { "empty", "full", "full", "Block", "full" }, { "full", "full", "Block", "full", "full" }, { "full", "Block", "full", "full", "empty" }, { "full", "full", "full", "empty", "empty" } };
        private static string[,] FURNITURE12 = new string[5, 5] { { "full", "full", "full", "full", "full" }, { "full", "Block", "full", "Block", "full" }, { "full", "full", "full", "full", "full" }, { "full", "Block", "full", "Block", "full" }, { "full", "full", "full", "full", "full" } };
        private static string[,] FURNITURE13 = new string[4, 5] { { "full", "full", "full", "full", "full" }, { "full", "Block", "Block", "Block", "full" }, { "full", "Block", "Block", "Block", "full" }, { "full", "full", "full", "full", "full" } };
        private static string[,] FURNITURE14 = new string[5, 4] { { "full", "full", "full", "full" }, { "full", "Block", "Block", "full" }, { "full", "Block", "Block", "full" }, { "full", "Block", "Block", "full" }, { "full", "full", "full", "full" } };


        // Enemies
        private static string[,] GORIYA = new string[1, 1] { { "Goriya" } };
        private static string[,] BLUEBAT = new string[1, 1] { { "Bluebat" } };
        private static string[,] BLUEGEL = new string[1, 1] { { "Bluegel" } };
        private static string[,] DARKNUT = new string[1, 1] { { "Darknut" } };
        private static string[,] SNAKE = new string[1, 1] { { "Snake" } };
        private static string[,] WIZZROBE = new string[1, 1] { { "Wizzrobe" } };
        private static string[,] DRAGON = new string[2, 2] { { "Dragon", "full" }, { "full", "full" } }; 

        // Preset Secret Rooms
        private static string[,] BOWROOM = new string[7, 12] { { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "Bow", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" } };
        private static string[,] BOOMERANGROOM = new string[7, 12] { { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "Boomerang", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" } };
        private static string[,] BOMBROOM = new string[7, 12] { { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "Bomb", "Bomb", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "Bomb", "Bomb", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" } };
        private static string[,] RUPIEROOM = new string[7, 12] { { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "Rupie", "Rupie", "Rupie", "Rupie", "Rupie", "Rupie", "Rupie", "Rupie", "Rupie", "Rupie", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" } };

        //private string[,] roomArray;
        private Random rng;
        private List<string[,]> furnitureList;
        private List<string[,]> enemyList;
        private List<string[,]> secretRoomList;

        public RoomGenerator()
        {
            rng = new Random();
            furnitureList = new List<string[,]>();
            furnitureList.Add(FURNITURE1);
            furnitureList.Add(FURNITURE2);
            furnitureList.Add(FURNITURE3);
            furnitureList.Add(FURNITURE4);
            furnitureList.Add(FURNITURE5);
            furnitureList.Add(FURNITURE6);
            furnitureList.Add(FURNITURE7);
            furnitureList.Add(FURNITURE8);
            furnitureList.Add(FURNITURE9);
            furnitureList.Add(FURNITURE10);
            furnitureList.Add(FURNITURE11);
            furnitureList.Add(FURNITURE12);
            furnitureList.Add(FURNITURE13);
            furnitureList.Add(FURNITURE14);

            enemyList = new List<string[,]>();
            enemyList.Add(GORIYA);
            enemyList.Add(BLUEBAT);
            enemyList.Add(BLUEGEL);
            enemyList.Add(DARKNUT);
            enemyList.Add(SNAKE);
            enemyList.Add(WIZZROBE);

            // Dragon still buggy
            //enemyList.Add(DRAGON);

            secretRoomList = new List<string[,]>();
            secretRoomList.Add(RUPIEROOM);
            secretRoomList.Add(BOWROOM);
            secretRoomList.Add(BOOMERANGROOM);
            secretRoomList.Add(BOMBROOM);
        }

        public string[,] GenerateRandomRoom(int difficulty)
        {
            // difficulty is a variable that determines how many enemies will spawn
            
            string[,] roomArray = new string[7, 12] { { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" } };
            roomArray = PopulateFurniture(roomArray);
            roomArray = PopulateEnemies(roomArray, difficulty);

            //print room
            Debug.WriteLine("Printing Matrix: ");
            
            for (int i = 0; i < roomArray.GetLength(0); i++)
            {
                for (int j = 0; j < roomArray.GetLength(1); j++)
                {
                    Debug.Write(roomArray[i, j] + "\t");
                }
                Debug.WriteLine("\n");
            }

            return roomArray;
        }

        public string[,] GenerateRandomSecretRoom()
        {
            int roomNum = rng.Next(0, secretRoomList.Count);
            string[,] room = secretRoomList[roomNum];
            return room;
        }

        private string[,] PopulateFurniture(string[,] matrix)
        {
            int x, y, furnitureNum, furnitureWidth, furnitureHeight;
            string[,] roomArray = matrix;

            for (int i = 0; i < 10; i++)
            {
                furnitureNum = rng.Next(0, furnitureList.Count);
                string[,] furniture = furnitureList[furnitureNum];

                furnitureHeight = furniture.GetLength(0);
                furnitureWidth = furniture.GetLength(1);
                x = rng.Next(0, roomArray.GetLength(1) - furnitureWidth);
                y = rng.Next(0, roomArray.GetLength(0) - furnitureHeight);

                string[,] tempRoomArray = roomArray;
                bool canPlace = true;
                int xCounter, yCounter;
                xCounter = 0;
                for (int j = x; j < furnitureWidth + x; j++)
                {
                    yCounter = 0;
                    for (int k = y; k < furnitureHeight + y; k++)
                    {
                        if (roomArray[k, j].Equals("empty"))
                        {
                            tempRoomArray[k, j] = furniture[yCounter, xCounter];
                        }
                        else if(!(furniture[yCounter, xCounter].Equals("empty") || (roomArray[k, j].Equals("full") && furniture[yCounter, xCounter].Equals("full"))))
                        {
                            canPlace = false;
                        }
                        //else canPlace = false;

                        yCounter++;
                    }
                    xCounter++;
                }

                Debug.WriteLine("Can Place furniture: " + canPlace);

                if (canPlace)
                {
                    Debug.WriteLine("Placing FURNITURE" + (furnitureNum + 1) + " at x = " + x + ", y = " + y);
                    roomArray = tempRoomArray;
                    /*for(int r = 0; r < roomArray.GetLength(0); r++)
                    {
                        for(int p = 0; p < roomArray.GetLength(1); p++)
                        {
                            roomArray[r, p] = tempRoomArray[r, p];
                        }
                    }*/
                    //int xCounter, yCounter;
                    /*xCounter = 0;
                    for (int j = x; j < furnitureWidth + x; j++)
                    {
                        yCounter = 0;
                        for (int k = y; k < furnitureHeight + y; k++)
                        {
                            roomArray[k, j] = furniture[yCounter, xCounter];
                            yCounter++;
                        }
                        xCounter++;
                    }*/
                }
            }
            return roomArray;
        }

        private string[,] PopulateEnemies(string[,] matrix, int difficulty)
        {
            int x, y, enemyWidth, enemyHeight, enemiesPlaced, whileCounter, minEnemies, placeAttempts;
            string[,] tempRoomArray;
            string[,] roomArray = matrix;

            minEnemies = difficulty / 5;
            placeAttempts = 2 + (difficulty / 5); 
            enemiesPlaced = whileCounter = 0;
            while(enemiesPlaced < minEnemies || whileCounter < placeAttempts)
            {
                int enemyNum = rng.Next(0, enemyList.Count);
                string[,] enemy = enemyList[enemyNum];

                enemyWidth = enemy.GetLength(1);
                enemyHeight = enemy.GetLength(0);
                x = rng.Next(0, roomArray.GetLength(1) - enemyWidth);
                y = rng.Next(0, roomArray.GetLength(0) - enemyHeight);

                tempRoomArray = roomArray;
                bool canPlace = true;
                int xCounter, yCounter;
                xCounter = 0;
                for (int j = x; j < enemyWidth + x; j++)
                {
                    yCounter = 0;
                    for (int k = y; k < enemyHeight + y; k++)
                    {
                        if (roomArray[k, j].Equals("empty") || roomArray[k, j].Equals("full"))
                        {
                            tempRoomArray[k, j] = enemy[yCounter, xCounter];
                        }
                        else canPlace = false;

                        yCounter++;
                    }
                    xCounter++;
                }

                Debug.WriteLine("Can Place enemy: " + canPlace);
                if (canPlace)
                {
                    Debug.WriteLine("Placing enemy" + (enemyNum + 1) + " at x = " + x + ", y = " + y);
                    roomArray = tempRoomArray;
                    enemiesPlaced++;
                }
                whileCounter++;
            }
            
            return roomArray;
        }
    
    }
}



/*int x, y, furnitureNum, furnitureWidth, furnitureHeight;
string[,] roomArray = matrix;

for (int i = 0; i < 10; i++)
{
    furnitureNum = rng.Next(0, furnitureList.Count);
    string[,] furniture = furnitureList[furnitureNum];

    furnitureHeight = furniture.GetLength(0);
    furnitureWidth = furniture.GetLength(1);
    x = rng.Next(0, roomArray.GetLength(1) - furnitureWidth);
    y = rng.Next(0, roomArray.GetLength(0) - furnitureHeight);

    string[,] tempRoomArray = roomArray;
    bool canPlace = true;
    int xCounter, yCounter;
    xCounter = 0;
    for (int j = x; j < furnitureWidth + x; j++)
    {
        yCounter = 0;
        for (int k = y; k < furnitureHeight + y; k++)
        {
            if (roomArray[k, j].Equals("empty") || furniture[yCounter, xCounter].Equals("empty") || (roomArray[k, j].Equals("full") && furniture[yCounter, xCounter].Equals("full")))
            {
                tempRoomArray[k, j] = furniture[yCounter, xCounter];
            }
            else canPlace = false;

            yCounter++;
        }
        xCounter++;
    }

    Debug.WriteLine("Can Place furniture: " + canPlace);

    if (canPlace)
    {
        Debug.WriteLine("Placing FURNITURE" + (furnitureNum + 1) + " at x = " + x + ", y = " + y);
        roomArray = tempRoomArray;
        //int xCounter, yCounter;
        *//*xCounter = 0;
        for (int j = x; j < furnitureWidth + x; j++)
        {
            yCounter = 0;
            for (int k = y; k < furnitureHeight + y; k++)
            {
                roomArray[k, j] = furniture[yCounter, xCounter];
                yCounter++;
            }
            xCounter++;
        }*//*
    }
}
return roomArray;*/