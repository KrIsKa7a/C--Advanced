using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CollectResources
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var field = new KeyValuePair<string, int>[input.Length];
            GettingFieldReadyForExamine(input, field);

            var n = int.Parse(Console.ReadLine());

            var maximalCollected = 0L;

            for (int i = 0; i < n; i++)
            {
                var currentIndexAndStep = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var indexToStart = currentIndexAndStep[0];
                var step = currentIndexAndStep[1];
                var nextIndex = (indexToStart + step) % field.Length;

                var collected = 0L;
                var whereIStepped = new bool[field.Length];

                if (field[indexToStart].Key == "stone" ||
                    field[indexToStart].Key == "gold" || 
                    field[indexToStart].Key == "wood" ||
                    field[indexToStart].Key == "food")
                {
                    collected += field[indexToStart].Value;
                }

                whereIStepped[indexToStart] = true;

                while (whereIStepped[nextIndex] == false)
                {
                    if (field[nextIndex].Key == "stone" ||
                        field[nextIndex].Key == "gold" ||
                        field[nextIndex].Key == "wood" ||
                        field[nextIndex].Key == "food")
                    {
                        collected += field[nextIndex].Value;
                    }
                    whereIStepped[nextIndex] = true;
                    nextIndex = (nextIndex + step) % field.Length;
                }

                if (collected > maximalCollected)
                {
                    maximalCollected = collected;
                }
            }

            Console.WriteLine(maximalCollected);

        }

        private static void GettingFieldReadyForExamine(string[] input, KeyValuePair<string, int>[] field)
        {
            var currentPos = 0;

            foreach (var itemQuantity in input)
            {
                var splitted = itemQuantity
                    .Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

                if (splitted.Length == 1)
                {
                    var kvp = new KeyValuePair<string, int>(splitted[0], 1);
                    field[currentPos] = kvp;
                }
                else
                {
                    var kvp = new KeyValuePair<string, int>(splitted[0], int.Parse(splitted[1]));
                    field[currentPos] = kvp;
                }

                currentPos++;
            }
        }
    }
}
