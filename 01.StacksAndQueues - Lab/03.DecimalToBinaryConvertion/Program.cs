using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.DecimalToBinaryConvertion
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine(0);
                return;
            }

            var binary = new Stack<int>();

            while (number != 0)
            {
                binary.Push(number % 2);
                number /= 2;
            }

            while (binary.Count != 0)
            {
                Console.Write(binary.Pop());
            }

            Console.WriteLine();
        }
    }
}
