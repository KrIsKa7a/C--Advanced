using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.RadioactiveBussiness
{
    class Program
    {
        static void Main(string[] args)
        {
            //80/100 compiletime errors
            //sad
            var matrixSizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rowsCount = matrixSizes[0];
            var colsCount = matrixSizes[1];

            var matrix = new char[rowsCount][];

            FillingTheMatrix(matrix);

            var moves = Console.ReadLine().ToCharArray();

            var endCoordinates = new int[2];

            var hasWon = false;
            var isAlive = true;

            for (int i = 0; i < moves.Length; i++)
            {
                var currentMove = moves[i];

                var indexesOfPlayer = new int[2];
                FindingIndexesOfThePlayer(matrix, indexesOfPlayer);

                var playerRow = indexesOfPlayer[0];
                var playerCol = indexesOfPlayer[1];

                if (hasWon || !isAlive)
                {
                    break;
                }

                DoingMoves(matrix, endCoordinates, ref hasWon, ref isAlive, currentMove, playerRow, playerCol);

                var indexesToSpreadAt = new List<int[]>();

                FindingIndexesToSpreadAt(matrix, endCoordinates, ref isAlive, indexesToSpreadAt);

                SpreadingBunnies(matrix, i, indexesToSpreadAt);
            }

            PrintOutput(matrix, endCoordinates, hasWon);
        }

        private static void PrintOutput(char[][] matrix, int[] endCoordinates, bool hasWon)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(String.Join("", matrix[row]));
            }

            if (hasWon)
            {
                Console.WriteLine("won: {0} {1}", endCoordinates[0], endCoordinates[1]);
            }
            else
            {
                Console.WriteLine("dead: {0} {1}", endCoordinates[0], endCoordinates[1]);
            }
        }

        private static void DoingMoves(char[][] matrix, int[] endCoordinates, ref bool hasWon, ref bool isAlive, char currentMove, int playerRow, int playerCol)
        {
            if (currentMove == 'L')
            {
                MoveLeft(matrix, playerRow, playerCol, ref hasWon, ref isAlive, endCoordinates);
            }
            else if (currentMove == 'R')
            {
                MoveRight(matrix, playerRow, playerCol, ref hasWon, ref isAlive, endCoordinates);
            }
            else if (currentMove == 'U')
            {
                MoveUp(matrix, playerRow, playerCol, ref hasWon, ref isAlive, endCoordinates);
            }
            else if (currentMove == 'D')
            {
                MoveDown(matrix, playerRow, playerCol, ref hasWon, ref isAlive, endCoordinates);
            }
        }

        private static void SpreadingBunnies(char[][] matrix, int i, List<int[]> indexesToSpreadAt)
        {
            for (int counter = 0; counter < indexesToSpreadAt.Count; counter++)
            {
                var currentIndexes = indexesToSpreadAt[counter];
                var currentRow = currentIndexes[0];
                var currentCol = currentIndexes[1];

                matrix[currentRow][currentCol] = 'B';
            }
        }

        private static void FindingIndexesToSpreadAt(char[][] matrix, int[] endCoordinates, ref bool isAlive, List<int[]> indexesToSpreadAt)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    var currentEl = matrix[row][col];

                    if (currentEl == 'B')
                    {
                        if (col - 1 >= 0)
                        {
                            if (matrix[row][col - 1] == '.')
                            {
                                indexesToSpreadAt.Add(new int[] { row, col - 1 });
                            }
                            else if (matrix[row][col - 1] == 'P')
                            {
                                isAlive = false;
                                endCoordinates[0] = row;
                                endCoordinates[1] = col - 1;
                                indexesToSpreadAt.Add(new int[] { row, col - 1 });
                            }
                        }

                        if (col + 1 < matrix[row].Length)
                        {
                            if (matrix[row][col + 1] == '.')
                            {
                                indexesToSpreadAt.Add(new int[] { row, col + 1 });
                            }
                            else if (matrix[row][col + 1] == 'P')
                            {
                                isAlive = false;
                                endCoordinates[0] = row;
                                endCoordinates[1] = col + 1;
                                indexesToSpreadAt.Add(new int[] { row, col + 1 });
                            }
                        }

                        if (row - 1 >= 0)
                        {
                            if (matrix[row - 1][col] == '.')
                            {
                                indexesToSpreadAt.Add(new int[] { row - 1, col });
                            }
                            else if (matrix[row - 1][col] == 'P')
                            {
                                isAlive = false;
                                endCoordinates[0] = row - 1;
                                endCoordinates[1] = col;
                                indexesToSpreadAt.Add(new int[] { row - 1, col });
                            }
                        }

                        if (row + 1 < matrix.Length)
                        {
                            if (matrix[row + 1][col] == '.')
                            {
                                indexesToSpreadAt.Add(new int[] { row + 1, col });
                            }
                            else if (matrix[row + 1][col] == 'P')
                            {
                                isAlive = false;
                                endCoordinates[0] = row + 1;
                                endCoordinates[1] = col;
                                indexesToSpreadAt.Add(new int[] { row + 1, col });
                            }
                        }
                    }
                }
            }
        }

        private static void MoveDown(char[][] matrix, int playerRow, int playerCol, ref bool hasWon, ref bool isAlive, int[] coor)
        {
            if (playerRow + 1 > matrix.Length - 1)
            {
                hasWon = true;
                coor[0] = playerRow;
                coor[1] = playerCol;
                matrix[playerRow][playerCol] = '.';
            }
            else
            {
                if (matrix[playerRow + 1][playerCol] == '.')
                {
                    matrix[playerRow + 1][playerCol] = 'P';
                    matrix[playerRow][playerCol] = '.';
                }
                else
                {
                    isAlive = false;
                    coor[0] = playerRow + 1;
                    coor[1] = playerCol;
                    matrix[playerRow][playerCol] = '.';
                }
            }
        }

        private static void MoveUp(char[][] matrix, int playerRow, int playerCol, ref bool hasWon, ref bool isAlive, int[] coor)
        {
            if (playerRow - 1 < 0)
            {
                hasWon = true;
                coor[0] = playerRow;
                coor[1] = playerCol;
                matrix[playerRow][playerCol] = '.';
            }
            else
            {
                if (matrix[playerRow - 1][playerCol] == '.')
                {
                    matrix[playerRow - 1][playerCol] = 'P';
                    matrix[playerRow][playerCol] = '.';
                }
                else
                {
                    isAlive = false;
                    coor[0] = playerRow - 1;
                    coor[1] = playerCol;
                    matrix[playerRow][playerCol] = '.';
                }
            }
        }

        private static void MoveRight(char[][] matrix, int playerRow, int playerCol, ref bool hasWon, ref bool isAlive, int[] coor)
        {
            if (playerCol + 1 > matrix[playerCol].Length - 1)
            {
                hasWon = true;
                coor[0] = playerRow;
                coor[1] = playerCol;
                matrix[playerRow][playerCol] = '.';
            }
            else
            {
                if (matrix[playerRow][playerCol + 1] == '.')
                {
                    matrix[playerRow][playerCol + 1] = 'P';
                    matrix[playerRow][playerCol] = '.';
                }
                else
                {
                    isAlive = false;
                    coor[0] = playerRow;
                    coor[1] = playerCol + 1;
                    matrix[playerRow][playerCol] = '.';
                }
            }
        }

        private static void MoveLeft(char[][] matrix, int playerRow, int playerCol, ref bool hasWon, ref bool isAlive, int[] coor)
        {
            if (playerCol - 1 < 0)
            {
                hasWon = true;
                coor[0] = playerRow;
                coor[1] = playerCol;
                matrix[playerRow][playerCol] = '.';
            }
            else
            {
                if (matrix[playerRow][playerCol - 1] == '.')
                {
                    matrix[playerRow][playerCol - 1] = 'P';
                    matrix[playerRow][playerCol] = '.';
                }
                else
                {
                    isAlive = false;
                    coor[0] = playerRow;
                    coor[1] = playerCol - 1;
                    matrix[playerRow][playerCol] = '.';
                }
            }
        }

        private static void FindingIndexesOfThePlayer(char[][] matrix, int[] indexesOfPlayer)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                if (matrix[row].Contains('P'))
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        indexesOfPlayer[0] = row;
                        indexesOfPlayer[1] = Array.IndexOf(matrix[row], 'P');
                    }
                }
            }
        }

        private static void FillingTheMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                var currentLine = Console.ReadLine().ToCharArray();
                matrix[row] = currentLine;
            }
        }
    }
}
