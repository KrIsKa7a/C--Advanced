using System;
using System.Linq;

namespace _10.TheHeiganDance
{
    class Program
    {
        public static int[][] playground;
        public static double playerHP;
        public static double heiganHP;

        static void Main(string[] args)
        {
            playground = new int[15][];
            FillThePlayGround();

            var playerDamagePerRound = double.Parse(Console.ReadLine());

            playerHP = 18500d;
            heiganHP = 3000000d;

            bool heiganDefeated = false;
            bool playerDefeated = false;

            string winner = string.Empty;
            string killedBy = string.Empty;
            bool plagueActive = false;
            string lastUsedMagic = string.Empty;

            var lastPlayerRow = 0;
            var lastPlayerCol = 0;

            while (true)
            {
                var currentAbility = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var type = currentAbility[0];
                var rowOfAbility = int.Parse(currentAbility[1]);
                var colOfAbility = int.Parse(currentAbility[2]);

                heiganHP -= playerDamagePerRound;

                if (heiganHP <= 0)
                {
                    if (plagueActive)
                    {
                        playerHP -= 3500;
                    }

                    if (playerHP <= 0)
                    {
                        if (plagueActive)
                        {
                            killedBy = "Plague Cloud";
                        }

                        playerDefeated = true;
                    }

                    heiganDefeated = true;
                    int[] lastIndexesOfPlayer = FindLastIndexesOfThePlayer();
                    lastPlayerRow = lastIndexesOfPlayer[0];
                    lastPlayerCol = lastIndexesOfPlayer[1];
                    break;
                }

                if (plagueActive)
                {
                    playerHP -= 3500;
                }

                plagueActive = false;

                if (playerHP <= 0)
                {
                    if (plagueActive)
                    {
                        killedBy = "Plague Cloud";
                    }
                    else
                    {
                        killedBy = lastUsedMagic;
                    }
                    playerDefeated = true;
                    int[] lastIndexesOfPlayer = FindLastIndexesOfThePlayer();
                    lastPlayerRow = lastIndexesOfPlayer[0];
                    lastPlayerCol = lastIndexesOfPlayer[1];
                    break;
                }


                lastUsedMagic = string.Empty;
                var playerIndexes = FindLastIndexesOfThePlayer();

                bool isPlayerInArea = FindIfPlayerIsWithinTheArea(rowOfAbility, colOfAbility, playerIndexes);

                if (isPlayerInArea)
                {
                    bool moveUpSuccess = CheckIfHeCanMoveUp(rowOfAbility, colOfAbility, playerIndexes);

                    int[] lastIndexesOfPlayer = FindLastIndexesOfThePlayer();
                    lastPlayerRow = lastIndexesOfPlayer[0];
                    lastPlayerCol = lastIndexesOfPlayer[1];

                    if (moveUpSuccess)
                    {
                        //We move player up
                        playground[lastPlayerRow - 1][lastPlayerCol] = 1;
                        //Clear last position
                        playground[lastPlayerRow][lastPlayerCol] = 0;

                        continue;
                    }

                    bool moveRightSucess = CheckIfHeCanMoveRight(rowOfAbility, colOfAbility, playerIndexes);

                    if (moveRightSucess)
                    {
                        //We move player up
                        playground[lastPlayerRow][lastPlayerCol + 1] = 1;
                        //Clear last position
                        playground[lastPlayerRow][lastPlayerCol] = 0;

                        continue;
                    }

                    bool moveDownSuccess = CheckIfHeCanMoveDown(rowOfAbility, colOfAbility, playerIndexes);

                    if (moveDownSuccess)
                    {
                        //We move player up
                        playground[lastPlayerRow + 1][lastPlayerCol] = 1;
                        //Clear last position
                        playground[lastPlayerRow][lastPlayerCol] = 0;

                        continue;
                    }

                    bool moveLeftSuccess = CheckIfHeCanMoveLeft(rowOfAbility, colOfAbility, playerIndexes);

                    if (moveLeftSuccess)
                    {
                        //We move player up
                        playground[lastPlayerRow][lastPlayerCol - 1] = 1;
                        //Clear last position
                        playground[lastPlayerRow][lastPlayerCol] = 0;

                        continue;
                    }

                    //----------------------------------------------------------
                    //Here we assume that player can't escape and he should face the music
                    //He will take up the dmg

                    if (heiganHP > 0)
                    {
                        if (type == "Cloud")
                        {
                            playerHP -= 3500;
                            plagueActive = true;
                            lastUsedMagic = "Plague Cloud";
                        }
                        else if (type == "Eruption")
                        {
                            playerHP -= 6000;
                            lastUsedMagic = "Eruption";
                        }
                    }
                }

                if (playerHP <= 0)
                {
                    if (plagueActive)
                    {
                        killedBy = "Plague Cloud";
                    }
                    else
                    {
                        killedBy = lastUsedMagic;
                    }
                    playerDefeated = true;
                    int[] lastIndexesOfPlayer = FindLastIndexesOfThePlayer();
                    lastPlayerRow = lastIndexesOfPlayer[0];
                    lastPlayerCol = lastIndexesOfPlayer[1];
                    break;
                }
            }

            PrintResult(heiganDefeated, playerDefeated, killedBy, lastPlayerRow, lastPlayerCol);
        }

