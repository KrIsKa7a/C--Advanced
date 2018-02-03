using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n += n * 0.20)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n:f2}"));
        }
    }
}
