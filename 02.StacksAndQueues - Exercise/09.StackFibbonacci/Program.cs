using System;
using System.Collections.Generic;

namespace _09.StackFibbonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<long>();
            stack.Push(1);
            stack.Push(1);

            for (int i = 0; i < n - 2; i++)
            {
                var popped = stack.Pop();
                var nextNum = stack.Peek() + popped;
                stack.Push(popped);
                stack.Push(nextNum);
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
