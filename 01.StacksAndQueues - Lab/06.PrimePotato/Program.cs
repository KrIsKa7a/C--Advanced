using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.PrimePotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
               .Split(' ')
               .ToArray();
            var queue = new Queue<string>(input);
            var number = int.Parse(Console.ReadLine());

            int cycle = 0;
            while (queue.Count > 1)
            {
                for (int i = 0; i < number - 1; i++)
                {
                    string reminder = queue.Dequeue();
                    queue.Enqueue(reminder);
                }
                cycle++;
                if (IsPrime(cycle))
                {
                    Console.WriteLine($"Prime {queue.Peek()}");
                }
                else
                {    
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }

        public static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
