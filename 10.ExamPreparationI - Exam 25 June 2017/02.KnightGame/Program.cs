using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new char[n][];
            FillMatrix(matrix);


            var countOfRemoved = 0;

            while (true)
            {
                var dictAttack = new Dictionary<int[], int>();

                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        var currentCh = matrix[row][col];

                        if (currentCh == 'K')
                        {
                            int count = FindingCountOfAttacks(matrix, row, col);

                            var coordinates = new int[2];
                            coordinates[0] = row;
                            coordinates[1] = col;

                            dictAttack[coordinates] = count;
                        }
                    }
                }

                if (dictAttack.Values.All(num => num == 0))
                {
                    break;
                }


                dictAttack = dictAttack
                    .OrderByDescending(s => s.Value)
                    .ToDictionary(a => a.Key, b => b.Value);

                foreach (var kvp in dictAttack)
                {
                    var coordinatesOfCh = kvp.Key;
                    var rowOfCh = coordinatesOfCh[0];
                    var colOfCh = coordinatesOfCh[1];

                    matrix[rowOfCh][colOfCh] = '0';
                    countOfRemoved++;
                    break;
                }
            }

            Console.WriteLine(countOfRemoved);
        }

        private static int FindingCountOfAttacks(char[][] matrix, int row, int col)
        {
            var count = 0;

            if (col - 1 >= 0 && row - 2 >= 0)
            {
                var chAtPos = matrix[row - 2][col - 1];

                if (chAtPos == 'K')
                {
                    count++;
                }
            }

            if (col - 2 >= 0 && row - 1 >= 0)
            {
                var chAtPos = matrix[row - 1][col - 2];

                if (chAtPos == 'K')
                {
                    count++;
                }
            }

            if (row - 2 >= 0 && col + 1 < matrix[row - 2].Length)
            {
                var chAtPos = matrix[row - 2][col + 1];

                if (chAtPos == 'K')
                {
                    count++;
                }
            }

            if (row - 1 >= 0 && col + 2 < matrix[row - 1].Length)
            {
                var chAtPos = matrix[row - 1][col + 2];

                if (chAtPos == 'K')
                {
                    count++;
                }
            }

            if (row + 1 < matrix.Length && col - 2 >= 0)
            {
                var chAtPos = matrix[row + 1][col - 2];

                if (chAtPos == 'K')
                {
                    count++;
                }
            }

            if (row + 2 < matrix.Length && col - 1 >= 0)
            {
                var chAtPos = matrix[row + 2][col - 1];

                if (chAtPos == 'K')
                {
                    count++;
                }
            }

            if (row + 2 < matrix.Length && col + 1 < matrix[row + 2].Length)
            {
                var chAtPos = matrix[row + 2][col + 1];

                if (chAtPos == 'K')
                {
                    count++;
                }
            }

            if (row + 1 < matrix.Length && col + 2 < matrix[row + 1].Length)
            {
                var chAtPos = matrix[row + 1][col + 2];

                if (chAtPos == 'K')
                {
                    count++;
                }
            }

            return count;
        }

        private static void FillMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .ToCharArray();
            }
        }
    }
}
