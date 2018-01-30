using System;
using System.Linq;

namespace _06.TargetPractice
{
    class Program
    {
        public static char[][] matrix;
        static void Main(string[] args)
        {
            var matrixSizes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = matrixSizes[0];
            var cols = matrixSizes[1];

            InitMatrix(rows, cols);
            FillMatrix();
            BombMatrix();
            ApplyGravityToMatrix();

            PrintMatrix();
        }

        private static void ApplyGravityToMatrix()
        {
            for (int col = 0; col < matrix[0].Length; col++)
            {
                var emptyRows = 0;
                for (int row = matrix.Length - 1; row >= 0; row--)
                {
                    var currentEl = matrix[row][col];

                    if (currentEl == ' ')
                    {
                        emptyRows++;
                    }
                    else
                    {
                        if (row + emptyRows != row)
                        {
                            var elToMove = matrix[row][col];
                            matrix[row + emptyRows][col] = elToMove;
                            matrix[row][col] = ' ';
                        }
                    }
                }
            }
        }

        private static void BombMatrix()
        {
            var bombInfo = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            var rowToBomb = bombInfo[0];
            var colToBomb = bombInfo[1];
            var bombRadius = bombInfo[2];

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    var distanceBetweenPoints =
                        Math.Sqrt
                        (
                            Math.Pow(row - rowToBomb, 2) +
                            Math.Pow(col - colToBomb, 2)
                            );

                    if (distanceBetweenPoints <= bombRadius)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(String.Join("", matrix[row]));
            }
        }

        private static void FillMatrix()
        {
            var snake = Console.ReadLine();

            var snakeIndex = 0;
            bool moveLeft = true;

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                if (moveLeft)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        matrix[row][col] = snake[snakeIndex];
                        snakeIndex++;

                        if (snakeIndex >= snake.Length)
                        {
                            snakeIndex = 0;
                        }
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] = snake[snakeIndex];
                        snakeIndex++;

                        if (snakeIndex >= snake.Length)
                        {
                            snakeIndex = 0;
                        }
                    }
                }

                moveLeft = !moveLeft;
            }
        }

        private static void InitMatrix(int rows, int cols)
        {
            matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new char[cols];
            }
        }
    }
}
