using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var operators = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            var N = operators[0];
            var S = operators[1];
            var X = operators[2];

            var numbersToAdd = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            var numbers = new Stack<long>();

            PushingNumbers(numbersToAdd, numbers);

            PopingNumbers(S, numbers);

            PrintResult(X, numbers);
        }

        private static void PrintResult(long X, Stack<long> numbers)
        {
            if (numbers.Contains(X))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numbers.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(numbers.Min());
                }
            }
        }

        private static void PopingNumbers(long S, Stack<long> numbers)
        {
            for (int i = 0; i < S; i++)
            {
                if (numbers.Count == 0)
                {
                    break;
                }

                numbers.Pop();
            }
        }

        private static void PushingNumbers(long[] numbersToAdd, Stack<long> numbers)
        {
            foreach (var number in numbersToAdd)
            {
                numbers.Push(number);
            }
        }
    }
}
