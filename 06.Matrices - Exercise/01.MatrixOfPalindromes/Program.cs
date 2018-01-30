using System;
using System.Linq;

namespace _01.MatrixOfPalindromes
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

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            var matrix = new string[rowsCount][];

            for (int row = 0; row < rowsCount; row++)
            {
                matrix[row] = new string[colsCount];
                for (int col = 0; col < colsCount; col++)
                {
                    var toAppend = "" + alphabet[row] + alphabet[row + col] +
                        alphabet[row];

                    matrix[row][col] = toAppend;
                }
            }

            PrintTheMatrix(matrix);
        }

        private static void PrintTheMatrix(string[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }
    }
}
