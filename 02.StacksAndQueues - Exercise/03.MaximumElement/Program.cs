using System;
using System.Collections.Generic;

namespace _03.MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var maxValuesStack = new Stack<int>();
            maxValuesStack.Push(int.MinValue);

            for (int i = 0; i < n; i++)
            {
                var commandArgs = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var cmdType = commandArgs[0];

                if (cmdType == "1")
                {
                    var toPush = int.Parse(commandArgs[1]);
                    stack.Push(toPush);

                    if (toPush > maxValuesStack.Peek())
                    {
                        maxValuesStack.Push(toPush);
                    }
                }
                else if (cmdType == "2")
                {
                    var toPop = stack.Pop();

                    if (toPop == maxValuesStack.Peek())
                    {
                        maxValuesStack.Pop();
                    }
                }
                else if (cmdType == "3")
                {
                    Console.WriteLine(maxValuesStack.Peek());
                }
            }
        }
    }
}
