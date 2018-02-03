using System;
using System.Linq;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            //Print count of all numbers read
            Console.WriteLine(numbers.Count);

            //Print the all numbers read sum
            Console.WriteLine(numbers.Sum());
        }
    }
}
