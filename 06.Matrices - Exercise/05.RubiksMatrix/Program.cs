using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RubiksMatrix
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

            var matrix = new int[rowsCount][];

            FillingTheMatrix(rowsCount, colsCount, matrix);

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var cmdArgs = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var firstIndex = int.Parse(cmdArgs[0]);
                var cmdType = cmdArgs[1];
                var secondIndex = int.Parse(cmdArgs[2]);

                if (cmdType == "left")
                {
                    RollLeft(matrix, firstIndex, secondIndex);
                }
                else if (cmdType == "right")
                {
                    RollRight(matrix, firstIndex, secondIndex);
                }
                else if (cmdType == "up")
                {
                    RollUp(matrix, firstIndex, secondIndex);
                }
                else if (cmdType == "down")
                {
                    RollDown(matrix, firstIndex, secondIndex);
                }
            }

            SwapingTheRubik(matrix);
        }

        private static void SwapingTheRubik(int[][] matrix)
        {
            var counter = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    var currentEl = matrix[row][col];

                    if (currentEl == counter)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        var indexesOfWanted = FindingIndexOfWanted(matrix, counter);
                        var rowToSwapTo = indexesOfWanted[0];
                        var colToSwapTo = indexesOfWanted[1];

                        Console.WriteLine("Swap ({0}, {1}) with ({2}, {3})",
                            row, col, rowToSwapTo, colToSwapTo);

                        matrix[row][col] = counter;
                        matrix[rowToSwapTo][colToSwapTo] = currentEl;
                    }

                    counter++;
                }
            }
        }

        private static int[] FindingIndexOfWanted(int[][] matrix, int counter)
        {
            var indexesOfWanted = new int[2];

            for (int rowProto = 0; rowProto < matrix.Length; rowProto++)
            {
                var currentRow = matrix[rowProto];

                if (!currentRow.Contains(counter))
                {
                    continue;
                }
                else
                {
                    indexesOfWanted[0] = rowProto;
                    indexesOfWanted[1] = Array.IndexOf(currentRow, counter);
                }
            }

            return indexesOfWanted;
        }

        private static void RollDown(int[][] matrix, int firstIndex, int secondIndex)
        {
            var colAsList = FindingColAsList(matrix, firstIndex);

            var toMove = secondIndex % colAsList.Count;

            for (int count = 0; count < toMove; count++)
            {
                var lastEl = colAsList[colAsList.Count - 1];
                colAsList.RemoveAt(colAsList.Count - 1);
                colAsList.Insert(0, lastEl);
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][firstIndex] = colAsList[row];
            }
        }

        private static void RollUp(int[][] matrix, int firstIndex, int secondIndex)
        {
            var colAsList = FindingColAsList(matrix, firstIndex);

            var toMove = secondIndex % colAsList.Count;

            for (int count = 0; count < toMove; count++)
            {
                var firstEl = colAsList[0];
                colAsList.RemoveAt(0);
                colAsList.Add(firstEl);
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][firstIndex] = colAsList[row];
            }
        }

        private static List<int> FindingColAsList(int[][] matrix, int firstIndex)
        {
            var colAsList = new List<int>();

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                colAsList.Add(matrix[rowIndex][firstIndex]);
            }

            return colAsList;
        }

        private static void RollRight(int[][] matrix, int firstIndex, int secondIndex)
        {
            var rowAsList = matrix[firstIndex].ToList();

            var toMove = secondIndex % rowAsList.Count;

            for (int count = 0; count < toMove; count++)
            {
                var lastEl = rowAsList[rowAsList.Count - 1];
                rowAsList.RemoveAt(rowAsList.Count - 1);
                rowAsList.Insert(0, lastEl);
            }

            matrix[firstIndex] = rowAsList.ToArray();
        }

        private static void RollLeft(int[][] matrix, int firstIndex, int secondIndex)
        {
            var rowAsList = matrix[firstIndex].ToList();

            var toMove = secondIndex % rowAsList.Count;

            for (int count = 0; count < toMove; count++)
            {
                var firstEl = rowAsList[0];
                rowAsList.RemoveAt(0);
                rowAsList.Add(firstEl);
            }

            matrix[firstIndex] = rowAsList.ToArray();
        }

        private static void FillingTheMatrix(int rowsCount, int colsCount, int[][] matrix)
        {
            var counter = 1;

            for (int row = 0; row < rowsCount; row++)
            {
                matrix[row] = new int[colsCount];
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row][col] = counter;
                    counter++;
                }
            }
        }
    }
}
