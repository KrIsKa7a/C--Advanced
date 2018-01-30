using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _12.StringMatrixRotation
{
    class Program
    {
        public static char[][] matrix;
        static void Main(string[] args)
        {
            var rotateInput = Console.ReadLine();

            var pattern = @"\(([0-9]+)\)";

            var match = Regex.Match(rotateInput, pattern);

            var anglesToRotate = int.Parse(match.Groups[1].ToString());

            var timesToRotate = anglesToRotate / 90;

            var indexOfRotation = timesToRotate % 4;

            var wordsToAppend = new List<string>();
            var bestLenght = -2;

            while (true)
            {
                var input = Console.ReadLine();   

                if (input == "END")
                {
                    break;
                }

                var inputLenght = input.Length;

                if (inputLenght > bestLenght)
                {
                    bestLenght = inputLenght;
                }

                wordsToAppend.Add(input);
            }

            if (indexOfRotation == 0)
            {
                matrix = FillMatrixStandart(wordsToAppend, bestLenght);
            }
            else if (indexOfRotation == 1)
            {
                matrix = FillMatrix90Rotated(wordsToAppend, bestLenght);
            }
            else if (indexOfRotation == 2)
            {
                matrix = FillMatrix180Rotated(wordsToAppend, bestLenght);
            }
            else if (indexOfRotation == 3)
            {
                matrix = FillMatrix270Rotated(wordsToAppend, bestLenght);
            }

            PrintMatrix();
        }

        private static char[][] FillMatrix270Rotated(List<string> wordsToAppend, int bestLenght)
        {
            matrix = new char[bestLenght][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new char[wordsToAppend.Count];
            }

            for (int col = 0; col < wordsToAppend.Count; col++)
            {
                var currentWord = wordsToAppend[col];
                string wordReversed = ReverseWord(currentWord, bestLenght);

                for (int row = 0; row < matrix.Length; row++)
                {
                    matrix[row][col] = wordReversed[row];
                }
            }

            return matrix;
        }

        private static char[][] FillMatrix180Rotated(List<string> wordsToAppend, int bestLenght)
        {
            matrix = new char[wordsToAppend.Count][];
            
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new char[bestLenght];
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                var currentWord = wordsToAppend[wordsToAppend.Count - row - 1];

                string currentWordReversed = ReverseWord(currentWord, bestLenght);

                for (int col = 0; col < bestLenght; col++)
                {
                    matrix[row][col] = currentWordReversed[col];
                }
            }

            return matrix;
        }

        private static string ReverseWord(string currentWord, int bestLenght)
        {
            var reversed = new StringBuilder();

            for (int i = 0; i < bestLenght - currentWord.Length; i++)
            {
                reversed.Append(' ');
            }

            for (int i = 0; i < currentWord.Length; i++)
            {
                reversed.Append(currentWord[currentWord.Length - i - 1]);
            }

            return reversed.ToString();
        }

        private static char[][] FillMatrix90Rotated(List<string> wordsToAppend, int bestLenght)
        {
            matrix = new char[bestLenght][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new char[wordsToAppend.Count];
            }

            for (int col = 0; col < wordsToAppend.Count; col++)
            {
                var currentWord = wordsToAppend[wordsToAppend.Count - col - 1];

                for (int row = 0; row < bestLenght; row++)
                {
                    if (row >= currentWord.Length)
                    {
                        matrix[row][col] = ' ';
                    }
                    else
                    {
                        matrix[row][col] = currentWord[row];
                    }
                }
            }

            return matrix;
        }

        private static char[][] FillMatrixStandart(List<string> wordsToAppend, int bestLenght)
        {
            matrix = new char[wordsToAppend.Count][];

            for (int row = 0; row < wordsToAppend.Count; row++)
            {
                matrix[row] = wordsToAppend[row].ToCharArray();
            }

            return matrix;
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(String.Join("", matrix[row]));
            }
        }
    }
}
