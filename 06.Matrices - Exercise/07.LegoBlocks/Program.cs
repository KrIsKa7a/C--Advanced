using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var firstJaggedArray = new int[n][];
            FillingFirstJaggedArray(n, firstJaggedArray);

            var secondJaggedArray = new int[n][];
            FillingSecondJaggedArray(n, secondJaggedArray);

            var lenghts = new HashSet<int>();
            var allCelssCount = 0;

            for (int row = 0; row < n; row++)
            {
                var totalLenght = firstJaggedArray[row].Length +
                    secondJaggedArray[row].Length;

                lenghts.Add(totalLenght);
                allCelssCount += totalLenght;
            }

            PrintOutput(n, firstJaggedArray, secondJaggedArray, lenghts, allCelssCount);
        }

        private static void PrintOutput(int n, int[][] firstJaggedArray, int[][] secondJaggedArray, HashSet<int> lenghts, int allCelssCount)
        {
            if (lenghts.Count == 1)
            {
                for (int row = 0; row < n; row++)
                {
                    var currentRow = firstJaggedArray[row].Concat(secondJaggedArray[row]);
                    Console.WriteLine("[{0}]",
                        String.Join(", ", currentRow));
                }
            }
            else
            {
                Console.WriteLine("The total number of cells is: {0}",
                    allCelssCount);
            }
        }

        private static void FillingSecondJaggedArray(int n, int[][] secondJaggedArray)
        { 
            for (int i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Reverse()
                    .ToArray();
                secondJaggedArray[i] = inputLine;
            }
        }

        private static void FillingFirstJaggedArray(int n, int[][] firstJaggedArray)
        {
            for (int i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                firstJaggedArray[i] = inputLine;
            }
        }
    }
}
