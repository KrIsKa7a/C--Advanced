using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var equation = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var stack = new Stack<string>(equation.Reverse());

            while (stack.Count > 1)
            {
                var leftOperand = int.Parse(stack.Pop());
                var op = stack.Pop();
                var rightOperand = int.Parse(stack.Pop());

                var result = 0;

                if (op == "+")
                {
                    result = leftOperand + rightOperand;
                }
                else
                {
                    result = leftOperand - rightOperand;
                }

                stack.Push(result.ToString());
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
