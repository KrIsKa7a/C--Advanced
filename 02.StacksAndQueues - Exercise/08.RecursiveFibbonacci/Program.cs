using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.RecursiveFibbonacci
{
    class Program
    {
        private static long[] fibNumbers;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            fibNumbers = new long[n];

            long fibb = GetFibbonacci(n);

            Console.WriteLine(fibb);
        }

        private static long GetFibbonacci(int n)
        {
            if (n <= 2)
            {
                fibNumbers[n - 1] = 1;
                return 1;
            }
            if (fibNumbers[n - 1] != 0)
            {
                return fibNumbers[n - 1];
            }
            
            return fibNumbers[n - 1] = GetFibbonacci(n - 1) + GetFibbonacci(n - 2);
        }
    }
}
