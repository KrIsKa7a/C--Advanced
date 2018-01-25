using System;
using System.Collections.Generic;

namespace _05.CalculateSequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = double.Parse(Console.ReadLine());

            var sequence = new List<double>();
            var queueForCalculations = new Queue<double>();

            sequence.Add(n);
            queueForCalculations.Enqueue(n);

            for (int i = 1; i < 50; i+=3)
            {
                var currentS = queueForCalculations.Dequeue();

                var next1S = currentS + 1;
                var next2S = 2 * currentS + 1;
                var next3S = currentS + 2;

                queueForCalculations.Enqueue(next1S);
                queueForCalculations.Enqueue(next2S);
                queueForCalculations.Enqueue(next3S);
                sequence.Add(next1S);
                sequence.Add(next2S);
                sequence.Add(next3S);
            }

            sequence.RemoveAt(sequence.Count - 1);
            sequence.RemoveAt(sequence.Count - 1);

            Console.WriteLine(String.Join(" ", sequence));
            //Console.WriteLine(sequence.Count);
        }
    }
}
