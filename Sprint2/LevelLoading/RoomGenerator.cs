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
        private static string[,] FURNITURE15 = new string[7, 3] { { "full", "full", "full" }, { "full", "Block", "full" }, { "full", "Block", "full" }, { "full", "Block", "full" }, { "full", "Block", "full" }, { "full", "Block", "full" }, { "full", "full", "full" } };
        private static string[,] FURNITURE16 = new string[6, 5] { { "empty", "full", "full", "full", "empty" }, { "empty", "full", "Block", "full", "empty" }, { "full", "full", "Block", "full", "full" }, { "full", "Block", "full", "Block", "full" }, { "full", "Block", "full", "Block", "full" }, { "full", "full", "full", "full", "full" } };
        private static string[,] FURNITURE17 = new string[6, 5] { { "full", "full", "full", "full", "full" }, { "full", "Block", "full", "Block", "full" }, { "full", "Block", "full", "Block", "full" }, { "full", "full", "Block", "full", "full" }, { "empty", "full", "Block", "full", "empty" }, { "empty", "full", "full", "full", "empty" } };
        private static string[,] FURNITURE18 = new string[5, 5] { { "full", "full", "full", "full", "full" }, { "full", "Block", "full", "Block", "full" }, { "full", "full", "Block", "full", "full" }, { "full", "Block", "full", "Block", "full" }, { "full", "full", "full", "full", "full" } };
        private static string[,] FURNITURE19 = new string[7, 7] { { "empty", "full", "full", "full", "full", "full", "empty" }, { "full", "full", "Block", "full", "Block", "full", "full" }, { "full", "Block", "Block", "Block", "Block", "Block", "full" }, { "full", "Block", "Block", "Block", "Block", "Block", "full" }, { "full", "full", "Block", "Block", "Block", "full", "full" }, { "empty", "full", "full", "Block", "full", "full", "empty" }, { "empty", "empty", "full", "full", "full", "empty", "empty" } };


        // Enemies
        private static string[,] GORIYA = new string[1, 1] { { "Goriya" } };
        private static string[,] BLUEBAT = new string[1, 1] { { "Bluebat" } };
        private static string[,] BLUEGEL = new string[1, 1] { { "Bluegel" } };
        private static string[,] DARKNUT = new string[1, 1] { { "Darknut" } };
        private static string[,] SNAKE = new string[1, 1] { { "Snake" } };
        private static string[,] WIZZROBE = new string[1, 1] { { "Wizzrobe" } };
        private static string[,] DRAGON = new string[2, 2] { { "Dragon", "bFull" }, { "bFull", "bFull" } };
        private static string[,] BOSS = new string[2, 2] { { "Boss", "bFull" }, { "bFull", "bFull" } };

        // Preset Secret Rooms
        private static string[,] BOWROOM = new string[7, 12] { { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "Bow", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" } };
        private static string[,] BOOMERANGROOM = new string[7, 12] { { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "Boomerang", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" } };
        private static string[,] BOMBROOM = new string[7, 12] { { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "Bomb", "Bomb", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "Bomb", "Bomb", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" } };
        private static string[,] RUPIEROOM = new string[7, 12] { { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "Rupie", "Rupie", "Rupie", "Rupie", "Rupie", "Rupie", "Rupie", "Rupie", "Rupie", "Rupie", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" } };
        private static string[,] HEARTROOM = new string[7, 12] { { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "Heart", "Heart", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" } };
        private static string[,] HEARTCANNISTERROOM = new string[7, 12] { { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "Heart Cannister", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" } };


        // Preset Boss Rooms
        private static string[,] BOSSROOM = new string[7, 12] { { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "Boss", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" } };
        private static string[,] DRAGONROOM = new string[7, 12] { { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "Block", "empty", "empty", "empty", "empty", "empty", "Dragon", "empty", "empty", "empty" }, { "empty", "empty", "Block", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "Block", "empty", "empty", "empty", "empty", "empty", "Dragon", "empty", "empty", "empty" }, { "empty", "empty", "Block", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" } };
        private static string[,] BOSSMINIONROOM = new string[7, 12] { { "empty", "empty", "empty", "empty", "empty", "empty", "Goriya", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "Boss", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "Goriya", "empty", "empty", "empty", "empty" } };

        //private string[,] roomArray;
        private Random rng;
        private List<string[,]> furnitureList;
        private List<string[,]> enemyList;
        private List<string[,]> secretRoomList;
        private List<string[,]> bossRoomList;

        // constants
        private const int BASE_MIN_ENEMIES = 2;
        private const int DIFFICULTY_DIVISOR = 5;
        private const int DRAGON_SPAWN_DIFFICULTY = 10;
        private const int BOSS_SPAWN_DIFFICULTY = 20;
        private const int FURNITURE_PLACE_ATTEMPTS = 10;

        public RoomGenerator()
        {
            rng = new Random();
            furnitureList = new List<string[,]>
            {
                FURNITURE1,
                FURNITURE2,
                FURNITURE3,
                FURNITURE4,
                FURNITURE5,
                FURNITURE6,
                FURNITURE7,
                FURNITURE8,
                FURNITURE9,
                FURNITURE10,
                FURNITURE11,
                FURNITURE12,
                FURNITURE13,
                FURNITURE14,
                FURNITURE15,
                FURNITURE16,
                FURNITURE17,
                FURNITURE18,
                FURNITURE19
            };

            enemyList = new List<string[,]>
            {
                GORIYA,
                BLUEBAT,
                BLUEGEL,
                DARKNUT,
                SNAKE,
                WIZZROBE
            };


            secretRoomList = new List<string[,]>
            {
                RUPIEROOM,
                BOWROOM,
                BOOMERANGROOM,
                BOMBROOM,
                HEARTROOM,
                HEARTCANNISTERROOM
            };

            //boss rooms
            bossRoomList = new List<string[,]>
            {
                BOSSMINIONROOM,
                BOSSROOM,
                DRAGONROOM
            };
        }

        public string[,] GenerateRandomRoom(int difficulty)
        {
            // difficulty is a variable that determines how many enemies will spawn
            
            // create empty rooom
            string[,] roomArray = new string[7, 12] { { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" }, { "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty", "empty" } };
            
            // Populate room with furniture and enemies
            roomArray = PopulateFurniture(roomArray);
            roomArray = PopulateEnemies(roomArray, difficulty);

            //print room
            /*Debug.WriteLine("Printing Matrix: ");
            
            for (int i = 0; i < roomArray.GetLength(0); i++)
            {
                for (int j = 0; j < roomArray.GetLength(1); j++)
                {
                    Debug.Write(roomArray[i, j] + "\t");
                }
                Debug.WriteLine("\n");
            }*/

            return roomArray;
        }

        public string[,] GenerateRandomSecretRoom()
        {
            return secretRoomList[rng.Next(0, secretRoomList.Count)];
        }

        public string[,] GenerateRandomBossRoom()
        {
            return bossRoomList[rng.Next(0, bossRoomList.Count)];
        }

        private string[,] PopulateFurniture(string[,] matrix)
        {
            int x, y, furnitureNum, furnitureWidth, furnitureHeight;
            string[,] roomArray = matrix;

            for (int i = 0; i < FURNITURE_PLACE_ATTEMPTS; i++)
            {
                furnitureNum = rng.Next(0, furnitureList.Count);
                string[,] furniture = furnitureList[furnitureNum];

                furnitureHeight = furniture.GetLength(0);
                furnitureWidth = furniture.GetLength(1);

                // randomly generate a spot to place the furniture
                x = rng.Next(0, roomArray.GetLength(1) - furnitureWidth);
                y = rng.Next(0, roomArray.GetLength(0) - furnitureHeight);

                string[,] tempRoomArray = (string[,]) roomArray.Clone();
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

                        yCounter++;
                    }
                    xCounter++;
                }

                //Debug.WriteLine("Can Place furniture: " + canPlace);

                if (canPlace)
                {
                    //Debug.WriteLine("Placing FURNITURE" + (furnitureNum + 1) + " at x = " + x + ", y = " + y);
                    roomArray = tempRoomArray;
                }
            }
            return roomArray;
        }

        private string[,] PopulateEnemies(string[,] matrix, int difficulty)
        {
            int x, y, enemyWidth, enemyHeight, enemiesPlaced, whileCounter, minEnemies, placeAttempts;
            string[,] tempRoomArray;
            string[,] roomArray = matrix;

            // more enemies spawn the higher the difficulty
            minEnemies = difficulty / DIFFICULTY_DIVISOR;
            placeAttempts = BASE_MIN_ENEMIES + (difficulty / DIFFICULTY_DIVISOR);

            // at certain difficulty thresholds, add more difficult enemies to the list
            if (difficulty > DRAGON_SPAWN_DIFFICULTY && !enemyList.Contains(DRAGON)) enemyList.Add(DRAGON);
            if (difficulty > BOSS_SPAWN_DIFFICULTY && !enemyList.Contains(BOSS)) enemyList.Add(BOSS);

            enemiesPlaced = whileCounter = 0;
            while(enemiesPlaced < minEnemies || whileCounter < placeAttempts)
            {
                int enemyNum = rng.Next(0, enemyList.Count);
                string[,] enemy = enemyList[enemyNum];

                enemyWidth = enemy.GetLength(1);
                enemyHeight = enemy.GetLength(0);
                x = rng.Next(0, roomArray.GetLength(1) - enemyWidth);
                y = rng.Next(0, roomArray.GetLength(0) - enemyHeight);

                tempRoomArray = (string[,])roomArray.Clone();
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

                //Debug.WriteLine("Can Place enemy: " + canPlace);
                if (canPlace)
                {
                    //Debug.WriteLine("Placing enemy" + (enemyNum + 1) + " at x = " + x + ", y = " + y);
                    roomArray = tempRoomArray;
                    enemiesPlaced++;
                }
                whileCounter++;
            }
            
            return roomArray;
        }
    
    }
}
