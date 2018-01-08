using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var chemicalTable = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                FillingTheTable(chemicalTable);
            }

            Console.WriteLine(String.Join(" ", chemicalTable));
        }

        private static void FillingTheTable(SortedSet<string> chemicalTable)
        {
            var input = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                chemicalTable.Add(input[i]);
            }
        }
    }
}