        private static void PrintResult(bool heiganDefeated, bool playerDefeated, string killedBy, int lastPlayerRow, int lastPlayerCol)
        {
            if (heiganDefeated)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine("Heigan: {0:f2}",
                    heiganHP);
            }

            if (playerDefeated)
            {
                Console.WriteLine("Player: Killed by {0}", killedBy);
            }
            else
            {
                Console.WriteLine("Player: {0}", playerHP);
            }

            Console.WriteLine("Final position: {0}, {1}",
                lastPlayerRow, lastPlayerCol);
        }

        private static bool CheckIfHeCanMoveLeft(int rowOfAbility, int colOfAbility, int[] playerIndexes)
        {
            var playerRow = playerIndexes[0];
            var playerCol = playerIndexes[1];

            if (playerCol - 1 < 0)
            {
                return false;
            }

            if (playerCol - 1 >= colOfAbility - 1)
            {
                return false;
            }

            return true;
        }

        private static bool CheckIfHeCanMoveDown(int rowOfAbility, int colOfAbility, int[] playerIndexes)
        {
            var playerRow = playerIndexes[0];
            var playerCol = playerIndexes[1];

            if (playerRow + 1 >= playground.Length)
            {
                return false;
            }

            if (playerRow + 1 <= rowOfAbility + 1)
            {
                return false;
            }

            return true;
        }

        private static bool CheckIfHeCanMoveRight(int rowOfAbility, int colOfAbility, int[] playerIndexes)
        {
            var playerRow = playerIndexes[0];
            var playerCol = playerIndexes[1];

            if (playerCol + 1 >= playground[playerRow].Length)
            {
                return false;
            }

            if (playerCol + 1 <= colOfAbility + 1)
            {
                return false;
            }

            return true;
        }

        private static bool CheckIfHeCanMoveUp(int rowOfAbility, int colOfAbility, int[] playerIndexes)
        {
            var playerRow = playerIndexes[0];
            var playerCol = playerIndexes[1];

            if (playerRow - 1 < 0)
            {
                return false;
            }

            if (playerRow - 1 >= rowOfAbility - 1)
            {
                return false;
            }

            return true;
        }

        private static bool FindIfPlayerIsWithinTheArea(int rowOfAbility, int colOfAbility, int[] playerIndexes)
        {
            var playerRow = playerIndexes[0];
            var playerCol = playerIndexes[1];

            bool isPlayerOnTopRow = (playerRow == rowOfAbility - 1) &&
                (playerCol >= colOfAbility - 1 && playerCol <= colOfAbility + 1);
            bool isPlayerOnMiddleRow = (playerRow == rowOfAbility) &&
                (playerCol >= colOfAbility - 1 && playerCol <= colOfAbility + 1);
            bool isPlayerOnBottomRow = (playerRow == rowOfAbility + 1) &&
                (playerCol >= colOfAbility - 1 && playerCol <= colOfAbility + 1);

            bool isPlayerWithinArea = isPlayerOnTopRow || isPlayerOnMiddleRow ||
                isPlayerOnBottomRow;

            return isPlayerWithinArea;
        }

        private static int[] FindLastIndexesOfThePlayer()
        {
            var coordinates = new int[2];

            for (int row = 0; row < playground.Length; row++)
            {
                var currentRow = playground[row];

                if (currentRow.Contains(1))
                {
                    var col = Array.IndexOf(currentRow, 1);
                    coordinates[0] = row;
                    coordinates[1] = col;
                    break;
                }
            }

            return coordinates;
        }

        private static void FillThePlayGround()
        {
            for (int row = 0; row < playground.Length; row++)
            {
                playground[row] = new int[15];
            }

            playground[7][7] = 1;
        }
    }
}
