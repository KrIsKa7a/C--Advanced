using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.GroupElementsByReminder
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var numbersWithReminderZero = elements
                .Where(e => e % 3 == 0)
                .ToArray();
            var numbersWithReminderOne = elements
                .Where(e => Math.Abs(e % 3) == 1)
                .ToArray();
            var numbersWithReminderTwo = elements
                .Where(e => Math.Abs(e % 3) == 2)
                .ToArray();

            int[][] jaggedArray =
            {
                new int[numbersWithReminderZero.Length],
                new int[numbersWithReminderOne.Length],
                new int[numbersWithReminderTwo.Length]
            };

            for (int i = 0; i < numbersWithReminderZero.Length; i++)
            {
                jaggedArray[0][i] = numbersWithReminderZero[i];
            }

            for (int i = 0; i < numbersWithReminderOne.Length; i++)
            {
                jaggedArray[1][i] = numbersWithReminderOne[i];
            }

            for (int i = 0; i < numbersWithReminderTwo.Length; i++)
            {
                jaggedArray[2][i] = numbersWithReminderTwo[i];
            }

            for (int i = 0; i < jaggedArray.GetLength(0); i++)
            {
                var arrayAtCurrentIndex = jaggedArray[i];

                if (arrayAtCurrentIndex.Length == 0)
                {
                    continue;
                }

                Console.WriteLine(String.Join(" ", arrayAtCurrentIndex));
            }
        }
    }
}
