using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var countOfSymbols = new SortedDictionary<char, int>();

            CountingTheSymbols(input, countOfSymbols);

            PrintingResult(countOfSymbols);
        }

        private static void PrintingResult(SortedDictionary<char, int> countOfSymbols)
        {
            foreach (var kvp in countOfSymbols)
            {
                Console.WriteLine("{0}: {1} time/s",
                    kvp.Key, kvp.Value);
            }
        }

        private static void CountingTheSymbols(string input, SortedDictionary<char, int> countOfSymbols)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var currentSymbol = input[i];

                if (!countOfSymbols.ContainsKey(currentSymbol))
                {
                    countOfSymbols[currentSymbol] = 1;
                }
                else
                {
                    countOfSymbols[currentSymbol]++;
                }
            }
        }
    }
}
