using System;
using System.Collections.Generic;

namespace _03.DecimalToBinaryConvertion
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberDecimal = int.Parse(Console.ReadLine());

            var numberInBinaryStack = new Stack<int>();

            if (numberDecimal == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while (numberDecimal > 0)
            {
                numberInBinaryStack.Push(numberDecimal % 2);
                numberDecimal /= 2;
            }

            foreach (var item in numberInBinaryStack)
            {
                Console.Write(item);
            }

            Console.WriteLine();
        }
    }
}
