using System;
using System.Collections.Generic;

namespace _05.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var kids = Console.ReadLine()
                .Split(' ');

            var numberToEndTheGame = int.Parse(Console.ReadLine());
            var queue = new Queue<string>(kids);

            while (queue.Count > 1)
            {
                for (int i = 1; i < numberToEndTheGame; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
