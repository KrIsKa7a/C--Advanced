using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = decimal.Parse(Console.ReadLine());

            var sums = new Queue<decimal>();

            var listOfSums = new List<decimal>();

            listOfSums.Add(n);
            sums.Enqueue(n);

            var counter = 1;

            while (true)
            {
                listOfSums.Add(sums.Peek() + 1);
                sums.Enqueue(sums.Peek() + 1);
                counter++;

                if (counter == 50)
                {
                    break;
                }

                listOfSums.Add(2 * sums.Peek() + 1);
                sums.Enqueue(2 * sums.Peek() + 1);
                counter++;

                if (counter == 50)
                {
                    break;
                }

                listOfSums.Add(sums.Peek() + 2);
                sums.Enqueue(sums.Peek() + 2);
                counter++;

                sums.Dequeue();

                if (counter == 50)
                {
                    break;
                }
            }

            Console.WriteLine(String.Join(" ", listOfSums));
        }
    }
}
