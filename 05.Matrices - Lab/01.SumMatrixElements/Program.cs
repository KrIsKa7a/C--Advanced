using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SumMatrixElements
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
            var matrixSum = 0;

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
                    matrixSum += currentLine[j];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(matrixSum);
        }
    }
}
