using System;
using System.Collections.Generic;

namespace _06.TrafficLight
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var input = Console.ReadLine();
            var carsQueue = new Queue<string>();

            var counter = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    var toPass = Math.Min(carsQueue.Count, n);
                    for (int i = 0; i < toPass; i++)
                    {
                        Console.WriteLine($"{carsQueue.Dequeue()} passed!");
                        counter++;
                    }
                }
                else
                {
                    carsQueue.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
