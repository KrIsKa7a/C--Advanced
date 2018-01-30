using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Crossfire
{
    class Program
    {
        public static List<List<int>> matrix;
        static void Main(string[] args)
        {
            var matrixSizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = matrixSizes[0];
            var cols = matrixSizes[1];

            matrix = new List<List<int>>();
            InitTheMatrix(rows);
            FillTheMatrix(cols);

            var input = Console.ReadLine();

            while (input != "Nuke it from orbit")
            {
                var inputArgs = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var rowBomb = inputArgs[0];
                var rowBombForCalc = 0;

                if (rowBomb >= matrix.Count)
                {
                    rowBombForCalc = matrix.Count - 1;
                }

                var colBomb = inputArgs[1];
                var radius = inputArgs[2];

                var upperBomb = Math.Max(rowBomb - radius, 0);
                var bombBottom = Math.Min(rowBomb + radius, matrix.Count - 1);
                RemoveColumn(rowBomb, colBomb, upperBomb, bombBottom);

                if (rowBomb >= matrix.Count)
                {
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    var leftBomb = Math.Max(colBomb - radius, 0);
                    var rightBomb = colBomb + radius;
                    RemoveRow(rowBomb, rightBomb, leftBomb);
                }


                input = Console.ReadLine();
            }

            PrintMatrix();
        }

        private static void RemoveRow(int rowBomb, int rightBomb, int leftBomb)
        {
            List<int> currentRow = new List<int>();
            try
            {
                currentRow = matrix[rowBomb];
            }
            catch (Exception)
            {
                
            }

            rightBomb = Math.Min(rightBomb, currentRow.Count - 1);

            for (int col = rightBomb; col >= leftBomb; col--)
            {
                if (col >= currentRow.Count)
                {
                    continue;
                }

                matrix[rowBomb].RemoveAt(col);
            }
        }

        private static void RemoveColumn(int rowBomb, int colBomb, int upperBomb, int bombBottom)
        {
            for (int row = upperBomb; row <= bombBottom; row++)
            {
                if (row == rowBomb)
                {
                    continue;
                }

                List<int> currentRow;
                try
                {
                    currentRow = matrix[row];
                }
                catch (Exception)
                {
                    continue;
                }

                if (colBomb >= currentRow.Count)
                {
                    continue;
                }

                try
                {
                    matrix[row].RemoveAt(colBomb);
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                if (matrix[row].Count == 0)
                {
                    continue;
                }

                Console.WriteLine(String.Join(" ", matrix[row]));
            }
        }

        private static void FillTheMatrix(int cols)
        {
            var number = 1;

            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row].Add(number);
                    number++;
                }
            }
        }

        private static void InitTheMatrix(int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                matrix.Add(new List<int>());
            }
        }
    }
}
