using System;
using System.Linq;

namespace _03.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rowsCount = matrixSizes[0];
            var colsCount = matrixSizes[1];

            var matrix = new string[rowsCount][];

            for (int row = 0; row < rowsCount; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                matrix[row] = currentRow;
            }

            int counter = FindingCountOfEqualSquares(matrix);

            Console.WriteLine(counter);
        }

        private static int FindingCountOfEqualSquares(string[][] matrix)
        {
            var counter = 0;

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    var topLeft = matrix[row][col];
                    var topRight = matrix[row][col + 1];
                    var bottomLeft = matrix[row + 1][col];
                    var bottomRight = matrix[row + 1][col + 1];

                    bool areEqual = topLeft == topRight &&
                        topRight == bottomLeft && bottomLeft == bottomRight;

                    if (areEqual)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }
    }
}
