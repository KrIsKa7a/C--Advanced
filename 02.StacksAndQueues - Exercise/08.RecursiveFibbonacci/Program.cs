using System;

namespace _08.RecursiveFibbonacci
{
    class Program
    {
        private static long[] fibbonacciNumbers;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            fibbonacciNumbers = new long[n];

            long fibb = GetFibbonacci(n);

            Console.WriteLine(fibb);
        }

        private static long GetFibbonacci(int n)
        {
            if (n <= 2)
            {
                fibbonacciNumbers[n - 1] = 1;
                return 1;
            }

            if (fibbonacciNumbers[n - 1] != 0)
            {
                return fibbonacciNumbers[n - 1];
            }

            return fibbonacciNumbers[n - 1] = GetFibbonacci(n - 1) + GetFibbonacci(n - 2);
        }
    }
}
