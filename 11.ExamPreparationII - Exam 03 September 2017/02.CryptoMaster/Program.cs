using System;
using System.Linq;

namespace _02.CryptoMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var maxSequence = 0;

            for (int index = 0; index < numbers.Length; index++)
            {
                for (int step = 1; step < numbers.Length; step++)
                {
                    var currentIndex = index;
                    var nextIndex = (currentIndex + step) % numbers.Length;

                    var currentSequenceLenght = 1;

                    while (numbers[currentIndex] < numbers[nextIndex])
                    {
                        currentIndex = nextIndex;
                        nextIndex = (nextIndex + step) % numbers.Length;
                        currentSequenceLenght++;
                    }

                    if (currentSequenceLenght > maxSequence)
                    {
                        maxSequence = currentSequenceLenght;
                    }
                }
            }

            Console.WriteLine(maxSequence);
        }
    }
}
