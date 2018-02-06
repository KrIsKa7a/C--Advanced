using System;
using System.Linq;
using System.Collections.Generic;

namespace _13.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, bool> filter = name =>
            {
                var nameSum = 0;

                foreach (var ch in name)
                {
                    nameSum += (int)ch;
                }

                return nameSum >= n;
            };

            Console.WriteLine(names.FirstOrDefault(filter));
        }
    }
}
