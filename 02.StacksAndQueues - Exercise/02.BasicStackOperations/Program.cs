using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var toAdd = commands[0];
            var toPop = commands[1];
            var toContain = commands[2];

            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>(numbers);

            PoppingFromStack(toPop, stack);

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (stack.Contains(toContain))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
        }

        private static void PoppingFromStack(int toPop, Stack<int> stack)
        {
            for (int i = 0; i < toPop; i++)
            {
                if (stack.Count == 0)
                {
                    break;
                }

                stack.Pop();
            }
        }
    }
}
