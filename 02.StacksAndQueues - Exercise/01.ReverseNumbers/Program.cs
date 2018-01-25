using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var reversingStack = new Stack<double>();

            for (int i = 0; i < numbers.Length; i++)
            {
                reversingStack.Push(numbers[i]);
            }

            foreach (var item in reversingStack)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
