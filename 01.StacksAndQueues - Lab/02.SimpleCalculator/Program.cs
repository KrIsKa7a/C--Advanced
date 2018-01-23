using System;
using System.Collections.Generic;

namespace _02.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ');

            var stack = new Stack<string>();

            FillingTheStackReversed(input, stack);

            var result = 0d;

            while (stack.Count > 1)
            {
                var leftOperand = double.Parse(stack.Pop());
                var operation = stack.Pop();
                var rightOperand = double.Parse(stack.Pop());

                switch (operation)
                {
                    case "+":
                        result = leftOperand + rightOperand;
                        break;
                    case "-":
                        result = leftOperand - rightOperand;
                        break;
                    default:
                        break;
                }

                stack.Push(result.ToString());
            }

            Console.WriteLine(result);
        }

        private static void FillingTheStackReversed(string[] input, Stack<string> stack)
        {
            for (int i = input.Length - 1; i >= 0; i--)
            {
                stack.Push(input[i]);
            }
        }
    }
}
