using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var rowsCount = matrixSizes[0];
            var colsCount = matrixSizes[1];

            var matrix = new char[rowsCount][];
            FillMatrix(matrix);

            var money = 50;
            var turnsMade = 0;
            bool movingRight = true;
            var hotelsBought = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                if (movingRight)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        var currentObj = matrix[row][col];

                        if (currentObj == 'H')
                        {
                            hotelsBought++;
                            Console.WriteLine($"Bought a hotel for {money}. Total hotels: {hotelsBought}.");
                            money = 0;
                        }
                        else if (currentObj == 'J')
                        {
                            Console.WriteLine($"Gone to jail at turn {turnsMade}.");
                            turnsMade += 2;
                            money += 2 * (hotelsBought * 10);
                        }
                        else if (currentObj == 'S')
                        {
                            var moneyToSpend = (row + 1) * (col + 1);

                            if (moneyToSpend > money)
                            {
                                moneyToSpend = money;
                            }

                            Console.WriteLine($"Spent {moneyToSpend} money at the shop.");
                            money -= moneyToSpend;
                        }

                        turnsMade++;
                        money += hotelsBought * 10;
                    }
                }
                else
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        var currentObj = matrix[row][col];

                        if (currentObj == 'H')
                        {
                            hotelsBought++;
                            Console.WriteLine($"Bought a hotel for {money}. Total hotels: {hotelsBought}.");
                            money = 0;
                        }
                        else if (currentObj == 'J')
                        {
                            Console.WriteLine($"Gone to jail at turn {turnsMade}.");
                            turnsMade += 2;
                            money += 2 * (hotelsBought * 10);
                        }
                        else if (currentObj == 'S')
                        {
                            var moneyToSpend = (row + 1) * (col + 1);

                            if (moneyToSpend > money)
                            {
                                moneyToSpend = money;
                            }

                            Console.WriteLine($"Spent {moneyToSpend} money at the shop.");
                            money -= moneyToSpend;
                        }

                        turnsMade++;
                        money += hotelsBought * 10;
                    }
                }

                movingRight = !movingRight;
            }

            Console.WriteLine($"Turns {turnsMade}");
            Console.WriteLine($"Money {money}");
        }

        private static void FillMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }
        }
    }
}
