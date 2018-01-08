using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            var countOfEachNumber = new SortedDictionary<decimal, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNum = numbers[i];

                if (!countOfEachNumber.ContainsKey(currentNum))
                {
                    countOfEachNumber[currentNum] = 1;
                }
                else
                {
                    countOfEachNumber[currentNum]++;
                }
            }

            foreach (var kvp in countOfEachNumber)
            {
                Console.WriteLine("{0} - {1} times",
                    kvp.Key, kvp.Value);
            }
        }
    }
}
