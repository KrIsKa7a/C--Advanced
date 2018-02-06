using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var range = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var numbers = new List<int>();
            FillRange(range, numbers);

            var toFind = Console.ReadLine();

            Predicate<int> filter = GetFilter(toFind);

            List<int> wantedNumbers = numbers
                .Where(num => filter(num))
                .ToList();

            Console.WriteLine(String.Join(" ", wantedNumbers));
        }

        private static Predicate<int> GetFilter(string toFind)
        {
            if (toFind == "even")
            {
                return num => num % 2 == 0;
            }
            else if(toFind == "odd")
            {
                return num => num % 2 != 0;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private static void FillRange(int[] range, List<int> numbers)
        {
            var start = range.Min();
            var end = range.Max();

            for (int num = start; num <= end; num++)
            {
                numbers.Add(num);
            }
        }
    }
}
