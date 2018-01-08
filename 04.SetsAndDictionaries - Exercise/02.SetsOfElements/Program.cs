using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var allElements = new List<int>();

            var n = input[0];
            var m = input[1];

            var nNumbers = new SortedSet<int>();
            var mNumbers = new SortedSet<int>();

            FillingNNumbers(n, nNumbers, allElements);
            FillingMNumbers(m, mNumbers, allElements);

            //We have all unique elements
            nNumbers.UnionWith(mNumbers);
            mNumbers.Clear();

            //Here we should have all non unique elements left in our list
            RemovingUniqueElements(allElements, nNumbers);

            Console.WriteLine(String.Join(" ", allElements));
        }

        private static void RemovingUniqueElements(List<int> allElements, SortedSet<int> nNumbers)
        {
            foreach (var num in nNumbers)
            {
                allElements.Remove(num);
            }
        }

        private static void FillingMNumbers(int m, SortedSet<int> mNumbers, List<int> allNumbers)
        {
            for (int i = 0; i < m; i++)
            {
                var num = int.Parse(Console.ReadLine());

                mNumbers.Add(num);
                allNumbers.Add(num);
            }
        }

        private static void FillingNNumbers(int n, SortedSet<int> nNumbers, List<int> allNumbers)
        {
            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());

                nNumbers.Add(num);
                allNumbers.Add(num);
            }
        }
    }
}
