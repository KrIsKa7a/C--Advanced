using System;
using System.Linq;

namespace _04.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            var rowsCount = matrixSizes[0];
            var colsCount = matrixSizes[1];

            var matrix = new long[rowsCount][];

            for (int row = 0; row < rowsCount; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
                matrix[row] = currentRow;
            }

            var bestSum = long.MinValue;
            var bestRow = 0;
            var bestCol = 0;

            FindingBestSquareSum(matrix, ref bestSum, ref bestRow, ref bestCol);

            PrintResult(matrix, bestSum, bestRow, bestCol);
        }

        private static void PrintResult(long[][] matrix, long bestSum, int bestRow, int bestCol)
        {
            Console.WriteLine($"Sum = {bestSum}");
            Console.WriteLine("{0} {1} {2}",
                matrix[bestRow][bestCol], matrix[bestRow][bestCol + 1],
                matrix[bestRow][bestCol + 2]);
            Console.WriteLine("{0} {1} {2}",
                matrix[bestRow + 1][bestCol], matrix[bestRow + 1][bestCol + 1],
                matrix[bestRow + 1][bestCol + 2]);
            Console.WriteLine("{0} {1} {2}",
                matrix[bestRow + 2][bestCol], matrix[bestRow + 2][bestCol + 1],
                matrix[bestRow + 2][bestCol + 2]);
        }

        private static void FindingBestSquareSum(long[][] matrix, ref long bestSum, ref int bestRow, ref int bestCol)
        {
            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    var currentSquareSum =
                        matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] +
                        matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] +
                        matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                    if (currentSquareSum > bestSum)
                    {
                        bestSum = currentSquareSum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }
        }
    }
}
