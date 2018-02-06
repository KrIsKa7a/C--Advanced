using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var currentMin = int.MaxValue;

            Func<int, int, int> minFunc = (num, min) =>
            {
                if (num <= min)
                {
                    return num;
                }
                else
                {
                    return min;
                }
            };

            numbers.ForEach(num => currentMin = minFunc(num, currentMin));

            Console.WriteLine(currentMin);
        }
    }
}
