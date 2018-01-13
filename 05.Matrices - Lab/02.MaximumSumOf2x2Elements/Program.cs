using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.MaximumSumOf2x2Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = rowsAndCols[0];
            var cols = rowsAndCols[1];

            var matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var currentLine = Console.ReadLine()
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < currentLine.Length; j++)
                {
                    matrix[i, j] = currentLine[j];
                }
            }

            var bestSum = int.MinValue;
            var bestRow = 0;
            var bestCol = 0;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    var sum = matrix[i, j] + matrix[i, j + 1] +
                        matrix[i + 1, j] + matrix[i + 1, j + 1];
                    if (sum > bestSum)
                    {
                        bestRow = i;
                        bestCol = j;
                        bestSum = sum;
                    }
                }
            }

            Console.WriteLine("{0} {1}", 
                matrix[bestRow, bestCol], matrix[bestRow, bestCol + 1]);
            Console.WriteLine("{0} {1}", 
                matrix[bestRow + 1, bestCol], matrix[bestRow + 1, bestCol + 1]);
            Console.WriteLine(bestSum);
        }
    }
}
