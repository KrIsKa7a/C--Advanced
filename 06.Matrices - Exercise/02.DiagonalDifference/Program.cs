using System;
using System.Linq;

namespace _02.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = int.Parse(Console.ReadLine());

            var matrix = new int[rowsAndCols][];

            for (int row = 0; row < rowsAndCols; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = currentRow;
            }

            var leftDiagonalSum = 0;
            var rightDiagonalSum = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                leftDiagonalSum += matrix[row][row];
                rightDiagonalSum += matrix[row][matrix[row].Length - row - 1];
            }

            var difference = Math.Abs(leftDiagonalSum - rightDiagonalSum);

            Console.WriteLine(difference);
        }
    }
}
