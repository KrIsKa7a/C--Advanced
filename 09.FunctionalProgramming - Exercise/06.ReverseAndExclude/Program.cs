using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int[]> reverse = nums =>
            {
                var reversed = new int[nums.Length];

                for (int i = 0; i < nums.Length; i++)
                {
                    reversed[i] = nums[nums.Length - i - 1];
                }

                return reversed;
            };

            var reversedNumbers = reverse(numbers);

            var devisor = int.Parse(Console.ReadLine());

            Predicate<int> filter = num => num % devisor != 0;

            reversedNumbers = reversedNumbers.Where(num => filter(num)).ToArray();

            Console.WriteLine(String.Join(" ", reversedNumbers));
        }
    }
}
