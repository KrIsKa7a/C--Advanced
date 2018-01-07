using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.FibbonacciStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var fibbonacciStack = new Stack<long>();

            fibbonacciStack.Push(1);
            fibbonacciStack.Push(1);

            for (int i = 2; i < n; i++)
            {
                var popped = fibbonacciStack.Pop();
                var peeked = fibbonacciStack.Pop();

                fibbonacciStack.Push(popped);

                fibbonacciStack.Push(popped + peeked);
            }

            Console.WriteLine(fibbonacciStack.Pop());
        }
    }
}
