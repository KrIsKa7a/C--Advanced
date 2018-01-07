using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BasicQueueOperations
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

            var toAdd = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            var numbers = new Queue<long>();

            EnqueuingNumbers(toAdd, numbers);

            DequeuingNumbers(S, numbers);

            PrintingResult(X, numbers);
        }

        private static void PrintingResult(long X, Queue<long> numbers)
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

        private static void DequeuingNumbers(long S, Queue<long> numbers)
        {
            for (int i = 0; i < S; i++)
            {
                if (numbers.Count == 0)
                {
                    break;
                }

                numbers.Dequeue();
            }
        }

        private static void EnqueuingNumbers(long[] toAdd, Queue<long> numbers)
        {
            foreach (var number in toAdd)
            {
                numbers.Enqueue(number);
            }
        }
    }
}
