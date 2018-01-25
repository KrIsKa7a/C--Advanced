using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                var currentInput = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                queue.Enqueue(currentInput);
            }

            var perfectIndex = 0;
            var counter = 0;

            while (true)
            {
                //var protoQueue = new Queue<string>(queue);
                var toBreak = false;

                var fuelAmount = 0;

                for (int i = 0; i < n; i++)
                {
                    var currentPumpString = queue.Dequeue();

                    fuelAmount += currentPumpString[0];

                    if (fuelAmount < currentPumpString[1])
                    {
                        toBreak = true;
                    }

                    fuelAmount -= currentPumpString[1];
                    queue.Enqueue(currentPumpString);
                }

                if (toBreak == false)
                {
                    perfectIndex = counter;
                    break;
                }

                counter++;

                queue.Enqueue(queue.Dequeue());
            }

            Console.WriteLine(counter);
        }
    }
}
