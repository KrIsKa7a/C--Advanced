using System;
using System.Linq;
using System.Collections.Generic;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var numbers = new List<int>();
            FillRange(n, numbers);

            var devisors = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<int, List<int>, bool> filter = (num, numbersToDevide) =>
            {
                foreach (var dev in numbersToDevide)
                {
                    if (num % dev != 0)
                    {
                        return false;
                    }
                }
                return true;
            };


            numbers = numbers
                .Where(num => filter(num, devisors))
                .ToList();

            Console.WriteLine(String.Join(" ", numbers));
        }

        private static void FillRange(int n, List<int> numbers)
        {
            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);
            }
        }
    }
}
