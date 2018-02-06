using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var command = Console.ReadLine();

            Func<int, int> add = num => num + 1;
            Func<int, int> multiply = num => num * 2;
            Func<int, int> substract = num => num - 1;

            while (command != "end")
            {
                if (command == "add")
                {
                    numbers = numbers
                        .Select(add)
                        .ToList();
                }
                else if (command == "multiply")
                {
                    numbers = numbers
                        .Select(multiply)
                        .ToList();
                }
                else if (command == "subtract")
                {
                    numbers = numbers
                        .Select(substract)
                        .ToList();
                }
                else if (command == "print")
                {
                    Console.WriteLine(String.Join(" ", numbers));
                }

                command = Console.ReadLine();
            }
        }
    }
}
