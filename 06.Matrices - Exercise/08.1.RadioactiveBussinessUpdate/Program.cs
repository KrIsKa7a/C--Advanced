using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._1.RadioactiveBussinessUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            //100/100 solution
            var matrixSizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rowsCount = matrixSizes[0];
            var colsCount = matrixSizes[1];

            var matrix = new char[rowsCount][];

            FillingTheMatrix(matrix);

            var moves = Console.ReadLine();

            bool isDead = false;
            bool hasWin = false;
            var rowIndex = 0;
            var colIndex = 0;

            for (int m = 0; m < moves.Length; m++)
            {
                var currentMove = moves[m];

                MovingThePlayer(matrix, ref isDead, ref hasWin, ref rowIndex, ref colIndex, currentMove);
                SpreadingTheBunnies(matrix, ref isDead, ref rowIndex, ref colIndex);

                if (isDead || hasWin)
                {
                    break;
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(String.Join("", row));
            }

            if (isDead)
            {
                Console.WriteLine("dead: {0} {1}",
                    rowIndex, colIndex);
            }
            else
            {
                Console.WriteLine("won: {0} {1}",
                    rowIndex, colIndex);
            }
        }

        private static void SpreadingTheBunnies(char[][] matrix, ref bool isDead, ref int rowIndex, ref int colIndex)
        {
            var toProcedure = new List<int[]>();

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    var currSymbol = matrix[row][col];

                    if (currSymbol == 'B')
                    {
                        if (row - 1 >= 0 && matrix[row - 1][col] != 'B')
                        {
                            if (matrix[row - 1][col] == 'P')
                            {
                                isDead = true;
                                rowIndex = row - 1;
                                colIndex = col;
                            }
                            toProcedure.Add(new int[]
                            {
                                row - 1,
                                col
                            });

                        }

                        if (row + 1 < matrix.Length && matrix[row + 1][col] != 'B')
                        {
                            if (matrix[row + 1][col] == 'P')
                            {
                                isDead = true;
                                rowIndex = row + 1;
                                colIndex = col;
                            }
                            toProcedure.Add(new int[]
                            {
                                row + 1,
                                col
                            });
                        }

                        if (col - 1 >= 0 && matrix[row][col - 1] != 'B')
                        {
                            if (matrix[row][col - 1] == 'P')
                            {
                                isDead = true;
                                rowIndex = row;
                                colIndex = col - 1;
                            }
                            toProcedure.Add(new int[]
                            {
                                row,
                                col - 1
                            });
                        }

                        if (col + 1 < matrix[row].Length && matrix[row][col + 1] != 'B')
                        {
                            if (matrix[row][col + 1] == 'P')
                            {
                                isDead = true;
                                rowIndex = row;
                                colIndex = col + 1;
                            }
                            toProcedure.Add(new int[]
                            {
                                row,
                                col + 1
                            });
                        }
                    }
                }
            }

            foreach (var rcp in toProcedure)
            {
                var row = rcp[0];
                var col = rcp[1];
                matrix[row][col] = 'B';
            }
        }

        private static void MovingThePlayer(char[][] matrix, ref bool isDead, ref bool hasWin, ref int rowIndex, ref int colIndex, char currentMove)
        {
            bool isMoved = false;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    var currentEl = matrix[row][col];

                    if (currentEl == 'P')
                    {
                        if (currentMove == 'L')
                        {
                            if (col - 1 < 0)
                            {
                                hasWin = true;
                                colIndex = col;
                                rowIndex = row;
                                matrix[row][col] = '.';
                                break;
                            }

                            if (matrix[row][col - 1] == 'B')
                            {
                                isDead = true;
                                rowIndex = row;
                                colIndex = col - 1;
                                matrix[row][col] = '.';
                                break;
                            }
                            else
                            {
                                matrix[row][col - 1] = 'P';
                                matrix[row][col] = '.';
                                isMoved = true;
                                break;
                            }
                        }
                        else if (currentMove == 'R')
                        {
                            if (col + 1 >= matrix[row].Length)
                            {
                                hasWin = true;
                                colIndex = col;
                                rowIndex = row;
                                matrix[row][col] = '.';
                                break;
                            }

                            if (matrix[row][col + 1] == 'B')
                            {
                                isDead = true;
                                rowIndex = row;
                                colIndex = col + 1;
                                matrix[row][col] = '.';
                                break;
                            }
                            else
                            {
                                matrix[row][col + 1] = 'P';
                                matrix[row][col] = '.';
                                isMoved = true;
                                break;
                            }
                        }
                        else if (currentMove == 'U')
                        {
                            if (row - 1 < 0)
                            {
                                hasWin = true;
                                rowIndex = row;
                                colIndex = col;
                                matrix[row][col] = '.';
                                break;
                            }

                            if (matrix[row - 1][col] == 'B')
                            {
                                isDead = true;
                                rowIndex = row - 1;
                                colIndex = col;
                                matrix[row][col] = '.';
                                break;
                            }
                            else
                            {
                                matrix[row - 1][col] = 'P';
                                matrix[row][col] = '.';
                                isMoved = true;
                                break;
                            }
                        }
                        else if (currentMove == 'D')
                        {
                            if (row + 1 >= matrix.Length)
                            {
                                hasWin = true;
                                rowIndex = row;
                                colIndex = col;
                                matrix[row][col] = '.';
                                break;
                            }

                            if (matrix[row + 1][col] == 'B')
                            {
                                isDead = true;
                                rowIndex = row + 1;
                                colIndex = col;
                                matrix[row][col] = '.';
                                break;
                            }
                            else
                            {
                                matrix[row + 1][col] = 'P';
                                matrix[row][col] = '.';
                                isMoved = true;
                                break;
                            }
                        }
                    }
                }

                if (isDead || hasWin || isMoved)
                {
                    break;
                }
            }
        }

        private static void FillingTheMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                var input = Console.ReadLine()
                    .ToCharArray();
                matrix[row] = input;
            }
        }
    }
}
